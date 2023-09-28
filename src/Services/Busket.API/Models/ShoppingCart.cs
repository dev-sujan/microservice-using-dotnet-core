namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public string Username { get; set; }

        public ShoppingCart(string username)
        {
            Username = username;
        }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price;
                }
                return totalPrice;
            }
        }


    }
}
