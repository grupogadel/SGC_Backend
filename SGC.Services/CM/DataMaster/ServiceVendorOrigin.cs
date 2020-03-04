using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using SGC.InterfaceServices.CM.DataMaster;
using SGC.Entities.Entities.CM.DataMaster;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SGC.Services.CM.DataMaster
{
    public class ServiceVendorOrigin : IServiceVendorOrigin
    {
        private readonly string _context;

        public ServiceVendorOrigin(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/VendorOrigin/GetAllVendors/1
        public async Task<List<VendorOrigin>> GetAllVendors(int idCompany)
        {
            var response = new List<VendorOrigin>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].VendorOrigin_GetAllDistinctByOrigins";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Add(MapToVendorOrigin(reader));
                    }
                }

                cmd.CommandText = "[CM].VendorOrigin_GetAllVendors";

                foreach (var vo in response)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));
                    cmd.Parameters.Add(new SqlParameter("@Orig_ID", vo.Orig_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            vo.Vendors.Add(MapToVendor(dr));
                        }
                    }
                }

                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return response;
                throw e;
            }
        }

        private VendorOrigin MapToVendorOrigin(SqlDataReader reader)
        {
            return new VendorOrigin()
            {
                Orig_ID = (int)reader["Orig_ID"],
                Orig_Name = reader["Orig_Name"].ToString()
            };
        }

        private Vendor MapToVendor(SqlDataReader reader)
        {
            return new Vendor()
            {
                VendorOrig_ID = (int)reader["VendorOrig_ID"],
                Vendor_LastName = (string)reader["Vendor_Name"],
                Vendor_SurName = (string)reader["Vendor_LastName"]
            };
        }
    }

}