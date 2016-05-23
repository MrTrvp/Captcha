namespace dCaptcha.UI.Forms
{
    partial class MainForm
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
                components.Dispose();        

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerateNewCode = new System.Windows.Forms.Button();
            this.lblCode = new System.Windows.Forms.Label();
            this.cbDifficulty = new System.Windows.Forms.ComboBox();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.dcMain = new dCaptcha.UI.Controls.dCaptcha();
            ((System.ComponentModel.ISupportInitialize)(this.dcMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateNewCode
            // 
            this.btnGenerateNewCode.Location = new System.Drawing.Point(87, 186);
            this.btnGenerateNewCode.Name = "btnGenerateNewCode";
            this.btnGenerateNewCode.Size = new System.Drawing.Size(160, 23);
            this.btnGenerateNewCode.TabIndex = 2;
            this.btnGenerateNewCode.Text = "Generate New Code";
            this.btnGenerateNewCode.UseVisualStyleBackColor = true;
            this.btnGenerateNewCode.Click += new System.EventHandler(this.btnGenerateNewCode_Click);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(84, 110);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(75, 13);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "Code: None";
            // 
            // cbDifficulty
            // 
            this.cbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDifficulty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbDifficulty.FormattingEnabled = true;
            this.cbDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.cbDifficulty.Location = new System.Drawing.Point(87, 159);
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(159, 21);
            this.cbDifficulty.TabIndex = 4;
            this.cbDifficulty.SelectedIndexChanged += new System.EventHandler(this.cbDifficulty_SelectedIndexChanged);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(84, 143);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(57, 13);
            this.lblDifficulty.TabIndex = 5;
            this.lblDifficulty.Text = "Difficulty";
            // 
            // dcMain
            // 
            this.dcMain.BackColor = System.Drawing.Color.White;
            this.dcMain.Difficulty = dCaptcha.UI.Controls.dCaptcha.Mode.Easy;
            this.dcMain.Location = new System.Drawing.Point(84, 53);
            this.dcMain.Name = "dcMain";
            this.dcMain.Size = new System.Drawing.Size(163, 50);
            this.dcMain.TabIndex = 1;
            this.dcMain.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 262);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.cbDifficulty);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnGenerateNewCode);
            this.Controls.Add(this.dcMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dcMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dCaptcha.UI.Controls.dCaptcha dcMain;
        private System.Windows.Forms.Button btnGenerateNewCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.ComboBox cbDifficulty;
        private System.Windows.Forms.Label lblDifficulty;
    }
}

