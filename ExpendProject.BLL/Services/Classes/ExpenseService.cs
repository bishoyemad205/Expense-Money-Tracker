using AutoMapper;
using ExpendProject.BLL.Common;
using ExpendProject.BLL.DTO_S;
using ExpendProject.BLL.Services.Interfces;
using ExpendProject.BLL.Utilites;
using ExpendProject.DAL.Model;
using ExpendProject.DAL.Repository;
using ExpendProject.DAL.Repository.Interfaces;
using Microsoft.IdentityModel.Tokens.Experimental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExpendProject.BLL.Services.Classes
{
    public class ExpenseService : IExpenseService
    {
        private readonly IgenericRepo<Expense , int> _expenseRepo;
        private readonly IMapper mapper;

        public ExpenseService(IgenericRepo<Expense ,int> ExpenseRepo , IMapper mapper)
        {
            _expenseRepo = ExpenseRepo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ExpenseDto>> GetAllExpenseAsync(CancellationToken ct = default)
        {
            var expense = await _expenseRepo.GetAllAsync(false, ct);
            if (!expense.Any())
            {
                return [];
            }
            var AllExpenses = mapper.Map<IEnumerable<Expense> ,  IEnumerable<ExpenseDto>>(expense);
            return AllExpenses;
        }

        public async Task<ExpenseDto> GetExpenseByIdAsync(int id, CancellationToken ct = default)
        {
            var expenese = await _expenseRepo.GetByIdAsync(id, ct);
            if (expenese is null)
            {
                return null;
            }
            var exp = mapper.Map<Expense, ExpenseDto>(expenese);
            return exp;
        }

         
        public async Task<Result> UpDateExpenseAsync(int id, UpDateExpenseDto upDateExpense, CancellationToken ct = default)
        {
            var Expense = await _expenseRepo.GetByIdAsync(id, ct);
            if (Expense is null )
            {
                return Result.NotFound("Expense not found");
            }
            if (upDateExpense.Date > DateTime.Now || upDateExpense.Amount <= 0)
            {
                return Result.Validation("Invalid expense data");
            }

             mapper.Map(upDateExpense, Expense);

            _expenseRepo.UpDate(Expense);
           var result = await _expenseRepo.CompleteAysnc();

            return result > 0 ? Result.ok() : Result.Fail("Faied To Update");
            
             
        }


        public async Task<Result> AddExpensesAsync(CreateExpenseDto createExpense, CancellationToken ct = default)
        {
            var AmountCheck = createExpense.Amount ;
            if (AmountCheck < 0)
            {
                return Result.Fail("Amount is Under Limt");
            }
            var DescropationCheck = createExpense.Description ;
            if (string.IsNullOrWhiteSpace(DescropationCheck))
            {
                return Result.Fail("Expend Descration id Requierd");
            }
            var addexp = mapper.Map<CreateExpenseDto, Expense>(createExpense);
            _expenseRepo.Add(addexp);
            var result = await _expenseRepo.CompleteAysnc();
            return result > 0 ? Result.ok() : Result.Fail("Fail Create Expense");

                
        }

        public async Task<Result> DeleteExpenseAsync(int id, CancellationToken ct = default)
        {
            var removeexp = await _expenseRepo.GetByIdAsync(id,ct);
            if (removeexp is null)
            {
                return Result.NotFound("Not Found Id");
            }
           await _expenseRepo.Delete(id);
            var result = await _expenseRepo.CompleteAysnc();
            return result > 0 ? Result.ok() : Result.Fail("Fail Delete Expense");

        }

      

     

        
    }
}
