using DoppleApi.Entities;
using DoppleApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace DoppleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperatorController : Controller
    {

        private readonly bs39hu6mp56dbv0qContext DoppleDB;

        public OperatorController(bs39hu6mp56dbv0qContext bs39hu6mp56dbv0qContext)
        {
            this.DoppleDB = bs39hu6mp56dbv0qContext;
        }
        // get operator by id in either XML or  JSON format
        [HttpGet("GetOperatorById.{format}"), FormatFilter]
        public async Task<ActionResult<OperatorModel>> GetOrderById(String Id)
        {
            OperatorModel Operator = await DoppleDB.Operators.Select(s => new OperatorModel
            {
                OperatorId = s.OperatorId,
                Username = s.Username,
                Password = s.Password,
                Authorization = s.Authorization,

            }).FirstOrDefaultAsync(s => s.OperatorId == Id);
            if (Operator == null)
            {
                return null;
            }
            else
            {
                return Operator;
            }
        }
        // insert operator in the database either XML or  JSON format
        [HttpPost("InsertOperator.{format}"), FormatFilter]
        public async Task<HttpStatusCode> InsertUser(OperatorModel Operator)
        {

            var entity = new Operator()
            {
                OperatorId = Operator.OperatorId,
                Username = Operator.Username,
                Password = Operator.Password,
                Authorization = Operator.Authorization,

            };

            DoppleDB.Operators.Add(entity);

            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        // delete operator from the database either XML or  JSON format
        [HttpDelete("DeleteOperator/{Id}.{format}"), FormatFilter]
        public async Task<HttpStatusCode> DeleteUser(String Id)
        {
            var entity = new Operator()
            {
                OperatorId = Id,
            };
            DoppleDB.Operators.Attach(entity);
            DoppleDB.Operators.Remove(entity);
            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        // update operator in the database either XML or  JSON format
        [HttpPut("UpdateOperator.{format}"), FormatFilter]
        public async Task<HttpStatusCode> UpdateOrder(OperatorModel Operator)
        {
            var entity = await DoppleDB.Operators.FirstOrDefaultAsync(s => s.OperatorId == Operator.OperatorId);

            entity.OperatorId = Operator.OperatorId;
            entity.Username = Operator.Username;
            entity.Password = Operator.Password;
            entity.Authorization = Operator.Authorization;

            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


    }
}