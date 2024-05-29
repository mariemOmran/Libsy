using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Angular.DTO;
using Project_Angular.Models;
using Project_Angular.UniteOfwork;

namespace Project_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly _uniteOfwork uniteOfWork;

        public OrderDetailsController(_uniteOfwork uniteOfWork)
        {
            this.uniteOfWork = uniteOfWork;
        }
      //  [HttpGet]
        //public IActionResult AddOrder(int userId,int idProduct,int quantity) {

        //    Order orderWithUser = uniteOfWork.Orders.SearchingForSpecificITem(n => n.user_id == userId);
        //    decimal price = uniteOfWork.Clothes.getByID(idProduct).Price;
        //  decimal   totalPriceForPeace = price * quantity;
        //    if (orderWithUser != null)
        //    {
        //        order_details orderDetails = uniteOfWork.Order_detailses.SearchingForSpecificITem(n => n.clothesID == idProduct && n.orderID == orderWithUser.Id);
        //        if (orderDetails != null)
        //        {
        //            orderDetails.quantity = quantity;
        //            orderDetails.price = totalPriceForPeace;
        //        }
        //        else
        //        {
        //            order_details order_Details = new order_details()
        //            {
        //                orderID = orderWithUser.Id,
        //                clothesID = idProduct,
        //                quantity = quantity,
        //                price = totalPriceForPeace,
        //            };
        //            uniteOfWork.Order_detailses.add(order_Details);
        //        }
        //        uniteOfWork.save();

        //    }
        //    else {
        //        orderWithUser = new Order()
        //        {
        //            time = DateTime.Now.TimeOfDay,
        //            user_id = userId,
        //            totalPrice = totalPriceForPeace,
        //        };
        //        uniteOfWork.Orders.add(orderWithUser);
        //        order_details order_Details = new order_details()
        //        {
        //            orderID = orderWithUser.Id,
        //            clothesID = idProduct,
        //            quantity = quantity,
        //            price = totalPriceForPeace,
        //        };
        //        uniteOfWork.Order_detailses.add(order_Details);
        //        uniteOfWork.save();

        //    }

        //    OrderDto orderDto = new OrderDto() {
        //        time = DateTime.Now.TimeOfDay,
        //        totalPrice = orderWithUser.totalPrice,
        //        userName = uniteOfWork.Users.getByID(userId).UserName,
                
        //    };
        //}
   }
}
