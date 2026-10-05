using AutoMapper;
using ExpendProject.BLL.DTO_S;
using ExpendProject.BLL.DTO_S.Inom_Dto;
using ExpendProject.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Utilites
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapExpense();
        }
        private void MapExpense()
        {
            // Map Expense
            CreateMap<Expense, ExpenseDto>()
                   .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(des => des.Amount, opt => opt.MapFrom(src => src.Amount))
                   .ForMember(des => des.Description, opt => opt.MapFrom(src => src.Description))
                   .ForMember(des => des.Date, opt => opt.MapFrom(src => src.Date))
                   .ReverseMap();

            // map createExpense
            CreateMap<Expense, CreateExpenseDto>()
                   .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                   .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                   .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                   .ReverseMap();

            // map updateExpenes
            CreateMap<Expense, UpDateExpenseDto>()
                   .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                   .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                   .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                   .ReverseMap();

            // map incom  
            CreateMap<Income, IncomDtos>()
                     .ForMember(dest => dest.Name, opt => opt.MapFrom(scr => scr.Name))
                     .ForMember(dest => dest.Date, opt => opt.MapFrom(scr => scr.Date))
                     .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(scr => scr.CreatedAt))
                     .ForMember(dest => dest.Amount, opt => opt.MapFrom(scr => scr.Amount))
                     .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            //map create incom 
            CreateMap<Income, CreateIncomDto>()
                     .ForMember(dest => dest.Name, opt => opt.MapFrom(scr => scr.Name))
                     .ForMember(dest => dest.Date, opt => opt.MapFrom(scr => scr.Date))
                     .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(scr => scr.CreatedAt))
                     .ForMember(dest => dest.Amount, opt => opt.MapFrom(scr => scr.Amount))
                     .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                     .ReverseMap();

            //map UpdateIncom
            CreateMap<Income, CreateIncomDto>()
                     .ForMember(dest => dest.Name, opt => opt.MapFrom(scr => scr.Name))
                     .ForMember(dest => dest.Date, opt => opt.MapFrom(scr => scr.Date))
                     .ForMember(dest => dest.Amount, opt => opt.MapFrom(scr => scr.Amount))
                     .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                     .ReverseMap();











        }
    }
}
