using System;
using System.Drawing;
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
        private TypeOfTransaction _typeOfTransaction;

        public OperationForm(int selectedTabControl, TypeOfTransaction typeOfTransaction, object classObject = null)
        {
            InitializeComponent();

            _typeOfTransaction = typeOfTransaction;
            Text = typeOfTransaction + (selectedTabControl == 0 ? " записи учета" : " услуги");

            switch (selectedTabControl)
            {
                case 0:
                    groupBoxAccounting.Visible = true;
                    LoadFieldsAccounting(classObject);
                    break;
                case 1:
                    groupBoxService.Visible = true;
                    LoadFieldsService(classObject);
                    break;
            }
        }

        private void LoadFieldsAccounting(object classObject)
        {
            groupBoxService.Location = new Point(500, 500);
            groupBoxAccounting.Location = new Point(12, 12);
            Width = 465;
            Height = 275;

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

            if (classObject == null)
            {
                return;
            }

            buttonAccountingCommit.Text = "Изменить";

            _accounting = (Accounting)classObject;
            comboBoxService.Text = _accounting.Service.Name;
            comboBoxClient.Text = _accounting.Client.FullName;
            textBoxClientFullName.Text = _accounting.Client.FullName;
            comboBoxTypeClient.Text = _accounting.Client.TypeClient.ToString();
            dateTimePickerAccounting.Value = _accounting.Date;
        }

        private void LoadFieldsService(object classObject)
        {
            Width = 525;
            Height = 365;

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
                e.Handled = true;
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
                    Client currentClient;
                    if (comboBoxClient.SelectedIndex != 0)
                    {
                        currentClient = db.Clients.First(x => x.FullName == comboBoxClient.Text);
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
                        db.Accountings.Add(new Accounting
                        {
                            Client = db.Clients.First(x => x.FullName == textBoxClientFullName.Text),
                            ClientId = db.Clients.First(x => x.FullName == textBoxClientFullName.Text).Id,
                            Date = dateTimePickerAccounting.Value,
                            Service = db.Services.First(x => x.Name == comboBoxService.Text),
                            ServiceId = db.Services.First(x => x.Name == comboBoxService.Text).Id
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
                    }

                    db.SaveChanges();

                    MessageBox.Show("Действие успешно выполнено.");
                }
            }
        }

        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_typeOfTransaction != TypeOfTransaction.Редактирование)
            {
                return;
            }

            var db = new ModelsContext();
            try
            {
                labelWarningAccess.Text =
                    "Доступно для: " + db.Services.First(x => x.Name == comboBoxService.Text).Access;
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
