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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            if (Autorization.agent.type == "Секретарь") buttonAgent.Enabled = false;
            labelHello.Text = "Приветствую тебя, " + Autorization.agent.login;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void buttonAgent_Click(object sender, EventArgs e)
        {
            Form formAgent = new FormAgent();
            formAgent.Show();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            Form formClient = new Client();
            formClient.Show();
        }

        private void buttonITS_Click(object sender, EventArgs e)
        {
            Form formITS = new ITS();
            formITS.Show();
        }

        private void buttonProgramProduct_Click(object sender, EventArgs e)
        {
            Form formProgramProduct = new ProgramProduct();
            formProgramProduct.Show();

        }

        private void buttonDeal_Click(object sender, EventArgs e)
        {
            Form formDeal = new Deal();
            formDeal.Show();
        }
    }
}
