using SchoolAccounting.Forms;
using SchoolAccounting.Models;
using SchoolAccounting.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace SchoolAccounting
{
    public partial class Main : Form
    {
        private const int AmountOfColumns = 6;
        public string Buffer;
        private bool _dataGridViewAccountingSort = true;
        private bool _dataGridViewServiceSort = true;

        public Main()
        {
            InitializeComponent();

            StartInit();
        }

        private void StartInit()
        {
            dataGridViewService.ContextMenuStrip = contextMenuStripDataGrid;
            dataGridViewAccounting.ContextMenuStrip = contextMenuStripDataGrid;

            LoadDataGridViewAccounting();
            LoadDataGridViewService();

            var typeClients = Enum.GetValues(typeof(TypeClient))
                .Cast<TypeClient>()
                .Select(p => new { Name = Enum.GetName(typeof(TypeClient), p), Value = (int)p })
                .ToList();

            typeClients.Insert(0, new { Name = "Все", Value = 0 });

            comboBoxTypeClient.DataSource = typeClients;
            comboBoxTypeClient.DisplayMember = "Name";
            comboBoxTypeClient.ValueMember = "Name";
        }

        private void LoadDataGridViewAccounting(List<Accounting> accountingsList = null)
        {
            dataGridViewAccounting.Rows.Clear();
            dataGridViewAccounting.Columns.Clear();

            for (var x = 0; x < AmountOfColumns; x++)
            {
                var column = new DataGridViewTextBoxColumn();
                dataGridViewAccounting.Columns.Add(column);
            }

            using (var db = new ModelsContext())
            {
                if (accountingsList == null)
                {
                    db.Clients.ToList();
                    db.Services.ToList();

                    foreach (var accounting in db.Accountings)
                    {
                        dataGridViewAccounting.Rows.Add(accounting.Id, accounting.Client.FullName,
                            accounting.Client.TypeClient, accounting.Service.Name, accounting.Service.Price,
                            accounting.Date.ToShortDateString());
                    }
                }
                else
                {
                    foreach (var accounting in accountingsList)
                    {
                        dataGridViewAccounting.Rows.Add(accounting.Id, accounting.Client.FullName,
                            accounting.Client.TypeClient, accounting.Service.Name, accounting.Service.Price,
                            accounting.Date.ToShortDateString());
                    }
                }
            }

            dataGridViewAccounting.Columns[0].Visible = false;

            dataGridViewAccounting.Columns[1].Width = 200;
            dataGridViewAccounting.Columns[1].HeaderText = "ФИО клиента";

            dataGridViewAccounting.Columns[2].Width = 120;
            dataGridViewAccounting.Columns[2].HeaderText = "Тип клиента";

            dataGridViewAccounting.Columns[3].Width = 170;
            dataGridViewAccounting.Columns[3].HeaderText = "Название услуги";

            dataGridViewAccounting.Columns[4].Width = 80;
            dataGridViewAccounting.Columns[4].HeaderText = "Цена услуги";

            dataGridViewAccounting.Columns[5].Width = 120;
            dataGridViewAccounting.Columns[5].HeaderText = "Дата";
        }

        private void LoadDataGridViewService()
        {
            using (var db = new ModelsContext())
            {
                dataGridViewService.DataSource = db.Services.ToList();
            }

            using (var db = new ModelsContext())
            {
                var services = db.Services.ToList();

                services.Insert(0,
                    new Service
                    {
                        Access = "",
                        Name = "Все",
                        Description = "",
                        Price = 0,
                        TypeOfService = TypeOfService.Аренда
                    });
                comboBoxServiceName.DataSource = services;
                comboBoxServiceName.DisplayMember = "Name";
                comboBoxServiceName.ValueMember = "Id";
            }

            dataGridViewService.Columns[0].Visible = false;

            dataGridViewService.Columns[1].Width = 200;
            dataGridViewService.Columns[1].HeaderText = "Название";

            dataGridViewService.Columns[2].Width = 120;
            dataGridViewService.Columns[2].HeaderText = "Тип";

            dataGridViewService.Columns[3].Width = 70;
            dataGridViewService.Columns[3].HeaderText = "Цена";

            dataGridViewService.Columns[4].Width = 180;
            dataGridViewService.Columns[4].HeaderText = "Описание";

            dataGridViewService.Columns[5].Width = 220;
            dataGridViewService.Columns[5].HeaderText = "Доступность";
        }

        private void removeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    try
                    {
                        if (MessageBox.Show(
                                string.Format("Действительно удалить запись: {0} - {1} ({2})",
                                    dataGridViewAccounting.CurrentRow.Cells[3].Value,
                                    dataGridViewAccounting.CurrentRow.Cells[1].Value,
                                    dataGridViewAccounting.CurrentRow.Cells[5].Value),
                                "Подтвердите действие", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            using (var db = new ModelsContext())
                            {
                                var currentAccountingId =
                                    Convert.ToInt32(dataGridViewAccounting.CurrentRow.Cells[0].Value.ToString());
                                var currentAccounting = db.Accountings.FirstOrDefault(x => x.Id == currentAccountingId);
                                if (currentAccounting != null)
                                {
                                    db.Accountings.Remove(currentAccounting);
                                    db.SaveChanges();
                                    LoadDataGridViewAccounting();
                                    return;
                                }

                                MessageBox.Show("Удаление невозможно в силу непредвиденных обстоятельств.");
                            }
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Не выбрана запись для удаления.");
                    }

                    break;
                case 1:
                    try
                    {
                        if (MessageBox.Show(
                                string.Format("Действительно удалить запись: {0} - {1} ({2})",
                                    dataGridViewService.CurrentRow.Cells[1].Value,
                                    dataGridViewService.CurrentRow.Cells[3].Value,
                                    dataGridViewService.CurrentRow.Cells[5].Value),
                                "Подтвердите действие", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            using (var db = new ModelsContext())
                            {
                                var currentSeviceId =
                                    Convert.ToInt32(dataGridViewService.CurrentRow.Cells[0].Value.ToString());
                                var currentService = db.Services.FirstOrDefault(x => x.Id == currentSeviceId);

                                var usesAccounting =
                                    db.Accountings.FirstOrDefault(x => x.ServiceId == currentService.Id);
                                if (usesAccounting != null)
                                {
                                    MessageBox.Show("Удаление невозможно. Услуга находится в списке  учета.");
                                    return;
                                }

                                if (currentService != null)
                                {
                                    db.Services.Remove(currentService);
                                    db.SaveChanges();
                                    LoadDataGridViewService();
                                    LoadDataGridViewAccounting();
                                    return;
                                }

                                MessageBox.Show("Удаление невозможно в силу непредвиденных обстоятельств.");
                            }
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Не выбрана запись для удаления.");
                    }

                    break;
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (*.docx)|*.docx";
            sfd.FileName = "export.docx";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    Export_Data_To_Word(dataGridViewAccounting, sfd.FileName);
                    break;
                case 1:
                    Export_Data_To_Word(dataGridViewService, sfd.FileName);
                    break;
            }
        }

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            try
            {
                if (DGV.Rows.Count != 0)
                {
                    int RowCount = DGV.Rows.Count;
                    int ColumnCount = DGV.Columns.Count;
                    Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                    int r = 0;
                    for (int c = 0; c <= ColumnCount - 1; c++)
                        for (r = 0; r <= RowCount - 1; r++)
                            DataArray[r, c] = DGV.Rows[r].Cells[c].Value;

                    Word.Document oDoc = new Word.Document();
                    oDoc.Application.Visible = true;

                    oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                    dynamic oRange = oDoc.Content.Application.Selection.Range;
                    string oTemp = "";
                    for (r = 0; r <= RowCount - 1; r++)
                        for (int c = 0; c <= ColumnCount - 1; c++)
                            oTemp = oTemp + DataArray[r, c] + "\t";

                    oRange.Text = oTemp;
                    object oMissing = Missing.Value;
                    object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                    object ApplyBorders = true;
                    object AutoFit = true;
                    object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                    oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                          Type.Missing, Type.Missing, ref ApplyBorders,
                                          Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);
                    oRange.Select();

                    oDoc.Application.Selection.Tables[1].Select();
                    oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                    oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();
                    oDoc.Application.Selection.InsertRowsAbove(1);
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();

                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                    }

                    oDoc.Application.Selection.Tables[1].Rows[1].Select();
                    oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                    {
                        Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                        headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                        headerRange.Text = tabControl.SelectedTab.Text;
                        headerRange.Font.Size = 16;
                        headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    oDoc.SaveAs(filename, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

                switch (tabControl.SelectedIndex)
                {
                    case 0:
                        for (var i = 0; i < dataGridViewAccounting.Rows.Count; i++)
                        {
                            for (var j = 0; j < dataGridViewAccounting.ColumnCount; j++)
                            {
                                ExcelApp.Cells[i + 1, j + 1] = dataGridViewAccounting.Rows[i].Cells[j].Value;
                            }
                        }

                        break;
                    case 1:
                        for (var i = 0; i < dataGridViewService.Rows.Count; i++)
                        {
                            for (var j = 0; j < dataGridViewService.ColumnCount; j++)
                            {
                                ExcelApp.Cells[i + 1, j + 1] = dataGridViewService.Rows[i].Cells[j].Value;
                            }
                        }

                        break;
                }
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutProgram = new AboutProgram();
            aboutProgram.ShowDialog(this);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var operationForm = new OperationForm(tabControl.SelectedIndex, TypeOfTransaction.Добавление);
            operationForm.ShowDialog(this);

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    LoadDataGridViewAccounting();
                    break;
                case 1:
                    LoadDataGridViewService();
                    LoadDataGridViewAccounting();
                    break;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object classObject = null;
            switch (tabControl.SelectedIndex)
            {
                case 1:
                    try
                    {
                        classObject = new Service
                        {
                            Id = Convert.ToInt32(dataGridViewService.CurrentRow.Cells[0].Value.ToString()),
                            Access = dataGridViewService.CurrentRow.Cells[5].Value.ToString(),
                            Description = dataGridViewService.CurrentRow.Cells[4].Value.ToString(),
                            Price = Convert.ToDouble(dataGridViewService.CurrentRow.Cells[3].Value.ToString()),
                            TypeOfService = (TypeOfService)Enum.Parse(typeof(TypeOfService),
                                dataGridViewService.CurrentRow.Cells[2].Value.ToString()),
                            Name = dataGridViewService.CurrentRow.Cells[1].Value.ToString()
                        };
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Не выбрана запись для редактирования");
                        return;
                    }
                    
                    break;
                case 0:
                    using (var db = new ModelsContext())
                    {
                        try
                        {
                            var currentFullName = dataGridViewAccounting.CurrentRow.Cells[1].Value.ToString();
                            var currentTypeClient = (TypeClient)Enum.Parse(typeof(TypeClient),
                                dataGridViewAccounting.CurrentRow.Cells[2].Value.ToString());

                            var accountingClient = db.Clients.First(x =>
                                x.FullName == currentFullName && x.TypeClient == currentTypeClient);

                            var currentServiceName = dataGridViewAccounting.CurrentRow.Cells[3].Value.ToString();
                            var currentServicePrice = double.Parse(dataGridViewAccounting.CurrentRow.Cells[4].Value.ToString());

                            var accountingService = db.Services.First(x =>
                                x.Name == currentServiceName && x.Price == currentServicePrice);

                            classObject = new Accounting
                            {
                                Id = Convert.ToInt32(dataGridViewAccounting.CurrentRow.Cells[0].Value.ToString()),
                                Client = accountingClient,
                                ClientId = accountingClient.Id,
                                Date = DateTime.Parse(dataGridViewAccounting.CurrentRow.Cells[5].Value.ToString()),
                                Service = accountingService,
                                ServiceId = accountingService.Id
                            };
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Не выбрана запись для редактирования");
                            return;
                        }
                    }

                    break;
            }
        

            var operationForm = new OperationForm(tabControl.SelectedIndex, TypeOfTransaction.Редактирование, classObject);
            operationForm.ShowDialog(this);

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    LoadDataGridViewAccounting();
                    break;
                case 1:
                    LoadDataGridViewService();
                    LoadDataGridViewAccounting();
                    break;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accountingDataSet.Accountings' table. You can move, or remove it, as needed.

        }

        private void dataGridViewAccounting_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_dataGridViewAccountingSort)
            {
                _dataGridViewAccountingSort = false;
                DataGridViewColumn newColumn = dataGridViewAccounting.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = dataGridViewAccounting.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        dataGridViewAccounting.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }

                // Sort the selected column.
                dataGridViewAccounting.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
            }
            else
            {
                foreach (DataGridViewColumn column in dataGridViewAccounting.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    _dataGridViewAccountingSort = true;
                }
            }
        }

        private void buttonApplyAccountingFilter_Click(object sender, EventArgs e)
        {
            List<Accounting> accountingsList = null;

            if (dateTimePickerDateFrom.Value > dateTimePickerDateTo.Value)
            {
                MessageBox.Show("Начальная дата должна быть меньше конечной.");
                return;
            }
            if (double.Parse(textBoxPriceFrom.Text) > double.Parse(textBoxPriceTo.Text))
            {
                MessageBox.Show("Начальная сумма должна быть меньше конечной.");
                return;
            }

            using (var db = new ModelsContext())
            {
                IQueryable<Accounting> dbAccountings = db.Accountings;
                db.Clients.ToList();
                db.Services.ToList();

                CorrectionFilterPrice(textBoxPriceFrom);
                CorrectionFilterPrice(textBoxPriceTo);

                if (!string.IsNullOrEmpty(textBoxClientFullName.Text))
                {
                    dbAccountings = dbAccountings.Where(x => x.Client.FullName.Contains(textBoxClientFullName.Text));
                }

                if (!comboBoxTypeClient.Text.Contains("Все"))
                {
                    var valueTypeClientFilter = (TypeClient) Enum.Parse(typeof(TypeClient),
                        comboBoxTypeClient.Text);
                    dbAccountings = dbAccountings.Where(x => x.Client.TypeClient == valueTypeClientFilter);
                }

                if (!comboBoxServiceName.Text.Contains("Все"))
                {
                    var valueServiceNameFilter = comboBoxServiceName.Text;
                    dbAccountings = dbAccountings.Where(x => x.Service.Name == valueServiceNameFilter);
                }

                if (!string.IsNullOrEmpty(textBoxPriceFrom.Text))
                {
                    var priceFrom = double.Parse(textBoxPriceFrom.Text);
                    dbAccountings = dbAccountings.Where(x => x.Service.Price >= priceFrom);
                }

                if (!string.IsNullOrEmpty(textBoxPriceTo.Text))
                {
                    var priceTo = double.Parse(textBoxPriceTo.Text);
                    dbAccountings = dbAccountings.Where(x => x.Service.Price <= priceTo);
                }

                if (checkBoxFilterDate.Checked)
                {
                    var dateFrom = DateTime.Parse(dateTimePickerDateFrom.Value.ToShortDateString());
                    var dateTo = DateTime.Parse(dateTimePickerDateTo.Value.AddDays(1).ToShortDateString());
                    dbAccountings = dbAccountings.Where(x => x.Date >= dateFrom && x.Date <= dateTo);
                }

                accountingsList = dbAccountings.ToList();
            }

            if (accountingsList.ToList().Count == 0)
            {
                MessageBox.Show("Результаты не надены.");
                return;
            }

            LoadDataGridViewAccounting(accountingsList);
        }

        public void ValidPriceData(TextBox textBox, KeyPressEventArgs e)
        {
            if (e.KeyChar == 44 && !string.IsNullOrEmpty(textBox.Text) && !textBox.Text.Contains(','))
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar != 8 && textBox.Text.Contains(',') && (textBox.Text.Length - 3 == textBox.Text.IndexOf(',')))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void textBoxPriceFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidPriceData(textBoxPriceFrom, e);
        }

        private void textBoxPriceTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidPriceData(textBoxPriceTo, e);
        }

        private void buttonResetAccountingFilter_Click(object sender, EventArgs e)
        {
            comboBoxServiceName.Text = "Все";
            comboBoxTypeClient.Text = "Все";
            textBoxPriceFrom.Text = string.Empty;
            textBoxPriceTo.Text = string.Empty;
            textBoxClientFullName.Text = string.Empty;
            dateTimePickerDateFrom.Value = DateTime.Now;
            dateTimePickerDateTo.Value = DateTime.Now;
            checkBoxFilterDate.Checked = false;

            LoadDataGridViewAccounting();
        }

        private void CorrectionFilterPrice(TextBox textBox)
        {
            if (textBox.Text.Contains(','))
            {
                for (var i = 0; i < 2; i++)
                {
                    if (textBox.Text.Length - 1 != textBox.Text.IndexOf(',') + 2)
                    {
                        textBox.Text += "0";
                    }
                }
            }
            else
            {
                textBox.Text += ",00";
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var pathHelper = Directory.GetParent(workingDirectory).Parent.FullName + "\\Util\\Helper.chm";
            if (File.Exists(pathHelper))
            {
                Process.Start(pathHelper);
            }
            else
            {
                MessageBox.Show("Файл-помощник отсутсвует.");
            }
        }
    }
}
