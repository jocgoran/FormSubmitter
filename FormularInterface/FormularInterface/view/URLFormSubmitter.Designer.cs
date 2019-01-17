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

      
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UrlImput = new System.Windows.Forms.TextBox();
            URLImputLabel = new System.Windows.Forms.Label();
            XMLFormularText = new System.Windows.Forms.DataGridView();
            GetURLRequest = new System.Windows.Forms.Button();
            XMLFormularLabel = new System.Windows.Forms.Label();
            SubmitURLRequest = new System.Windows.Forms.Button();
            ChoosenForm = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(XMLFormularText)).BeginInit();
            this.SuspendLayout();
            // 
            // UrlImput
            // 
            UrlImput.Location = new System.Drawing.Point(15, 32);
            UrlImput.Name = "UrlImput";
            UrlImput.Size = new System.Drawing.Size(554, 20);
            UrlImput.TabIndex = 0;
            UrlImput.Text = "http://pamela.joc.ch";
            // 
            // URLImputLabel
            // 
            URLImputLabel.Location = new System.Drawing.Point(13, 9);
            URLImputLabel.Name = "URLImputLabel";
            URLImputLabel.Size = new System.Drawing.Size(152, 20);
            URLImputLabel.TabIndex = 1;
            URLImputLabel.Text = "write the URL of formular";
            URLImputLabel.Click += new System.EventHandler(this.lbl_Click);
            // 
            // XMLFormularText
            // 
            XMLFormularText.Location = new System.Drawing.Point(15, 95);
            XMLFormularText.Name = "XMLFormularText";
            XMLFormularText.Size = new System.Drawing.Size(635, 233);
            XMLFormularText.TabIndex = 2;
            //
            // Column of FormularText can be added hardcoded
            //
            XMLFormularText.Columns.Add("Key", "key");
            XMLFormularText.Columns.Add("Form", "form");
            XMLFormularText.Columns.Add("Action", "action");
            XMLFormularText.Columns.Add("Type", "type");
            XMLFormularText.Columns.Add("Name", "name");
            XMLFormularText.Columns.Add("Value", "value");
            // 
            // GetURLRequest
            // 
            GetURLRequest.Location = new System.Drawing.Point(575, 29);
            GetURLRequest.Name = "GetURLRequest";
            GetURLRequest.Size = new System.Drawing.Size(75, 23);
            GetURLRequest.TabIndex = 3;
            GetURLRequest.Text = "Get request";
            GetURLRequest.UseVisualStyleBackColor = true;
            GetURLRequest.Click += new System.EventHandler(this.ButtonURLGetRequest_Click);
            // 
            // XMLFormularLabel
            // 
            XMLFormularLabel.AutoSize = true;
            XMLFormularLabel.Location = new System.Drawing.Point(13, 72);
            XMLFormularLabel.Name = "XMLFormularLabel";
            XMLFormularLabel.Size = new System.Drawing.Size(69, 13);
            XMLFormularLabel.TabIndex = 4;
            XMLFormularLabel.Text = "XML formular";
            // 
            // SubmitURLRequest
            // 
            SubmitURLRequest.Location = new System.Drawing.Point(16, 337);
            SubmitURLRequest.Name = "SubmitURLRequest";
            SubmitURLRequest.Size = new System.Drawing.Size(129, 23);
            SubmitURLRequest.TabIndex = 5;
            SubmitURLRequest.Text = "Send formular\'s values";
            SubmitURLRequest.UseVisualStyleBackColor = true;
            SubmitURLRequest.Click += new System.EventHandler(this.ButtonSubmitURLRequest_Click);
            // 
            // ChoosenForm
            // 
            ChoosenForm.Location = new System.Drawing.Point(164, 339);
            ChoosenForm.Name = "ChoosenForm";
            ChoosenForm.Size = new System.Drawing.Size(60, 21);
            ChoosenForm.TabIndex = 6;
            // 
            // URLFormSubmitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 368);
            this.Controls.Add(ChoosenForm);
            this.Controls.Add(SubmitURLRequest);
            this.Controls.Add(XMLFormularLabel);
            this.Controls.Add(GetURLRequest);
            this.Controls.Add(XMLFormularText);
            this.Controls.Add(UrlImput);
            this.Controls.Add(URLImputLabel);
            this.Name = "URLFormSubmitter";
            this.Text = "URL form submitter";
            this.Load += new System.EventHandler(this.URLFormSubmitter_Load);
            ((System.ComponentModel.ISupportInitialize)(XMLFormularText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();



        }

        private void ButtonURLGetRequest_Click(object sender, EventArgs e)
        {
            FormInterface.controller.Navigator.ButtonURLGetRequest();
        }

        private void ButtonSubmitURLRequest_Click(object sender, EventArgs e)
        {
            FormInterface.controller.Navigator.SendPostRequest();
        }

        public static TextBox UrlImput;
        public static Label URLImputLabel;
        public static DataGridView XMLFormularText;
        public static Button GetURLRequest;
        public static Label XMLFormularLabel;
        public static Button SubmitURLRequest;
        public static ComboBox ChoosenForm;
    }
}