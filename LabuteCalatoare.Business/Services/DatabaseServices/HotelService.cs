using LabuteCalatoare.Business.Services.Interfaces;
using LabuteCalatoare.DataBase.Repositories.Interface;
using LabuteCalatoare.DataBase.TableModels;
using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabuteCalatoare.Business.Services.DatabaseServices
{
    public class HotelService : IHotelService
    {
        private IHotelRepository _hotelRepository;
        private static readonly Logger Logger = NLogService.GetLogger();

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        /// <summary>
        /// It gets all the hotels from DB
        /// </summary>
        /// <returns></returns>
        public List<HotelHoteldata> GetAll()
        {
            return _hotelRepository.GetAll();
        }

        /// <summary>
        /// Returns the hotel details for the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotelHoteldata GetById(int id)
        {
            return _hotelRepository.GetById(id);
        }

        /// <summary>
        /// Inserts a new hotel with its data
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task Insert(HotelHoteldata requestData)
        {
            await _hotelRepository.Insert(requestData);
        }

        /// <summary>
        /// Delete hotel by the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteById(int id)
        {
            await _hotelRepository.DeleteById(id);
        }
    }
}
