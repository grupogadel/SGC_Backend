using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations.Mining
{
    public interface IServiceMaterialType
    {
        Task<List<MaterialType>> GetAll(int id);
        int Add(MaterialType model);
        int Update(MaterialType model);
        int Delete(JObject obj);
        MaterialType Get(int id);
        MaterialType GetCod(String cod);
        Task<List<MaterialType>> Search(JObject obj);
    }
}
