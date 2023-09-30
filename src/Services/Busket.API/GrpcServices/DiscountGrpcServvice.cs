using Discount.gRPC.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcServvice
    {
        public readonly DiscountProtoService.DiscountProtoServiceClient _discountService;

        public DiscountGrpcServvice(DiscountProtoService.DiscountProtoServiceClient discountService)
        {
            _discountService = discountService;
        }

        public async Task<CouponRequest> GetDiscount(string productId)
        {
            var getDiscountData = new GetDiscountRequest() { ProductId = productId };
            return await _discountService.GetDiscountAsync(getDiscountData);
        }
    }
}
