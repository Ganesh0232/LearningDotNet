using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using MyRestaurantDM.Models.Domain;
using MyRestaurantDM.Models.DTO;
using MyRestaurantDM.Repositories;

namespace MyRestaurantDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IimageRepo imgRepo;

        public ImagesController(IimageRepo imgRepo)
        {
            this.imgRepo = imgRepo;
        }

        [HttpPost ("ImageUpload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDto upload)
        {
            ValidateFileUpload (upload);
            if(ModelState.IsValid)
            {
                var imageDomain = new Image
                {
                    File = upload.File,
                    FileExtension = Path.GetExtension(upload.File.FileName),
                    FileSizeInBytes = upload.File.Length,
                    FileName = upload.File.FileName,
                    FileDescription = upload.FileDescription,
                    
                };
            //User repository to upload image

            await imgRepo.Upload(imageDomain);
                return Ok(imageDomain);

            }



            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto upload)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (allowedExtensions.Contains(Path.GetExtension(upload.File.FileName)) == false) 
            {
                ModelState.AddModelError("file", "Unsupported file extension");

            }

            if (upload.File.Length > 32000000000)
            {
                ModelState.AddModelError("File","File Size exceeds 32GB , please upload a smaller size file");
            }
        }
    }
}
