using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using Restaurador.Helpers;

namespace Restaurador
{
    public class LoaderController : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public delegate void RestoringEventHandler(int progression);
        public event RestoringEventHandler RestoringEvent;

        public static Object LOCK = new Object();

        private String sourceDatabaseName;
        private String sourceFilePath;

        private String destinationLogicalDataName;
        private String destinationLogicalLogName;

        private String destinationPhysicalDataPath;
        private String destinationPhysicalLogPath;

        private BindingList<Database> databases;
        private String selectedDatabaseName;

        private Boolean isManualSetLogicalNames;
        private Boolean isManualSetPhysicalNames;

        private BackupFileInfo backupFileOpened;
        private Boolean isBackupOpened;


        private int restorationProgress;

        private BackupFileInfo BackupFileOpened
        {
            get { return this.backupFileOpened; }
            set { this.backupFileOpened = value; this.IsBackupOpened = (this.backupFileOpened != null); }
        }

        public Boolean IsBackupOpened
        {
            get
            {
                return this.isBackupOpened;
            }
            private set
            {
                if (this.isBackupOpened != value)
                {
                    OnPropertyChanging("IsBackupOpened");
                    this.isBackupOpened = value;
                    OnPropertyChanged("IsBackupOpened");
                }
            }
        }

        public Boolean IsManualSetLogicalNames
        {
            get
            {
                return this.isManualSetLogicalNames;
            }
            set
            {
                if (this.isManualSetLogicalNames != value)
                {
                    OnPropertyChanging("IsManualSetLogicalNames");
                    this.isManualSetLogicalNames = value;
                    OnPropertyChanged("IsManualSetLogicalNames");

                    this.UpdateAutomaticLogicalSettings();
                }
            }
        }

        public Boolean IsManualSetPhysicalNames
        {
            get
            {
                return this.isManualSetPhysicalNames;
            }
            set
            {
                if (this.isManualSetPhysicalNames != value)
                {
                    OnPropertyChanging("IsManualSetPhysicalNames");
                    this.isManualSetPhysicalNames = value;
                    OnPropertyChanged("IsManualSetPhysicalNames");

                    this.UpdateAutomaticPhysicalSettings();
                }
            }
        }


        public String SourceDatabaseName
        {
            get
            {
                return this.sourceDatabaseName;
            }
            set
            {
                if (this.sourceDatabaseName != value)
                {
                    OnPropertyChanging("SourceDatabaseName");
                    this.sourceDatabaseName = value;
                    OnPropertyChanged("SourceDatabaseName");
                }
            }
        }

        public BindingList<Database> Databases
        {
            get
            {
                return this.databases;
            }
            private set
            {
                if (this.databases != value)
                {
                    OnPropertyChanging("Databases");
                    this.databases = value;
                    OnPropertyChanged("Databases");
                }
            }
        }

        public String SelectedDatabaseName
        {
            get
            {
                return this.selectedDatabaseName;
            }
            set
            {
                if (this.selectedDatabaseName != value)
                {
                    OnPropertyChanging("SelectedDatabaseName");
                    this.selectedDatabaseName = value.Trim();
                    OnPropertyChanged("SelectedDatabaseName");

                    if (!this.IsManualSetLogicalNames && this.isBackupOpened)
                    {
                        this.DestinationLogicalDataName = this.SelectedDatabaseName;
                        this.DestinationLogicalLogName = this.SelectedDatabaseName + "_LOG";
                    }

                    if (!this.IsManualSetPhysicalNames && this.isBackupOpened)
                    {
                        this.DestinationPhysicalDataPath = Path.GetDirectoryName(this.BackupFileOpened.Data.PhysicalName) + "\\" + this.SelectedDatabaseName + ".mdf";
                        this.DestinationPhysicalLogPath = Path.GetDirectoryName(this.BackupFileOpened.Log.PhysicalName) + "\\" + this.SelectedDatabaseName + "_LOG.ldf";
                    }
                }
            }
        }

        public String SourceFilePath
        {
            get
            {
                return this.sourceFilePath;
            }
            set
            {
                if (this.sourceFilePath != value)
                {
                    OnPropertyChanging("SourceFilePath");
                    this.sourceFilePath = value;
                    OnPropertyChanged("SourceFilePath");
                }
            }
        }

