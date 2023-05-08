using DoppleApi.Entities;
using DoppleApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace DoppleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {

        private readonly bs39hu6mp56dbv0qContext DoppleDB;

        public OrderController(bs39hu6mp56dbv0qContext bs39hu6mp56dbv0qContext)
        {
            this.DoppleDB = bs39hu6mp56dbv0qContext;
        }
        //get orders by user id in either XML or  JSON format
        [HttpGet("GetOrderById.{format}"), FormatFilter]
        public async Task<ActionResult<OrderModel>> GetOrderById(String Id)
        {
            OrderModel Orders = await DoppleDB.Orders.Select(s => new OrderModel
            {
                OrderId = s.OrderId,
                OrderDate = s.OrderDate,
                FaceplateText = s.FaceplateText,
                EarshellSize = s.EarshellSize,
                EarshellColor = s.EarshellColor,
                CradleColor = s.CradleColor,
                StatusOrder = s.StatusOrder,
            }).FirstOrDefaultAsync(s => s.OrderId == Id);
            if (Orders == null)
            {
                return null;
            }
            else
            {
                return Orders;
            }
        }
        // insert order by id in either XML or  JSON format
        [HttpPost("InsertOrder.{format}"), FormatFilter]
        public async Task<HttpStatusCode> InsertUser(OrderModel Order)
        {
            var entity = new Order()
            {
                OrderId = Order.OrderId,
                OrderDate = Order.OrderDate,
                FaceplateText = Order.FaceplateText,
                EarshellSize = Order.EarshellSize,
                EarshellColor = Order.EarshellColor,
                CradleColor = Order.CradleColor,
                StatusOrder = Order.StatusOrder,
            };
            DoppleDB.Orders.Add(entity);
            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        // delete order by id in either XML or  JSON format
        [HttpDelete("DeleteOrder/{Id}.{format}"), FormatFilter]
        public async Task<HttpStatusCode> DeleteUser(String Id)
        {
            var entity = new Order()
            {
                OrderId = Id,
            };
            DoppleDB.Orders.Attach(entity);
            DoppleDB.Orders.Remove(entity);
            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        // update order by id in either XML or  JSON format
        [HttpPut("UpdateOrder.{format}"), FormatFilter]
        public async Task<HttpStatusCode> UpdateOrder(OrderModel Order)
        {
            var entity = new Order();

            entity.OrderId = Order.OrderId;
            entity.OrderDate = Order.OrderDate; ;
            entity.FaceplateText = Order.FaceplateText;
            entity.EarshellSize = Order.EarshellSize;
            entity.EarshellColor = Order.EarshellColor;
            entity.CradleColor = Order.CradleColor;
            entity.StatusOrder = Order.StatusOrder;


            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

    }
}