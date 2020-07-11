using System;
using GlobalDal.Constants;
using GlobalDal.DataObjects;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GlobalEntity;
using GLI.GlobalEntity;

namespace GlobalDal.DataLayer
{
    public class CommonDal : CommonMethods
    {
        IDBManager dbManager = null;
        public CommonDal()
        {
            if (dbManager == null)
                dbManager = new DBManager();
        }

        //public bool Notifications(Masters AR)
        //{
        //    bool _val = false;
        //    try
        //    {
        //        dbManager.Open();
        //        dbManager.BeginTransaction();
        //        dbManager.CreateParameters(7);
        //        dbManager.AddParameters(0, "Id", AR.Id, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(1, "NotificationTitle", AR.Notifications, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(2, "FromDate", AR.FromDate, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(3, "ToDate", AR.ToDate, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(4, "CreatedBy", AR.UserName, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(5, "IpAddress", AR.Ip, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(6, "Action", "I", ParameterDirection.Input, DaoConstants.InParamSize);

        //        Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Notifications"));
        //        if (iResult > 0)
        //        {
        //            dbManager.CommitTransaction();
        //            _val = true;
        //        }
        //        else
        //        {
        //            dbManager.RollBackTransaction();
        //            _val = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        dbManager.Dispose();
        //        dbManager = null;
        //    }
        //    return _val;
        //}

        //public bool Arbitration(Masters AR)
        //{
        //    bool _val = false;
        //    try
        //    {
        //        dbManager.Open();
        //        dbManager.BeginTransaction();
        //        dbManager.CreateParameters(6);
        //        dbManager.AddParameters(0, "Id", AR.Id, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(1, "ArbitrationTitle", AR.ArbitrationTitle, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(2, "ArbitrationDescription", AR.ArbitrationDescription, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(3, "CreatedBy", AR.UserName, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(4, "IpAddress", AR.Ip, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(5, "Action", "I", ParameterDirection.Input, DaoConstants.InParamSize);

        //        Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_GetArbitration"));
        //        if (iResult > 0)
        //        {
        //            dbManager.CommitTransaction();
        //            _val = true;
        //        }
        //        else
        //        {
        //            dbManager.RollBackTransaction();
        //            _val = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        dbManager.Dispose();
        //        dbManager = null;
        //    }
        //    return _val;
        //}

        public List<AdminMenu_DTO> GetArbitrations(AdminMenu_DTO M)
        {
            IDataReader dr = null;
            List<AdminMenu_DTO> lstMenus = new List<AdminMenu_DTO>();
            try
            {
                dbManager.Open();
                AdminMenu_DTO obj = null;
                dbManager.CreateParameters(1);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GetModules");
                while (dr.Read())
                {
                    obj = new AdminMenu_DTO();
                    obj.MenuId = dr["MenuId"] == DBNull.Value ? default(int) : Convert.ToInt32(dr["MenuId"]);
                    obj.MenuName = dr["MenuName"] == DBNull.Value ? string.Empty : dr["MenuName"].ToString();
                    obj.MainMenuId = dr["MainMenuId"] == DBNull.Value ? default(int) : Convert.ToInt32(dr["MainMenuId"]);
                    lstMenus.Add(obj);
                    obj = null;
                }
                dr.Close();
                return lstMenus;
            }
            catch (Exception ex)
            {
                if (dr != null)
                    dr.Close();
                return null;
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                dbManager.Dispose();
                dbManager = null;
            }
        }

        public List<AdminMenu_DTO> GetMenu(AdminMenu_DTO M)
        {
            IDataReader dr = null;
            List<AdminMenu_DTO> lstMenus = new List<AdminMenu_DTO>();
            try
            {
                dbManager.Open();
                AdminMenu_DTO obj = null;
                dbManager.CreateParameters(1);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GetModules");
                while (dr.Read())
                {
                    obj = new AdminMenu_DTO();
                    obj.MenuId = dr["MenuId"] == DBNull.Value ? default(int) : Convert.ToInt32(dr["MenuId"]);
                    obj.MenuName = dr["MenuName"] == DBNull.Value ? string.Empty : dr["MenuName"].ToString();
                    obj.MainMenuId = dr["MainMenuId"] == DBNull.Value ? default(int) : Convert.ToInt32(dr["MainMenuId"]);
                    lstMenus.Add(obj);
                    obj = null;
                }
                dr.Close();
                return lstMenus;
            }
            catch (Exception ex)
            {
                if (dr != null)
                    dr.Close();
                return null;
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                dbManager.Dispose();
                dbManager = null;
            }
        }

