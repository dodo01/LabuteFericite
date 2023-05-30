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
    public class HotelRepository:  IHotelRepository
    {
        private LabuteCalatoareContext _context;
        public HotelRepository(LabuteCalatoareContext context)
        {
            _context = context;
        }

        public List<HotelHoteldata> GetAllHotels()
        {
            return _context.HotelHoteldata.ToList();
        }

        public HotelHoteldata GetHotelById(int id)
        {
            return _context.HotelHoteldata.FirstOrDefault(item => item.HotelId == id);
        }

        public async Task InsertHotel(HotelHoteldata requestData)
        {
            await _context.HotelHoteldata.AddRangeAsync(requestData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotelById(int id)
        {
            var entry = _context.HotelHoteldata.FirstOrDefault(item => item.HotelId == id);
            if (entry==null)
                throw new Exception("There are no entries to be deleted");

            _context.HotelHoteldata.RemoveRange(entry);
            await _context.SaveChangesAsync();
        }
    }
}
