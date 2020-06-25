using System;
using System.Collections.Generic;
using System.Text;

namespace IoT.Application.CityAppService.DTO
{
    public class CityGeoDto
    {
        public String status { get; set; }
        public String info { get; set; }
        public String infocode { get; set; }
        public String count { get; set; }
        public List<GeocodeModel> geocodes { get; set; }
    }

    public class GeocodeModel
    {
        public String formatted_address { get; set; }
        public String country { get; set; }
        public String province { get; set; }
        public String citycode { get; set; }
        public String city { get; set; }
        public String location { get; set; }
    }
}
