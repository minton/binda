namespace BindaTests.NeededObjects
{
    partial class PostWithOptionsPrefixForm
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
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.txtPostLocation = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPublishState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudHitCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tvComments = new System.Windows.Forms.TreeView();
            this.fcPopularityRanking = new BindaTests.NeededObjects.FluxCapacitor();
            ((System.ComponentModel.ISupportInitialize)(this.nudHitCount)).BeginInit();
            this.SuspendLayout();
            // 
            // dpDate
            // 
            this.dpDate.CustomFormat = "M/d/yy h:mm tt";
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDate.Location = new System.Drawing.Point(15, 105);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(200, 20);
            this.dpDate.TabIndex = 14;
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(15, 145);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(373, 299);
            this.txtBody.TabIndex = 13;
            // 
            // txtPostLocation
            // 
            this.txtPostLocation.Location = new System.Drawing.Point(170, 65);
            this.txtPostLocation.Name = "txtPostLocation";
            this.txtPostLocation.Size = new System.Drawing.Size(149, 20);
            this.txtPostLocation.TabIndex = 12;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(15, 65);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(149, 20);
            this.txtAuthor.TabIndex = 11;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 26);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(275, 20);
            this.txtTitle.TabIndex = 10;
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
            // cbPublishState
            // 
            this.cbPublishState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPublishState.FormattingEnabled = true;
            this.cbPublishState.Location = new System.Drawing.Point(401, 24);
            this.cbPublishState.Name = "cbPublishState";
            this.cbPublishState.Size = new System.Drawing.Size(198, 21);
            this.cbPublishState.TabIndex = 15;
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
            // nudHitCount
            // 
            this.nudHitCount.Location = new System.Drawing.Point(401, 64);
            this.nudHitCount.Name = "nudHitCount";
            this.nudHitCount.Size = new System.Drawing.Size(120, 20);
            this.nudHitCount.TabIndex = 17;
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
            // tvComments
            // 
            this.tvComments.Location = new System.Drawing.Point(660, 24);
            this.tvComments.Name = "tvComments";
            this.tvComments.Size = new System.Drawing.Size(180, 420);
            this.tvComments.TabIndex = 19;
            // 
            // fcPopularityRanking
            // 
            this.fcPopularityRanking.Location = new System.Drawing.Point(394, 145);
            this.fcPopularityRanking.Name = "fcPopularityRanking";
            this.fcPopularityRanking.PopularityRanking = null;
            this.fcPopularityRanking.Size = new System.Drawing.Size(260, 89);
            this.fcPopularityRanking.TabIndex = 20;
            // 
            // PostWithOptionsPrefixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 512);
            this.Controls.Add(this.fcPopularityRanking);
            this.Controls.Add(this.tvComments);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudHitCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbPublishState);
            this.Controls.Add(this.dpDate);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtPostLocation);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.label1);
            this.Name = "PostWithOptionsPrefixForm";
            this.Text = "PostWithOptionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudHitCount)).EndInit();
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
        public System.Windows.Forms.DateTimePicker dpDate;
        public System.Windows.Forms.TextBox txtBody;
        public System.Windows.Forms.TextBox txtPostLocation;
        public System.Windows.Forms.TextBox txtAuthor;
        public System.Windows.Forms.TextBox txtTitle;
        public System.Windows.Forms.ComboBox cbPublishState;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown nudHitCount;
        internal System.Windows.Forms.TreeView tvComments;
        internal FluxCapacitor fcPopularityRanking;
    }
}