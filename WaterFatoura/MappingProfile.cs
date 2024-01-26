using DomainLayer.DTO.Requests;
using DomainLayer.DTO;
using DomainLayer.models;
using AutoMapper;

namespace WaterFatoura
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DTORequest_Default_Slice_Values, Default_Slice_Values>().ReverseMap();
            CreateMap<Default_Slice_Values, DTO_Default_Slice_Values>().ReverseMap();
            //CreateMap<Default_Slice_Values, Default_Slice_Values>().ReverseMap();

            CreateMap<DTORequest_Invoices, Invoices>().ReverseMap();
            CreateMap<Invoices, DTO_Invoices>().ReverseMap();
            //CreateMap<Invoices, Invoices>().ReverseMap();

            CreateMap<DTORequest_Real_Estate_Types, Real_Estate_Types>().ReverseMap();
            CreateMap<Real_Estate_Types, DTO_Real_Estate_Types>().ReverseMap();
            //CreateMap<Real_Estate_Types, Real_Estate_Types>().ReverseMap();

            CreateMap<DTORequest_Subscriber_File, Subscriber_File>().ReverseMap();
            CreateMap<Subscriber_File, DTO_Subscriber_File>().ReverseMap();
            //CreateMap<Subscriber_File, Subscriber_File>().ReverseMap();

            CreateMap<DTORequest_Subscription_File, Subscription_File>().ReverseMap();
            CreateMap<Subscription_File, DTO_Subscription_File>().ReverseMap();
            //CreateMap<Subscription_File, Subscription_File>().ReverseMap();
        }
    }
}
