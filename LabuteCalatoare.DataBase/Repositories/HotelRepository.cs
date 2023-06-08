using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabuteCalatoare.DataBase.BaseRepositories;
using LabuteCalatoare.DataBase.Contexts;
using LabuteCalatoare.DataBase.Repositories.Interface;
using LabuteCalatoare.DataBase.TableModels;

namespace LabuteCalatoare.DataBase.Repositories

{
    public class HotelRepository: BaseRepository<LabuteCalatoareContext, HotelData>, IHotelRepository
    {

        public HotelRepository(LabuteCalatoareContext context) : base(context)
        {
            
        }
     
    }
}
