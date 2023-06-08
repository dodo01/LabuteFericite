using System.Collections.Generic;
using System.Threading.Tasks;
using LabuteCalatoare.Business.Services.Interfaces;
using LabuteCalatoare.DataBase.TableModels;
using Microsoft.AspNetCore.Mvc;


namespace LabuteFericite.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<HotelData>> GetAll()
        {
            return await _hotelService.GetAll();
        }

        [HttpGet("[action]")]
        public async Task<HotelData> GetById(int id)
        {
            return await _hotelService.GetById(id);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Insert(HotelData requestModel)
        {
            await _hotelService.Insert(requestModel);
            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteById(int id)
        {
            await _hotelService.DeleteById(id);
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
