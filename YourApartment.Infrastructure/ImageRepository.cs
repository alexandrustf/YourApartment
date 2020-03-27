using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using YourApartment.Business;
using YourApartment.Domain;

namespace YourApartment.Infrastructure
{
    public class ImageRepository : IImageRepository
    {
        readonly string folderPath;
        readonly IDictionary<string, ApartmentImage> addImages;
        readonly ICollection<ApartmentImage> removeImages;
        private readonly ICollection<string> addedPaths = new List<string>();

        public IEnumerable<string> AddedImagePaths => addedPaths;
        public ImageRepository(IConfiguration configuration)
        {
            this.addImages = new Dictionary<string, ApartmentImage>();
            this.removeImages = new List<ApartmentImage>();

            this.folderPath = configuration.GetValue<string>("Images:Folder");
            if (string.IsNullOrWhiteSpace(this.folderPath))
            {
                //Throw exception  
            }
            else if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public ImageRepository(string path)
        {
            this.addImages = new Dictionary<string, ApartmentImage>();
            this.removeImages = new List<ApartmentImage>();
            this.folderPath = path;
            if (string.IsNullOrWhiteSpace(this.folderPath))
            {
                //Throw exception  
            }
            else if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
        public async Task AddImage(Guid apartmentId, IEnumerable<byte[]> images)
        {
            foreach (var apartmentImage in images.Select(image => new ApartmentImage(apartmentId) { Content = image }))
            {
                await AddImage(apartmentImage);
            }
            //images.ToList().ForEach(async i => await AddImage(new ApartmentImage(apartmentId) { Content = i };));
        }

        public async Task DeleteImage(Guid apartmentId)
        {
            //var productImage = new ApartmentImage(productId);

            //this.addImages.Remove(productImage.Id.ToString()); //Cancel image add  
            //if (!this.removeImages.Any(r => r.Id.Equals(productImage.Id)))
            //{
            //    this.removeImages.Add(productImage);
            //}
            await Task.CompletedTask;
        }

        public async Task<byte[]> GetImage(Guid apartmentId, String name)
        {
            return await File.ReadAllBytesAsync(GetImagePath(apartmentId, name));
        }

        public async Task<IEnumerable<byte[]>> GetImagesForApartment(Guid apartmentId)
        {
            string[] fileEntries = Directory.GetFiles(GetApartmentImageFolder(apartmentId));
            var images = new List<byte[]>();
            foreach (var fileEntry in fileEntries)
            {
                images.Add(await File.ReadAllBytesAsync(fileEntry));
            }
            return images;

            //return fileEntries.Select(async (p) => await File.ReadAllBytesAsync(p))
            //    .Select(t => t.Result);
        }

        public async Task SaveChanges()
        {
            foreach (var addFile in addImages)
            {
                var filePath = GetImagePath(addFile.Value.ProductId, addFile.Value.Id) + ".jpg";
                Directory.CreateDirectory(Path.Combine(folderPath, addFile.Value.ProductId.ToString()));
                File.WriteAllBytes(filePath,
                    addFile.Value.Content);

                addedPaths.Add(filePath);
            }
            foreach (var removeFile in removeImages)
            {
                File.Delete(this.GetImagePath(removeFile.ProductId, removeFile.Id));
            }
            await Task.CompletedTask;
        }

        private async Task AddImage(ApartmentImage productImage)
        {
            this.addImages.Remove(productImage.Id); //Remove old image  
            if (this.removeImages.Any(r => r.Id.Equals(productImage.Id, StringComparison.InvariantCultureIgnoreCase)))
            {
                this.removeImages.Remove(this.removeImages.First(r => r.Id.Equals(productImage.Id, StringComparison.InvariantCultureIgnoreCase))); //Cancel deletion  
            }

            this.addImages.Add(productImage.Id, productImage); //Add new image  
            await Task.CompletedTask;
        }

        private string GetApartmentImageFolder(Guid productId)
        {
            return Path.Combine(folderPath, productId.ToString());
        }

        private String GetImagePath(Guid productId, String name)
        {
            return Path.Combine(folderPath, productId.ToString(), name);
        }

        private IEnumerable<string> GetImagesPathForApartment(Guid productId)
        {
            return AddedImagePaths;
        }
    }
}
