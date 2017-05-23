namespace dictionary
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button_createList = new System.Windows.Forms.Button();
            this.textBox_newList = new System.Windows.Forms.TextBox();
            this.button_create = new System.Windows.Forms.Button();
            this.label_listName = new System.Windows.Forms.Label();
            this.panel_button = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button_createList
            // 
            this.button_createList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_createList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_createList.Location = new System.Drawing.Point(267, 347);
            this.button_createList.Name = "button_createList";
            this.button_createList.Size = new System.Drawing.Size(75, 23);
            this.button_createList.TabIndex = 0;
            this.button_createList.Text = "新建列表";
            this.button_createList.UseVisualStyleBackColor = false;
            this.button_createList.Click += new System.EventHandler(this.button_createList_Click);
            // 
            // textBox_newList
            // 
            this.textBox_newList.Location = new System.Drawing.Point(199, 318);
            this.textBox_newList.Name = "textBox_newList";
            this.textBox_newList.Size = new System.Drawing.Size(149, 21);
            this.textBox_newList.TabIndex = 3;
            this.textBox_newList.Visible = false;
            // 
            // button_create
            // 
            this.button_create.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_create.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_create.Location = new System.Drawing.Point(267, 347);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(75, 23);
            this.button_create.TabIndex = 4;
            this.button_create.Text = "新建";
            this.button_create.UseVisualStyleBackColor = false;
            this.button_create.Visible = false;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // label_listName
            // 
            this.label_listName.AutoSize = true;
            this.label_listName.Location = new System.Drawing.Point(152, 321);
            this.label_listName.Name = "label_listName";
            this.label_listName.Size = new System.Drawing.Size(41, 12);
            this.label_listName.TabIndex = 5;
            this.label_listName.Text = "列表名";
            this.label_listName.Visible = false;
            // 
            // panel_button
            // 
            this.panel_button.BackgroundImage = global::dictionary.Properties.Resources.草莓1280x800;
            this.panel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_button.Location = new System.Drawing.Point(12, 12);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(336, 300);
            this.panel_button.TabIndex = 6;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::dictionary.Properties.Resources.草莓1280x800;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(368, 381);
            this.Controls.Add(this.panel_button);
            this.Controls.Add(this.label_listName);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.textBox_newList);
            this.Controls.Add(this.button_createList);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "背诵列表";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_createList;
        private System.Windows.Forms.TextBox textBox_newList;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Label label_listName;
        private System.Windows.Forms.Panel panel_button;
    }
}