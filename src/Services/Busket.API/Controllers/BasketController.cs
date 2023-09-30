using Basket.API.GrpcServices;
using Basket.API.Models;
using Basket.API.Repositories;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : BaseController
    {
        IBasketRepository _basketRepository;
        DiscountGrpcServvice _discountGrpcServvice;

        public BasketController(IBasketRepository basketRepository, DiscountGrpcServvice discountGrpcServvice)
        {
            _basketRepository = basketRepository;
            _discountGrpcServvice = discountGrpcServvice;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasket(string username)
        {
            try
            {
                var basket = await _basketRepository.GetBasket(username);

                return CustomResult("Basket data load successfully", basket);
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart basket)
        {
            try
            {
                // Calculate latest price after discount
                foreach (var item in basket.Items)
                {
                    var coupon = await _discountGrpcServvice.GetDiscount(item.ProductId);

                    item.Price -= coupon.Amount;
                }

                return CustomResult("Basket modified successfully", await _basketRepository.UpdateBasket(basket));
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string username)
        {
            try
            {
                await _basketRepository.DeleteBasket(username);
                return CustomResult("Basket deleted successfully");
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

    }
}
