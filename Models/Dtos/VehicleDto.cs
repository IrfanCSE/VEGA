using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace VEGA.Models.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        
        [Required]
        public int MakeId { get; set; }
        
        [Required]
        public int ModelId { get; set; }
        
        // public ModelDto Model { get; set; }
        
        public bool IsRegisterd { get; set; }
        
        [Required]
        public ContactDto Contact { get; set; }

        // public ICollection<VehicleFeatureDto> Features { get; set; }
        public ICollection<int> Features { get; set; }

        public VehicleDto()
        {
        //  Features=new Collection<VehicleFeatureDto>();   
         Features=new Collection<int>();   
        }
    }
}