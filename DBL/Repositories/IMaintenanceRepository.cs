using DBL.Entities;
using DBL.Models;
using System.Collections.Generic;

namespace DBL.Repositories
{
    public interface IMaintenanceRepository
    {

        #region System Permissions
        IEnumerable<Systempermissions> Getsystempermissiondata();
        Genericmodel Registersystempermissiondata(string jsonObjectdata);
        Systempermissions Getsystempermissiondatabyid(long Permissionid);
        #endregion


        #region System Vehicle Makes
        IEnumerable<Systemvehiclemakes> Getsystemvehiclemakedata();
        Genericmodel Registersystemvehiclemakedata(string jsonObjectdata);
        Systemvehiclemakes Getsystemvehiclemakedatabyid(long Vehiclemakeid);
        #endregion

        #region System Vehicle Models
        IEnumerable<Systemvehiclemodeldata> Getsystemvehiclemodeldata();
        Genericmodel Registersystemvehiclemodeldata(string jsonObjectdata);
        Systemvehiclemodels Getsystemvehiclemodeldatabyid(long Vehiclemodelid);
        #endregion

        #region System Tenants
        IEnumerable<Systemtenantdatamodel> Getsystemtenantdata();
        Genericmodel Registersystemtenantdata(string jsonObjectdata);
        Systemtenants Getsystemtenantdatabyid(long Tenantid);
        #endregion

        #region System Assets
        IEnumerable<Systemassetdatamodel> Getsystemassetsdata();
        Genericmodel Registersystemassetdata(string jsonObjectdata);
        Systemassets Getsystemassetdatabyid(long Assetid);
        #endregion
    }
}
