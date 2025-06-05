namespace NemeckaSifra
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SeedButton = new Button();
            Input = new TextBox();
            label1 = new Label();
            labelResult = new Label();
            EI = new TextBox();
            EncryptButton = new Button();
            KeyInput = new TextBox();
            Tip = new Label();
            label2 = new Label();
            label3 = new Label();
            CopyButton = new Button();
            DI = new TextBox();
            DecryptButton = new Button();
            label4 = new Label();
            rbADFGX = new RadioButton();
            rbADFGVX = new RadioButton();
            pictureBox1 = new PictureBox();
            rbCZEN = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // SeedButton
            // 
            SeedButton.BackColor = Color.Black;
            SeedButton.FlatStyle = FlatStyle.Flat;
            SeedButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SeedButton.ForeColor = Color.Red;
            SeedButton.Location = new Point(12, 47);
            SeedButton.Name = "SeedButton";
            SeedButton.Size = new Size(100, 32);
            SeedButton.TabIndex = 0;
            SeedButton.Text = "Generate";
            SeedButton.UseVisualStyleBackColor = false;
            SeedButton.Click += SeedButton_Click;
            // 
            // Input
            // 
            Input.BackColor = Color.Black;
            Input.BorderStyle = BorderStyle.FixedSingle;
            Input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Input.ForeColor = Color.Red;
            Input.Location = new Point(12, 12);
            Input.Name = "Input";
            Input.Size = new Size(100, 29);
            Input.TabIndex = 1;
            Input.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(118, 14);
            label1.Name = "label1";
            label1.Size = new Size(59, 21);
            label1.TabIndex = 2;
            label1.Text = "- SEED";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.BackColor = Color.Black;
            labelResult.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelResult.ForeColor = Color.Red;
            labelResult.Location = new Point(12, 375);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(22, 21);
            labelResult.TabIndex = 4;
            labelResult.Text = "...";
            // 
            // EI
            // 
            EI.BackColor = Color.Black;
            EI.BorderStyle = BorderStyle.FixedSingle;
            EI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EI.ForeColor = Color.Red;
            EI.Location = new Point(12, 176);
            EI.Name = "EI";
            EI.Size = new Size(317, 29);
            EI.TabIndex = 5;
            // 
            // EncryptButton
            // 
            EncryptButton.BackColor = Color.Black;
            EncryptButton.FlatStyle = FlatStyle.Flat;
            EncryptButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            EncryptButton.ForeColor = Color.Red;
            EncryptButton.Location = new Point(12, 211);
            EncryptButton.Name = "EncryptButton";
            EncryptButton.Size = new Size(115, 27);
            EncryptButton.TabIndex = 6;
            EncryptButton.Text = "ZAŠIFROVAT";
            EncryptButton.UseVisualStyleBackColor = false;
            EncryptButton.Click += EncryptButton_Click;
            // 
            // KeyInput
            // 
            KeyInput.BackColor = Color.Black;
            KeyInput.BorderStyle = BorderStyle.FixedSingle;
            KeyInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            KeyInput.ForeColor = Color.Red;
            KeyInput.Location = new Point(12, 141);
            KeyInput.Name = "KeyInput";
            KeyInput.Size = new Size(100, 29);
            KeyInput.TabIndex = 7;
            // 
            // Tip
            // 
            Tip.AutoSize = true;
            Tip.BackColor = Color.Black;
            Tip.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Tip.ForeColor = Color.Red;
            Tip.Location = new Point(12, 480);
            Tip.Name = "Tip";
            Tip.Size = new Size(349, 100);
            Tip.TabIndex = 8;
            Tip.Text = "1. Zvolte tip tabulky (5x5, 6x6)\r\n2. Zadejte SEED a vygenerujte tabulku\r\n3. Napiště větu a Klíč\r\n4. Zašifrujte pomocí tlačítka\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(335, 179);
            label2.Name = "label2";
            label2.Size = new Size(172, 20);
            label2.TabIndex = 9;
            label2.Text = "- TEXT PRO ŠIFROVÁNÍ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(118, 144);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 10;
            label3.Text = "- KLÍČ";
            // 
            // CopyButton
            // 
            CopyButton.BackColor = Color.Black;
            CopyButton.FlatStyle = FlatStyle.Flat;
            CopyButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CopyButton.ForeColor = Color.Red;
            CopyButton.Location = new Point(12, 399);
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new Size(128, 29);
            CopyButton.TabIndex = 11;
            CopyButton.Text = "ZKOPÍROVAT";
            CopyButton.UseVisualStyleBackColor = false;
            CopyButton.Click += CopyButton_Click;
            // 
            // DI
            // 
            DI.BackColor = Color.Black;
            DI.BorderStyle = BorderStyle.FixedSingle;
            DI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DI.ForeColor = Color.Red;
            DI.Location = new Point(12, 262);
            DI.Name = "DI";
            DI.Size = new Size(317, 29);
            DI.TabIndex = 12;
            // 
            // DecryptButton
            // 
            DecryptButton.BackColor = Color.Black;
            DecryptButton.FlatStyle = FlatStyle.Flat;
            DecryptButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            DecryptButton.ForeColor = Color.Red;
            DecryptButton.Location = new Point(12, 297);
            DecryptButton.Name = "DecryptButton";
            DecryptButton.Size = new Size(115, 31);
            DecryptButton.TabIndex = 13;
            DecryptButton.Text = "DEŠIFROVAT";
            DecryptButton.UseVisualStyleBackColor = false;
            DecryptButton.Click += DecryptButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Black;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(335, 265);
            label4.Name = "label4";
            label4.Size = new Size(191, 20);
            label4.TabIndex = 14;
            label4.Text = "- TEXT PRO DEŠIFROVÁNÍ";
            // 
            // rbADFGX
            // 
            rbADFGX.AutoSize = true;
            rbADFGX.BackColor = Color.Black;
            rbADFGX.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            rbADFGX.ForeColor = Color.Red;
            rbADFGX.Location = new Point(195, 12);
            rbADFGX.Name = "rbADFGX";
            rbADFGX.Size = new Size(86, 24);
            rbADFGX.TabIndex = 15;
            rbADFGX.TabStop = true;
            rbADFGX.Text = "Je Česká";
            rbADFGX.UseVisualStyleBackColor = false;
            // 
            // rbADFGVX
            // 
            rbADFGVX.AutoSize = true;
            rbADFGVX.BackColor = Color.Black;
            rbADFGVX.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            rbADFGVX.ForeColor = Color.Red;
            rbADFGVX.Location = new Point(195, 42);
            rbADFGVX.Name = "rbADFGVX";
            rbADFGVX.Size = new Size(100, 24);
            rbADFGVX.TabIndex = 16;
            rbADFGVX.TabStop = true;
            rbADFGVX.Text = "ADFG(V)X";
            rbADFGVX.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.photo_1708447782261_cdbecd7c97c6;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1157, 589);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // rbCZEN
            // 
            rbCZEN.AutoSize = true;
            rbCZEN.BackColor = Color.Black;
            rbCZEN.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            rbCZEN.ForeColor = Color.Red;
            rbCZEN.Location = new Point(308, 12);
            rbCZEN.Name = "rbCZEN";
            rbCZEN.Size = new Size(106, 24);
            rbCZEN.TabIndex = 18;
            rbCZEN.TabStop = true;
            rbCZEN.Text = "Je Anglická";
            rbCZEN.UseVisualStyleBackColor = false;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 589);
            Controls.Add(rbCZEN);
            Controls.Add(rbADFGVX);
            Controls.Add(rbADFGX);
            Controls.Add(label4);
            Controls.Add(DecryptButton);
            Controls.Add(DI);
            Controls.Add(CopyButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Tip);
            Controls.Add(KeyInput);
            Controls.Add(EncryptButton);
            Controls.Add(EI);
            Controls.Add(labelResult);
            Controls.Add(label1);
            Controls.Add(Input);
            Controls.Add(SeedButton);
            Controls.Add(pictureBox1);
            Name = "MainScreen";
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SeedButton;
        private TextBox Input;
        private Label label1;
        private Label labelResult;
        private TextBox EI;
        private Button EncryptButton;
        private TextBox KeyInput;
        private Label Tip;
        private Label label2;
        private Label label3;
        private Button CopyButton;
        private TextBox DI;
        private Button DecryptButton;
        private Label label4;
        private RadioButton rbADFGX;
        private RadioButton rbADFGVX;
        private PictureBox pictureBox1;
        private RadioButton rbCZEN;
    }
}