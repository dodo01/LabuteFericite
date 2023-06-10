using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabuteCalatoare.DataBase.TableModels;

namespace LabuteCalatoare.Business.Services.Interfaces
{
    public interface IImagesService
    {
        Task<IEnumerable<Images>> GetAllImages();
    }
}
