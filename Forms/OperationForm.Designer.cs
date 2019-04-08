namespace SchoolAccounting.Forms
{
    partial class OperationForm
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
            this.groupBoxService = new System.Windows.Forms.GroupBox();
            this.groupBoxServiceAccess = new System.Windows.Forms.GroupBox();
            this.checkBoxOldSchool = new System.Windows.Forms.CheckBox();
            this.checkBoxSecondarySchool = new System.Windows.Forms.CheckBox();
            this.checkBoxJuniorSchool = new System.Windows.Forms.CheckBox();
            this.checkBoxPreschooler = new System.Windows.Forms.CheckBox();
            this.checkBoxAdult = new System.Windows.Forms.CheckBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.labelServiceDescription = new System.Windows.Forms.Label();
            this.buttonServiceCommit = new System.Windows.Forms.Button();
            this.labelServicePrice = new System.Windows.Forms.Label();
            this.textBoxServicePrice = new System.Windows.Forms.TextBox();
            this.labelTypeOfService = new System.Windows.Forms.Label();
            this.comboBoxTypeOfService = new System.Windows.Forms.ComboBox();
            this.labelServiceName = new System.Windows.Forms.Label();
            this.textBoxServiceName = new System.Windows.Forms.TextBox();
            this.richTextBoxServiceDescription = new System.Windows.Forms.RichTextBox();
            this.groupBoxAccounting = new System.Windows.Forms.GroupBox();
            this.labelWarningAccess = new System.Windows.Forms.Label();
            this.buttonAccountingCommit = new System.Windows.Forms.Button();
            this.labelService = new System.Windows.Forms.Label();
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.labelAccountingDate = new System.Windows.Forms.Label();
            this.dateTimePickerAccounting = new System.Windows.Forms.DateTimePicker();
            this.groupBoxClient = new System.Windows.Forms.GroupBox();
            this.labelTypeClient = new System.Windows.Forms.Label();
            this.comboBoxTypeClient = new System.Windows.Forms.ComboBox();
            this.labelClinetFullName = new System.Windows.Forms.Label();
            this.textBoxClientFullName = new System.Windows.Forms.TextBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.groupBoxService.SuspendLayout();
            this.groupBoxServiceAccess.SuspendLayout();
            this.groupBoxAccounting.SuspendLayout();
            this.groupBoxClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxService
            // 
            this.groupBoxService.Controls.Add(this.groupBoxServiceAccess);
            this.groupBoxService.Controls.Add(this.labelServiceDescription);
            this.groupBoxService.Controls.Add(this.buttonServiceCommit);
            this.groupBoxService.Controls.Add(this.labelServicePrice);
            this.groupBoxService.Controls.Add(this.textBoxServicePrice);
            this.groupBoxService.Controls.Add(this.labelTypeOfService);
            this.groupBoxService.Controls.Add(this.comboBoxTypeOfService);
            this.groupBoxService.Controls.Add(this.labelServiceName);
            this.groupBoxService.Controls.Add(this.textBoxServiceName);
            this.groupBoxService.Controls.Add(this.richTextBoxServiceDescription);
            this.groupBoxService.Location = new System.Drawing.Point(12, 12);
            this.groupBoxService.Name = "groupBoxService";
            this.groupBoxService.Size = new System.Drawing.Size(485, 305);
            this.groupBoxService.TabIndex = 3;
            this.groupBoxService.TabStop = false;
            this.groupBoxService.Text = "Данные об услуге";
            this.groupBoxService.Visible = false;
            // 
            // groupBoxServiceAccess
            // 
            this.groupBoxServiceAccess.Controls.Add(this.checkBoxOldSchool);
            this.groupBoxServiceAccess.Controls.Add(this.checkBoxSecondarySchool);
            this.groupBoxServiceAccess.Controls.Add(this.checkBoxJuniorSchool);
            this.groupBoxServiceAccess.Controls.Add(this.checkBoxPreschooler);
            this.groupBoxServiceAccess.Controls.Add(this.checkBoxAdult);
            this.groupBoxServiceAccess.Controls.Add(this.checkBoxAll);
            this.groupBoxServiceAccess.Location = new System.Drawing.Point(9, 168);
            this.groupBoxServiceAccess.Name = "groupBoxServiceAccess";
            this.groupBoxServiceAccess.Size = new System.Drawing.Size(460, 100);
            this.groupBoxServiceAccess.TabIndex = 10;
            this.groupBoxServiceAccess.TabStop = false;
            this.groupBoxServiceAccess.Text = "Кому услуга доступна";
            // 
            // checkBoxOldSchool
            // 
            this.checkBoxOldSchool.AutoSize = true;
            this.checkBoxOldSchool.Location = new System.Drawing.Point(264, 51);
            this.checkBoxOldSchool.Name = "checkBoxOldSchool";
            this.checkBoxOldSchool.Size = new System.Drawing.Size(105, 17);
            this.checkBoxOldSchool.TabIndex = 5;
            this.checkBoxOldSchool.Text = "Старшая школа";
            this.checkBoxOldSchool.UseVisualStyleBackColor = true;
            // 
            // checkBoxSecondarySchool
            // 
            this.checkBoxSecondarySchool.AutoSize = true;
            this.checkBoxSecondarySchool.Location = new System.Drawing.Point(130, 51);
            this.checkBoxSecondarySchool.Name = "checkBoxSecondarySchool";
            this.checkBoxSecondarySchool.Size = new System.Drawing.Size(104, 17);
            this.checkBoxSecondarySchool.TabIndex = 4;
            this.checkBoxSecondarySchool.Text = "Средняя школа";
            this.checkBoxSecondarySchool.UseVisualStyleBackColor = true;
            // 
            // checkBoxJuniorSchool
            // 
            this.checkBoxJuniorSchool.AutoSize = true;
            this.checkBoxJuniorSchool.Location = new System.Drawing.Point(10, 51);
            this.checkBoxJuniorSchool.Name = "checkBoxJuniorSchool";
            this.checkBoxJuniorSchool.Size = new System.Drawing.Size(108, 17);
            this.checkBoxJuniorSchool.TabIndex = 3;
            this.checkBoxJuniorSchool.Text = "Младшая школа";
            this.checkBoxJuniorSchool.UseVisualStyleBackColor = true;
            // 
            // checkBoxPreschooler
            // 
            this.checkBoxPreschooler.AutoSize = true;
            this.checkBoxPreschooler.Location = new System.Drawing.Point(264, 19);
            this.checkBoxPreschooler.Name = "checkBoxPreschooler";
            this.checkBoxPreschooler.Size = new System.Drawing.Size(105, 17);
            this.checkBoxPreschooler.TabIndex = 2;
            this.checkBoxPreschooler.Text = "Дошкольникам";
            this.checkBoxPreschooler.UseVisualStyleBackColor = true;
            // 
            // checkBoxAdult
            // 
            this.checkBoxAdult.AutoSize = true;
            this.checkBoxAdult.Location = new System.Drawing.Point(130, 19);
            this.checkBoxAdult.Name = "checkBoxAdult";
            this.checkBoxAdult.Size = new System.Drawing.Size(79, 17);
            this.checkBoxAdult.TabIndex = 1;
            this.checkBoxAdult.Text = "Взрослым";
            this.checkBoxAdult.UseVisualStyleBackColor = true;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(10, 19);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(53, 17);
            this.checkBoxAll.TabIndex = 0;
            this.checkBoxAll.Text = "Всем";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // labelServiceDescription
            // 
            this.labelServiceDescription.AutoSize = true;
            this.labelServiceDescription.Location = new System.Drawing.Point(6, 60);
            this.labelServiceDescription.Name = "labelServiceDescription";
            this.labelServiceDescription.Size = new System.Drawing.Size(93, 13);
            this.labelServiceDescription.TabIndex = 8;
            this.labelServiceDescription.Text = "Описание услуги";
            // 
            // buttonServiceCommit
            // 
            this.buttonServiceCommit.Location = new System.Drawing.Point(201, 274);
            this.buttonServiceCommit.Name = "buttonServiceCommit";
            this.buttonServiceCommit.Size = new System.Drawing.Size(75, 23);
            this.buttonServiceCommit.TabIndex = 7;
            this.buttonServiceCommit.Text = "Сохранить";
            this.buttonServiceCommit.UseVisualStyleBackColor = true;
            this.buttonServiceCommit.Click += new System.EventHandler(this.buttonServiceCommit_Click);
            // 
            // labelServicePrice
            // 
            this.labelServicePrice.AutoSize = true;
            this.labelServicePrice.Location = new System.Drawing.Point(270, 144);
            this.labelServicePrice.Name = "labelServicePrice";
            this.labelServicePrice.Size = new System.Drawing.Size(62, 13);
            this.labelServicePrice.TabIndex = 6;
            this.labelServicePrice.Text = "Стоимость";
            // 
            // textBoxServicePrice
            // 
            this.textBoxServicePrice.Location = new System.Drawing.Point(338, 141);
            this.textBoxServicePrice.Name = "textBoxServicePrice";
            this.textBoxServicePrice.Size = new System.Drawing.Size(131, 20);
            this.textBoxServicePrice.TabIndex = 5;
            this.textBoxServicePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrice_KeyPress);
            // 
            // labelTypeOfService
            // 
            this.labelTypeOfService.AutoSize = true;
            this.labelTypeOfService.Location = new System.Drawing.Point(6, 144);
            this.labelTypeOfService.Name = "labelTypeOfService";
            this.labelTypeOfService.Size = new System.Drawing.Size(62, 13);
            this.labelTypeOfService.TabIndex = 4;
            this.labelTypeOfService.Text = "Тип услуги";
            // 
            // comboBoxTypeOfService
            // 
            this.comboBoxTypeOfService.FormattingEnabled = true;
            this.comboBoxTypeOfService.Location = new System.Drawing.Point(105, 141);
            this.comboBoxTypeOfService.Name = "comboBoxTypeOfService";
            this.comboBoxTypeOfService.Size = new System.Drawing.Size(142, 21);
            this.comboBoxTypeOfService.TabIndex = 3;
            this.comboBoxTypeOfService.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxTypeOfService_KeyPress);
            // 
            // labelServiceName
            // 
            this.labelServiceName.AutoSize = true;
            this.labelServiceName.Location = new System.Drawing.Point(6, 34);
            this.labelServiceName.Name = "labelServiceName";
            this.labelServiceName.Size = new System.Drawing.Size(93, 13);
            this.labelServiceName.TabIndex = 2;
            this.labelServiceName.Text = "Название услуги";
            // 
            // textBoxServiceName
            // 
            this.textBoxServiceName.Location = new System.Drawing.Point(105, 31);
            this.textBoxServiceName.Name = "textBoxServiceName";
            this.textBoxServiceName.Size = new System.Drawing.Size(364, 20);
            this.textBoxServiceName.TabIndex = 0;
            // 
            // richTextBoxServiceDescription
            // 
            this.richTextBoxServiceDescription.Location = new System.Drawing.Point(105, 57);
            this.richTextBoxServiceDescription.Name = "richTextBoxServiceDescription";
            this.richTextBoxServiceDescription.Size = new System.Drawing.Size(364, 78);
            this.richTextBoxServiceDescription.TabIndex = 1;
            this.richTextBoxServiceDescription.Text = "";
            // 
            // groupBoxAccounting
            // 
            this.groupBoxAccounting.Controls.Add(this.labelWarningAccess);
            this.groupBoxAccounting.Controls.Add(this.buttonAccountingCommit);
            this.groupBoxAccounting.Controls.Add(this.labelService);
            this.groupBoxAccounting.Controls.Add(this.comboBoxService);
            this.groupBoxAccounting.Controls.Add(this.labelAccountingDate);
            this.groupBoxAccounting.Controls.Add(this.dateTimePickerAccounting);
            this.groupBoxAccounting.Controls.Add(this.groupBoxClient);
            this.groupBoxAccounting.Controls.Add(this.labelClient);
            this.groupBoxAccounting.Controls.Add(this.comboBoxClient);
            this.groupBoxAccounting.Location = new System.Drawing.Point(525, 40);
            this.groupBoxAccounting.Name = "groupBoxAccounting";
            this.groupBoxAccounting.Size = new System.Drawing.Size(425, 215);
            this.groupBoxAccounting.TabIndex = 4;
            this.groupBoxAccounting.TabStop = false;
            this.groupBoxAccounting.Text = "Данные учета";
            this.groupBoxAccounting.Visible = false;
            // 
            // labelWarningAccess
            // 
            this.labelWarningAccess.AutoSize = true;
            this.labelWarningAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarningAccess.Location = new System.Drawing.Point(52, 149);
            this.labelWarningAccess.Name = "labelWarningAccess";
            this.labelWarningAccess.Size = new System.Drawing.Size(0, 13);
            this.labelWarningAccess.TabIndex = 16;
            // 
            // buttonAccountingCommit
            // 
            this.buttonAccountingCommit.Location = new System.Drawing.Point(191, 181);
            this.buttonAccountingCommit.Name = "buttonAccountingCommit";
            this.buttonAccountingCommit.Size = new System.Drawing.Size(75, 23);
            this.buttonAccountingCommit.TabIndex = 11;
            this.buttonAccountingCommit.Text = "Сохранить";
            this.buttonAccountingCommit.UseVisualStyleBackColor = true;
            this.buttonAccountingCommit.Click += new System.EventHandler(this.buttonAccountingCommit_Click);
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Location = new System.Drawing.Point(6, 117);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(43, 13);
            this.labelService.TabIndex = 15;
            this.labelService.Text = "Услуга";
            // 
            // comboBoxService
            // 
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(55, 114);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(354, 21);
            this.comboBoxService.TabIndex = 14;
            this.comboBoxService.SelectedIndexChanged += new System.EventHandler(this.comboBoxService_SelectedIndexChanged);
            this.comboBoxService.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxTypeOfService_KeyPress);
            // 
            // labelAccountingDate
            // 
            this.labelAccountingDate.AutoSize = true;
            this.labelAccountingDate.Location = new System.Drawing.Point(6, 71);
            this.labelAccountingDate.Name = "labelAccountingDate";
            this.labelAccountingDate.Size = new System.Drawing.Size(33, 13);
            this.labelAccountingDate.TabIndex = 13;
            this.labelAccountingDate.Text = "Дата";
            // 
            // dateTimePickerAccounting
            // 
            this.dateTimePickerAccounting.Location = new System.Drawing.Point(55, 67);
            this.dateTimePickerAccounting.Name = "dateTimePickerAccounting";
            this.dateTimePickerAccounting.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerAccounting.TabIndex = 7;
            this.dateTimePickerAccounting.Value = new System.DateTime(2019, 4, 7, 16, 58, 5, 0);
            // 
            // groupBoxClient
            // 
            this.groupBoxClient.Controls.Add(this.labelTypeClient);
            this.groupBoxClient.Controls.Add(this.comboBoxTypeClient);
            this.groupBoxClient.Controls.Add(this.labelClinetFullName);
            this.groupBoxClient.Controls.Add(this.textBoxClientFullName);
            this.groupBoxClient.Location = new System.Drawing.Point(182, 19);
            this.groupBoxClient.Name = "groupBoxClient";
            this.groupBoxClient.Size = new System.Drawing.Size(235, 87);
            this.groupBoxClient.TabIndex = 12;
            this.groupBoxClient.TabStop = false;
            this.groupBoxClient.Text = "Данные о клиенте";
            // 
            // labelTypeClient
            // 
            this.labelTypeClient.AutoSize = true;
            this.labelTypeClient.Location = new System.Drawing.Point(6, 55);
            this.labelTypeClient.Name = "labelTypeClient";
            this.labelTypeClient.Size = new System.Drawing.Size(70, 13);
            this.labelTypeClient.TabIndex = 6;
            this.labelTypeClient.Text = "Тип клиента";
            // 
            // comboBoxTypeClient
            // 
            this.comboBoxTypeClient.FormattingEnabled = true;
            this.comboBoxTypeClient.Location = new System.Drawing.Point(82, 52);
            this.comboBoxTypeClient.Name = "comboBoxTypeClient";
            this.comboBoxTypeClient.Size = new System.Drawing.Size(145, 21);
            this.comboBoxTypeClient.TabIndex = 5;
            this.comboBoxTypeClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxTypeOfService_KeyPress);
            // 
            // labelClinetFullName
            // 
            this.labelClinetFullName.AutoSize = true;
            this.labelClinetFullName.Location = new System.Drawing.Point(6, 29);
            this.labelClinetFullName.Name = "labelClinetFullName";
            this.labelClinetFullName.Size = new System.Drawing.Size(34, 13);
            this.labelClinetFullName.TabIndex = 4;
            this.labelClinetFullName.Text = "ФИО";
            // 
            // textBoxClientFullName
            // 
            this.textBoxClientFullName.Location = new System.Drawing.Point(46, 26);
            this.textBoxClientFullName.Name = "textBoxClientFullName";
            this.textBoxClientFullName.Size = new System.Drawing.Size(181, 20);
            this.textBoxClientFullName.TabIndex = 3;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(6, 34);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(43, 13);
            this.labelClient.TabIndex = 11;
            this.labelClient.Text = "Клиент";
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(55, 31);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(121, 21);
            this.comboBoxClient.TabIndex = 0;
            this.comboBoxClient.SelectedIndexChanged += new System.EventHandler(this.comboBoxClient_SelectedIndexChanged);
            this.comboBoxClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxTypeOfService_KeyPress);
            // 
            // OperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 493);
            this.Controls.Add(this.groupBoxService);
            this.Controls.Add(this.groupBoxAccounting);
            this.Name = "OperationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Операции";
            this.groupBoxService.ResumeLayout(false);
            this.groupBoxService.PerformLayout();
            this.groupBoxServiceAccess.ResumeLayout(false);
            this.groupBoxServiceAccess.PerformLayout();
            this.groupBoxAccounting.ResumeLayout(false);
            this.groupBoxAccounting.PerformLayout();
            this.groupBoxClient.ResumeLayout(false);
            this.groupBoxClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxService;
        private System.Windows.Forms.GroupBox groupBoxServiceAccess;
        private System.Windows.Forms.CheckBox checkBoxOldSchool;
        private System.Windows.Forms.CheckBox checkBoxSecondarySchool;
        private System.Windows.Forms.CheckBox checkBoxJuniorSchool;
        private System.Windows.Forms.CheckBox checkBoxPreschooler;
        private System.Windows.Forms.CheckBox checkBoxAdult;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.Label labelServiceDescription;
        private System.Windows.Forms.Button buttonServiceCommit;
        private System.Windows.Forms.Label labelServicePrice;
        private System.Windows.Forms.TextBox textBoxServicePrice;
        private System.Windows.Forms.Label labelTypeOfService;
        private System.Windows.Forms.ComboBox comboBoxTypeOfService;
        private System.Windows.Forms.Label labelServiceName;
        private System.Windows.Forms.TextBox textBoxServiceName;
        private System.Windows.Forms.RichTextBox richTextBoxServiceDescription;
        private System.Windows.Forms.GroupBox groupBoxAccounting;
        private System.Windows.Forms.Label labelWarningAccess;
        private System.Windows.Forms.Button buttonAccountingCommit;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.Label labelAccountingDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerAccounting;
        private System.Windows.Forms.GroupBox groupBoxClient;
        private System.Windows.Forms.Label labelTypeClient;
        private System.Windows.Forms.ComboBox comboBoxTypeClient;
        private System.Windows.Forms.Label labelClinetFullName;
        private System.Windows.Forms.TextBox textBoxClientFullName;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.ComboBox comboBoxClient;
    }
}