namespace BindaTests.NeededObjects
{
    partial class MySampleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Body = new System.Windows.Forms.TextBox();
            this.Date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.PostLocation = new System.Windows.Forms.TextBox();
            this.PopularityRanking = new BindaTests.NeededObjects.FluxCapacitor();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(12, 26);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(275, 20);
            this.Title.TabIndex = 0;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(12, 49);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 0;
            this.lblAuthor.Text = "Author:";
            // 
            // Author
            // 
            this.Author.Location = new System.Drawing.Point(15, 65);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(149, 20);
            this.Author.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Body:";
            // 
            // Body
            // 
            this.Body.Location = new System.Drawing.Point(15, 145);
            this.Body.Multiline = true;
            this.Body.Name = "Body";
            this.Body.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Body.Size = new System.Drawing.Size(633, 299);
            this.Body.TabIndex = 3;
            // 
            // Date
            // 
            this.Date.CustomFormat = "M/d/yy h:mm tt";
            this.Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Date.Location = new System.Drawing.Point(15, 105);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(200, 20);
            this.Date.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Location:";
            // 
            // PostLocation
            // 
            this.PostLocation.Location = new System.Drawing.Point(170, 65);
            this.PostLocation.Name = "PostLocation";
            this.PostLocation.Size = new System.Drawing.Size(149, 20);
            this.PostLocation.TabIndex = 1;
            // 
            // PopularityRanking
            // 
            this.PopularityRanking.Location = new System.Drawing.Point(367, 13);
            this.PopularityRanking.Name = "PopularityRanking";
            this.PopularityRanking.PopularityRanking = null;
            this.PopularityRanking.Size = new System.Drawing.Size(281, 112);
            this.PopularityRanking.TabIndex = 5;
            // 
            // MySampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 456);
            this.Controls.Add(this.PopularityRanking);
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
            this.Name = "MySampleForm";
            this.Text = "New Blog Post";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Label lblAuthor;
        internal System.Windows.Forms.TextBox Author;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox Body;
        internal System.Windows.Forms.DateTimePicker Date;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox PostLocation;
        internal FluxCapacitor PopularityRanking;
    }
}