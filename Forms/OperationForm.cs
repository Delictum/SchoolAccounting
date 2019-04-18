using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchoolAccounting.Models;
using SchoolAccounting.Util;

namespace SchoolAccounting.Forms
{
    public partial class OperationForm : Form
    {
        private Service _service;
        private Accounting _accounting;
        private readonly TypeOfTransaction _typeOfTransaction;
        private byte[] _fileData;
        private string _fileName = null;

        public OperationForm(int selectedTabControl, TypeOfTransaction typeOfTransaction, object classObject = null)
        {
            InitializeComponent();

            _typeOfTransaction = typeOfTransaction;
            Text = typeOfTransaction + (selectedTabControl == 0 ? " записи учета" : " услуги");

            switch (selectedTabControl)
            {
                case 0:
                    groupBoxAccounting.Visible = true;
                    if (_typeOfTransaction == TypeOfTransaction.Редактирование)
                    {
                        groupBoxAttacments.Enabled = true;
                    }
                    LoadFieldsAccounting(classObject);
                    break;
                case 1:
                    groupBoxService.Visible = true;
                    LoadFieldsService(classObject);
                    break;
            }
        }

        private void LoadAttachments(Accounting accounting)
        {
            dataGridViewAttachments.Rows.Clear();
            dataGridViewAttachments.Columns.Clear();

            for (var x = 0; x < 4; x++)
            {
                var column = new DataGridViewTextBoxColumn();
                dataGridViewAttachments.Columns.Add(column);
            }

            double amountCost = 0;
            if (accounting != null)
            {
                using (var db = new ModelsContext())
                {
                    var list = db.Attachments.Where(x => x.PaymentId == accounting.PaymentId).ToList();

                    foreach (var attachment in list)
                    {
                        dataGridViewAttachments.Rows.Add(attachment.Id, attachment.MadeBy,
                            attachment.FileName, (attachment.File != null ? "+" : string.Empty));
                        amountCost += attachment.MadeBy;
                    }
                }
            }

            if (accounting != null && amountCost > accounting.Service.Price)
            {
                labelWarningErrorMessage.Text = "Возможно допущена ошибка в подсчетах.";
                labelWarningAmountCost.Text = string.Join(string.Empty, "Стоимость услуги ", accounting.Service.Price, "р., внесено ", amountCost, "р.");
            }

            if (accounting != null && amountCost >= accounting.Service.Price)
            {
                using (var db = new ModelsContext())
                {
                    var payment = db.Payments.First(x => x.Id == accounting.PaymentId);
                    payment.Paid = true;
                    db.SaveChanges();
                }
            }

            dataGridViewAttachments.Columns[0].Visible = false;

            dataGridViewAttachments.Columns[1].Width = 120;
            dataGridViewAttachments.Columns[1].HeaderText = "Внесено";

            dataGridViewAttachments.Columns[2].Width = 200;
            dataGridViewAttachments.Columns[2].HeaderText = "Файл";

            dataGridViewAttachments.Columns[3].Width = 70;
            dataGridViewAttachments.Columns[3].HeaderText = "Скачать";
        }

        private void LoadFieldsAccounting(object classObject)
        {
            groupBoxService.Location = new Point(1000, 500);
            groupBoxAccounting.Location = new Point(12, 12);
            Width = 920;
            Height = 375;

            comboBoxTypeClient.DataSource = Enum.GetValues(typeof(TypeClient))
                .Cast<TypeClient>()
                .Select(p => new { Name = Enum.GetName(typeof(TypeClient), p), Value = (int)p })
                .ToList();

            comboBoxTypeClient.DisplayMember = "Name";
            comboBoxTypeClient.ValueMember = "Name";

            dateTimePickerAccounting.Value = DateTime.Now;

            using (var db = new ModelsContext())
            {
                var listClients = db.Clients.ToList();
                listClients.Insert(0, new Client {Id = 0, FullName = "Новый клиент" });

                comboBoxClient.DataSource = listClients;
                comboBoxClient.DisplayMember = "FullName";
                comboBoxClient.ValueMember = "Id";

                comboBoxService.DataSource = db.Services.ToList();
                comboBoxService.DisplayMember = "Name";
                comboBoxService.ValueMember = "Id";
            }

            buttonAccountingCommit.Text = "Создать";

            LoadAttachments(null);
            if (classObject == null)
            {
                return;
            }

            buttonAccountingCommit.Text = "Изменить";

            _accounting = (Accounting)classObject;
            LoadAttachments(_accounting);
            comboBoxService.Text = _accounting.Service.Name;
            comboBoxClient.Text = _accounting.Client.FullName;
            textBoxClientFullName.Text = _accounting.Client.FullName;
            comboBoxTypeClient.Text = _accounting.Client.TypeClient.ToString();
            dateTimePickerAccounting.Value = _accounting.Date;

            using (var db = new ModelsContext())
            {
                var payment = db.Payments.First(x => x.Id == _accounting.PaymentId);
                textBoxComment.Text = payment.Comment ?? string.Empty;
                checkBoxPaid.Checked = payment.Paid;

                //if (payment.File == null)
                //{
                //    return;
                //}

                //var mStream = new MemoryStream();
                //mStream.Write(payment.File, 0, Convert.ToInt32(payment.File.Length));
                //var bm = new Bitmap(mStream, false);
                //pictureBoxFile.Image = bm;
                //mStream.Dispose();
            }
        }

