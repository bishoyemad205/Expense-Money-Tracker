using ExpendProject.BLL.Common;
using ExpendProject.BLL.DTO_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Services.Interfces
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDto>> GetAllExpenseAsync(CancellationToken ct = default);
        Task<ExpenseDto> GetExpenseByIdAsync(int id, CancellationToken ct = default);
        Task<Result> AddExpensesAsync(CreateExpenseDto createExpense, CancellationToken ct = default);
        Task<Result> UpDateExpenseAsync( int id,UpDateExpenseDto upDateExpense,  CancellationToken ct = default);
        Task<Result> DeleteExpenseAsync(int id, CancellationToken ct = default);
       
      
    }
}
