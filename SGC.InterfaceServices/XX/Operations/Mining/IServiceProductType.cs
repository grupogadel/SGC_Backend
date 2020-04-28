using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations.Mining
{
    public interface IServiceProductType
    {
        Task<List<ProductType>> GetAll(int id);
        int Add(ProductType model);
        int Update(ProductType model);
        int Delete(JObject obj);
        Task<List<ProductType>> Search(JObject obj);
    }
}

