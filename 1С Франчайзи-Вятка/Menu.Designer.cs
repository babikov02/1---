namespace _1С_Франчайзи_Вятка
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.buttonAgent = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.buttonITS = new System.Windows.Forms.Button();
            this.buttonProgramProduct = new System.Windows.Forms.Button();
            this.buttonDeal = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAgent
            // 
            this.buttonAgent.BackColor = System.Drawing.Color.LemonChiffon;
            this.buttonAgent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAgent.ForeColor = System.Drawing.Color.Red;
            this.buttonAgent.Location = new System.Drawing.Point(12, 142);
            this.buttonAgent.Name = "buttonAgent";
            this.buttonAgent.Size = new System.Drawing.Size(300, 56);
            this.buttonAgent.TabIndex = 1;
            this.buttonAgent.Text = "Сотрудники";
            this.buttonAgent.UseVisualStyleBackColor = false;
            this.buttonAgent.Click += new System.EventHandler(this.buttonAgent_Click);
            // 
            // buttonClient
            // 
            this.buttonClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClient.ForeColor = System.Drawing.Color.Red;
            this.buttonClient.Location = new System.Drawing.Point(12, 204);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(300, 56);
            this.buttonClient.TabIndex = 2;
            this.buttonClient.Text = "Клиенты";
            this.buttonClient.UseVisualStyleBackColor = true;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // buttonITS
            // 
            this.buttonITS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonITS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonITS.ForeColor = System.Drawing.Color.Red;
            this.buttonITS.Location = new System.Drawing.Point(12, 266);
            this.buttonITS.Name = "buttonITS";
            this.buttonITS.Size = new System.Drawing.Size(300, 56);
            this.buttonITS.TabIndex = 3;
            this.buttonITS.Text = "ИТС";
            this.buttonITS.UseVisualStyleBackColor = true;
            this.buttonITS.Click += new System.EventHandler(this.buttonITS_Click);
            // 
            // buttonProgramProduct
            // 
            this.buttonProgramProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProgramProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonProgramProduct.ForeColor = System.Drawing.Color.Red;
            this.buttonProgramProduct.Location = new System.Drawing.Point(12, 328);
            this.buttonProgramProduct.Name = "buttonProgramProduct";
            this.buttonProgramProduct.Size = new System.Drawing.Size(300, 56);
            this.buttonProgramProduct.TabIndex = 4;
            this.buttonProgramProduct.Text = "Программные продукты";
            this.buttonProgramProduct.UseVisualStyleBackColor = true;
            this.buttonProgramProduct.Click += new System.EventHandler(this.buttonProgramProduct_Click);
            // 
            // buttonDeal
            // 
            this.buttonDeal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeal.ForeColor = System.Drawing.Color.Red;
            this.buttonDeal.Location = new System.Drawing.Point(12, 390);
            this.buttonDeal.Name = "buttonDeal";
            this.buttonDeal.Size = new System.Drawing.Size(300, 56);
            this.buttonDeal.TabIndex = 5;
            this.buttonDeal.Text = "Сделки";
            this.buttonDeal.UseVisualStyleBackColor = true;
            this.buttonDeal.Click += new System.EventHandler(this.buttonDeal_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.pictureBox1.Image = global::_1С_Франчайзи_Вятка.Properties.Resources.logo_under_1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(324, 458);
            this.Controls.Add(this.buttonDeal);
            this.Controls.Add(this.buttonProgramProduct);
            this.Controls.Add(this.buttonITS);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.buttonAgent);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAgent;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button buttonITS;
        private System.Windows.Forms.Button buttonProgramProduct;
        private System.Windows.Forms.Button buttonDeal;
    }
}

