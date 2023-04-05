using ShopifySharp.Filters;
using ShopifySharp;
using ShopifySharp.Lists;

namespace ShopifyExample;

internal class Program {

    static async Task Main(string[] args) {
        await (new Program()).Run();
    }

    private async Task Run() {
        var orders = await GetOpenShopifyOrders();
        foreach(var order in orders.Items) {
            Console.WriteLine(order);
        }
    }

    public async Task<ListResult<ShopifySharp.Order>> GetOpenShopifyOrders() {
        string ShopUrl = "https://skl-home.myshopify.com/admin/api/2022-10/";
        string AccessToken = "shpat"+
                            "_fe3b499e742"
                            +"f97b11362ae"
                            +"4b3fb14388";

        try {
            var orderService = new OrderService(ShopUrl, AccessToken);
            var shopifyOrders = await orderService.ListAsync(new OrderListFilter() { Status = "open", Limit = 250 });
            return shopifyOrders;
        } catch (Exception ex) {
            throw;
        }

    }
}
