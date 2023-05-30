﻿using System.Collections.Generic;
using System.Threading.Tasks;
using LabuteCalatoare.DataBase.TableModels;

namespace LabuteCalatoare.DataBase.Repositories.Interface
{
    public interface IHotelRepository
    {
        /// <summary>
        /// Returns all hotel details from db
        /// </summary>
        /// <returns></returns>
        List<HotelHoteldata> GetAll();

        /// <summary>
        /// Returns hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HotelHoteldata GetById(int id);

        /// <summary>
        /// Insert new entry in hotel database
        /// </summary>
        /// <param name="requestData"></param>
        Task Insert(HotelHoteldata requestData);

        /// <summary>
        /// Delete hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteById(int id);
    }
}
