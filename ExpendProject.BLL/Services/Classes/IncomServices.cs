using AutoMapper;
using ExpendProject.BLL.Common;
using ExpendProject.BLL.DTO_S.Inom_Dto;
using ExpendProject.BLL.Services.Interfces;
using ExpendProject.DAL.Model;
using ExpendProject.DAL.Repository.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Services.Classes
{
    public class IncomServices : IIncomServices
    {
        private readonly IgenericRepo<Income, int> igenericRepo;
        private readonly IMapper mapper;

        public IncomServices(IgenericRepo<Income, int> igenericRepo , IMapper mapper )
        {
            this.igenericRepo = igenericRepo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<IncomDtos>> GetAllIncom(CancellationToken ct = default)
        {
            var incom = await igenericRepo.GetAllAsync(false, ct);
            if (!incom.Any())
            {
                return [];
            }
            var AllIncom =  mapper.Map<IEnumerable<Income> , IEnumerable<IncomDtos>>(incom);
            return AllIncom; 

        }


        public async Task<IncomDtos?> GetByIdAsync(int id, CancellationToken ct = default)
        {
           var incom = await igenericRepo.GetByIdAsync(id, ct);
            if (incom is null)
                return null;
            var AllIncom = mapper.Map<Income, IncomDtos>(incom);
            return AllIncom;

        }

        public async Task<Result> AddIncom(CreateIncomDto createIncomDto, CancellationToken ct = default)
        {
            var amount = createIncomDto.Amount;
            if (amount <= 0)
            {
                return Result.Fail("This Amount less than limt");
            }
            if (string.IsNullOrWhiteSpace(createIncomDto.Description) ||
                string.IsNullOrWhiteSpace( createIncomDto.Name))
            {
                return Result.Fail("This is Requird");

            }
            var Addincom = mapper.Map<CreateIncomDto , Income>(createIncomDto);
            igenericRepo.Add(Addincom);
            var result = await igenericRepo.CompleteAysnc();
            return result > 0? Result.ok() : Result.Fail("Failed Add Incom");
        }

        public async Task<Result> UpDateIncom(UpDateIncomDto upDateIncomDto, int id, CancellationToken ct = default)
        {
            var incomid = await igenericRepo.GetByIdAsync(id, ct);
            if(incomid is null)
            {
                return Result.NotFound("Incom NotFound ");
            }

            if (upDateIncomDto.Date > DateTime.Now)
            {
                return Result.Validation("A Date Not Valid");
            }

            if (upDateIncomDto.Amount <= 0)
            {
                return Result.Validation("Amount must be greater than zero");
            }

            if (string.IsNullOrWhiteSpace(upDateIncomDto.Description))
            {
                return Result.Validation("Description is required");
            }

            if (string.IsNullOrEmpty(upDateIncomDto.Name))
            {
                return Result.Fail("The Name Requird");
            }
            mapper.Map(upDateIncomDto, incomid);
            igenericRepo.UpDate(incomid);
            var result = await igenericRepo.CompleteAysnc();
            return result > 0? Result.ok():Result.Fail("Failed UpDate incom");
        }


        public async Task<Result> DeleteIncom(int id, CancellationToken ct = default)
        {
            var incomid = await igenericRepo.GetByIdAsync(id, ct);
            if (incomid is null)
            {
                return Result.NotFound("Incom NotFound ");
         
            }
          await igenericRepo.Delete(id);
            var result = await igenericRepo.CompleteAysnc();
            return result > 0 ? Result.ok() : Result.Fail("Failed Delete"); 


        }

      

      
    }
    
}
