using AutoMapper;
using LeaveMangmentSystem.API.Models.Domain;
using LeaveMangmentSystem.API.Models.DTO;

namespace LAS.API.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LeaveApplication, LeaveApplicationDto>().ReverseMap();
            CreateMap<AddLeaveRequestDto, LeaveApplication>().ReverseMap();
            CreateMap<WFHDto, WfhOof>().ReverseMap();
            CreateMap<WfhOof,AddWFHRequestDto>().ReverseMap();
            CreateMap<WfhOof, UpdateWFHDto>().ReverseMap();
            CreateMap<Balance,BalanceDto>().ReverseMap();
        }
    }
}
