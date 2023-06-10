using System;
using LabuteCalatoare.DataBase.BaseModel;

namespace LabuteCalatoare.DataBase.TableModels
{
    public partial class Images : BaseDbModel
    {
        public int ImageId { get; set; }
        public string ImageLink { get; set; }
        public string ImageDescription { get; set; }
        public int ImageHotelId { get; set; }

        public virtual HotelData ImageHotel { get; set; }
    }
}
