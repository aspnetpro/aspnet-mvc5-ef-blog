using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Application
{
    public class AzureBlobStorageImpl
    {
        CloudStorageAccount _account;
        CloudBlobClient _blobClient;

        public AzureBlobStorageImpl()
        {
            _account = CloudStorageAccount.Parse(AzureSettings.StorageConnectionString);
            _blobClient = _account.CreateCloudBlobClient();
        }

        public string Upload(string fileName, Stream stream)
        {
            if (null == stream)
            {
                throw new ArgumentNullException("fileStream");
            }

            CloudBlobContainer container = GetBlobContainer();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            stream.Seek(0, SeekOrigin.Begin);
            blockBlob.UploadFromStream(stream);

            return String.Format(AzureSettings.BlobUrl, AzureSettings.BlobContainerName, fileName);
        }

        CloudBlobContainer GetBlobContainer()
        {
            if (null == _blobClient)
            {
                throw new ArgumentNullException("blobClient");
            }

            CloudBlobContainer container = _blobClient.GetContainerReference(AzureSettings.BlobContainerName);
            container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            return container;
        }
    }
}