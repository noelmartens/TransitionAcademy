using System;
using System.Collections.Generic;
using System.Text;

namespace ioc
{
    public class ProductService
    {
        
        private readonly ILogger _logger;
        public ProductService(ILogger logger)
        {
            _logger = logger;
        }
        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
