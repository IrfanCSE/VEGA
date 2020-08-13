using System.Collections.Generic;
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
            CreateMap<Vehicle,VehicleDetailsDto>()
                .ForMember(vDto=>vDto.Features,opt=>opt
                .MapFrom(v=>v.Features.Select(f=> new FeatureDto{Id=f.Feature.Id,Name=f.Feature.Name})))
                .ForMember(vDto=>vDto.Make,opt=>opt.MapFrom(v=>v.Model.Make));                

            //DTO To Domain
            CreateMap<MakeDto,Make>();
            CreateMap<ModelDto,Model>();
            CreateMap<VehicleDto,Vehicle>()
                .ForMember(v=>v.Id,opt=>opt.Ignore())
                .ForMember(v=>v.Features,opt=>opt.MapFrom(vd=> vd.Features.Select(id=> new VehicleFeature{FeatureId=id})));
            CreateMap<ContactDto,Contact>();
            CreateMap<VehicleFeatureDto,VehicleFeature>();
            CreateMap<FilterDto,Filter>();

        }
    }
}