namespace Matlab_desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            generuj = new Button();
            wykres = new PictureBox();
            funkcja = new TextBox();
            podajFunkcje = new Label();
            textBoxMaxX = new TextBox();
            textBoxMinX = new TextBox();
            zakresX = new Label();
            zakresXMax = new Label();
            pochodnaFunkcji = new Button();
            pochodna = new TextBox();
            miejscaZeroweButton = new Button();
            min_od = new TextBox();
            label1 = new Label();
            label2 = new Label();
            max_do = new TextBox();
            miejscaZerowe = new TextBox();
            panelTitleBar = new Panel();
            btnMinimize = new Button();
            btnClose = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)wykres).BeginInit();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // generuj
            // 
            generuj.Font = new Font("Segoe UI", 20F);
            generuj.Location = new Point(1014, 725);
            generuj.Name = "generuj";
            generuj.Size = new Size(307, 57);
            generuj.TabIndex = 0;
            generuj.Text = "Generuj wykres";
            generuj.UseVisualStyleBackColor = true;
            generuj.Click += buttonGenerate_Click;
            // 
            // wykres
            // 
            wykres.Location = new Point(56, 34);
            wykres.Name = "wykres";
            wykres.Size = new Size(930, 748);
            wykres.SizeMode = PictureBoxSizeMode.StretchImage;
            wykres.TabIndex = 2;
            wykres.TabStop = false;
            // 
            // funkcja
            // 
            funkcja.Location = new Point(1002, 123);
            funkcja.Name = "funkcja";
            funkcja.Size = new Size(234, 27);
            funkcja.TabIndex = 3;
            // 
            // podajFunkcje
            // 
            podajFunkcje.AutoSize = true;
            podajFunkcje.Font = new Font("Segoe UI", 15F);
            podajFunkcje.Location = new Point(1002, 53);
            podajFunkcje.Name = "podajFunkcje";
            podajFunkcje.Size = new Size(246, 35);
            podajFunkcje.TabIndex = 4;
            podajFunkcje.Text = "Podaj funkcję y= f(x):";
            // 
            // textBoxMaxX
            // 
            textBoxMaxX.Location = new Point(366, 799);
            textBoxMaxX.Name = "textBoxMaxX";
            textBoxMaxX.Size = new Size(125, 27);
            textBoxMaxX.TabIndex = 5;
            // 
            // textBoxMinX
            // 
            textBoxMinX.Location = new Point(189, 798);
            textBoxMinX.Name = "textBoxMinX";
            textBoxMinX.Size = new Size(125, 27);
            textBoxMinX.TabIndex = 6;
            // 
            // zakresX
            // 
            zakresX.AutoSize = true;
            zakresX.Font = new Font("Segoe UI", 12F);
            zakresX.Location = new Point(46, 798);
            zakresX.Name = "zakresX";
            zakresX.Size = new Size(137, 28);
            zakresX.TabIndex = 7;
            zakresX.Text = "Zakres x:    Od:";
            // 
            // zakresXMax
            // 
            zakresXMax.AutoSize = true;
            zakresXMax.Font = new Font("Segoe UI", 12F);
            zakresXMax.Location = new Point(320, 798);
            zakresXMax.Name = "zakresXMax";
            zakresXMax.Size = new Size(40, 28);
            zakresXMax.TabIndex = 8;
            zakresXMax.Text = "do:";
            // 
            // pochodnaFunkcji
            // 
            pochodnaFunkcji.Font = new Font("Segoe UI", 12F);
            pochodnaFunkcji.Location = new Point(1002, 203);
            pochodnaFunkcji.Name = "pochodnaFunkcji";
            pochodnaFunkcji.Size = new Size(319, 53);
            pochodnaFunkcji.TabIndex = 11;
            pochodnaFunkcji.Text = "Oblicz pochodną podanej funkcji:";
            pochodnaFunkcji.UseVisualStyleBackColor = true;
            pochodnaFunkcji.Click += pochodnaFunkcji_Click_1;
            // 
            // pochodna
            // 
            pochodna.Location = new Point(1002, 262);
            pochodna.Name = "pochodna";
            pochodna.Size = new Size(234, 27);
            pochodna.TabIndex = 12;
            // 
            // miejscaZeroweButton
            // 
            miejscaZeroweButton.Font = new Font("Segoe UI", 12F);
            miejscaZeroweButton.Location = new Point(1002, 340);
            miejscaZeroweButton.Name = "miejscaZeroweButton";
            miejscaZeroweButton.Size = new Size(319, 68);
            miejscaZeroweButton.TabIndex = 13;
            miejscaZeroweButton.Text = "Podaj miejsca zerowe na danym przedziale:";
            miejscaZeroweButton.UseVisualStyleBackColor = true;
            miejscaZeroweButton.Click += miejscaZeroweButton_Click;
            // 
            // min_od
            // 
            min_od.Location = new Point(1068, 414);
            min_od.Name = "min_od";
            min_od.Size = new Size(188, 27);
            min_od.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(1006, 414);
            label1.Name = "label1";
            label1.Size = new Size(43, 28);
            label1.TabIndex = 15;
            label1.Text = "Od:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(1006, 458);
            label2.Name = "label2";
            label2.Size = new Size(42, 28);
            label2.TabIndex = 16;
            label2.Text = "Do:";
            // 
            // max_do
            // 
            max_do.Location = new Point(1068, 458);
            max_do.Name = "max_do";
            max_do.Size = new Size(188, 27);
            max_do.TabIndex = 17;
            // 
            // miejscaZerowe
            // 
            miejscaZerowe.Location = new Point(1011, 504);
            miejscaZerowe.Multiline = true;
            miejscaZerowe.Name = "miejscaZerowe";
            miejscaZerowe.Size = new Size(225, 187);
            miejscaZerowe.TabIndex = 18;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = SystemColors.ActiveBorder;
            panelTitleBar.Controls.Add(btnMinimize);
            panelTitleBar.Controls.Add(btnClose);
            panelTitleBar.Controls.Add(label3);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1489, 28);
            panelTitleBar.TabIndex = 19;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = SystemColors.ButtonHighlight;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 15F);
            btnMinimize.Location = new Point(1359, -19);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(67, 47);
            btnMinimize.TabIndex = 2;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimizeClick;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.BackgroundImageLayout = ImageLayout.None;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(1425, -3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(64, 31);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnCloseClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(0, -3);
            label3.Name = "label3";
            label3.Size = new Size(165, 28);
            label3.TabIndex = 0;
            label3.Text = "Matlab generator";
            label3.MouseDown += panelTitleBar_MouseDown;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1489, 891);
            Controls.Add(panelTitleBar);
            Controls.Add(miejscaZerowe);
            Controls.Add(max_do);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(min_od);
            Controls.Add(miejscaZeroweButton);
            Controls.Add(pochodna);
            Controls.Add(pochodnaFunkcji);
            Controls.Add(zakresXMax);
            Controls.Add(zakresX);
            Controls.Add(textBoxMinX);
            Controls.Add(textBoxMaxX);
            Controls.Add(podajFunkcje);
            Controls.Add(funkcja);
            Controls.Add(wykres);
            Controls.Add(generuj);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Matlab generator";
            ((System.ComponentModel.ISupportInitialize)wykres).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button generuj;
        private PictureBox wykres;
        private TextBox funkcja;
        private Label podajFunkcje;
        private TextBox textBoxMaxX;
        private TextBox textBoxMinX;
        private Label zakresX;
        private Label zakresXMax;
        private Button pochodnaFunkcji;
        private TextBox pochodna;
        private Button miejscaZeroweButton;
        private TextBox min_od;
        private Label label1;
        private Label label2;
        private TextBox max_do;
        private TextBox miejscaZerowe;
        private Panel panelTitleBar;
        private Button btnClose;
        private Label label3;
        private Button btnMinimize;
    }
}
