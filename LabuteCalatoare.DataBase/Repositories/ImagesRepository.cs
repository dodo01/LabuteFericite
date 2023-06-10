using LabuteCalatoare.DataBase.BaseRepositories;
using LabuteCalatoare.DataBase.Contexts;
using LabuteCalatoare.DataBase.Repositories.Interfaces;
using LabuteCalatoare.DataBase.TableModels;

namespace LabuteCalatoare.DataBase.Repositories
{
    public class ImageRepository : BaseRepository<LabuteCalatoareContext, Images>, IImagesRepository
    {
        public ImageRepository(LabuteCalatoareContext context) : base(context)
        {
        }
    }
}
