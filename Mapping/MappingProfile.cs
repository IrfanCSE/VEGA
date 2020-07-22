using System.Security.Cryptography.X509Certificates;
using System.Linq;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using VEGA.Models;
using VEGA.Models.Dtos;
namespace VEGA.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain To DTO
            CreateMap<Make,MakeDto>();
            CreateMap<Model,ModelDto>();
            CreateMap<Vehicle,VehicleDto>();
            CreateMap<Contact,ContactDto>();
            CreateMap<VehicleFeature,VehicleFeatureDto>();
                

            //DTO To Domain
            CreateMap<MakeDto,Make>();
            CreateMap<ModelDto,Model>();
            CreateMap<VehicleDto,Vehicle>()
                .ForMember(v=>v.Id,opt=>opt.Ignore());
            CreateMap<ContactDto,Contact>();
            CreateMap<VehicleFeatureDto,VehicleFeature>();

        }
    }
}