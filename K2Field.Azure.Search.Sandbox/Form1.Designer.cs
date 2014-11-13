namespace K2Field.Azure.Search.Sandbox
{
    partial class Form1
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
            this.btnCreateIndex = new System.Windows.Forms.Button();
            this.btnExists = new System.Windows.Forms.Button();
            this.txtIndexName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCreateIndex
            // 
            this.btnCreateIndex.Location = new System.Drawing.Point(346, 24);
            this.btnCreateIndex.Name = "btnCreateIndex";
            this.btnCreateIndex.Size = new System.Drawing.Size(75, 23);
            this.btnCreateIndex.TabIndex = 0;
            this.btnCreateIndex.Text = "Create Index";
            this.btnCreateIndex.UseVisualStyleBackColor = true;
            this.btnCreateIndex.Click += new System.EventHandler(this.btnCreateIndex_Click);
            // 
            // btnExists
            // 
            this.btnExists.Location = new System.Drawing.Point(321, 68);
            this.btnExists.Name = "btnExists";
            this.btnExists.Size = new System.Drawing.Size(100, 23);
            this.btnExists.TabIndex = 1;
            this.btnExists.Text = "Index Exists?";
            this.btnExists.UseVisualStyleBackColor = true;
            this.btnExists.Click += new System.EventHandler(this.btnExists_Click);
            // 
            // txtIndexName
            // 
            this.txtIndexName.Location = new System.Drawing.Point(96, 70);
            this.txtIndexName.Name = "txtIndexName";
            this.txtIndexName.Size = new System.Drawing.Size(100, 20);
            this.txtIndexName.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 324);
            this.Controls.Add(this.txtIndexName);
            this.Controls.Add(this.btnExists);
            this.Controls.Add(this.btnCreateIndex);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateIndex;
        private System.Windows.Forms.Button btnExists;
        private System.Windows.Forms.TextBox txtIndexName;
    }
}

