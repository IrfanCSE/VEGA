using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VEGA.Models.Dtos
{
    public class FeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<VehicleFeatureDto> VehicalFeatures { get; set; }
        public FeatureDto()
        {
            VehicalFeatures = new Collection<VehicleFeatureDto>();
        }
    }
}