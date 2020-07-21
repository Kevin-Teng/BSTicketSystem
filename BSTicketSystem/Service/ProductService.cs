using BSTicketSystem.Interface;
using BSTicketSystem.Models;
using BSTicketSystem.Repository;
using BSTicketSystem.Service.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSTicketSystem.Service
{
    public class ProductService : IProductService
    {
        private IRepository<Product> repository = new GenericRepository<Product>();
        public IResult Create(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this.repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int productId)
        {
            IResult result = new Result(false);

            if (!IsExists(productId))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = GetById(productId);
                repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(int productId)
        {
            return repository.GetAll().Any(x => x.Id == productId);
        }

        public Product GetById(int productId)
        {
            return repository.Get(x => x.Id == productId);
        }

        public IEnumerable<Product> GetAll()
        {
            return this.repository.GetAll();
        }
    }
}