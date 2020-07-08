using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wep.Api.Models.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CityDto> Cities { get; set; }
    }
}