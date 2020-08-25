using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace VEGA.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool IsRegisterd { get; set; }
        public Contact Contact { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }

        public Vehicle()
        {
            Features = new Collection<VehicleFeature>();
            Photos = new Collection<Photo>();
        }
    }
}