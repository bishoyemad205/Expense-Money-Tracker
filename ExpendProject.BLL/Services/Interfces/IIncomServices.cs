using ExpendProject.BLL.Common;
using ExpendProject.BLL.DTO_S.Inom_Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Services.Interfces
{
    public interface IIncomServices
    {
        Task<IEnumerable<IncomDtos>> GetAllIncom(CancellationToken ct = default);
        Task<IncomDtos?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Result> UpDateIncom(UpDateIncomDto upDateIncomDto,int id, CancellationToken ct = default);
        Task<Result> AddIncom(CreateIncomDto createIncomDto, CancellationToken ct = default);
        Task<Result> DeleteIncom(int id, CancellationToken ct = default);

    }
}
