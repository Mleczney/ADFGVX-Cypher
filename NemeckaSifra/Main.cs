using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NemeckaSifra
{
    public partial class MainScreen : Form
    {
        private TabulkaGen tabulkaGen;
        private bool isADFGVX = false;
        private bool isCzechAlphabet = false;
        private bool isEnglishAlphabet = false;

        public MainScreen()
        {
            InitializeComponent();
            rbADFGX.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            rbADFGVX.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            rbCZEN.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rbADFGX.Checked)
            {
                isCzechAlphabet = true;
                isADFGVX = false;
                isEnglishAlphabet = false;
            }
            else if (rbADFGVX.Checked)
            {
                isCzechAlphabet = false;
                isADFGVX = true;
                isEnglishAlphabet = false;
            }
            else
            {
                isCzechAlphabet = false;
                isADFGVX = false;
                isEnglishAlphabet = true;
            }
        }

        private void SeedButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Input.Text, out int seed))
            {
                tabulkaGen = new TabulkaGen(seed, isADFGVX, isCzechAlphabet);
                tabulkaGen.ShowDialog();
            }
            else
            {
                MessageBox.Show("Zadejte platné číslo jako seed.");
            }
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            if (tabulkaGen == null)
            {
                MessageBox.Show("Nejdřív musíte vygenerovat tabulku.");
                return;
            }

            string word = EI.Text.ToUpper();
            string key = KeyInput.Text.ToUpper();

            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Zadejte slovo k zašifrování a klíč.");
                return;
            }

            word = RemoveDiacritics(word);

            // Nahrazení pouze při ADFGX (při ADFGVX neprovádíme nahrazování)
            if (!isADFGVX)
            {
                if (isCzechAlphabet)
                {
                    // Nahrazení Q za O při české abecedě
                    word = word.Replace("W", "V");
                }
                else if(isEnglishAlphabet)
                {
                    // Nahrazení W za V při anglické abecedě
                    word = word.Replace("Q", "O");
                }
            }

            // Replace spaces and numbers with special codes
            word = ReplaceSpacesAndNumbers(word);

            string encryptedWord = tabulkaGen.EncryptWord(word, isADFGVX);
            string finalEncryptedText = EncryptWithKey(encryptedWord, key);

            string formattedText = FormatEncryptedText(finalEncryptedText);

            labelResult.Text = formattedText;
        }



        private string ReplaceSpacesAndNumbers(string word)
        {
            // Replace spaces with "XMEZX"
            word = word.Replace(" ", "XMEZX");

            // Replace numbers with the respective code (e.g., 1 -> XONEX, 2 -> XTWOX, etc.)
            word = word.Replace("1", "XONEX")
                       .Replace("2", "XTWOX")
                       .Replace("3", "XTHREEX")
                       .Replace("4", "XFOURX")
                       .Replace("5", "XFIVEX")
                       .Replace("6", "XSIXX")
                       .Replace("7", "XSEVENX")
                       .Replace("8", "XEIGHTX")
                       .Replace("9", "XNINEX")
                       .Replace("0", "XZEROX");

            return word;
        }



        public string FormatEncryptedText(string encryptedText)
        {
            var formattedText = new StringBuilder();

            for (int i = 0; i < encryptedText.Length; i++)
            {
                formattedText.Append(encryptedText[i]);

                if ((i + 1) % 5 == 0 && i + 1 < encryptedText.Length)
                {
                    formattedText.Append('-');
                }
            }

            return formattedText.ToString();
        }


        public string EncryptWithKey(string encryptedText, string key)
        {
            int columns = key.Length;
            int rows = (int)Math.Ceiling((double)encryptedText.Length / columns);

            // Náhodné znaky (mimo platnou sadu)
            char[] fillChars = "!".ToArray();
            Random random = new Random();

            // Naplň tabulku
            char[,] table = new char[rows, columns];
            int textIndex = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (textIndex < encryptedText.Length)
                    {
                        table[r, c] = encryptedText[textIndex];
                        textIndex++;
                    }
                    else
                    {
                        table[r, c] = fillChars[random.Next(fillChars.Length)];
                    }
                }
            }

            // Seřaď klíč podle abecedy a přiřaď indexy sloupců
            var sortedKey = key
                .Select((ch, idx) => new { Char = ch, Index = idx })
                .OrderBy(item => item.Char)
                .ThenBy(item => item.Index)
                .ToList();

            // Vytvoř finální šifrovaný text podle seřazeného klíče
            StringBuilder finalEncryptedText = new StringBuilder();
            foreach (var item in sortedKey)
            {
                int col = item.Index;
                for (int r = 0; r < rows; r++)
                {
                    finalEncryptedText.Append(table[r, col]);
                }
            }

            return finalEncryptedText.ToString();
        }



        private string RemoveDiacritics(string input)
        {
            string normalizedString = input.Normalize(System.Text.NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }


        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelResult.Text))
            {
                Clipboard.SetText(labelResult.Text);
            }
            else
            {
                MessageBox.Show("Není žádný text k zkopírování.");
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            if (tabulkaGen == null)
            {
                MessageBox.Show("Nejdřív musíte vygenerovat tabulku.");
                return;
            }

            string encryptedText = DI.Text.Replace("-", ""); // Odstranění pomlček
            string key = KeyInput.Text.ToUpper();

            if (string.IsNullOrEmpty(encryptedText) || string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Zadejte zašifrovaný text a klíč.");
                return;
            }

            string decryptedText = DecryptWithKey(encryptedText, key);

            // Po dešifrování proveď náhradu zpět
            decryptedText = ReplaceBackCodes(decryptedText);

            labelResult.Text = decryptedText.Replace("?", "");
        }

        private string ReplaceBackCodes(string decryptedText)
        {
            // Náhrada XMEZX zpět na mezery
            decryptedText = decryptedText.Replace("XMEZX", " ");

            // Náhrada číselných kódů zpět na čísla
            decryptedText = decryptedText.Replace("XONEX", "1")
                                         .Replace("XTWOX", "2")
                                         .Replace("XTHREEX", "3")
                                         .Replace("XFOURX", "4")
                                         .Replace("XFIVEX", "5")
                                         .Replace("XSIXX", "6")
                                         .Replace("XSEVENX", "7")
                                         .Replace("XEIGHTX", "8")
                                         .Replace("XNINEX", "9")
                                         .Replace("XZEROX", "0");

            return decryptedText;
        }



        public string DecryptWithKey(string encryptedText, string key)
        {
            int columns = key.Length;
            int rows = encryptedText.Length / columns;

            var sortedKey = key
                .Select((ch, idx) => new { Char = ch, Index = idx })
                .OrderBy(item => item.Char)
                .ThenBy(item => item.Index)
                .ToList();

            char[,] table = new char[rows, columns];
            int textIndex = 0;

            foreach (var item in sortedKey)
            {
                int col = item.Index;
                for (int r = 0; r < rows; r++)
                {
                    if (textIndex < encryptedText.Length)
                    {
                        table[r, col] = encryptedText[textIndex];
                        textIndex++;
                    }
                }
            }

            StringBuilder decryptedWord = new StringBuilder();
            bool skipFirstInNextRow = false;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c += 2)
                {
                    if (c == columns - 1 && columns % 2 != 0)
                    {
                        if (r + 1 < rows)
                        {
                            char rowLetter = table[r, c];
                            char colLetter = table[r + 1, 0];
                            decryptedWord.Append(tabulkaGen.GetLetterFromCoordinates(rowLetter, colLetter, isADFGVX));
                            skipFirstInNextRow = true;
                        }
                    }
                    else
                    {
                        if (skipFirstInNextRow && c == 0)
                        {
                            skipFirstInNextRow = false;
                            c += 1;
                        }

                        if (c + 1 < columns)
                        {
                            char rowLetter = table[r, c];
                            char colLetter = table[r, c + 1];
                            decryptedWord.Append(tabulkaGen.GetLetterFromCoordinates(rowLetter, colLetter, isADFGVX));
                        }
                    }
                }
            }

            return decryptedWord.ToString();
        }
    }
}