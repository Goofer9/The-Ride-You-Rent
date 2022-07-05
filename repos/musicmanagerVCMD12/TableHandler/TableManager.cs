using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace musicmanagerVCMD12.TableHandler
{
    public class TableManager
    {
        //connection to storage account
        private CloudTable table;

        public TableManager(string _CloudTablename)
        {
            //check if the table name is empty or null
            if (string.IsNullOrEmpty(_CloudTablename))
            {
                throw new ArgumentNullException("Table", "Table name connot be empty");
            }
            try
            {
                //get azure storage account conneciton string
                string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=musicmanagersavcmd12;AccountKey=qmtHxhyU8MnhXjeqCMHkr1Y+TYuaFBkRbPi/ZlK07n+wtSinGqpXCsGfHmHvdpRXIQKKymrxPP+IMuislmE33w==;EndpointSuffix=core.windows.net";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);

                //create table if not exists
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                table = tableClient.GetTableReference(_CloudTablename);
                table.CreateIfNotExists();
            }
            catch (StorageException StorageExceptionObj)
            {
                throw StorageExceptionObj;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        //retrieve all musicians GET R
        public List<T> RetrieveEntity<T>(String Query = null) where T : TableEntity, new()
        {
            try
            {
                TableQuery<T> DataTableQuery = new TableQuery<T>();
                if (!string.IsNullOrEmpty(Query))
                {
                    DataTableQuery = new TableQuery<T>().Where(Query);
                }
                IEnumerable<T> IDataList = table.ExecuteQuery(DataTableQuery);
                List<T> DataList = new List<T>();
                foreach (var singleData in IDataList)
                    DataList.Add(singleData);
                return DataList;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        //Insert or Update/Replace C U
        public void InsertEntity<T>(T entity, bool forInsert = true) where T : TableEntity, new()
        {
            try
            {
                if (forInsert)
                {
                    //Insert a new entity
                    var InsertOperation = TableOperation.Insert(entity);
                    table.Execute(InsertOperation);
                }
                else
                {
                    //Update an entity
                    var InsertOrReplaceOperation = TableOperation.InsertOrReplace(entity);
                    table.Execute(InsertOrReplaceOperation);
                }
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        //Delete Musician D
        public bool DeleteEntity<T>(T entity) where T : TableEntity, new() 
        {
            try
            {
                var DeleteOperation = TableOperation.Delete(entity);
                table.Execute(DeleteOperation);
                return true;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }
    }
}