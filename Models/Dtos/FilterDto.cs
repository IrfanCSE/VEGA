namespace VEGA.Models.Dtos
{
    public class FilterDto
    {
        public int? MakeId { get; set; }
        public int? ModelId { get; set; }
        public string SortBy { get; set; }
        public bool IsAscending { get; set; }
    }
}