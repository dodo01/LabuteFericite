using LabuteCalatoare.DataBase.TableModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabuteCalatoare.Business.Services.Interfaces
{
    public interface IHotelService
    {

        /// <summary>
        /// It gets all the hotels from DB
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<HotelData>> GetAll();

        /// <summary>
        /// Returns the hotel details for the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HotelData> GetById(int id);

        /// <summary>
        /// Inserts a new hotel with its data
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task Insert(HotelData requestData);

        /// <summary>
        /// Delete hotel by the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteById(int id);
    }
}
