using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabuteCalatoare.DataBase.BaseRepositories.Interfaces;
using LabuteCalatoare.DataBase.Contexts;
using LabuteCalatoare.DataBase.TableModels;

namespace LabuteCalatoare.DataBase.Repositories.Interface
{
    public interface IHotelRepository
    {
        /// <summary>
        /// Returns all hotel details from db
        /// </summary>
        /// <returns></returns>
        List<HotelHoteldata> GetAllHotels();

        /// <summary>
        /// Returns hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HotelHoteldata GetHotelById(int id);

        /// <summary>
        /// Insert new entry in hotel database
        /// </summary>
        /// <param name="requestData"></param>
        Task InsertHotel(HotelHoteldata requestData);

        /// <summary>
        /// Delete hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteHotelById(int id);
    }
}
