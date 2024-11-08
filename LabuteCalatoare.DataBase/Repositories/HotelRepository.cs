﻿using LabuteCalatoare.DataBase.BaseRepositories;
using LabuteCalatoare.DataBase.Contexts;
using LabuteCalatoare.DataBase.Repositories.Interfaces;
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
