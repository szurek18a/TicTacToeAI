namespace KolkoKrzyzykAI
{
    partial class FormStart
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxNick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton3x3 = new System.Windows.Forms.RadioButton();
            this.radioButton4x4 = new System.Windows.Forms.RadioButton();
            this.radioButton5x5 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBoxNick
            // 
            this.textBoxNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNick.Location = new System.Drawing.Point(159, 21);
            this.textBoxNick.Name = "textBoxNick";
            this.textBoxNick.Size = new System.Drawing.Size(182, 30);
            this.textBoxNick.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj nick:";
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.Location = new System.Drawing.Point(149, 252);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(89, 30);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(97, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wielkość planszy:";
            // 
            // radioButton3x3
            // 
            this.radioButton3x3.AutoSize = true;
            this.radioButton3x3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton3x3.Location = new System.Drawing.Point(159, 118);
            this.radioButton3x3.Name = "radioButton3x3";
            this.radioButton3x3.Size = new System.Drawing.Size(65, 29);
            this.radioButton3x3.TabIndex = 0;
            this.radioButton3x3.TabStop = true;
            this.radioButton3x3.Text = "3x3";
            this.radioButton3x3.UseVisualStyleBackColor = true;
            // 
            // radioButton4x4
            // 
            this.radioButton4x4.AutoSize = true;
            this.radioButton4x4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton4x4.Location = new System.Drawing.Point(159, 157);
            this.radioButton4x4.Name = "radioButton4x4";
            this.radioButton4x4.Size = new System.Drawing.Size(65, 29);
            this.radioButton4x4.TabIndex = 1;
            this.radioButton4x4.TabStop = true;
            this.radioButton4x4.Text = "4x4";
            this.radioButton4x4.UseVisualStyleBackColor = true;
            // 
            // radioButton5x5
            // 
            this.radioButton5x5.AutoSize = true;
            this.radioButton5x5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton5x5.Location = new System.Drawing.Point(159, 197);
            this.radioButton5x5.Name = "radioButton5x5";
            this.radioButton5x5.Size = new System.Drawing.Size(65, 29);
            this.radioButton5x5.TabIndex = 2;
            this.radioButton5x5.TabStop = true;
            this.radioButton5x5.Text = "5x5";
            this.radioButton5x5.UseVisualStyleBackColor = true;
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 303);
            this.Controls.Add(this.radioButton5x5);
            this.Controls.Add(this.radioButton3x3);
            this.Controls.Add(this.radioButton4x4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormStart";
            this.Text = "Kółko i krzyżyk ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton5x5;
        private System.Windows.Forms.RadioButton radioButton4x4;
        private System.Windows.Forms.RadioButton radioButton3x3;
    }
}

