namespace Demo.Core.Services.Orders
{
    public class OrderItemModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the selling price.
        /// </summary>
        public decimal Amount { get; set; }
    }
}