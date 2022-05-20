using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitiesApp.Model
{
    public class Coords
    {
        [Key]
        [ForeignKey("City")]
        public int Id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
}
