using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace VEGA.Models.Dtos
{
    public class MakeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelDto> Model { get; set; }
        public MakeDto()
        {
            Model= new Collection<ModelDto>();
        }
    }
}