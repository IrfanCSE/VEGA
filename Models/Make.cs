using System.Collections.Generic;
namespace VEGA.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Model { get; set; }
    }
}