using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wep.Api.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int Id { get; set; }

        
        public string Name { get; set; }

        

        public virtual List<City> Cities { get; set; }


    }
}