        public String DestinationPhysicalDataPath
        {
            get
            {
                return this.destinationPhysicalDataPath;
            }
            set
            {
                if (this.destinationPhysicalDataPath != value)
                {
                    OnPropertyChanging("DestinationPhysicalDataPath");
                    this.destinationPhysicalDataPath = value;
                    OnPropertyChanged("DestinationPhysicalDataPath");
                }
            }
        }

        public String DestinationPhysicalLogPath
        {
            get
            {
                return this.destinationPhysicalLogPath;
            }
            set
            {
                if (this.destinationPhysicalLogPath != value)
                {
                    OnPropertyChanging("DestinationPhysicalLogPath");
                    this.destinationPhysicalLogPath = value;
                    OnPropertyChanged("DestinationPhysicalLogPath");
                }
            }
        }

        public String DestinationLogicalDataName
        {
            get
            {
                return this.destinationLogicalDataName;
            }
            set
            {
                if (this.destinationLogicalDataName != value)
                {
                    OnPropertyChanging("DestinationLogicalDataName");
                    this.destinationLogicalDataName = value;
                    OnPropertyChanged("DestinationLogicalDataName");
                }
            }
        }

        public String DestinationLogicalLogName
        {
            get
            {
                return this.destinationLogicalLogName;
            }
            set
            {
                if (this.destinationLogicalLogName != value)
                {
                    OnPropertyChanging("DestinationLogicalLogName");
                    this.destinationLogicalLogName = value;
                    OnPropertyChanged("DestinationLogicalLogName");
                }
            }
        }

        /// <summary>
        /// While restoration is running, it takes from 0 to 100.
        /// </summary>
        public int RestorationProgress
        {
            get
            {
                return this.restorationProgress;
            }
            private set
            {
                if (this.restorationProgress != value)
                {
                    OnPropertyChanging("RestorationProgress");
                    this.restorationProgress = value;
                    OnPropertyChanged("RestorationProgress");
                }
            }
        }


