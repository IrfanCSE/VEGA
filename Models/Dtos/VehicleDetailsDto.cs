using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VEGA.Models.Dtos
{
    public class VehicleDetailsDto
    {
        public int Id { get; set; }
        public ModelDto Model { get; set; }
        public MakeDto Make { get; set; }
        public bool IsRegisterd { get; set; }
        public ContactDto Contact { get; set; }
        public ICollection<FeatureDto> Features { get; set; }

        public VehicleDetailsDto()
        {
            Features = new Collection<FeatureDto>();
        }
    }
}