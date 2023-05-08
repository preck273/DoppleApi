using DoppleApi.Entities;
using DoppleApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace DoppleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructionController : Controller
    {
        private readonly bs39hu6mp56dbv0qContext DoppleDB;
        public InstructionController(bs39hu6mp56dbv0qContext bs39hu6mp56dbv0qContext)
        {
            this.DoppleDB = bs39hu6mp56dbv0qContext;
        }

        // get the intruction by id in either XML or  JSON format
        [HttpGet("GetInstructionById.{format}"), FormatFilter]
        public async Task<ActionResult<InstructionModel>> GetInstructionById(String Id)
        {
            InstructionModel Instructions = await DoppleDB.Instructions.Select(s => new InstructionModel
            {
                InstructionId = s.InstructionId,
                StationId = s.StationId,
                Description = s.Description,
                ImagePath = s.ImagePath,
            }).FirstOrDefaultAsync(s => s.InstructionId == Id);
            if (Instructions == null)
            {
                return null;
            }
            else
            {
                return Instructions;

            }
        }
        // get the intruction by id in either XML or  JSON format
        [HttpGet("GetInstructionByStationId.{format}"), FormatFilter]
        public async Task<ActionResult<InstructionModel>> GetInstructionByStationId(int Id)
        {
            InstructionModel Instructions = await DoppleDB.Instructions.Select(s => new InstructionModel
            {
                InstructionId = s.InstructionId,
                StationId = s.StationId,
                Description = s.Description,
                ImagePath = s.ImagePath,
            }).FirstOrDefaultAsync(s => s.StationId == Id);
            if (Instructions == null)
            {
                return null;
            }
            else
            {
                return Instructions;

            }
        }
        // insert instruction into the database in either XML or  JSON format
        [HttpPost("InsertInstruction.{format}"), FormatFilter]
        public async Task<HttpStatusCode> InsertUser(InstructionModel Instructions)
        {


            // gets existing object with the requested id
            Station stat = DoppleDB.Stations.FirstOrDefault(s => s.StationId == Instructions.StationId);
            var entity = new Instruction()
            {
                InstructionId = Instructions.InstructionId,
                Description = Instructions.Description,
                ImagePath = Instructions.ImagePath,
                StationId = stat.StationId,
            };

            DoppleDB.Instructions.Add(entity);

            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        // deletes intruction based on the id in either XML or  JSON format
        [HttpDelete("DeleteInstruction/{Id}.{format}"), FormatFilter]
        public async Task<HttpStatusCode> DeleteUser(String Id)
        {
            var entity = new Instruction()
            {
                InstructionId = Id,
            };
            DoppleDB.Instructions.Attach(entity);
            DoppleDB.Instructions.Remove(entity);
            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        // updates intruction based on the id in either XML or  JSON format
        [HttpPut("UpdateInstruction.{format}"), FormatFilter]
        public async Task<HttpStatusCode> UpdateUser(InstructionModel Instructions)
        {
            var entity = await DoppleDB.Instructions.FirstOrDefaultAsync(s => s.InstructionId == Instructions.InstructionId);
            entity.InstructionId = Instructions.InstructionId;
            entity.Description = Instructions.Description;
            entity.ImagePath = Instructions.ImagePath;
            entity.StationId = Instructions.StationId;
            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.OK;
        }     
    }
}



