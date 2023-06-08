using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabuteCalatoare.DataBase.BaseModel;

namespace LabuteCalatoare.DataBase.TableModels
{
    public partial class HotelData : BaseDbModel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public string HotelLink { get; set; }
    }
}
