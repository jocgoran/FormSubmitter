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
            CookiesOutput = new System.Windows.Forms.RichTextBox();
            dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(XMLFormularText)).BeginInit();
            SuspendLayout();
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
            URLImputLabel.Click += new System.EventHandler(lbl_Click);
            // 
            // XMLFormularText
            // 
            XMLFormularText.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn1,
            dataGridViewTextBoxColumn2,
            dataGridViewTextBoxColumn3,
            dataGridViewTextBoxColumn4,
            dataGridViewTextBoxColumn5,
            dataGridViewTextBoxColumn6});
            XMLFormularText.Location = new System.Drawing.Point(15, 95);
            XMLFormularText.Name = "XMLFormularText";
            XMLFormularText.Size = new System.Drawing.Size(635, 233);
            XMLFormularText.TabIndex = 2;
            // 
            // GetURLRequest
            // 
            GetURLRequest.Location = new System.Drawing.Point(575, 29);
            GetURLRequest.Name = "GetURLRequest";
            GetURLRequest.Size = new System.Drawing.Size(75, 23);
            GetURLRequest.TabIndex = 3;
            GetURLRequest.Text = "Get request";
            GetURLRequest.UseVisualStyleBackColor = true;
            GetURLRequest.Click += new System.EventHandler(ButtonURLGetRequest_Click);
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
            SubmitURLRequest.Click += new System.EventHandler(ButtonSubmitURLRequest_Click);
            // 
            // ChoosenForm
            // 
            ChoosenForm.Location = new System.Drawing.Point(164, 339);
            ChoosenForm.Name = "ChoosenForm";
            ChoosenForm.Size = new System.Drawing.Size(60, 21);
            ChoosenForm.TabIndex = 6;
            // 
            // CookiesOutput
            // 
            CookiesOutput.Location = new System.Drawing.Point(372, 340);
            CookiesOutput.Multiline = true;
            CookiesOutput.Name = "CookiesOutput";
            CookiesOutput.Size = new System.Drawing.Size(278, 161);
            CookiesOutput.TabIndex = 7;
            CookiesOutput.Text = "Cookies Output";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "key";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "form";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "action";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "type";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "name";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "value";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // URLFormSubmitter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(662, 517);
            Controls.Add(CookiesOutput);
            Controls.Add(ChoosenForm);
            Controls.Add(SubmitURLRequest);
            Controls.Add(XMLFormularLabel);
            Controls.Add(GetURLRequest);
            Controls.Add(XMLFormularText);
            Controls.Add(UrlImput);
            Controls.Add(URLImputLabel);
            Name = "URLFormSubmitter";
            Text = "URL form submitter";
            Load += new System.EventHandler(URLFormSubmitter_Load);
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

        private static DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private static DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private static DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private static DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private static DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private static DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        public static TextBox UrlImput;
        public static Label URLImputLabel;
        public static DataGridView XMLFormularText;
        public static Button GetURLRequest;
        public static Label XMLFormularLabel;
        public static Button SubmitURLRequest;
        public static ComboBox ChoosenForm;
        public static RichTextBox CookiesOutput;
    }
}