namespace SchoolAccounting
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewAccounting = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonApplyAccountingFilter = new System.Windows.Forms.Button();
            this.labelDateTo = new System.Windows.Forms.Label();
            this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
            this.labelDateFrom = new System.Windows.Forms.Label();
            this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
            this.labelServiceName = new System.Windows.Forms.Label();
            this.comboBoxServiceName = new System.Windows.Forms.ComboBox();
            this.labelTypeClient = new System.Windows.Forms.Label();
            this.comboBoxTypeClient = new System.Windows.Forms.ComboBox();
            this.textBoxPriceTo = new System.Windows.Forms.TextBox();
            this.labelPriceTo = new System.Windows.Forms.Label();
            this.textBoxPriceFrom = new System.Windows.Forms.TextBox();
            this.labelPriceFrom = new System.Windows.Forms.Label();
            this.textBoxClientFullName = new System.Windows.Forms.TextBox();
            this.labelClientFullName = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewService = new System.Windows.Forms.DataGridView();
            this.contextMenuStripDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonResetAccountingFilter = new System.Windows.Forms.Button();
            this.checkBoxFilterDate = new System.Windows.Forms.CheckBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounting)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).BeginInit();
            this.contextMenuStripDataGrid.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAccounting
            // 
            this.dataGridViewAccounting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccounting.Location = new System.Drawing.Point(6, 59);
            this.dataGridViewAccounting.Name = "dataGridViewAccounting";
            this.dataGridViewAccounting.ReadOnly = true;
            this.dataGridViewAccounting.Size = new System.Drawing.Size(776, 330);
            this.dataGridViewAccounting.TabIndex = 0;
            this.dataGridViewAccounting.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAccounting_ColumnHeaderMouseClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 423);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBoxFilterDate);
            this.tabPage1.Controls.Add(this.buttonResetAccountingFilter);
            this.tabPage1.Controls.Add(this.buttonApplyAccountingFilter);
            this.tabPage1.Controls.Add(this.labelDateTo);
            this.tabPage1.Controls.Add(this.dateTimePickerDateTo);
            this.tabPage1.Controls.Add(this.labelDateFrom);
            this.tabPage1.Controls.Add(this.dateTimePickerDateFrom);
            this.tabPage1.Controls.Add(this.labelServiceName);
            this.tabPage1.Controls.Add(this.comboBoxServiceName);
            this.tabPage1.Controls.Add(this.labelTypeClient);
            this.tabPage1.Controls.Add(this.comboBoxTypeClient);
            this.tabPage1.Controls.Add(this.textBoxPriceTo);
            this.tabPage1.Controls.Add(this.labelPriceTo);
            this.tabPage1.Controls.Add(this.textBoxPriceFrom);
            this.tabPage1.Controls.Add(this.labelPriceFrom);
            this.tabPage1.Controls.Add(this.textBoxClientFullName);
            this.tabPage1.Controls.Add(this.labelClientFullName);
            this.tabPage1.Controls.Add(this.dataGridViewAccounting);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Учет услуг";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonApplyAccountingFilter
            // 
            this.buttonApplyAccountingFilter.Location = new System.Drawing.Point(706, 32);
            this.buttonApplyAccountingFilter.Name = "buttonApplyAccountingFilter";
            this.buttonApplyAccountingFilter.Size = new System.Drawing.Size(76, 21);
            this.buttonApplyAccountingFilter.TabIndex = 15;
            this.buttonApplyAccountingFilter.Text = "Применить";
            this.buttonApplyAccountingFilter.UseVisualStyleBackColor = true;
            this.buttonApplyAccountingFilter.Click += new System.EventHandler(this.buttonApplyAccountingFilter_Click);
            // 
            // labelDateTo
            // 
            this.labelDateTo.AutoSize = true;
            this.labelDateTo.Location = new System.Drawing.Point(451, 35);
            this.labelDateTo.Name = "labelDateTo";
            this.labelDateTo.Size = new System.Drawing.Size(19, 13);
            this.labelDateTo.TabIndex = 14;
            this.labelDateTo.Text = "до";
            // 
            // dateTimePickerDateTo
            // 
            this.dateTimePickerDateTo.Location = new System.Drawing.Point(476, 33);
            this.dateTimePickerDateTo.Name = "dateTimePickerDateTo";
            this.dateTimePickerDateTo.Size = new System.Drawing.Size(130, 20);
            this.dateTimePickerDateTo.TabIndex = 13;
            // 
            // labelDateFrom
            // 
            this.labelDateFrom.AutoSize = true;
            this.labelDateFrom.Location = new System.Drawing.Point(262, 35);
            this.labelDateFrom.Name = "labelDateFrom";
            this.labelDateFrom.Size = new System.Drawing.Size(47, 13);
            this.labelDateFrom.TabIndex = 12;
            this.labelDateFrom.Text = "Дата от";
            // 
            // dateTimePickerDateFrom
            // 
            this.dateTimePickerDateFrom.Location = new System.Drawing.Point(315, 33);
            this.dateTimePickerDateFrom.Name = "dateTimePickerDateFrom";
            this.dateTimePickerDateFrom.Size = new System.Drawing.Size(130, 20);
            this.dateTimePickerDateFrom.TabIndex = 11;
            // 
            // labelServiceName
            // 
            this.labelServiceName.AutoSize = true;
            this.labelServiceName.Location = new System.Drawing.Point(451, 10);
            this.labelServiceName.Name = "labelServiceName";
            this.labelServiceName.Size = new System.Drawing.Size(93, 13);
            this.labelServiceName.TabIndex = 10;
            this.labelServiceName.Text = "Название услуги";
            // 
            // comboBoxServiceName
            // 
            this.comboBoxServiceName.FormattingEnabled = true;
            this.comboBoxServiceName.Location = new System.Drawing.Point(550, 6);
            this.comboBoxServiceName.Name = "comboBoxServiceName";
            this.comboBoxServiceName.Size = new System.Drawing.Size(150, 21);
            this.comboBoxServiceName.TabIndex = 9;
            // 
            // labelTypeClient
            // 
            this.labelTypeClient.AutoSize = true;
            this.labelTypeClient.Location = new System.Drawing.Point(262, 10);
            this.labelTypeClient.Name = "labelTypeClient";
            this.labelTypeClient.Size = new System.Drawing.Size(70, 13);
            this.labelTypeClient.TabIndex = 8;
            this.labelTypeClient.Text = "Тип клиента";
            // 
            // comboBoxTypeClient
            // 
            this.comboBoxTypeClient.FormattingEnabled = true;
            this.comboBoxTypeClient.Location = new System.Drawing.Point(338, 6);
            this.comboBoxTypeClient.Name = "comboBoxTypeClient";
            this.comboBoxTypeClient.Size = new System.Drawing.Size(107, 21);
            this.comboBoxTypeClient.TabIndex = 7;
            // 
            // textBoxPriceTo
            // 
            this.textBoxPriceTo.Location = new System.Drawing.Point(171, 32);
            this.textBoxPriceTo.Name = "textBoxPriceTo";
            this.textBoxPriceTo.Size = new System.Drawing.Size(85, 20);
            this.textBoxPriceTo.TabIndex = 6;
            this.textBoxPriceTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPriceTo_KeyPress);
            // 
            // labelPriceTo
            // 
            this.labelPriceTo.AutoSize = true;
            this.labelPriceTo.Location = new System.Drawing.Point(146, 35);
            this.labelPriceTo.Name = "labelPriceTo";
            this.labelPriceTo.Size = new System.Drawing.Size(19, 13);
            this.labelPriceTo.TabIndex = 5;
            this.labelPriceTo.Text = "до";
            // 
            // textBoxPriceFrom
            // 
            this.textBoxPriceFrom.Location = new System.Drawing.Point(61, 32);
            this.textBoxPriceFrom.Name = "textBoxPriceFrom";
            this.textBoxPriceFrom.Size = new System.Drawing.Size(79, 20);
            this.textBoxPriceFrom.TabIndex = 4;
            this.textBoxPriceFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPriceFrom_KeyPress);
            // 
            // labelPriceFrom
            // 
            this.labelPriceFrom.AutoSize = true;
            this.labelPriceFrom.Location = new System.Drawing.Point(8, 35);
            this.labelPriceFrom.Name = "labelPriceFrom";
            this.labelPriceFrom.Size = new System.Drawing.Size(47, 13);
            this.labelPriceFrom.TabIndex = 3;
            this.labelPriceFrom.Text = "Цена от";
            // 
            // textBoxClientFullName
            // 
            this.textBoxClientFullName.Location = new System.Drawing.Point(92, 6);
            this.textBoxClientFullName.Name = "textBoxClientFullName";
            this.textBoxClientFullName.Size = new System.Drawing.Size(164, 20);
            this.textBoxClientFullName.TabIndex = 2;
            // 
            // labelClientFullName
            // 
            this.labelClientFullName.AutoSize = true;
            this.labelClientFullName.Location = new System.Drawing.Point(8, 9);
            this.labelClientFullName.Name = "labelClientFullName";
            this.labelClientFullName.Size = new System.Drawing.Size(78, 13);
            this.labelClientFullName.TabIndex = 1;
            this.labelClientFullName.Text = "ФИО клиента";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewService);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Услуги";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewService
            // 
            this.dataGridViewService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewService.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewService.Name = "dataGridViewService";
            this.dataGridViewService.ReadOnly = true;
            this.dataGridViewService.Size = new System.Drawing.Size(776, 318);
            this.dataGridViewService.TabIndex = 1;
            // 
            // contextMenuStripDataGrid
            // 
            this.contextMenuStripDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStripDataGrid.Name = "contextMenuStripDataGrid";
            this.contextMenuStripDataGrid.Size = new System.Drawing.Size(155, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addToolStripMenuItem.Text = "Добавить";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editToolStripMenuItem.Text = "Редактировать";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removeToolStripMenuItem.Text = "Удалить";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.mainMenuStrip.TabIndex = 57;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.editToolStripMenuItem1,
            this.removeToolStripMenuItem1,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.operationToolStripMenuItem.Text = "Операции";
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.addToolStripMenuItem1.Text = "Добавление";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem1.Text = "Редактирование";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.removeToolStripMenuItem1.Text = "Удаление";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordToolStripMenuItem,
            this.excelToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.reportToolStripMenuItem.Text = "Отчет";
            // 
            // wordToolStripMenuItem
            // 
            this.wordToolStripMenuItem.Name = "wordToolStripMenuItem";
            this.wordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wordToolStripMenuItem.Text = "Word";
            this.wordToolStripMenuItem.Click += new System.EventHandler(this.wordToolStripMenuItem_Click);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helperToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutProgramToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.aboutToolStripMenuItem.Text = "Спра&вка";
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutProgramToolStripMenuItem.Text = "&О программе...";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem_Click);
            // 
            // buttonResetAccountingFilter
            // 
            this.buttonResetAccountingFilter.Location = new System.Drawing.Point(706, 6);
            this.buttonResetAccountingFilter.Name = "buttonResetAccountingFilter";
            this.buttonResetAccountingFilter.Size = new System.Drawing.Size(76, 21);
            this.buttonResetAccountingFilter.TabIndex = 16;
            this.buttonResetAccountingFilter.Text = "Сбросить";
            this.buttonResetAccountingFilter.UseVisualStyleBackColor = true;
            this.buttonResetAccountingFilter.Click += new System.EventHandler(this.buttonResetAccountingFilter_Click);
            // 
            // checkBoxFilterDate
            // 
            this.checkBoxFilterDate.AutoSize = true;
            this.checkBoxFilterDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxFilterDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFilterDate.Location = new System.Drawing.Point(612, 34);
            this.checkBoxFilterDate.Name = "checkBoxFilterDate";
            this.checkBoxFilterDate.Size = new System.Drawing.Size(87, 17);
            this.checkBoxFilterDate.TabIndex = 17;
            this.checkBoxFilterDate.Text = "Учесть дату";
            this.checkBoxFilterDate.UseVisualStyleBackColor = true;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // helperToolStripMenuItem
            // 
            this.helperToolStripMenuItem.Name = "helperToolStripMenuItem";
            this.helperToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.helperToolStripMenuItem.Text = "Помощь";
            this.helperToolStripMenuItem.Click += new System.EventHandler(this.helperToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.tabControl);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет школьных услуг";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounting)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).EndInit();
            this.contextMenuStripDataGrid.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAccounting;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataGrid;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewService;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.TextBox textBoxPriceTo;
        private System.Windows.Forms.Label labelPriceTo;
        private System.Windows.Forms.TextBox textBoxPriceFrom;
        private System.Windows.Forms.Label labelPriceFrom;
        private System.Windows.Forms.TextBox textBoxClientFullName;
        private System.Windows.Forms.Label labelClientFullName;
        private System.Windows.Forms.Button buttonApplyAccountingFilter;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateTo;
        private System.Windows.Forms.Label labelDateFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateFrom;
        private System.Windows.Forms.Label labelServiceName;
        private System.Windows.Forms.ComboBox comboBoxServiceName;
        private System.Windows.Forms.Label labelTypeClient;
        private System.Windows.Forms.ComboBox comboBoxTypeClient;
        private System.Windows.Forms.Button buttonResetAccountingFilter;
        private System.Windows.Forms.CheckBox checkBoxFilterDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helperToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

