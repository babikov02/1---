using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1С_Франчайзи_Вятка
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            ShowClient();
        }

        void ShowClient()
        {
            listViewClient.Items.Clear();
            foreach (ClientSet clientSet in Program.entities1c.ClientSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    clientSet.Id.ToString(), clientSet.INN, clientSet.Name,
                    clientSet.Adress, clientSet.Email, clientSet.Phone, clientSet.ContactPerson
                });
                item.Tag = clientSet;
                listViewClient.Items.Add(item);

            }
            listViewClient.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                ClientSet clientSet = listViewClient.SelectedItems[0].Tag as ClientSet;
                textBoxINN.Text = clientSet.INN;
                textBoxName.Text = clientSet.Name;
                textBoxAddress.Text = clientSet.Adress;
                textBoxEmail.Text = clientSet.Email;
                textBoxPhone.Text = clientSet.Phone;
                textBoxContactPerson.Text = clientSet.ContactPerson;
            }
            else
            {
                textBoxINN.Text = "";
                textBoxName.Text = "";
                textBoxAddress.Text = "";
                textBoxEmail.Text = "";
                textBoxPhone.Text = "";
                textBoxContactPerson.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ClientSet clientSet = new ClientSet();
            clientSet.INN = textBoxINN.Text;
            clientSet.Name = textBoxName.Text;
            clientSet.Adress = textBoxAddress.Text;
            clientSet.Email = textBoxEmail.Text;
            clientSet.Phone = textBoxPhone.Text;
            clientSet.ContactPerson = textBoxContactPerson.Text;
            Program.entities1c.ClientSet.Add(clientSet);
            Program.entities1c.SaveChanges();
            ShowClient();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                ClientSet clientSet = listViewClient.SelectedItems[0].Tag as ClientSet;
                clientSet.INN = textBoxINN.Text;
                clientSet.Name = textBoxName.Text;
                clientSet.Adress = textBoxAddress.Text;
                clientSet.Email = textBoxEmail.Text;
                clientSet.Phone = textBoxPhone.Text;
                clientSet.ContactPerson = textBoxContactPerson.Text;
                Program.entities1c.SaveChanges();
                ShowClient();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewClient.SelectedItems.Count == 1)
                {
                    ClientSet clientSet = listViewClient.SelectedItems[0].Tag as ClientSet;
                    Program.entities1c.ClientSet.Remove(clientSet);
                    Program.entities1c.SaveChanges();
                    ShowClient();
                }
                textBoxINN.Text = "";
                textBoxName.Text = "";
                textBoxAddress.Text = "";
                textBoxEmail.Text = "";
                textBoxPhone.Text = "";
                textBoxContactPerson.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxINN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
