using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1С_Франчайзи_Вятка
{
    public partial class DealPP : Form
    {
        public DealPP()
        {
            InitializeComponent();
            ShowAgent();
            ShowClient();
            ShowPP();
            ShowDealPP();
        }

        void ShowDealPP()
        {

            listViewDealPP.Items.Clear();
            foreach (DealSetPP dealSet in Program.entities1c.DealSetPP)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    dealSet.Id.ToString(), dealSet.AgentSet.Id + ". " + dealSet.AgentSet.LastName + dealSet.AgentSet.Name, dealSet.ClientSet.Id.ToString() + ". " + dealSet.ClientSet.Name,
                    dealSet.ProgramProductSet.Id.ToString() + ". " + dealSet.ProgramProductSet.Name, dealSet.Amount.ToString(), dealSet.TotalPrice.ToString()
                });
                item.Tag = dealSet;
                listViewDealPP.Items.Add(item);
            }
        }

        void ShowPP()
        {
            comboBoxPP.Items.Clear();
            foreach (ProgramProductSet programProduct in Program.entities1c.ProgramProductSet)
            {
                string[] item = { programProduct.Id.ToString() + ". " + programProduct.Name };
                comboBoxPP.Items.Add(string.Join(" ", item));
            }
        }

        void ShowAgent()
        {
            comboBoxAgent.Items.Clear();
            foreach (AgentSet agent in Program.entities1c.AgentSet)
            {
                string[] item = {agent.Id.ToString() + ". ", agent.Name, agent.MiddleName,
                agent.LastName};
                comboBoxAgent.Items.Add(string.Join(" ", item));
            }
        }

        void ShowClient()
        {
            comboBoxClient.Items.Clear();
            foreach (ClientSet client in Program.entities1c.ClientSet)
            {
                string[] item = { client.Id.ToString() + ". ", client.Name };
                comboBoxClient.Items.Add(string.Join(" ", item));
            }
        }

        private void DealPP_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBoxAgent.SelectedItem != null && comboBoxClient.SelectedItem != null && comboBoxPP.SelectedItem != null && textBoxAmount.Text.Length > 0)
            {

                ProgramProductSet programProduct
                    = Program.entities1c.ProgramProductSet.Find(Convert.ToInt32(comboBoxPP.SelectedItem.ToString().Split('.')[0]));
                int a = Convert.ToInt32(textBoxAmount.Text);
                int totalprice = programProduct.Price * a;
                textBoxTotalPrice.Text = totalprice.ToString();
            }
            else
            {
                textBoxTotalPrice.Text = "";
            }
        }

        private void listViewDealPP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDealPP.SelectedItems.Count == 1)
            {
                DealSetPP dealSet = listViewDealPP.SelectedItems[0].Tag as DealSetPP;
                comboBoxAgent.SelectedIndex = comboBoxAgent.FindString(dealSet.IdAgent.ToString());
                comboBoxClient.SelectedIndex = comboBoxClient.FindString(dealSet.IdClient.ToString());
                comboBoxPP.SelectedIndex = comboBoxPP.FindString(dealSet.IdProgramProduct.ToString());
                textBoxAmount.Text = dealSet.Amount.ToString();
                textBoxTotalPrice.Text = dealSet.TotalPrice.ToString();

            }
            else
            {
                comboBoxAgent.SelectedItem = null;
                comboBoxClient.SelectedItem = null;
                comboBoxPP.SelectedItem = null;
                textBoxAmount.Text = "";
                textBoxTotalPrice.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxAgent.SelectedItem != null && comboBoxClient.SelectedItem != null && comboBoxPP.SelectedItem != null && textBoxAmount.Text.Length > 0 && textBoxTotalPrice.Text.Length > 0)
            {
                DealSetPP dealSet = new DealSetPP();

                dealSet.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                dealSet.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                dealSet.IdProgramProduct = Convert.ToInt32(comboBoxPP.SelectedItem.ToString().Split('.')[0]);
                dealSet.Amount = Convert.ToInt32(textBoxAmount.Text);
                dealSet.TotalPrice = Convert.ToInt32(textBoxTotalPrice.Text);
                Program.entities1c.DealSetPP.Add(dealSet);
                Program.entities1c.SaveChanges();
                ShowDealPP();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewDealPP.SelectedItems.Count == 1)
            {
                DealSetPP dealSet = listViewDealPP.SelectedItems[0].Tag as DealSetPP;

                dealSet.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                dealSet.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                dealSet.IdProgramProduct = Convert.ToInt32(comboBoxPP.SelectedItem.ToString().Split('.')[0]);
                dealSet.Amount = Convert.ToInt32(textBoxAmount.Text);
                dealSet.TotalPrice = Convert.ToInt32(textBoxTotalPrice.Text);
                Program.entities1c.SaveChanges();
                ShowDealPP();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDealPP.SelectedItems.Count == 1)
                {
                    DealSetPP dealSet = listViewDealPP.SelectedItems[0].Tag as DealSetPP;
                    Program.entities1c.DealSetPP.Remove(dealSet);
                    Program.entities1c.SaveChanges();
                    ShowDealPP();
                }
                comboBoxAgent.SelectedItem = null;
                comboBoxClient.SelectedItem = null;
                comboBoxPP.SelectedItem = null;
                textBoxAmount.Text = "";
                textBoxTotalPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
