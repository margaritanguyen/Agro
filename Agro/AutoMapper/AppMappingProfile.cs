using Agro.DataAccess.Entities;
using Agro.Models;
using AutoMapper;

namespace Agro.AutoMapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<AnimalGroup, AnimalGroupViewModel>().ReverseMap();
            CreateMap<ArchiveMessage, ArchiveMessageViewModel>().ReverseMap();
            CreateMap<Area, AreaViewModel>().ReverseMap();
            CreateMap<Balance, BalanceViewModel>().ReverseMap();
            CreateMap<DosingTask, DosingTaskViewModel>().ReverseMap();
            CreateMap<DosingTask, DosingTaskEditViewModel>().ReverseMap();
            CreateMap<DosingTask, DosingTaskCreateViewModel>().ReverseMap();
            CreateMap<DosingType, DosingTypeViewModel>().ReverseMap();
            CreateMap<ProductRecipe,ProductRecipeViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductEditViewModel>().ReverseMap();
            CreateMap<RecipeIngredient, RecipeIngredientViewModel>().ReverseMap();
            CreateMap<ResourceType, ResourceTypeViewModel>().ReverseMap();
            CreateMap<Resource, ResourceViewModel>().ReverseMap();
            CreateMap<SiloType, SiloTypeViewModel>().ReverseMap();
            CreateMap<Silo, SiloViewModel>().ReverseMap();
            CreateMap<TaskMessage, TaskMessageViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();

            CreateMap<BatchReport, BatchReportViewModel>().ReverseMap();
            CreateMap<TechCardReport, TechCardReportViewModel>().ReverseMap();
        }
    }
}