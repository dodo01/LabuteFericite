using System;
using LabuteCalatoare.DataBase.BaseRepositories;
using LabuteCalatoare.DataBase.Contexts;
using LabuteCalatoare.DataBase.Repositories.Interface;
using LabuteCalatoare.DataBase.TableModels;

namespace LabuteCalatoare.DataBase.Repositories
{
    public class HotelRepository : BaseRepository<LabuteCalatoareContext,HotelHoteldata>,  IHotelRepository
    {
        public HotelRepository(LabuteCalatoareContext context): base(context)
        {
            
        }
    }
}
