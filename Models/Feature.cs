using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace VEGA.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<VehicleFeature> VehicalFeatures { get; set; }
        public Feature()
        {
            VehicalFeatures= new Collection<VehicleFeature>();
        }
    }
}