        private void LoadFieldsService(object classObject)
        {
            Width = 525;
            Height = 400;

            comboBoxTypeOfService.DataSource = Enum.GetValues(typeof(TypeOfService))
                .Cast<TypeOfService>()
                .Select(p => new {Name = Enum.GetName(typeof(TypeOfService), p), Value = (int) p})
                .ToList();

            comboBoxTypeOfService.DisplayMember = "Name";
            comboBoxTypeOfService.ValueMember = "Name";

            buttonServiceCommit.Text = "Создать";

            if (classObject == null)
            {
                return;
            }

            buttonServiceCommit.Text = "Изменить";

            _service = (Service) classObject;
            textBoxServiceName.Text = _service.Name;
            textBoxServicePrice.Text = _service.Price.ToString();
            comboBoxTypeOfService.Text = _service.TypeOfService.ToString();
            richTextBoxServiceDescription.Text = _service.Description;

            if (_service.Access.Contains("Взрослый;Дошкольник;Младшешкольник;Среднешкольник;Старшешкольник;"))
            {
                checkBoxAll.Checked = true;
                return;
            }

            if (_service.Access.Contains("Взрослый"))
            {
                checkBoxAdult.Checked = true;
            }

            if (_service.Access.Contains("Дошкольник"))
            {
                checkBoxPreschooler.Checked = true;
            }

            if (_service.Access.Contains("Младшешкольник"))
            {
                checkBoxJuniorSchool.Checked = true;
            }

            if (_service.Access.Contains("Среднешкольник"))
            {
                checkBoxSecondarySchool.Checked = true;
            }

            if (_service.Access.Contains("Старшешкольник"))
            {
                checkBoxOldSchool.Checked = true;
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 44 && !string.IsNullOrEmpty(textBoxServicePrice.Text) && !textBoxServicePrice.Text.Contains(','))
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar != 8 && textBoxServicePrice.Text.Contains(',') && (textBoxServicePrice.Text.Length - 3 == textBoxServicePrice.Text.IndexOf(',')))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void buttonServiceCommit_Click(object sender, EventArgs e)
        {
            if (!ValidateServiceFields())
            {
                return;
            }

            if (textBoxServicePrice.Text.Contains(','))
            {
                for (var i = 0; i < 2; i++)
                {
                    if (textBoxServicePrice.Text.Length - 1 != textBoxServicePrice.Text.IndexOf(',') + 2)
                    {
                        textBoxServicePrice.Text += "0";
                    }
                }
            }
            else
            {
                textBoxServicePrice.Text += ",00";
            }

            if (MessageBox.Show("Действительно выполнить действие?",
                    "Подтвердите действие", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var accessString = new StringBuilder();

                if (checkBoxAll.Checked)
                {
                    accessString.Append("Взрослый;Дошкольник;Младшешкольник;Среднешкольник;Старшешкольник;");
                }
                else
                {
                    if (checkBoxAdult.Checked)
                    {
                        accessString.Append("Взрослый;");
                    }
                    if (checkBoxPreschooler.Checked)
                    {
                        accessString.Append("Дошкольник;");
                    }
                    if (checkBoxJuniorSchool.Checked)
                    {
                        accessString.Append("Младшешкольник;");
                    }
                    if (checkBoxSecondarySchool.Checked)
                    {
                        accessString.Append("Среднешкольник;");
                    }
                    if (checkBoxOldSchool.Checked)
                    {
                        accessString.Append("Старшешкольник;");
                    }
                }

                using (var db = new ModelsContext())
                {
                    if (buttonServiceCommit.Text.Contains("Создать"))
                    {
                        db.Services.Add(new Service
                        {
                            Name = textBoxServiceName.Text,
                            Description = (string.IsNullOrEmpty(richTextBoxServiceDescription.Text) ? "" : richTextBoxServiceDescription.Text),
                            Price = double.Parse(textBoxServicePrice.Text),
                            TypeOfService = (TypeOfService)Enum.Parse(typeof(TypeOfService), comboBoxTypeOfService.Text),
                            Access = accessString.ToString()
                        });
                    }
                    else
                    {
                        var editedService = db.Services.FirstOrDefault(x => x.Id == _service.Id);
                        if (editedService == null)
                        {
                            MessageBox.Show("Изменение невозможно в силу непредвиденных обстоятельств.");
                        }

                        editedService.Name = textBoxServiceName.Text;
                        editedService.Description = (string.IsNullOrEmpty(richTextBoxServiceDescription.Text)
                            ? ""
                            : richTextBoxServiceDescription.Text);
                        editedService.Price = double.Parse(textBoxServicePrice.Text);
                        editedService.TypeOfService =
                            (TypeOfService) Enum.Parse(typeof(TypeOfService), comboBoxTypeOfService.Text);
                        editedService.Access = accessString.ToString();
                    }
                    
                    db.SaveChanges();

                    MessageBox.Show("Действие успешно выполнено.");
                }
            }
        }

        private bool ValidateServiceFields()
        {
            var messages = new StringBuilder();
            var validate = true;

            if (string.IsNullOrEmpty(textBoxServiceName.Text))
            {
                messages.Append("Не заполнено название услуги. ");
                validate = false;
            }

            if (string.IsNullOrEmpty(textBoxServicePrice.Text))
            {
                messages.Append("Не заполнена цена. ");
                validate = false;
            }

            if (string.IsNullOrEmpty(comboBoxTypeOfService.Text))
            {
                messages.Append("Не выбран тип услуги. ");
                validate = false;
            }

            if (checkBoxPreschooler.Checked == false && checkBoxAdult.Checked == false &&
                checkBoxAll.Checked == false && checkBoxJuniorSchool.Checked == false &&
                checkBoxOldSchool.Checked == false && checkBoxSecondarySchool.Checked == false)
            {
                messages.Append("Не выбрана доступность к услуге. ");
            }

            if (validate)
            {
                return true;
            }

            MessageBox.Show(messages.ToString());
            return false;

        }

        private bool ValidateAccountingFields()
        {
            var messages = new StringBuilder();
            var validate = true;

            if (string.IsNullOrEmpty(textBoxClientFullName.Text))
            {
                messages.Append("Не заполнено ФИО клиента. ");
                validate = false;
            }

            if (!labelWarningAccess.Text.Contains(comboBoxTypeClient.Text))
            {
                messages.Append("Данная услуга не доступна для этого типа клиента. ");
                validate = false;
            }

            if (validate)
            {
                return true;
            }

            MessageBox.Show(messages.ToString());
            return false;

        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAll.Checked)
            {
                checkBoxAdult.Checked = false;
                checkBoxJuniorSchool.Checked = false;
                checkBoxOldSchool.Checked = false;
                checkBoxPreschooler.Checked = false;
                checkBoxSecondarySchool.Checked = false;

                return;
            }

            checkBoxAdult.Checked = true;
            checkBoxJuniorSchool.Checked = true;
            checkBoxOldSchool.Checked = true;
            checkBoxPreschooler.Checked = true;
            checkBoxSecondarySchool.Checked = true;
        }

