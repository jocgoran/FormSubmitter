using System;
using System.Windows.Forms;

namespace FormInterface.view
{
    sealed partial class URLFormSubmitter
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
            this.UrlImput = new System.Windows.Forms.TextBox();
            this.URLImputLabel = new System.Windows.Forms.Label();
            this.XMLFormularText = new System.Windows.Forms.DataGridView();
            this.GetURLRequest = new System.Windows.Forms.Button();
            this.XMLFormularLabel = new System.Windows.Forms.Label();
            this.SubmitURLRequest = new System.Windows.Forms.Button();
            this.ChoosenForm = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.XMLFormularText)).BeginInit();
            this.SuspendLayout();
            // 
            // UrlImput
            // 
            this.UrlImput.Location = new System.Drawing.Point(15, 32);
            this.UrlImput.Name = "UrlImput";
            this.UrlImput.Size = new System.Drawing.Size(554, 20);
            this.UrlImput.TabIndex = 0;
            this.UrlImput.Text = "http://www.tio.ch";
            // 
            // URLImputLabel
            // 
            this.URLImputLabel.Location = new System.Drawing.Point(13, 9);
            this.URLImputLabel.Name = "URLImputLabel";
            this.URLImputLabel.Size = new System.Drawing.Size(152, 20);
            this.URLImputLabel.TabIndex = 1;
            this.URLImputLabel.Text = "write the URL of formular";
            this.URLImputLabel.Click += new System.EventHandler(this.lbl_Click);
            // 
            // XMLFormularText
            // 
            this.XMLFormularText.Location = new System.Drawing.Point(15, 95);
            this.XMLFormularText.Name = "XMLFormularText";
            this.XMLFormularText.Size = new System.Drawing.Size(635, 233);
            this.XMLFormularText.TabIndex = 2;
            // 
            // GetURLRequest
            // 
            this.GetURLRequest.Location = new System.Drawing.Point(575, 29);
            this.GetURLRequest.Name = "GetURLRequest";
            this.GetURLRequest.Size = new System.Drawing.Size(75, 23);
            this.GetURLRequest.TabIndex = 3;
            this.GetURLRequest.Text = "Get request";
            this.GetURLRequest.UseVisualStyleBackColor = true;
            this.GetURLRequest.Click += new System.EventHandler(this.ButtonURLGetRequest_Click);
            // 
            // XMLFormularLabel
            // 
            this.XMLFormularLabel.AutoSize = true;
            this.XMLFormularLabel.Location = new System.Drawing.Point(13, 72);
            this.XMLFormularLabel.Name = "XMLFormularLabel";
            this.XMLFormularLabel.Size = new System.Drawing.Size(69, 13);
            this.XMLFormularLabel.TabIndex = 4;
            this.XMLFormularLabel.Text = "XML formular";
            // 
            // SubmitURLRequest
            // 
            this.SubmitURLRequest.Location = new System.Drawing.Point(16, 337);
            this.SubmitURLRequest.Name = "SubmitURLRequest";
            this.SubmitURLRequest.Size = new System.Drawing.Size(129, 23);
            this.SubmitURLRequest.TabIndex = 5;
            this.SubmitURLRequest.Text = "Send formular\'s values";
            this.SubmitURLRequest.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.ChoosenForm.FormattingEnabled = true;
            this.ChoosenForm.Location = new System.Drawing.Point(164, 339);
            this.ChoosenForm.Name = "ChoosenForm";
            this.ChoosenForm.Size = new System.Drawing.Size(121, 21);
            this.ChoosenForm.TabIndex = 6;
            this.ChoosenForm.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // URLFormSubmitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 368);
            this.Controls.Add(this.ChoosenForm);
            this.Controls.Add(this.SubmitURLRequest);
            this.Controls.Add(this.XMLFormularLabel);
            this.Controls.Add(this.GetURLRequest);
            this.Controls.Add(this.XMLFormularText);
            this.Controls.Add(this.UrlImput);
            this.Controls.Add(this.URLImputLabel);
            this.Name = "URLFormSubmitter";
            this.Text = "URL form submitter";
            this.Load += new System.EventHandler(this.URLFormSubmitter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.XMLFormularText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ButtonURLGetRequest_Click(object sender, EventArgs e)
        {
            FormInterface.controller.navigator.ButtonURLGetRequest();
        }

        #endregion
        public TextBox UrlImput;
        public Label URLImputLabel;
        public DataGridView XMLFormularText;
        public Button GetURLRequest;
        public Label XMLFormularLabel;
        public Button SubmitURLRequest;
        public ComboBox ChoosenForm;
    }
}