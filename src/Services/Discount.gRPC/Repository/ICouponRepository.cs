using Discount.gRPC.Models;

namespace Discount.gRPC.Repository
{
    public interface ICouponRepository
    {
        Task<Coupon> GetDiscount(string productId);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productId);
    }
}
