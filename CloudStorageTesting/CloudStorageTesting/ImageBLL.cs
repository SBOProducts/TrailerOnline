using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorageTesting
{
    public class ImageBLL
    {

        public static void UploadImage(string FileName, byte[] ImageData)
        {
            CloudBlockBlob blob = GetContainer("images").GetBlockBlobReference(FileName);
            blob.Properties.ContentType = "image/jpeg";
            blob.UploadFromByteArray(ImageData, 0, ImageData.Length);

        }


        public static void DownloadImage(string FileName, string DestPath)
        {
            CloudBlockBlob blob = GetContainer("images").GetBlockBlobReference(FileName);
            blob.DownloadToFile(DestPath, System.IO.FileMode.Create);
        }


        /// <summary>
        /// Gets a blob container creating it with public access enabled if it doesn't exist
        /// </summary>
        /// <param name="ContainerName"></param>
        /// <returns></returns>
        private static CloudBlobContainer GetContainer(string ContainerName)
        {
            CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(ContainerName);

            // create the contaner with public access enabled
            if (!container.Exists())
                container.Create(BlobContainerPublicAccessType.Blob);

            return container;

        }



    }
}
