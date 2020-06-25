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
    public partial class ProgramProduct : Form
    {
        public ProgramProduct()
        {
            InitializeComponent();
            ShowProgramProduct();
        }

        void ShowProgramProduct()
        {
            listViewProgramProduct.Items.Clear();
            foreach (ProgramProductSet programProduct in Program.entities1c.ProgramProductSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    programProduct.Name,
                    programProduct.Descriptoin, programProduct.Price.ToString()
                });
                item.Tag = programProduct;
                listViewProgramProduct.Items.Add(item);

            }
            listViewProgramProduct.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ProgramProduct_Load(object sender, EventArgs e)
        {

        }

        private void listViewProgramProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listViewProgramProduct.SelectedItems.Count == 1)
            {
                ProgramProductSet programProduct = listViewProgramProduct.SelectedItems[0].Tag as ProgramProductSet;
                textBoxName.Text = programProduct.Name;
                textBoxDescription.Text = programProduct.Descriptoin;
                textBoxPrice.Text = programProduct.Price.ToString();

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
            ProgramProductSet programProduct = new ProgramProductSet();
            programProduct.Name = textBoxName.Text;
            programProduct.Descriptoin = textBoxDescription.Text;
            programProduct.Price = Convert.ToInt32(textBoxPrice.Text);
            Program.entities1c.ProgramProductSet.Add(programProduct);
            Program.entities1c.SaveChanges();
            ShowProgramProduct();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewProgramProduct.SelectedItems.Count == 1)
            {
                ProgramProductSet programProduct = listViewProgramProduct.SelectedItems[0].Tag as ProgramProductSet;
                programProduct.Name = textBoxName.Text;
                programProduct.Descriptoin = textBoxDescription.Text;
                programProduct.Price = Convert.ToInt32(textBoxPrice.Text);
                Program.entities1c.SaveChanges();
                ShowProgramProduct();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewProgramProduct.SelectedItems.Count == 1)
                {
                    ProgramProductSet programProduct = listViewProgramProduct.SelectedItems[0].Tag as ProgramProductSet;
                    Program.entities1c.ProgramProductSet.Remove(programProduct);
                    Program.entities1c.SaveChanges();
                    ShowProgramProduct();
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
