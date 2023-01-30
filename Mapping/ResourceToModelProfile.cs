using AutoMapper;
using Dws.Note_one.Api.Resource;
using Dws.Note_one.Api.Domain.Models;

namespace Dws.Note_one.Api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveStoreResource, Store>();
            CreateMap<DeleteStoreResource, Store>();


        }
    }
}