        private void comboBoxTypeOfService_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char) Keys.None;
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClient.SelectedIndex != 0)
            {
                textBoxClientFullName.Text = comboBoxClient.Text;
                using (var db = new ModelsContext())
                {
                    comboBoxTypeClient.Text = db.Clients.First(x => x.FullName == comboBoxClient.Text).TypeClient.ToString();
                }
            }
        }

        private void buttonAccountingCommit_Click(object sender, EventArgs e)
        {
            if (!ValidateAccountingFields())
            {
                return;
            }

            if (MessageBox.Show("Действительно выполнить действие?",
                    "Подтвердите действие", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (var db = new ModelsContext())
                {
                    if (comboBoxClient.SelectedIndex != 0)
                    {
                        var currentClient = db.Clients.First(x => x.FullName == comboBoxClient.Text);
                        currentClient.FullName = textBoxClientFullName.Text;
                        currentClient.TypeClient =
                            (TypeClient) Enum.Parse(typeof(TypeClient), comboBoxTypeClient.Text);
                    }
                    else
                    {
                        db.Clients.Add(new Client
                        {
                            FullName = textBoxClientFullName.Text,
                            TypeClient = (TypeClient)Enum.Parse(typeof(TypeClient), comboBoxTypeClient.Text)
                        });
                    }

                    db.SaveChanges();

                    if (buttonAccountingCommit.Text.Contains("Создать"))
                    {
                        var payment = new Payment
                        {
                            Comment = textBoxComment.Text,
                            Paid = checkBoxPaid.Checked,
                            //File = _fileData
                        };
                        db.Payments.Add(payment);
                        db.SaveChanges();

                        db.Accountings.Add(new Accounting
                        {
                            Client = db.Clients.First(x => x.FullName == textBoxClientFullName.Text),
                            ClientId = db.Clients.First(x => x.FullName == textBoxClientFullName.Text).Id,
                            Date = dateTimePickerAccounting.Value,
                            Service = db.Services.First(x => x.Name == comboBoxService.Text),
                            ServiceId = db.Services.First(x => x.Name == comboBoxService.Text).Id,
                            PaymentId = payment.Id
                        });
                    }
                    else
                    {
                        var editedAccounting = db.Accountings.FirstOrDefault(x => x.Id == _accounting.Id);
                        if (editedAccounting == null)
                        {
                            MessageBox.Show("Изменение невозможно в силу непредвиденных обстоятельств.");
                        }

                        editedAccounting.Service = db.Services.First(x => x.Name == comboBoxService.Text);
                        editedAccounting.ServiceId = db.Services.First(x => x.Name == comboBoxService.Text).Id;
                        editedAccounting.Client = db.Clients.First(x => x.FullName == textBoxClientFullName.Text);
                        editedAccounting.ClientId = db.Clients.First(x => x.FullName == textBoxClientFullName.Text).Id;
                        editedAccounting.Date = dateTimePickerAccounting.Value;

                        var payment = db.Payments.First(x => x.Id == _accounting.PaymentId);
                        payment.Comment = textBoxComment.Text;
                        payment.Paid = checkBoxPaid.Checked;
                        //payment.File = _fileData;
                    }

                    db.SaveChanges();

                    MessageBox.Show("Действие успешно выполнено.");
                }
            }
        }

        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new ModelsContext())
            {
                labelWarningAccess.Text =
                    "Доступно для: " + db.Services.First(x => x.Name == comboBoxService.Text).Access;
            }
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                using (var file = File.OpenRead(ofd.FileName))
                {
                    using (var binaryReader = new BinaryReader(file))
                    {
                        _fileData = binaryReader.ReadBytes((int)file.Length);
                    }
                }

                if (ofd.SafeFileName != null && (ofd.SafeFileName.Contains(".jpg") ||
                                                 ofd.SafeFileName.Contains(".jpeg") ||
                                                 ofd.SafeFileName.Contains(".png") ||
                                                 ofd.SafeFileName.Contains(".bmp")))
                {
                    pictureBoxFile.Image = Image.FromFile(ofd.FileName);
                }
                else
                {
                    labelFileName.Text = ofd.SafeFileName;
                }

                _fileName = ofd.SafeFileName;
            }
        }

        private void buttonUnloadFile_Click(object sender, EventArgs e)
        {
            _fileData = null;
            pictureBoxFile.Image = null;
            labelFileName.Text = null;
        }

        private void textBoxMadeBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 44 && !string.IsNullOrEmpty(textBoxMadeBy.Text) && !textBoxMadeBy.Text.Contains(','))
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar != 8 && textBoxMadeBy.Text.Contains(',') && (textBoxMadeBy.Text.Length - 3 == textBoxMadeBy.Text.IndexOf(',')))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private bool ValidateMadeBy()
        {
            if (string.IsNullOrEmpty(textBoxMadeBy.Text))
            {
                MessageBox.Show("Заполните внесенную оплату.");
                return false;
            }

            if (textBoxMadeBy.Text.Contains(','))
            {
                for (var i = 0; i < 2; i++)
                {
                    if (textBoxMadeBy.Text.Length - 1 != textBoxMadeBy.Text.IndexOf(',') + 2)
                    {
                        textBoxMadeBy.Text += "0";
                    }
                }
            }
            else
            {
                textBoxMadeBy.Text += ",00";
            }

            return true;
        }

        private void buttonAddAttachment_Click(object sender, EventArgs e)
        {
            if (!ValidateMadeBy())
            {
                return;
            }

            var fileMsg = (_fileData != null ? string.Empty : "(файл не добавлен)");
            if (MessageBox.Show(string.Join(string.Empty, "Действительно добавить", fileMsg, "?"),
                    "Подтвердите действие", MessageBoxButtons.OKCancel) == DialogResult.OK)
            { 
                using (var db = new ModelsContext())
                {
                    var attachment = new Attachment
                    {
                        MadeBy = double.Parse(textBoxMadeBy.Text),
                        PaymentId = _accounting.PaymentId
                    };

                    if (_fileData != null)
                    {
                        attachment.FileName = _fileName;
                        attachment.File = _fileData;
                    }

                    db.Attachments.Add(attachment);
                    db.SaveChanges();

                    LoadAttachments(_accounting);
                }
            }
        }

        private void dataGridViewAttachments_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var j = e.RowIndex;

            try
            {
                textBoxMadeBy.Text = dataGridViewAttachments[1, j].Value.ToString();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if (dataGridViewAttachments.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("Не выбрана запись.");
                return;
            }

            var id = Convert.ToInt32(dataGridViewAttachments.CurrentRow.Cells[0].Value.ToString());
            using (var db = new ModelsContext())
            {
                var attachment = db.Attachments.First(x => x.Id == id);
                var tempName = Path.Combine(Path.GetTempPath() + attachment.FileName);
                if (attachment.File != null)
                {
                    File.WriteAllBytes(tempName, attachment.File);
                    Process.Start(tempName);
                    return;
                }

                MessageBox.Show("Вложение не содержится.");
            }
            
        }

        private void dataGridViewAttachments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var j = e.RowIndex;

                if (dataGridViewAttachments[3, j].Value.ToString() != "+")
                {
                    return;
                }

                var id = Convert.ToInt32(dataGridViewAttachments.CurrentRow.Cells[0].Value.ToString());
                using (var db = new ModelsContext())
                {
                    var attachment = db.Attachments.First(x => x.Id == id);
                    var tempName = Path.Combine(Path.GetTempPath() + attachment.FileName);
                    if (attachment.File != null)
                    {
                        File.WriteAllBytes(tempName, attachment.File);
                        Process.Start(tempName);
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void buttonEditAttachment_Click(object sender, EventArgs e)
        {
            if (dataGridViewAttachments.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("Не выбрана запись.");
                return;
            }

            if (!ValidateMadeBy())
            {
                return;
            }

            var id = Convert.ToInt32(dataGridViewAttachments.CurrentRow.Cells[0].Value.ToString());
            var fileMsg = (_fileData != null ? string.Empty : "(файл не добавлен)");
            if (MessageBox.Show(string.Join(string.Empty, "Действительно редактировать", fileMsg, "?"),
                    "Подтвердите действие", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (var db = new ModelsContext())
                {
                    var attachment = db.Attachments.First(x => x.Id == id);

                    attachment.MadeBy = double.Parse(textBoxMadeBy.Text);

                    if (attachment.FileName != null && MessageBox.Show("Удалить текущее вложение?",
                            "Подтвердите действие", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        attachment.FileName = null;
                        attachment.File = null;
                    }

                    if (_fileData != null)
                    {
                        attachment.FileName = _fileName;
                        attachment.File = _fileData;
                    }

                    db.SaveChanges();
                    LoadAttachments(_accounting);
                }
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewAttachments.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("Не выбрана запись.");
                return;
            }

            var id = Convert.ToInt32(dataGridViewAttachments.CurrentRow.Cells[0].Value.ToString());
            if (MessageBox.Show("Действительно удалить?",
                    "Подтвердите действие", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (var db = new ModelsContext())
                {
                    var attachment = db.Attachments.First(x => x.Id == id);
                    db.Attachments.Remove(attachment);
                    db.SaveChanges();
                    LoadAttachments(_accounting);
                }
            }
        }
    }
}
