using DoppleApi.Entities;
using DoppleApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace DoppleApi.Controllers
{
   
    public class TurnOverTimeController : Controller
    {

        private readonly bs39hu6mp56dbv0qContext DoppleDB;
        public TurnOverTimeController(bs39hu6mp56dbv0qContext bs39hu6mp56dbv0qContext)
        {
            this.DoppleDB = bs39hu6mp56dbv0qContext;
        }
        // get turnOverTime by id in either XML or  JSON format
        [HttpGet("GetTurnoOverTimeById.{format}"), FormatFilter]
        public async Task<ActionResult<TurnOverTimeModel>> GetInstructionById(String Id)
        {
            TurnOverTimeModel TurnOverTime = await DoppleDB.Turnovertimes.Select(s => new TurnOverTimeModel
            {

                OrderId = s.OrderId,
                StationId = s.StationId,
                DateStart = s.DateStart,
                TimeStart = s.TimeStart,
                TimeEnd = s.TimeEnd,
            }).FirstOrDefaultAsync(s => s.OrderId == Id);
            if (TurnOverTime == null)
            {
                return null;
            }
            else
            {
                return TurnOverTime;

            }
        }
        // insert turnOverTime in the database in either XML or  JSON format
        [HttpPost("InsertTurnoOverTime.{format}"), FormatFilter]
        public async Task<HttpStatusCode> InsertUser(TurnOverTimeModel TurnOverTime)
        {


            // get existing subject with Id
            Station stat = DoppleDB.Stations.FirstOrDefault(s => s.StationId == TurnOverTime.StationId);
            Order order = DoppleDB.Orders.FirstOrDefault(s => s.OrderId == TurnOverTime.OrderId);
            var entity = new Turnovertime()
            {
                OrderId = order.OrderId,
                StationId = stat.StationId,
                DateStart = TurnOverTime.DateStart,
                TimeStart = TurnOverTime.TimeStart,
                TimeEnd = TurnOverTime.TimeEnd,
            };

            DoppleDB.Turnovertimes.Add(entity);

            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        // deletes turnOverTime in the database based on orderID and stationID in either XML or  JSON format
        [HttpDelete("DeleteTurnoOverTime/{Id}.{format}"), FormatFilter]
        public async Task<HttpStatusCode> DeleteUser(int StationId, String Id)
        {
            var entity = new Turnovertime()
            {
                OrderId = Id,
                StationId = StationId,
            };
            DoppleDB.Turnovertimes.Attach(entity);
            DoppleDB.Turnovertimes.Remove(entity);
            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        // update TurnOverTime based on OrderID and StationID in either XML or  JSON format
        [HttpPut("UpdateTurnoOverTime.{format}"), FormatFilter]
        public async Task<HttpStatusCode> UpdateUser(TurnOverTimeModel TurnOverTime)
        {
            var entity = await DoppleDB.Turnovertimes.FirstOrDefaultAsync(s => s.OrderId == TurnOverTime.OrderId && s.StationId == TurnOverTime.StationId);
            entity.OrderId = TurnOverTime.OrderId;
            entity.StationId = TurnOverTime.StationId;
            entity.DateStart = TurnOverTime.DateStart;
            entity.TimeStart = TurnOverTime.TimeStart;
            entity.TimeEnd = TurnOverTime.TimeEnd;
            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

    }
}


