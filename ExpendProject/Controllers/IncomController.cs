using ExpendProject.BLL.Common;
using ExpendProject.BLL.DTO_S.Inom_Dto;
using ExpendProject.BLL.Services.Classes;
using ExpendProject.BLL.Services.Interfces;
using ExpendProject.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExpendProject.Controllers
{
    
    public class IncomController : BaseController
    {
        private readonly IIncomServices incomServices;
        private readonly ILogger<IncomController> logger;

        public IncomController(IIncomServices incomServices , ILogger<IncomController> logger)
        {
            this.incomServices = incomServices;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllIncom(CancellationToken ct = default)
        {
            var result = await incomServices.GetAllIncom(ct);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id, CancellationToken ct = default)
        {
            var incomid = await incomServices.GetByIdAsync(id ,ct);
            if (incomid is null)
                return NotFound();

            return Ok(incomid);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateIncom(UpDateIncomDto upDateIncomDto , int id, CancellationToken ct = default)
        {
            var update = await incomServices.UpDateIncom(upDateIncomDto, id , ct);
            if (update.Succes)
                return Ok(update);

            if (update.kind == Resultkind.NotFound)
                return NotFound(update.Error);

            return BadRequest(update.Error);

        }
        [HttpPost]
        public async Task<ActionResult> Createincom(CreateIncomDto createIncomDto, CancellationToken ct = default)
        { 
          var incomadd = await incomServices.AddIncom(createIncomDto, ct);
            if(incomadd.Succes)
                return Ok(incomadd);

            return BadRequest(incomadd.Error);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIncome(int id,CancellationToken ct= default) 
        {
            var result = await incomServices.DeleteIncom(id, ct);

            if (result.Succes)
                return Ok(result);

            if (result.kind == Resultkind.NotFound)
                return NotFound(result.Error);

            return BadRequest(result.Error);
        }
    }

    
}
