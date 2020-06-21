using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFamilyManager.API.Core.Dtos;
using MyFamilyManager.API.Core.Interfaces;

namespace MyFamilyManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(TransactionDto transaction)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _transactionService.SaveTransaction(transaction);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult<TransactionListDto> Get()
        {
           return  _transactionService.GetTransactions();
        }

        [HttpGet("{Id}")]
        public ActionResult<TransactionDto> Get(Guid Id)
        {
           return _transactionService.GetTransaction(Id);
        }
    }
}
