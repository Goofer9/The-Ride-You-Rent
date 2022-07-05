using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace musicmanagerVCMD12.BlobHandler
{
    public class BlobManager
    {
        //connection to storage account
        private CloudBlobContainer blobContainer;

        public BlobManager(string ContainerName)
        {
            //check if the table name is empty or null
            if (string.IsNullOrEmpty(ContainerName))
            {
                throw new ArgumentNullException("Container", "Container name connot be empty");
            }
            try
            {
                //get azure storage account conneciton string
                string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=musicmanagersavcmd12;AccountKey=qmtHxhyU8MnhXjeqCMHkr1Y+TYuaFBkRbPi/ZlK07n+wtSinGqpXCsGfHmHvdpRXIQKKymrxPP+IMuislmE33w==;EndpointSuffix=core.windows.net";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);

                //create the container if not exists
                CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                blobContainer = cloudBlobClient.GetContainerReference(ContainerName);

                //create the container and set the permissions
                if (blobContainer.CreateIfNotExists()) {
                    blobContainer.SetPermissions(
                        new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        });
                }
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        //Upload Blob Insert or Update/Replace C U
        public string UploadFile(HttpPostedFileBase FileToUpload)
        {
            string AbsoluteUri;
            //check if posted file base is null or empty
            if (FileToUpload == null || FileToUpload.ContentLength == 0)
            {
                return null;
            }
            try
            {
                //get the file to be uploaded's name
                string FileName = Path.GetFileName(FileToUpload.FileName);

                // create the block blob
                CloudBlockBlob blockBlob;
                blockBlob = blobContainer.GetBlockBlobReference(FileName);

                //set the block blob content type
                blockBlob.Properties.ContentType = FileToUpload.ContentType;

                //upload the blob
                blockBlob.UploadFromStream(FileToUpload.InputStream);

                //get the URI
                AbsoluteUri = blockBlob.Uri.AbsoluteUri;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
            return AbsoluteUri;
        }

        //retrieve all musicians profile pictures GET R
        public List<string> BlobList()
        {
           List<string> _blobList = new List<string>();
            foreach (IListBlobItem item in blobContainer.ListBlobs())
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob _blobpage = (CloudBlockBlob)item;
                    _blobList.Add(_blobpage.Uri.AbsoluteUri.ToString());
                }
            }
            return _blobList;
        }


        //Delete Musician profile picture D
        public bool DeleteBlob(string AbsoluteUri)
        {
            try
            {
                //get back Image Uri
                Uri uriObj = new Uri(AbsoluteUri);
                string BlobName = Path.GetFileName(uriObj.LocalPath);
                //get reference to the blockblob
                CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(BlobName);
                //delete blob 
                blockBlob.Delete();
                return true;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }
    }
}