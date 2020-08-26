using System.IO;
using System.Linq;

namespace VEGA.Models
{
    public class PhotoSettings
    {
        public int MaxSize { get; set; }
        public string[] AcceptedFileType { get; set; }
        public bool IsSupported(string fileName){
            return AcceptedFileType.Any(x=>x == Path.GetExtension(fileName));
        }
    }
}