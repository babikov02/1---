using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1С_Франчайзи_Вятка
{
    public partial class FormAgent : Form
    {
     

        public FormAgent()
        {
            InitializeComponent();
            ShowAgent();
        }

        void ShowAgent()
        {
            listViewAgent.Items.Clear();
            foreach (AgentSet agentSet in Program.entities1c.AgentSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                        agentSet.Id.ToString(), agentSet.LastName, agentSet.Name, agentSet.MiddleName,agentSet.Phone,
                    agentSet.Position, agentSet.Login
                });

                item.Tag = agentSet;

                listViewAgent.Items.Add(item);
            }
            listViewAgent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormAgent_Load(object sender, EventArgs e)
        {

        }

        private void listViewAgent_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewAgent.SelectedItems.Count == 1)
            {
                AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                textBoxLastName.Text = agentSet.LastName;
                textBoxName.Text = agentSet.Name;
                textBoxMiddleName.Text = agentSet.MiddleName;
                textBoxPhone.Text = agentSet.Phone;
                textBoxPosition.Text = agentSet.Position;
                textBoxLogin.Text = agentSet.Login;
                textBoxPassword.Text = agentSet.Password;
            }
            else
            {
                textBoxLastName.Text = "";
                textBoxName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxPhone.Text = "";
                textBoxPosition.Text = "";
                textBoxLogin.Text = "";
                textBoxPassword.Text = "";

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AgentSet agentSet = new AgentSet();
            agentSet.LastName = textBoxLastName.Text;
            agentSet.Name = textBoxName.Text;
            agentSet.MiddleName = textBoxMiddleName.Text;
            agentSet.Phone = textBoxPhone.Text;
            agentSet.Position = textBoxPosition.Text;
            agentSet.Login = textBoxLogin.Text;
            agentSet.Password = textBoxPassword.Text;
            Program.entities1c.AgentSet.Add(agentSet);
            Program.entities1c.SaveChanges();
            ShowAgent();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            if (listViewAgent.SelectedItems.Count == 1)
            {

                AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                agentSet.LastName = textBoxLastName.Text;
                agentSet.Name = textBoxName.Text;
                agentSet.MiddleName = textBoxMiddleName.Text;
                agentSet.Phone = textBoxPhone.Text;
                agentSet.Position = textBoxPosition.Text;
                agentSet.Login = textBoxLogin.Text;
                agentSet.Password = textBoxPassword.Text;
                Program.entities1c.SaveChanges();
                ShowAgent();

            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (listViewAgent.SelectedItems.Count == 1)
                {
                    AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                    Program.entities1c.AgentSet.Remove(agentSet);
                    Program.entities1c.SaveChanges();
                    ShowAgent();
                }
                textBoxLastName.Text = "";
                textBoxName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxPhone.Text = "";
                textBoxPosition.Text = "";
                textBoxLogin.Text = "";
                textBoxPassword.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
