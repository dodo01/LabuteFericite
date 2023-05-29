
using System.Threading.Tasks;
using LabuteCalatoare.DataBase.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace LabuteFericite.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public IHotelRepository _hotelRepository;
        public TestController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet("[action]")]
        public async Task<int> Test()
        {
            var result = await _hotelRepository.ReadAsync();
           /* string connString = "server=eu-cdbr-west-03.cleardb.net;uid=b60c578282cd16;pwd=90489d0f;database=heroku_58b8c01ef1cb1bf;";
            MySql.Data.MySqlClient.MySqlConnection myConnection = new MySqlConnection(connString);
            myConnection.Open();
          
            myConnection.Close();*/
            return 1;
        }
    }
}
