using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.InternalControl.BatchManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.InterfaceServices.CM.InternalControl.BatchManagement
{
    public interface IServiceInternalCtrl
    {
        List<InternalCtrlHeadCommercial> GetAll(int id);
        int AddPuruna(JObject obj);
        int AddReq(JObject obj);
        int AddLabExt(JObject obj);
	    int Delete(JObject obj);
	    List<InternalCtrlHeadCommercial> SearchCommercial(JObject obj);
        List<InternalCtrlHeadCommercial> SearchCommercialInt(JObject obj);
        List<InternalCtrlHeadOperational> SearchOperational(JObject obj);
        List<InternalCtrlHeadOperational> SearchOperationalInt(JObject obj);

        //int Update(SampleDetailsCommercial model);
    }
}
