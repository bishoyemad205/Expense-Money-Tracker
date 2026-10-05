using ExpendProject.BLL.Common;
using ExpendProject.BLL.DTO_S;
using ExpendProject.BLL.Services.Classes;
using ExpendProject.BLL.Services.Interfces;
using ExpendProject.DAL.Model;
using ExpendProject.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpendProject.Controllers
{
   public class ExpenseController : BaseController
   {
        private readonly IExpenseService expenseService;
        private readonly ILogger<ExpenseDto> logger;

        public ExpenseController(IExpenseService expenseService ,  ILogger<ExpenseDto> logger)
        {
            this.expenseService = expenseService;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult>AddExpense( CreateExpenseDto createExpenseDto,CancellationToken ct = default)
        {
            var result = await expenseService.AddExpensesAsync(createExpenseDto, ct);
            if (result.Succes)
            {
                return Ok(result);
            }
           return BadRequest(result.Error);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetExpense(int id, CancellationToken ct = default)
        { 
            var exp = await expenseService.GetExpenseByIdAsync(id,ct);
            if (exp == null)
                return NotFound();
            return new ObjectResult(exp);

        }

        //[HttpGet("confirm-remove/{id}")]
        //public async Task<ActionResult>ConfermRemove(int id, CancellationToken ct = default)
        //{
        //    var exp = await expenseService.GetExpenseByIdAsync(id, ct);
        //    if (exp == null)
        //        return NotFound();
        //    return Ok(exp);

        //}
        [HttpPost("remove/{id}")]
        public async Task<ActionResult>Remove(int id, CancellationToken ct = default)
        {
            var exp = await expenseService.DeleteExpenseAsync(id, ct);
            if (exp.Succes)
                return Ok();
            return BadRequest(exp.Error);

        }
        
        [HttpPost("update/{id}")]
        public async Task<ActionResult> updateExp(int id, UpDateExpenseDto upDateExpense, CancellationToken ct = default)
        {
            var exp = await expenseService.UpDateExpenseAsync(id, upDateExpense , ct);
            if (exp.Succes)
                return new ObjectResult(exp);
            return BadRequest(exp.Error);

        }

   }
}
