using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabuteCalatoare.DataBase.BaseModel;

namespace LabuteCalatoare.DataBase.TableModels
{
    [Table("hotel.hoteldata")]
    public class HotelHoteldata : BaseDbModel
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelsLink { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelCity { get; set; }
        public string HotelEmail { get; set; }
        public string HotelPhoneNumber { get; set; }
        public int HotelPriceFrom { get; set; }
        public int? HotelPriceTo { get; set; }
        public int? HotelAvailableRooms { get; set; }
        public byte HotelHasWebcam { get; set; }
        public byte? HotelHasTransport { get; set; }
        public byte HotelForDogs { get; set; }
        public byte HotelForCats { get; set; }
        public byte? HotelForOtherAnimals { get; set; }
        public string HotelExtraActivities { get; set; }
        public string HotelDescription { get; set; }
        public string HotelPicture1 { get; set; }
        public string HotelPicture2 { get; set; }
        public string HotelPicture3 { get; set; }
    }
}
