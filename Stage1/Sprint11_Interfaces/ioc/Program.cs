using System;

namespace ioc
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new DatabaseLogger();
            ProductService productService = new ProductService(logger);
            productService.Log("Hello World!");
           
        }
    }
}
