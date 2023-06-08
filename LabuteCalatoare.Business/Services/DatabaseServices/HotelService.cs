using LabuteCalatoare.Business.Services.Interfaces;
using LabuteCalatoare.DataBase.Repositories.Interface;
using LabuteCalatoare.DataBase.TableModels;
using NLog;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEnumerable<HotelData>> GetAll()
        {
            return await _hotelRepository.ReadAsync();
        }

        /// <summary>
        /// Returns the hotel details for the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HotelData> GetById(int id)
        {
            var results = await _hotelRepository.ReadAsync(item=>item.HotelId==id);
            return results.FirstOrDefault();
        }

        /// <summary>
        /// Inserts a new hotel with its data
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task Insert(HotelData requestData)
        {
            await _hotelRepository.CreateAsync(requestData);
        }

        /// <summary>
        /// Delete hotel by the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteById(int id)
        {
            await _hotelRepository.DeleteAsync(item=>item.HotelId==id);
        }
    }
}