        //public bool InsertMediation(ArbitrationDTO AR)
        //{
        //    bool _val = false;
        //    try
        //    {
        //        dbManager.Open();
        //        dbManager.BeginTransaction();
        //        dbManager.CreateParameters(4);
        //        dbManager.AddParameters(0, "MediationTitle", AR.Title, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(1, "MediationDescription", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(2, "Action", 'I', ParameterDirection.Input, DaoConstants.InParamSize);
        //        // dbManager.AddParameters(2, "IpAddress", _accessor.HttpContext.Connection.RemoteIpAddress.ToString(), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(3, "CreatedBy", AR.CreatedBy, ParameterDirection.Input, DaoConstants.InParamSize);
        //        Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Mediation"));
        //        if (iResult > 0)
        //        {
        //            dbManager.CommitTransaction();
        //            _val = true;
        //        }
        //        else
        //        {
        //            dbManager.RollBackTransaction();
        //            _val = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        dbManager.Dispose();
        //        dbManager = null;
        //    }
        //    return _val;
        //}

        public LoginDTO GetLoginDetails(LoginDTO _log)
        {
            LoginDTO _lm = null;
            DataTable dt = null;
            int Id = 0, RoleId = 0;

            dbManager.Open();
            dbManager.CreateParameters(2);
            dbManager.AddParameters(0, "Email", _log.UserName, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(1, "Password", _log.Password, ParameterDirection.Input, DaoConstants.InParamSize);
            dt = dbManager.GetData(CommandType.StoredProcedure, "GLI_ValidateUser");
            _lm = new LoginDTO();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    _lm = new LoginDTO()
                    {
                        Id = Convert.ToInt32(row["ID"].ToString()),
                        UserName = row["UserName"].ToString(),
                        Password = row["Password"].ToString(),
                        Email = row["Email"].ToString(),
                        DisplayName = row["DisplayName"].ToString(),
                        RoleId = Convert.ToInt32(row["RoleId"].ToString()),
                        Status = Convert.ToBoolean(row["Status"].ToString()),
                    };
                }
                //if (dt.Columns["ID"] != null && dt.Columns["ID"].ToString() != "")
                //    int.TryParse(dt.Columns["ID"].ToString(), out Id);
                //_lm.Id = Id;
                //if (dt.Rows[0]["Email"] != null && dt.Rows[0]["Email"].ToString() != "")
                //    _lm.Email = dt.Rows[0]["Email"].ToString();
                //if (dt.Columns["Password"] != null && dt.Columns["Password"].ToString() != "")
                //    _lm.Password = dt.Columns["Password"].ToString();
                //if (dt.Columns["DisplayName"] != null && dt.Columns["DisplayName"].ToString() != "")
                //    _lm.DisplayName = dt.Columns["DisplayName"].ToString();
                //if (dt.Columns["Status"] != null && dt.Columns["Status"].ToString() != "")
                //    _lm.Status = Convert.ToBoolean(dt.Columns["Status"]);
                //if (dt.Columns["RoleId"] != null && dt.Columns["RoleId"].ToString() != "")
                //    int.TryParse(dt.Columns["RoleId"].ToString(), out RoleId);
                //    _lm.RoleId = RoleId;
            }
            else
                _lm.Status = false;
            return _lm;
        }


        //Insert Department
        public bool InsertArbitration(ArbitrationDTO AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "ArbitrationTitle", AR.ArbitrationName, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "ArbitrationDescription", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "Action", 'I', ParameterDirection.Input, DaoConstants.InParamSize);
                // dbManager.AddParameters(2, "IpAddress", _accessor.HttpContext.Connection.RemoteIpAddress.ToString(), ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "CreatedBy", AR.CreatedBy, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_GetArbitration"));
                if (iResult > 0)
                {
                    dbManager.CommitTransaction();
                    _val = true;
                }
                else
                {
                    dbManager.RollBackTransaction();
                    _val = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbManager.Dispose();
                dbManager = null;
            }
            return _val;
        }
    }
}
