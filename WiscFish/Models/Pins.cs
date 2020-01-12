using System;
using Dapper.Contrib.Extensions;

namespace WiscFish.Models
{
    [Table("Pins.dbo.[Pins]")]
    public class Pins
    {        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FishType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Date { get; set; }
    }
}
