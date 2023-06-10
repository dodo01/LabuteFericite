using System.Collections.Generic;
using System.Threading.Tasks;
using LabuteCalatoare.Business.Services.Interfaces;
using LabuteCalatoare.DataBase.Repositories.Interfaces;
using LabuteCalatoare.DataBase.TableModels;

namespace LabuteCalatoare.Business.Services.DatabaseServices
{
    public class ImagesService : IImagesService
    {
        private IImagesRepository _imagesRepository;
        public ImagesService(IImagesRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }

        public async Task<IEnumerable<Images>> GetAllImages()
        {
            return await _imagesRepository.ReadAsync();
        }
    }
}
