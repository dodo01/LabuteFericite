using System.Collections.Generic;
using System.Threading.Tasks;
using LabuteCalatoare.DataBase.BaseRepositories.Interfaces;
using LabuteCalatoare.DataBase.Contexts;
using LabuteCalatoare.DataBase.TableModels;

namespace LabuteCalatoare.DataBase.Repositories.Interfaces
{
    public interface IHotelRepository : IRepository<LabuteCalatoareContext, HotelData>
    {
    }
}