        public LoaderController()
        {
            this.Databases = new BindingList<Database>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        public void LoadDatabases()
        {
            DataTable table = DbHelper.ExecuteTable("SELECT name, database_id FROM [master].[sys].[databases]");

            this.Databases.Clear();

            foreach (DataRow row in table.Rows)
            {
                Database db = new Database();
                db.Name = row["name"].ToString();
                db.Id = row["database_id"].ToInt();
                this.Databases.Add(db);
            }
        }

        private bool DatabaseExists(string databaseName)
        {
            DataTable table = DbHelper.ExecuteTable("SELECT name FROM [master].[sys].[databases]");

            foreach (DataRow row in table.Rows)
            {
                if (databaseName.Trim() == row["name"].ToString().Trim())
                {
                    return true;
                }
            }

            return false;
        }


        public void RestoreSelectedDatabase(bool killProcesses = false)
        {
            int spid = 0;
            decimal percentual = 0;
            Exception exception = null;
            

            // Worker principal:
            Task scriptTask = Task.Run(() =>
                {
                    try
                    {
                        RunningScripts(out spid, killProcesses);
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                    }
                });

            System.Threading.Thread.Sleep(100);

            // Verifica andamento da restauração:
            while (!scriptTask.IsCompleted )
            {
                if (this.RestoringEvent != null)
                {
                    if (spid > 0)
                    {
                        // Retornando progressão da restauração:
                        string value = Helpers.DbHelper.ExecuteScalar("SELECT percent_complete FROM sys.dm_exec_requests WHERE session_id = " + spid.ToString()).ToString().Trim();
                        decimal.TryParse(value, out percentual);

                        // Atualizando propriedade:
                        this.RestorationProgress = (int)percentual;

                        // Acionando evento:
                        RestoringEvent((int)percentual);
                    }
                }

                System.Threading.Thread.Sleep(100);
            }

            // Se finalizar o procedimento e der tudo certo, sempre vai ter que exibir 100%:
            if (scriptTask.IsCompleted && exception == null)
            {
                this.RestorationProgress = 100;

                if (this.RestoringEvent != null)
                    RestoringEvent(100);
            }

            if (exception != null)
            {
                throw exception;
            }
        }

        private void RunningScripts(out int spid, bool killProcesses = false)
        {
            string script;
            List<String> commands = new List<string>();


            // Adicionando o comando REPLACE:
            commands.Add("REPLACE");


            // Verificando se precisa alterar o caminho físico de DATA:
            if (!this.DatabaseExists(this.SelectedDatabaseName) || this.DestinationPhysicalDataPath != this.BackupFileOpened.Data.PhysicalName)
            {
                commands.Add(
                    string.Format(
                                    "MOVE '{0}' TO '{1}'",
                                    this.BackupFileOpened.Data.LogicalName,
                                    this.DestinationPhysicalDataPath
                                )
                           );
            }

            // Verificando se precisa alterar o caminho físico de LOG:
            if (!this.DatabaseExists(this.SelectedDatabaseName) || this.DestinationPhysicalLogPath != this.BackupFileOpened.Log.PhysicalName)
            {
                commands.Add(
                    string.Format(
                                    "MOVE '{0}' TO '{1}'",
                                    this.BackupFileOpened.Log.LogicalName,
                                    this.DestinationPhysicalLogPath
                                )
                           );
            }

            // Formulando script de restauração:
            script = string.Format
                    (
                        @"RESTORE DATABASE {0} FROM DISK = '{1}' WITH {2};",
                        this.SelectedDatabaseName,
                        this.BackupFileOpened.FilePath,
                        string.Join(", ", commands)
                    );


            if (killProcesses)
            {
                DbHelper.KillAllProcesses(this.SelectedDatabaseName);
            }


            // Executando o SCRIPT:
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {


                conn.Open();
                //int spid = 0;
                int.TryParse(DbHelper.ExecuteScalar("SELECT @@SPID;", conn).ToString(), out spid);
                
                DbHelper.ExecuteNonQuery(script, false, conn);

                /*************************************************************************************************************************************************************************************************************************/

                // Verificando se precisa alterar o nome lógico de DATA:
                if (this.DestinationLogicalDataName != this.BackupFileOpened.Data.LogicalName)
                {
                    script = string.Format
                        (
                            @"ALTER DATABASE {0} MODIFY FILE ( NAME = '{1}', NEWNAME = '{2}' );",
                            this.SelectedDatabaseName,
                            this.BackupFileOpened.Data.LogicalName,
                            this.DestinationLogicalDataName
                        );

                    DbHelper.ExecuteNonQuery(script, false, conn);
                }

                // Verificando se precisa alterar o nome lógico de LOG:
                if (this.DestinationLogicalLogName != this.BackupFileOpened.Log.LogicalName)
                {
                    script = string.Format
                        (
                            @"ALTER DATABASE {0} MODIFY FILE ( NAME = '{1}', NEWNAME = '{2}' );",
                            this.SelectedDatabaseName,
                            this.BackupFileOpened.Log.LogicalName,
                            this.DestinationLogicalLogName
                        );

                    DbHelper.ExecuteNonQuery(script, false, conn);
                }

                try
                {
                    conn.Close();
                }
                finally { }
            }
        }

        public void SetBackupFile(string path)
        {
            BackupFileInfo backupFile = BackupHelper.Load(path);

            if (backupFile != null)
            {
                // Sources:
                this.SourceFilePath = backupFile.FilePath;
                this.SourceDatabaseName = backupFile.Name;

                this.DestinationLogicalDataName = backupFile.Data.LogicalName;
                this.DestinationLogicalLogName = backupFile.Log.LogicalName;

                this.DestinationPhysicalDataPath = backupFile.Data.PhysicalName;
                this.DestinationPhysicalLogPath = backupFile.Log.PhysicalName;

                // Destinations:
                this.SelectedDatabaseName = backupFile.Name;
            }

            this.BackupFileOpened = backupFile;
        }



        private void UpdateAutomaticLogicalSettings()
        {
            if (!this.IsManualSetLogicalNames)
            {
                this.DestinationLogicalDataName = this.BackupFileOpened.Data.LogicalName;
                this.DestinationLogicalLogName = this.BackupFileOpened.Log.LogicalName;


            }
        }

        private void UpdateAutomaticPhysicalSettings()
        {
            if (!this.IsManualSetPhysicalNames)
            {
                this.DestinationPhysicalDataPath = this.BackupFileOpened.Data.PhysicalName;
                this.DestinationPhysicalLogPath = this.BackupFileOpened.Log.PhysicalName;
            }
        }
    }
}