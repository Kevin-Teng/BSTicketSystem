using BSTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTicketSystem.Interface
{
    public interface IProductService
    {
        IResult Create(Product instance);
        IResult Update(Product instance);
        IResult Delete(int productId);
        bool IsExists(int productId);
        Product GetById(int productId);
        IEnumerable<Product> GetAll();
    }
}
