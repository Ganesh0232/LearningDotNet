using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyRestaurantDM.Data;
using MyRestaurantDM.Models.Domain;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace MyRestaurantDM.Repositories
{
    public class ImageRepository : IimageRepo
    {
        private readonly IWebHostEnvironment webHost;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly MyRestaurantDbContext db;

        public ImageRepository(IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor, MyRestaurantDbContext db)
        {
            this.webHost = webHost;
            this.httpContextAccessor = httpContextAccessor;
            this.db = db;
        }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public async Task<Models.Domain.Image> Upload(Models.Domain.Image image)
        {
            //    //throw new NotImplementedException();
            //    var localFilePath = Path.Combine(webHost.ContentRootPath,
            //                                    "Images", image.FileName, image.FileExtension);
            //    //Upload Image to Local path

            //    using var stream = new FileStream(localFilePath, FileMode.Create);
            //    await image.File.CopyToAsync(stream);

            //    var urlFilePath = $"{http.HttpContext.Request.Scheme}" +
            //        $"://{http.HttpContext.Request.Host}{http.HttpContext.Request.
            //        PathBase}/Images/{image.FileName}{image.FileExtension}";

            //    image.FilePath = urlFilePath; 

            //    //Add Images to the Image Table
            //    await db.Images.AddAsync(image);
            //    await db.SaveChangesAsync();

            //    return image;
            var localFilePath = Path.Combine(webHost.ContentRootPath, "Images",
                  $"{image.FileName}{image.FileExtension}");

            // Upload Image to Local Path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // https://localhost:1234/images/image.jpg

            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;


            // Add Image to the Images table
            await db.Images.AddAsync(image);
            await db.SaveChangesAsync();

            return image;


        }

        
    }

}

