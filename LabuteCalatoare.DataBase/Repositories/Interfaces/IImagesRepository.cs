using LabuteCalatoare.DataBase.BaseRepositories.Interfaces;
using LabuteCalatoare.DataBase.Contexts;
using LabuteCalatoare.DataBase.TableModels;

namespace LabuteCalatoare.DataBase.Repositories.Interfaces
{
    public interface IImagesRepository : IRepository<LabuteCalatoareContext, Images>
    {
    }
}
