using System;
using LabuteCalatoare.DataBase.BaseRepositories.Interfaces;
using LabuteCalatoare.DataBase.Contexts;
using LabuteCalatoare.DataBase.TableModels;

namespace LabuteCalatoare.DataBase.Repositories.Interface
{
    public interface IHotelRepository : IBaseRepository<LabuteCalatoareContext, HotelHoteldata>
    {
        
    }
}
