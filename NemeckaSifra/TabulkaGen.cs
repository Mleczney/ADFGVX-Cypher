using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NemeckaSifra
{
    public partial class TabulkaGen : Form
    {
        public Dictionary<char, (int Row, int Col)> AlphabetCoordinates { get; private set; }

        public TabulkaGen(int seed, bool isADFGVX, bool isCzechAlphabet)
        {
            InitializeComponent();
            AlphabetCoordinates = GenerateRandomAlphabet(seed, isADFGVX, isCzechAlphabet);
            DisplayAlphabetInLabels(isADFGVX);
        }

        private Dictionary<char, (int Row, int Col)> GenerateRandomAlphabet(int seed, bool isADFGVX, bool isCzechAlphabet)
        {
            Random random = new Random(seed);
            char[] alphabet;

            if (isADFGVX)
            {
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            }
            else if (isCzechAlphabet)
            {
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZ".ToCharArray();
            }
            else
            {
                alphabet = "ABCDEFGHIJKLMNOPRSTUVWXYZ".ToCharArray();
            }

            // Zamíchejte abecedu podle seed hodnoty
            alphabet = alphabet.OrderBy(x => random.Next()).ToArray();

            var coordinates = new Dictionary<char, (int Row, int Col)>();
            int size = isADFGVX ? 6 : 5; // Tabulka ADFGX má rozměry 6x6, jinak 5x5

            for (int i = 0; i < alphabet.Length; i++)
            {
                int row = i / size;
                int col = i % size;
                coordinates[alphabet[i]] = (row, col);
            }

            return coordinates;
        }


        public char GetLetterFromCoordinates(char rowLetter, char colLetter, bool isADFGVX)
        {
            string coordinatesSet = isADFGVX ? "ADFGVX" : "ADFGX";
            int row = coordinatesSet.IndexOf(rowLetter);
            int col = coordinatesSet.IndexOf(colLetter);

            foreach (var pair in AlphabetCoordinates)
            {
                if (pair.Value.Row == row && pair.Value.Col == col)
                {
                    return pair.Key;
                }
            }
            return '?';
        }

        private void DisplayAlphabetInLabels(bool isADFGVX)
        {
            if (isADFGVX)
            {
                for (int i = 26; i <= 61; i++)
                {
                    Label? label = this.Controls.Find($"label{i}", true).FirstOrDefault() as Label;

                    if (label != null)
                    {
                        int alphabetIndex = i - 26;
                        if (alphabetIndex < AlphabetCoordinates.Count)
                        {
                            label.Text = AlphabetCoordinates.ElementAt(alphabetIndex).Key.ToString();
                        }
                        else
                        {
                            label.Text = "";
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i <= 25; i++)
                {
                    Label? label = this.Controls.Find($"label{i}", true).FirstOrDefault() as Label;

                    if (label != null)
                    {
                        int alphabetIndex = i - 1;
                        if (alphabetIndex < AlphabetCoordinates.Count)
                        {
                            label.Text = AlphabetCoordinates.ElementAt(alphabetIndex).Key.ToString();
                        }
                        else
                        {
                            label.Text = "";
                        }
                    }
                }
            }
        }

        public Dictionary<char, (int Row, int Col)> GetAlphabetCoordinates()
        {
            return AlphabetCoordinates;
        }

        public string EncryptWord(string word, bool isADFGVX)
        {
            var encryptedWord = new StringBuilder();
            string coordinatesSet = isADFGVX ? "ADFGVX" : "ADFGX";

            foreach (char letter in word.ToUpper())
            {
                if (AlphabetCoordinates.TryGetValue(letter, out var coordinates))
                {
                    char rowLetter = coordinatesSet[coordinates.Row];
                    char colLetter = coordinatesSet[coordinates.Col];
                    encryptedWord.Append(rowLetter).Append(colLetter);
                }
            }

            return encryptedWord.ToString();
        }
    }
}