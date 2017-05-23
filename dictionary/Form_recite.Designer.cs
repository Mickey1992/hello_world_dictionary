namespace dictionary
{
    partial class Form_recite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_recite));
            this.button_next = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.label_word = new System.Windows.Forms.Label();
            this.label_att = new System.Windows.Forms.Label();
            this.label_mean = new System.Windows.Forms.Label();
            this.label_finish = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_next
            // 
            this.button_next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_next.Location = new System.Drawing.Point(302, 279);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 1;
            this.button_next.Text = "下一个";
            this.button_next.UseVisualStyleBackColor = false;
            this.button_next.Visible = false;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_start.Font = new System.Drawing.Font("Heartless Valiumwhore", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.Location = new System.Drawing.Point(120, 103);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(144, 90);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "START";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // label_word
            // 
            this.label_word.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label_word.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_word.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_word.Location = new System.Drawing.Point(22, 43);
            this.label_word.Name = "label_word";
            this.label_word.Size = new System.Drawing.Size(253, 29);
            this.label_word.TabIndex = 3;
            this.label_word.Visible = false;
            // 
            // label_att
            // 
            this.label_att.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label_att.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_att.Location = new System.Drawing.Point(281, 43);
            this.label_att.Name = "label_att";
            this.label_att.Size = new System.Drawing.Size(86, 29);
            this.label_att.TabIndex = 4;
            this.label_att.Visible = false;
            // 
            // label_mean
            // 
            this.label_mean.AutoSize = true;
            this.label_mean.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label_mean.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mean.Location = new System.Drawing.Point(22, 196);
            this.label_mean.Name = "label_mean";
            this.label_mean.Size = new System.Drawing.Size(0, 23);
            this.label_mean.TabIndex = 5;
            this.label_mean.Visible = false;
            // 
            // label_finish
            // 
            this.label_finish.AutoSize = true;
            this.label_finish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label_finish.Font = new System.Drawing.Font("迷你简卡通", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_finish.ForeColor = System.Drawing.Color.Red;
            this.label_finish.Location = new System.Drawing.Point(20, 112);
            this.label_finish.Name = "label_finish";
            this.label_finish.Size = new System.Drawing.Size(285, 35);
            this.label_finish.TabIndex = 6;
            this.label_finish.Text = "已完成该列表的背诵";
            this.label_finish.Visible = false;
            // 
            // Form_recite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::dictionary.Properties.Resources.草莓1280x800;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(410, 329);
            this.Controls.Add(this.label_finish);
            this.Controls.Add(this.label_mean);
            this.Controls.Add(this.label_att);
            this.Controls.Add(this.label_word);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_next);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_recite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_word;
        private System.Windows.Forms.Label label_att;
        private System.Windows.Forms.Label label_mean;
        private System.Windows.Forms.Label label_finish;
    }
}