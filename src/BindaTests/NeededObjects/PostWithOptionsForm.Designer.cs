namespace BindaTests.NeededObjects
{
    partial class PostWithOptionsForm
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
            this.Date = new System.Windows.Forms.DateTimePicker();
            this.Body = new System.Windows.Forms.TextBox();
            this.PostLocation = new System.Windows.Forms.TextBox();
            this.Author = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PublishState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HitCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HitCount)).BeginInit();
            this.SuspendLayout();
            // 
            // Date
            // 
            this.Date.CustomFormat = "M/d/yy h:mm tt";
            this.Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Date.Location = new System.Drawing.Point(15, 105);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(200, 20);
            this.Date.TabIndex = 14;
            // 
            // Body
            // 
            this.Body.Location = new System.Drawing.Point(15, 145);
            this.Body.Multiline = true;
            this.Body.Name = "Body";
            this.Body.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Body.Size = new System.Drawing.Size(633, 299);
            this.Body.TabIndex = 13;
            // 
            // PostLocation
            // 
            this.PostLocation.Location = new System.Drawing.Point(170, 65);
            this.PostLocation.Name = "PostLocation";
            this.PostLocation.Size = new System.Drawing.Size(149, 20);
            this.PostLocation.TabIndex = 12;
            // 
            // Author
            // 
            this.Author.Location = new System.Drawing.Point(15, 65);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(149, 20);
            this.Author.TabIndex = 11;
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(12, 26);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(275, 20);
            this.Title.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Body:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Location:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(12, 49);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 7;
            this.lblAuthor.Text = "Author:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Title";
            // 
            // PublishState
            // 
            this.PublishState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PublishState.FormattingEnabled = true;
            this.PublishState.Location = new System.Drawing.Point(401, 24);
            this.PublishState.Name = "PublishState";
            this.PublishState.Size = new System.Drawing.Size(198, 21);
            this.PublishState.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(398, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Publish State";
            // 
            // HitCount
            // 
            this.HitCount.Location = new System.Drawing.Point(401, 64);
            this.HitCount.Name = "HitCount";
            this.HitCount.Size = new System.Drawing.Size(120, 20);
            this.HitCount.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(398, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Hit Count:";
            // 
            // PostWithOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 512);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.HitCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PublishState);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Body);
            this.Controls.Add(this.PostLocation);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.label1);
            this.Name = "PostWithOptionsForm";
            this.Text = "PostWithOptionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.HitCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker Date;
        public System.Windows.Forms.TextBox Body;
        public System.Windows.Forms.TextBox PostLocation;
        public System.Windows.Forms.TextBox Author;
        public System.Windows.Forms.TextBox Title;
        public System.Windows.Forms.ComboBox PublishState;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown HitCount;
    }
}