using cozaStore.Models;

namespace cozaStore.Presentation
{
    public class CartItem
    {
        public int Quantity { get; set; }

        public ProductDetail ProductDetail { get; set; }
        
        public int QuantityReal { get
            {
                return ProductDetail.Quantity;
            } 
        }

        public decimal Total { get { return ProductDetail.Price * Quantity; } }

        
    }
}
