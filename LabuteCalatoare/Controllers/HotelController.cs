
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabuteCalatoare.DataBase.Contexts;
using LabuteCalatoare.DataBase.Repositories.Interface;
using LabuteCalatoare.DataBase.TableModels;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace LabuteFericite.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelRepository _hotelRepository;
        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet("[action]")]
        public List<HotelHoteldata> GetAll()
        {
            return _hotelRepository.GetAllHotels();
        }

        [HttpGet("[action]")]
        public HotelHoteldata GetById(int id)
        {
            return _hotelRepository.GetHotelById(id);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Insert(HotelHoteldata requestModel)
        {
            await _hotelRepository.InsertHotel(requestModel);
            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteById(int id)
        {
            await _hotelRepository.DeleteHotelById(id);
            return Ok();
        }

       /* [HttpPatch("[action]")]
        public async Task<ActionResult> UpdatById(int id, HotelHoteldata request)
        {
            await _hotelRepository.UpdateHotelDetailsById(id, request);
            return Ok();
        }
       */
    }
}
