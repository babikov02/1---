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
    public partial class ITS : Form
    {
        public ITS()
        {
            InitializeComponent();
            ShowITS();
        }

        void ShowITS()
        {
            listViewITS.Items.Clear();
            foreach (ItsSet its in Program.entities1c.ItsSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    its.Name,
                    its.Description, its.Price.ToString()
                });
                item.Tag = its;
                listViewITS.Items.Add(item);

            }
            listViewITS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ITS_Load(object sender, EventArgs e)
        {

        }

        private void listViewITS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewITS.SelectedItems.Count == 1)
            {
                ItsSet its = listViewITS.SelectedItems[0].Tag as ItsSet;
                textBoxName.Text = its.Name;
                textBoxDescription.Text = its.Description;
                textBoxPrice.Text = its.Price.ToString();
                
            }
            else
            {
                textBoxName.Text = "";
                textBoxDescription.Text = "";
                textBoxPrice.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ItsSet its = new ItsSet();
            its.Name = textBoxName.Text;
            its.Description = textBoxDescription.Text;
            its.Price = Convert.ToInt32(textBoxPrice.Text);
            Program.entities1c.ItsSet.Add(its);
            Program.entities1c.SaveChanges();
            ShowITS();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewITS.SelectedItems.Count == 1)
            {
                ItsSet its = listViewITS.SelectedItems[0].Tag as ItsSet;
                its.Name = textBoxName.Text;
                its.Description = textBoxDescription.Text;
                its.Price = Convert.ToInt32(textBoxPrice.Text);
                Program.entities1c.SaveChanges();
                ShowITS();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewITS.SelectedItems.Count == 1)
                {
                    ItsSet its = listViewITS.SelectedItems[0].Tag as ItsSet;
                    Program.entities1c.ItsSet.Remove(its);
                    Program.entities1c.SaveChanges();
                    ShowITS();
                }
                textBoxName.Text = "";
                textBoxDescription.Text = "";
                textBoxPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
