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
    public partial class Main : Form
    {
        //private ConfigController Config { get; set; }
        private LoaderController Controller { get; set; }
        private SqlConnection Connection { get; set; }
        private Boolean IsControlPressed { get; set; }


        public Main()
        {
            InitializeComponent();

            this.KeyPreview = true;

            ///// Aba Loader:
            this.Controller = new LoaderController();


            ///// Bindings:
            this.txtSourceFilePath.Enabled = false;
            this.txtSourceFilePath.DataBindings.Add("Text", this.Controller, "SourceFilePath");
            this.txtSourceDatabaseName.DataBindings.Add("Text", this.Controller, "SourceDatabaseName");



            this.txtLogicalDataName.DataBindings.Add("Text", this.Controller, "DestinationLogicalDataName");
            this.txtLogicalLogName.DataBindings.Add("Text", this.Controller, "DestinationLogicalLogName");

            this.txtPhysicalDataFile.DataBindings.Add("Text", this.Controller, "DestinationPhysicalDataPath");
            this.txtPhysicalLogFile.DataBindings.Add("Text", this.Controller, "DestinationPhysicalLogPath");


            this.cbxDatabases.DataSource = this.Controller.Databases;
            this.cbxDatabases.DisplayMember = "Name";
            this.cbxDatabases.DataBindings.Add("Text", this.Controller, "SelectedDatabaseName");
            this.cbxDatabases.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    this.Controller.SelectedDatabaseName = this.cbxDatabases.Text.Trim();
                };

            this.chkActivatesLogicalChange.DataBindings.Add("Checked", this.Controller, "IsManualSetLogicalNames");
            this.chkActivatesPhysicalChange.DataBindings.Add("Checked", this.Controller, "IsManualSetPhysicalNames");

            this.groupDestination.DataBindings.Add("Enabled", this.Controller, "IsBackupOpened");
            this.btnRestore.DataBindings.Add("Enabled", this.Controller, "IsBackupOpened");

            this.Controller.RestoringEvent += (percentual) =>
                {
                    toolStripProgressBar1.Value = percentual;
                    Application.DoEvents();
                };


            try
            {
                this.Controller.LoadDatabases();
            }
            catch (Exception ex)
            {
                MessageBox.Show("You have to set the Sql Server connection! Maybe, you also will have to run as administrator.");
            }


            this.cbxDatabases.SelectedIndex = -1;
            this.cbxDatabases.Text = "select a database...";


            try
            {
                ///// Trying to get association with file:
                if (System.Environment.GetCommandLineArgs().Count() > 1)
                {
                    string inputPath = System.Environment.GetCommandLineArgs()[1];

                    inputPath = Helpers.FileHelper.GetUNCPath(inputPath);
                    //MessageBox.Show(inputPath);
                    this.Controller.SetBackupFile(inputPath);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
                this.Close();
                //Application.Exit();
                
            }
        }


        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            Config config = Helpers.RegistryHelper.Load();


            try
            {
                if (config == null)
                    throw new NullReferenceException("The Sql Server instance must to be specified. See about [Settings...].");

                openFileDialog1.InitialDirectory = config.InitialDirectory;
                openFileDialog1.Title = "Open a backup file...";
                openFileDialog1.FileName = "";

                openFileDialog1.ShowDialog(this);

                if (openFileDialog1.FileName.Trim() != string.Empty)
                {
                    openFileDialog1.FileName = Helpers.FileHelper.GetUNCPath(openFileDialog1.FileName);
                    this.Controller.SetBackupFile(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("O banco de dados está corrompido, diretório fora do servidor ou a versão do SqlServer é incompatível!", "Error");
            }
        }


        private void btnRestore_Click(object sender, EventArgs e)
        {
            bool isPressed = this.IsControlPressed;

            if (isPressed)
            {
                toolStripStatusLabelKillProcesses.Text = "KO";
            }
            else
            {
                toolStripStatusLabelKillProcesses.Text = "";
            }


            try
            {
                btnRestore.Enabled = false;
                this.Controller.RestoreSelectedDatabase(isPressed);
                MessageBox.Show("Restoration complete!", "Restoration");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                btnRestore.Enabled = true;
            }
        }


        private void lnkSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmConfig frm = new FrmConfig();
            frm.ShowDialog(this);

            try
            {
                this.Controller.LoadDatabases();
            }
            catch (Exception ex)
            { }


            this.cbxDatabases.SelectedIndex = -1;
            this.cbxDatabases.Text = "select a database...";
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void chkActivatesLogicalChange_CheckedChanged(object sender, EventArgs e)
        {
            this.groupLogical.Enabled = chkActivatesLogicalChange.Checked;
            this.Controller.IsManualSetLogicalNames = chkActivatesLogicalChange.Checked;
        }

        private void chkActivatesPhysicalChange_CheckedChanged(object sender, EventArgs e)
        {
            this.groupPhysical.Enabled = chkActivatesPhysicalChange.Checked;
            this.Controller.IsManualSetPhysicalNames = chkActivatesPhysicalChange.Checked;
        }

        private void groupDestination_Resize(object sender, EventArgs e)
        {
            btnOpenFile.Left = groupSource.Width - (btnOpenFile.Width + 10);
            txtSourceFilePath.Width = groupSource.Width - txtSourceFilePath.Left - btnOpenFile.Width - 20;
            txtSourceDatabaseName.Width = txtSourceFilePath.Width;

            cbxDatabases.Width = groupDestination.Width - cbxDatabases.Left - 10;

            groupLogical.Width = groupDestination.Width - groupLogical.Left - 10;
            txtLogicalDataName.Width = groupLogical.Width - txtLogicalDataName.Left - 5;
            txtLogicalLogName.Width = groupLogical.Width - txtLogicalLogName.Left - 5;

            groupPhysical.Width = groupDestination.Width - groupPhysical.Left - 10;
            txtPhysicalDataFile.Width = groupPhysical.Width - txtPhysicalDataFile.Left - 5;
            txtPhysicalLogFile.Width = groupPhysical.Width - txtPhysicalLogFile.Left - 5;





        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            this.IsControlPressed = e.Control;
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            this.IsControlPressed = e.Control;
        }
    }
}