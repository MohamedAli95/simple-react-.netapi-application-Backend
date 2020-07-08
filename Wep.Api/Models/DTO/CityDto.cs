using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wep.Api.Models.DTO
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CountryName { get; set; }

        public int CountryID { get; set; }

    }
}