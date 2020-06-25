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
    public partial class DealITS : Form
    {
        public DealITS()
        {
            InitializeComponent();
            ShowAgent();
            ShowClient();
            ShowDealITS();
            ShowITS();
        }

        void ShowITS()
        {
            comboBoxITS.Items.Clear();
            foreach (ItsSet its in Program.entities1c.ItsSet)
            {
                string[] item = { its.Id.ToString() + ". " + its.Name };
                comboBoxITS.Items.Add(string.Join(" ", item));
            }
        }

        void ShowDealITS()
        {
            listViewDealITS.Items.Clear();
            foreach (DealSetITS dealSet in Program.entities1c.DealSetITS)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    dealSet.Id.ToString(), dealSet.AgentSet.Id + ". " + dealSet.AgentSet.LastName + dealSet.AgentSet.Name, dealSet.ClientSet.Id.ToString() + ". " + dealSet.ClientSet.Name,
                    dealSet.ItsSet.Id.ToString() + ". " + dealSet.ItsSet.Name, dealSet.Amount.ToString(), dealSet.TotalPrice.ToString()
                });
                item.Tag = dealSet;
                listViewDealITS.Items.Add(item);
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
                string[] item = {client.Id.ToString() + ". ", client.Name};
                comboBoxClient.Items.Add(string.Join(" ", item));
            }
        }

        

        private void DealITS_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxITS_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
                if (comboBoxAgent.SelectedItem != null && comboBoxClient.SelectedItem != null && comboBoxITS.SelectedItem != null && textBoxAmount.Text.Length > 0)
                {

                    ItsSet its
                        = Program.entities1c.ItsSet.Find(Convert.ToInt32(comboBoxITS.SelectedItem.ToString().Split('.')[0]));
                    int a = Convert.ToInt32(textBoxAmount.Text);
                    int totalprice = its.Price * a;
                    textBoxTotalPrice.Text = totalprice.ToString();
                }
                else
                {
                    textBoxTotalPrice.Text = "";
                }        
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxAgent.SelectedItem != null && comboBoxClient.SelectedItem != null && comboBoxITS.SelectedItem != null && textBoxAmount.Text.Length>0 && textBoxTotalPrice.Text.Length>0)
            {
                DealSetITS dealSet = new DealSetITS();

                dealSet.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                dealSet.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                dealSet.IdIts = Convert.ToInt32(comboBoxITS.SelectedItem.ToString().Split('.')[0]);
                dealSet.Amount = Convert.ToInt32(textBoxAmount.Text);
                dealSet.TotalPrice = Convert.ToInt32(textBoxTotalPrice.Text);
                Program.entities1c.DealSetITS.Add(dealSet);
                Program.entities1c.SaveChanges();
                ShowDealITS();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewDealITS.SelectedItems.Count == 1)
            {
                DealSetITS dealSet = listViewDealITS.SelectedItems[0].Tag as DealSetITS;

                dealSet.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                dealSet.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                dealSet.IdIts = Convert.ToInt32(comboBoxITS.SelectedItem.ToString().Split('.')[0]);
                dealSet.Amount = Convert.ToInt32(textBoxAmount.Text);
                dealSet.TotalPrice = Convert.ToInt32(textBoxTotalPrice.Text);
                Program.entities1c.SaveChanges();
                ShowDealITS();
            }
        }

        private void listViewDealITS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDealITS.SelectedItems.Count == 1)
            {
                DealSetITS dealSet = listViewDealITS.SelectedItems[0].Tag as DealSetITS;
                comboBoxAgent.SelectedIndex = comboBoxAgent.FindString(dealSet.IdAgent.ToString());
                comboBoxClient.SelectedIndex = comboBoxClient.FindString(dealSet.IdClient.ToString());
                comboBoxITS.SelectedIndex = comboBoxITS.FindString(dealSet.IdIts.ToString());
                textBoxAmount.Text = dealSet.Amount.ToString();
                textBoxTotalPrice.Text = dealSet.TotalPrice.ToString();

            }
            else
            {
                comboBoxAgent.SelectedItem = null;
                comboBoxClient.SelectedItem = null;
                comboBoxITS.SelectedItem = null;
                textBoxAmount.Text = "";
                textBoxTotalPrice.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDealITS.SelectedItems.Count == 1)
                {
                    DealSetITS dealSet = listViewDealITS.SelectedItems[0].Tag as DealSetITS;
                    Program.entities1c.DealSetITS.Remove(dealSet);
                    Program.entities1c.SaveChanges();
                    ShowDealITS();
                }
                comboBoxAgent.SelectedItem = null;
                comboBoxClient.SelectedItem = null;
                comboBoxITS.SelectedItem = null;
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
