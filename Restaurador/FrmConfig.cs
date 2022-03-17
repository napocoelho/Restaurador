using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Restaurador
{
    public partial class FrmConfig : Form
    {
        private ConfigController Controller { get; set; }

        public FrmConfig()
        {
            InitializeComponent();

            ///// Aba Config:
            this.Controller = new ConfigController();

            this.txtHost.DataBindings.Add("Text", this.Controller, "Host");
            this.txtUser.DataBindings.Add("Text", this.Controller, "User");
            this.txtPassword.DataBindings.Add("Text", this.Controller, "Password");
            this.txtInitialDirectory.DataBindings.Add("Text", this.Controller, "InitialDirectory");


            this.btnUninstall.DataBindings.Add("Enabled", this.Controller, "IsInstalled");
            btnUninstall.EnabledChanged += (object sender, EventArgs e) => btnInstall.Enabled = !btnUninstall.Enabled;
            this.btnInstall.Enabled = !this.Controller.IsInstalled;

            btnSave.Enabled = false;
        }

        
        private void FrmConfig_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            this.Controller.Save();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controller.Install();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controller.Uninstall();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controller.InitialDirectory = Helpers.FileHelper.GetUNCPath(this.Controller.InitialDirectory);
                this.Controller.TryConnection();
                btnSave.Enabled = true;
            }
            catch(Exception ex)
            {
                btnSave.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void txtInitialDirectory_TextChanged(object sender, EventArgs e)
        {

        }
    }
}