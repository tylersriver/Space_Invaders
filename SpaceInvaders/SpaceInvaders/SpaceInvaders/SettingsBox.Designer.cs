namespace SpaceInvaders
{
    partial class SettingsBox
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.skillLevel = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdInvincible = new System.Windows.Forms.RadioButton();
            this.rdNoCheat = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(73, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Okay";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(232, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Skill Level";
            // 
            // skillLevel
            // 
            this.skillLevel.FormattingEnabled = true;
            this.skillLevel.Items.AddRange(new object[] {
            "Beginner",
            "Intermediate",
            "Advanced"});
            this.skillLevel.Location = new System.Drawing.Point(105, 44);
            this.skillLevel.Name = "skillLevel";
            this.skillLevel.Size = new System.Drawing.Size(121, 21);
            this.skillLevel.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdInvincible);
            this.groupBox1.Controls.Add(this.rdNoCheat);
            this.groupBox1.Location = new System.Drawing.Point(105, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 91);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rdInvincible
            // 
            this.rdInvincible.AutoSize = true;
            this.rdInvincible.Location = new System.Drawing.Point(6, 57);
            this.rdInvincible.Name = "rdInvincible";
            this.rdInvincible.Size = new System.Drawing.Size(70, 17);
            this.rdInvincible.TabIndex = 1;
            this.rdInvincible.Text = "Invincible";
            this.rdInvincible.UseVisualStyleBackColor = true;
            // 
            // rdNoCheat
            // 
            this.rdNoCheat.AutoSize = true;
            this.rdNoCheat.Checked = true;
            this.rdNoCheat.Location = new System.Drawing.Point(7, 20);
            this.rdNoCheat.Name = "rdNoCheat";
            this.rdNoCheat.Size = new System.Drawing.Size(70, 17);
            this.rdNoCheat.TabIndex = 0;
            this.rdNoCheat.TabStop = true;
            this.rdNoCheat.Text = "No Cheat";
            this.rdNoCheat.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cheats";
            // 
            // SettingsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 335);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.skillLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "SettingsBox";
            this.Text = "Selet Difficulty";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox skillLevel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdInvincible;
        private System.Windows.Forms.RadioButton rdNoCheat;
        private System.Windows.Forms.Label label2;
    }
}