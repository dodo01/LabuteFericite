using System.Collections.Generic;
using System.Threading.Tasks;
using LabuteCalatoare.Business.Services.Interfaces;
using LabuteCalatoare.DataBase.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace LabuteCalatoare.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IImagesService _imagesService;
        public ImageController(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Images>> GetAll()
        {
            return await _imagesService.GetAllImages();
        }
     }
}
