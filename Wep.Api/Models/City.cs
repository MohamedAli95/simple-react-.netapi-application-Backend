using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wep.Api.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Country country { get; set; }

    }
}