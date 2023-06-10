using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabuteCalatoare.DataBase.BaseModel;

namespace LabuteCalatoare.DataBase.TableModels
{
    public partial class HotelData : BaseDbModel
    {
        public HotelData()
        {
            Images = new HashSet<Images>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public string HotelLink { get; set; }
        public string HotelAddress { get; set; }
        public string HotelCity { get; set; }
        public string HotelEmail { get; set; }
        public string HotelPhoneNumber { get; set; }
        public int HotelPriceFrom { get; set; }
        public int? HotelPriceMax { get; set; }
        public int? HotelAvalableRooms { get; set; }
        public bool? HotelHasWebcam { get; set; }
        public bool? HotelHasTransport { get; set; }
        public bool HotelForDogs { get; set; }
        public bool HotelForCats { get; set; }
        public bool? HotelForOtherAnimals { get; set; }
        public DateTime? HotelCreatedDt { get; set; }
        public DateTime? HotelModifiedDt { get; set; }

        public virtual ICollection<Images> Images { get; set; }
    }
}
