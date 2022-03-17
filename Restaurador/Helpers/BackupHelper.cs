using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace Restaurador.Helpers
{
    public static class BackupHelper
    {
        public static BackupFileInfo Load(string filePath)
        {
            BackupFileInfo bkpFile = null;
            string query = null;
            DataTable table = null;

            // Obtendo o nome do banco de dados:
            query = string.Format("RESTORE HEADERONLY FROM DISK='{0}'", filePath);
            table = DbHelper.ExecuteTable(query);
            string databaseName = table.Rows[0]["DatabaseName"] as String;

            if (string.IsNullOrEmpty ( databaseName))
            {
                throw new Exception("Versão não suportada!");
            }

            // Obtendo informações dos arquivos do banco de dados:
            query = string.Format("RESTORE FILELISTONLY FROM DISK = '{0}';", filePath);
            table = DbHelper.ExecuteTable(query);

            string serverDataDirectory = Path.GetDirectoryName(DbHelper.ExecuteScalar("SELECT physical_name FROM master.sys.master_files WHERE database_id = 1 AND file_id = 1") as String); //-->  Physical Data Name


            foreach (DataRow row in table.Rows)
            {
                BackupFilePart part = new BackupFilePart();
                part.Type = row["Type"].ToString().Trim();
                part.BackupSizeInBytes = row["BackupSizeInBytes"].ToInt64();
                part.LogicalName = row["LogicalName"].ToString();
                part.MaxSize = row["MaxSize"].ToInt64();
                part.Size = row["Size"].ToInt64();
                part.UniqueId = row["UniqueId"].ToString();


                if (bkpFile == null)
                {
                    bkpFile = new BackupFileInfo();
                    bkpFile.FilePath = filePath;
                    bkpFile.Name = databaseName;
                }


                if (part.Type.ToUpper() == "D")
                {
                    string fileName = databaseName + ".mdf"; //Path.GetFileNameWithoutExtension(row["PhysicalName"].ToString()) + ".mdf";
                    string pathName = Path.Combine(serverDataDirectory, fileName);

                    part.PhysicalName = pathName;
                    bkpFile.Data = part;
                }

                if (part.Type.ToUpper() == "L")
                {
                    string fileName = databaseName + "_LOG.ldf"; // Path.GetFileNameWithoutExtension(row["PhysicalName"].ToString()) + "_LOG.ldf";  //row["PhysicalName"].ToString();
                    string pathName = Path.Combine(serverDataDirectory, fileName);

                    part.PhysicalName = pathName;
                    bkpFile.Log = part;
                }
            }


            return bkpFile;
        }
    }
}