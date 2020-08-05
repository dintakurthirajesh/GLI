using System;
using GlobalDal.Constants;
using GlobalDal.DataObjects;
using System.Collections.Generic;
using System.Data;
using GLI.GlobalEntity;
using System.Web;

namespace GlobalDal.DataLayer
{
    public class CommonDal : CommonMethods
    {
        IDBManager dbManager = null;
<<<<<<< HEAD

        string Ip = HttpContext.Current.Request.UserHostAddress;

=======
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975
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


        public bool ExceptionDtls(string strMessage, string strType, string Trace)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "ExceptionMsg", strMessage, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "ExceptionType", strType, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "ExceptionSource", Trace, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "ExceptionURL", "", ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(4, "UserName", "SubMenu", ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(5, "IPAddress", HttpContext.Current.Request.UserHostAddress, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "ExceptionLoggingToDataBase"));
                _val = true;
                dbManager.CommitTransaction();
            }
            catch (Exception ex1)
            {
                dbManager.RollBackTransaction();
            }

            finally
            {
                dbManager.Dispose();
                dbManager = null;
            }
            return _val;
        }

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
                        // MemberShipId = Convert.ToInt32(row["MemberShipId"].ToString()),
                        //MemberShipId = DBNull.Value ? default(int) : Convert.ToInt32(row["MenuId"],
                        MemberShipId = row["MemberShipId"] == DBNull.Value ? default(int) : Convert.ToInt32(row["MemberShipId"]),
                    };
                }
            }
            else
                _lm.Status = false;
            return _lm;
        }

<<<<<<< HEAD

        /*Insert Arbitration*/
=======
        #region Arbitration
        //Insert Department
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975
        public bool InsertArbitration(ArbitrationDTO AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "ArbitrationTitle", AR.Title, ParameterDirection.Input, DaoConstants.InParamSize);
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

        public List<ArbitrationDTO> GetArbitration()
        {
            IDataReader dr = null;
            List<ArbitrationDTO> _lst = null;
            ArbitrationDTO obj = null;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "Action", "R", ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_GetArbitration");
                _lst = new List<ArbitrationDTO>();
                while (dr.Read())
                {
                    obj = new ArbitrationDTO();
                    obj.Id = Convert.ToInt32((dr["Id"]));
                    obj.Title = ((dr["ArbitrationTitle"]).ToString());
                    obj.Description = ((dr["ArbitrationDescription"]).ToString());
                    _lst.Add(obj);

                }
                dr.Close();
                return _lst;
            }
            catch
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
                obj = null;
            }
        }

        #region GetArbitrationById
        public ArbitrationDTO GetArbitrationById(int Id, char val)
        {
            IDataReader dr = null;
            ArbitrationDTO _ld = null;
            val = 'E';
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Action", val, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Id", Id, ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_GetArbitration");
                while (dr.Read())
                {
                    _ld = new ArbitrationDTO();
                    _ld.ArbitrationId = Convert.ToInt32((dr["Id"]));
                    _ld.ArbitrationName = ((dr["ArbitrationTitle"]).ToString());
                    _ld.Description = ((dr["ArbitrationDescription"]).ToString());

                }
                dr.Close();
                return _ld;
            }
            catch
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
        #endregion

        #region UpdateArbitration
        public bool UpdateArbitration(ArbitrationDTO AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "Id", AR.ArbitrationId, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "ArbitrationTitle", AR.ArbitrationName, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "ArbitrationDescription", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "Action", 'U', ParameterDirection.Input, DaoConstants.InParamSize);
                // dbManager.AddParameters(2, "IpAddress", _accessor.HttpContext.Connection.RemoteIpAddress.ToString(), ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(4, "CreatedBy", AR.CreatedBy, ParameterDirection.Input, DaoConstants.InParamSize);
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
        #endregion
<<<<<<< HEAD

=======
        #endregion
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975

        #region DeleteArbitration
        public bool DeleteArbitration(int id, string R)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Id", id, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Action", R, ParameterDirection.Input, DaoConstants.InParamSize);
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
        #endregion

        #region Mediation
        #region GetMediation
        public List<ArbitrationDTO> GetMediation()
        {
            IDataReader dr = null;
            List<ArbitrationDTO> _lst = null;
            ArbitrationDTO obj = null;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "Action", 'R', ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_Mediation");
                _lst = new List<ArbitrationDTO>();

                while (dr.Read())
                {
                    obj = new ArbitrationDTO();
                    obj.Id = Convert.ToInt32((dr["Id"]));
                    obj.Title = ((dr["MediationTitle"]).ToString());
                    obj.Description = ((dr["MediationDescription"]).ToString());
                    _lst.Add(obj);
                }
                dr.Close();
                return _lst;
            }
            catch
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
        #endregion
        #region GetMediationById
        public ArbitrationDTO GetMediationById(int Id, char val)
        {
            IDataReader dr = null;
            ArbitrationDTO _ld = null;
            val = 'E';
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Action", val, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Id", Id, ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_Mediation");
                while (dr.Read())
                {
                    _ld = new ArbitrationDTO();
                    _ld.Id = Convert.ToInt32((dr["Id"]));
                    _ld.Title = ((dr["MediationTitle"]).ToString());
                    _ld.Description = ((dr["MediationDescription"]).ToString());
                }
                dr.Close();
                return _ld;
            }
            catch
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
        #endregion

        #region UpdateMediations
        //Update Mediations
        public bool UpdateMediations(ArbitrationDTO AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "Id", AR.Id, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "MediationTitle", AR.Title, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "MediationDescription", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "Action", 'U', ParameterDirection.Input, DaoConstants.InParamSize);
                // dbManager.AddParameters(2, "IpAddress", _accessor.HttpContext.Connection.RemoteIpAddress.ToString(), ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(4, "CreatedBy", AR.CreatedBy, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Mediation"));
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
        #endregion

        #region DeleteMediations
        public bool DeleteMediations(int id, string R)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Id", id, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Action", R, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Mediation"));
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
        #endregion
        #endregion

        #region Concillation
        //Insert Concillation
        #region InsertConcillation
        public bool InsertConcillation(ArbitrationDTO AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "ConcillationTitle", AR.Title, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "ConcillationDescription", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "Action", 'I', ParameterDirection.Input, DaoConstants.InParamSize);
                // dbManager.AddParameters(2, "IpAddress", _accessor.HttpContext.Connection.RemoteIpAddress.ToString(), ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "CreatedBy", AR.CreatedBy, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Concillation"));
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
        #endregion

        #region GetConcillation
        //To Get Concillation
        public List<ArbitrationDTO> GetConcillation()
        {
            IDataReader dr = null;
            ArbitrationDTO _obj = null;
            List<ArbitrationDTO> _lst = null;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "Action", 'R', ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_Concillation");
                _lst = new List<ArbitrationDTO>();
                while (dr.Read())
                {
                    _obj = new ArbitrationDTO();
                    _obj.Id = Convert.ToInt32((dr["Id"]));
                    _obj.Title = ((dr["ConcillationTitle"]).ToString());
                    _obj.Description = ((dr["ConcillationDescription"]).ToString());
                    _lst.Add(_obj);
                }
                dr.Close();
                return _lst;
            }
            catch
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
        #endregion

        #region DeleteConcillation
        public bool DeleteConcillation(int id, string R)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Id", id, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Action", R, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Concillation"));
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
        #endregion
        #endregion

        #region CopyRights
        #region InsertCopyRights
        //Insert InsertCopyRights
        public bool InsertCopyRights(ArbitrationDTO AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "CopyRightsTitle", AR.Title, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "CopyRightsDescription", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "Action", 'I', ParameterDirection.Input, DaoConstants.InParamSize);
                // dbManager.AddParameters(2, "IpAddress", _accessor.HttpContext.Connection.RemoteIpAddress.ToString(), ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "CreatedBy", AR.CreatedBy, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_CopyRights"));
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
        #endregion
        #region GetCopyRights
        //To Get CopyRights
        public List<ArbitrationDTO> GetCopyRights()
        {
            IDataReader dr = null;
            ArbitrationDTO _obj = null;
            List<ArbitrationDTO> _lst = null;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "Action", 'R', ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_CopyRights");
                _lst = new List<ArbitrationDTO>();
                while (dr.Read())
                {
                    _obj = new ArbitrationDTO();
                    _obj.Id = Convert.ToInt32((dr["Id"]));
                    _obj.Title = ((dr["Title"]).ToString());
                    _obj.Description = ((dr["Description"]).ToString());
                    _lst.Add(_obj);
                }
                dr.Close();
                return _lst;
            }
            catch
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
        #endregion

        #region DeleteCopyRights
        public bool DeleteCopyRights(int id, string R)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Id", id, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Action", R, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_CopyRights"));
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
        #endregion
        #endregion

        #region TradeMarks
        #region InsertTradeMarks
        public bool InsertTradeMarks(ArbitrationDTO AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "TradeMarksTitle", AR.Title, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "TradeMarksDescription", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "Action", 'I', ParameterDirection.Input, DaoConstants.InParamSize);
                // dbManager.AddParameters(2, "IpAddress", _accessor.HttpContext.Connection.RemoteIpAddress.ToString(), ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "CreatedBy", AR.CreatedBy, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_TradeMarks"));
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
        #endregion

        #region GetTradeMarks
        //To Get Mediations
        public List<ArbitrationDTO> GetTradeMarks()
        {
            IDataReader dr = null;
            ArbitrationDTO _ld = null;
            List<ArbitrationDTO> _lst = new List<ArbitrationDTO>();
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "Action", 'R', ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_TradeMarks");
                while (dr.Read())
                {
                    _ld = new ArbitrationDTO();
                    _ld.Id = Convert.ToInt32((dr["Id"]));
                    _ld.Title = ((dr["TradeMarksTitle"]).ToString());
                    _ld.Description = ((dr["TradeMarksDescription"]).ToString());
                    _lst.Add(_ld);
                }
                dr.Close();
                return _lst;
            }
            catch
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
        #endregion

        #region InsertContactUs
        //Insert Department
        public bool InsertContactUs(ContactUs AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "Name", AR.FirstName + " " + AR.LastName, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Email", AR.Email, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "PhoneNo", AR.Mobile, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "Description", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_ContactUs"));
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
        #endregion

        #region InsertImageGallery
        //Insert Mediation
        public bool InsertImageGallery(ImageGallery AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "FileName", AR.FileName, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "FileContent", AR.FileContent, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "FileUrl", AR.UploadUrl, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "FileExt", AR.FileExt, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(4, "Action", 'I', ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_ImageGallery"));
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
        #endregion

        #region GetGallery
        //Get Gallery
        public List<Gallery> GetGallery(Char Val)
        {
            IDataReader dr = null;
            Gallery _ld = null;
            List<Gallery> _lst = new List<Gallery>();
            Val = 'R';
            try
            {

                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "Action", Val, ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_ImageGallery");
                while (dr.Read())
                {
                    _ld = new Gallery();
                    _ld.ID = Convert.ToInt32((dr["Sno"]));
                    _ld.FileName = ((dr["FileName"]).ToString());
                    _lst.Add(_ld);
                }
                dr.Close();
                return _lst;
            }
            catch
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
        #endregion
        #endregion

        #region Negotiation
        #region InsertNegotiation
        //Insert Negotiation
        public bool InsertNegotiation(ArbitrationDTO AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "NegotiationTitle", AR.Title, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "NegotiationDescription", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "Action", 'I', ParameterDirection.Input, DaoConstants.InParamSize);
                // dbManager.AddParameters(2, "IpAddress", _accessor.HttpContext.Connection.RemoteIpAddress.ToString(), ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "CreatedBy", AR.CreatedBy, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Negotiation"));
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
        #endregion

        #region GetNegotiation
        //To Get Negotiation
        public List<ArbitrationDTO> GetNegotiation()
        {
            IDataReader dr = null;
            ArbitrationDTO _obj = null;
            List<ArbitrationDTO> _lst = null;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "Action", 'R', ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_Negotiation");
                _lst = new List<ArbitrationDTO>();
                while (dr.Read())
                {
                    _obj = new ArbitrationDTO();
                    _obj.Id = Convert.ToInt32((dr["Id"]));
                    _obj.Title = ((dr["NegotiationTitle"]).ToString());
                    _obj.Description = ((dr["NegotiationDescription"]).ToString());
                    _lst.Add(_obj);
                }
                dr.Close();
                return _lst;
            }
            catch
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
        #endregion

        #region DeleteNegotiation
        public bool DeleteNegotiation(int id, string R)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Id", id, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Action", R, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Negotiation"));
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
        #endregion
        #endregion

        //public LoginDTO GetLoginDetails(LoginDTO _log)
        //{
        //    LoginDTO _lm = null;
        //    DataTable dt = null;
        //    int Id = 0, RoleId = 0;

        //    dbManager.Open();
        //    dbManager.CreateParameters(2);
        //    dbManager.AddParameters(0, "Email", _log.UserName, ParameterDirection.Input, DaoConstants.InParamSize);
        //    dbManager.AddParameters(1, "Password", _log.Password, ParameterDirection.Input, DaoConstants.InParamSize);
        //    dt = dbManager.GetData(CommandType.StoredProcedure, "GLI_ValidateUser");
        //    _lm = new LoginDTO();
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            _lm = new LoginDTO()
        //            {
        //                Id = Convert.ToInt32(row["ID"].ToString()),
        //                UserName = row["UserName"].ToString(),
        //                Password = row["Password"].ToString(),
        //                Email = row["Email"].ToString(),
        //                DisplayName = row["DisplayName"].ToString(),
        //                RoleId = Convert.ToInt32(row["RoleId"].ToString()),
        //                Status = Convert.ToBoolean(row["Status"].ToString()),
        //            };
        //        }
        //        //if (dt.Columns["ID"] != null && dt.Columns["ID"].ToString() != "")
        //        //    int.TryParse(dt.Columns["ID"].ToString(), out Id);
        //        //_lm.Id = Id;
        //        //if (dt.Rows[0]["Email"] != null && dt.Rows[0]["Email"].ToString() != "")
        //        //    _lm.Email = dt.Rows[0]["Email"].ToString();
        //        //if (dt.Columns["Password"] != null && dt.Columns["Password"].ToString() != "")
        //        //    _lm.Password = dt.Columns["Password"].ToString();
        //        //if (dt.Columns["DisplayName"] != null && dt.Columns["DisplayName"].ToString() != "")
        //        //    _lm.DisplayName = dt.Columns["DisplayName"].ToString();
        //        //if (dt.Columns["Status"] != null && dt.Columns["Status"].ToString() != "")
        //        //    _lm.Status = Convert.ToBoolean(dt.Columns["Status"]);
        //        //if (dt.Columns["RoleId"] != null && dt.Columns["RoleId"].ToString() != "")
        //        //    int.TryParse(dt.Columns["RoleId"].ToString(), out RoleId);
        //        //    _lm.RoleId = RoleId;
        //    }
        //    else
        //        _lm.Status = false;
        //    return _lm;
        //}

        public bool MemberShip(MemberShip M)
        {
            IDataReader dr = null;
            bool _val = false;

            dbManager.Open();
            dbManager.BeginTransaction();
            dbManager.CreateParameters(20);
            dbManager.AddParameters(0, "Id", M.Id, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(1, "Name", M.Name, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(2, "FatherName", M.FatherName, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(3, "DOB", M.DOB, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(4, "Nationality", M.Nationality, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(5, "Qualification", M.Qualification, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(6, "Address", M.Address, ParameterDirection.Input, DaoConstants.InParamSize);

            dbManager.AddParameters(7, "City", M.City, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(8, "Pin", M.Pin, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(9, "PhoneNo", M.PhoneNo, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(10, "Email", M.Email, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(11, "MobileNo", M.MobileNo, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(12, "Profession", M.Profession, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(13, "OtherDetails", M.OtherDetails, ParameterDirection.Input, DaoConstants.InParamSize);

            dbManager.AddParameters(14, "PhotoName", M.PhotoName, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(15, "PhotoType", M.PhotoType, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(16, "Ip", M.Ip, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(17, "Action", "I", ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(18, "Password", M.Password, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(19, "Country", M.Country, ParameterDirection.Input, DaoConstants.InParamSize);

            Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_MemberShipForm"));
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
            return _val;
        }

        public List<MemberShip> GetMemberShip(string memberShipId)
        {
            IDataReader dr = null;
            MemberShip _ld = null;
            List<MemberShip> _lst = new List<MemberShip>();

            var Val = 'R';
            Int64 intPhoneNo = 0, MobileNo = 0;

            dbManager.Open();
            dbManager.BeginTransaction();
            dbManager.CreateParameters(2);
            dbManager.AddParameters(0, "Id", "", ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(1, "Action", Val, ParameterDirection.Input, DaoConstants.InParamSize);
            dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_MemberShipForm");
            while (dr.Read())
            {
                _ld = new MemberShip();
                _ld.Id = Convert.ToInt32((dr["Id"]));
                _ld.Name = ((dr["Name"]).ToString());
                _ld.FatherName = ((dr["FatherName"]).ToString());
                _ld.DOB = Convert.ToDateTime((dr["DOB"]).ToString());
                _ld.Nationality = ((dr["Nationality"]).ToString());
                _ld.Country = ((dr["CountryName"]).ToString());
                _ld.Qualification = ((dr["Qualification"]).ToString());
                _ld.Address = ((dr["Address"]).ToString());
                _ld.City = ((dr["City"]).ToString());
                _ld.Pin = Convert.ToInt32((dr["Pin"]));
                Int64.TryParse((dr["PhoneNo"]).ToString(), out intPhoneNo);
                _ld.PhoneNo = intPhoneNo;
                _ld.Email = ((dr["Email"]).ToString());
                Int64.TryParse((dr["MobileNo"]).ToString(), out MobileNo);
                _ld.MobileNo = MobileNo;
                _ld.Profession = ((dr["Profession"]).ToString());
                _ld.OtherDetails = ((dr["OtherDetails"]).ToString());
                _ld.PhotoName = ((dr["PhotoName"]).ToString());
                _ld.PhotoType = ((dr["PhotoType"]).ToString());
                _ld.Date = ((dr["CreateDate"]).ToString());
                //_ld.PhotoContent =Convert.ToByte[]((dr["PhotoContent"]).ToString());
                _lst.Add(_ld);
            }
            dr.Close();
            return _lst;
        }

        public MemberShip EditMemberShip(MemberShip m)
        {
            IDataReader dr = null;
            MemberShip _ld = null;
            List<MemberShip> _lst = new List<MemberShip>();
            var Val = 'R';
            Int64 intPhoneNo = 0, MobileNo = 0;
            try
            {

                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Id", m.Id, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Action", Val, ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_MemberShipForm");
                while (dr.Read())
                {
                    _ld = new MemberShip();
                    _ld.Id = Convert.ToInt32((dr["Id"]));
                    _ld.Name = ((dr["Name"]).ToString());
                    _ld.FatherName = ((dr["FatherName"]).ToString());
                    _ld.DOB = Convert.ToDateTime((dr["DOB"]).ToString());
                    _ld.Nationality = ((dr["Nationality"]).ToString());
                    _ld.Qualification = ((dr["Qualification"]).ToString());
                    _ld.Address = ((dr["Address"]).ToString());
                    _ld.City = ((dr["City"]).ToString());
                    _ld.Pin = Convert.ToInt32((dr["Pin"]));
                    Int64.TryParse((dr["PhoneNo"]).ToString(), out intPhoneNo);
                    _ld.PhoneNo = intPhoneNo;
                    _ld.Email = ((dr["Email"]).ToString());
                    Int64.TryParse((dr["MobileNo"]).ToString(), out MobileNo);
                    _ld.MobileNo = MobileNo;
                    _ld.Profession = ((dr["Profession"]).ToString());
                    _ld.OtherDetails = ((dr["OtherDetails"]).ToString());
                    _ld.PhotoName = ((dr["PhotoName"]).ToString());
                    _ld.PhotoType = ((dr["PhotoType"]).ToString());
                    //_ld.PhotoContent =Convert.ToByte[]((dr["PhotoContent"]).ToString());
                    _lst.Add(_ld);
                }
                dr.Close();
                return _ld;
            }
            catch
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

        public bool UpdateMemberShip(MemberShip M)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(20);
                dbManager.AddParameters(0, "Id", M.Id, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Name", M.Name, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "FatherName", M.FatherName, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "DOB", M.DOB, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(4, "Nationality", M.Nationality, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(5, "Qualification", M.Qualification, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(6, "Address", M.Address, ParameterDirection.Input, DaoConstants.InParamSize);

                dbManager.AddParameters(7, "City", M.City, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(8, "Pin", M.Pin, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(9, "PhoneNo", M.PhoneNo, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(10, "Email", M.Email, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(11, "MobileNo", M.MobileNo, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(12, "Profession", M.Profession, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(13, "OtherDetails", M.OtherDetails, ParameterDirection.Input, DaoConstants.InParamSize);

                dbManager.AddParameters(14, "PhotoName", M.PhotoName, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(15, "PhotoType", M.PhotoType, ParameterDirection.Input, DaoConstants.InParamSize);
                //dbManager.AddParameters(16, "PhotoContent", M.PhotoContent, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(17, "Ip", M.Ip, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(18, "Action", "U", ParameterDirection.Input, DaoConstants.InParamSize);

                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_MemberShipForm"));
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

        public bool DeleteMemberShip(MemberShip M)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Id", M.Id, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Action", "D", ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_MemberShipForm"));
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

        #region InsertNotofications
        public bool InsertNotofications(Notifications AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "Id", AR.ID, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "NotificationTitle", AR.NotificationTitle, ParameterDirection.Input, DaoConstants.InParamSize);
                //dbManager.AddParameters(2, "FromDate", AR.FromDate, ParameterDirection.Input, DaoConstants.InParamSize);
                //dbManager.AddParameters(3, "ToDate", AR.ToDate, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "Action", 'I', ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Notifications"));
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
        #endregion

        #region GetNotification
        //To Get Negotiation

        public List<Notifications> GetNotification()
        {
            IDataReader dr = null;
            Notifications _obj = null;
            List<Notifications> _lst = null;

            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "Action", 'R', ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_Notifications");
                _lst = new List<Notifications>();
                while (dr.Read())
                {
                    _obj = new Notifications();
                    _obj.ID = Convert.ToInt32((dr["Id"]).ToString());
                    _obj.NotificationTitle = ((dr["Notification"]).ToString());
                    _lst.Add(_obj);
                }
                dr.Close();
                return _lst;
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

        public Notifications GetHitCount()
        {
            IDataReader dr = null;
            Notifications _obj = null;
            dbManager.Open();
            dbManager.BeginTransaction();
            //dbManager.CreateParameters(1);
            //dbManager.AddParameters(0, "Count", 1, ParameterDirection.Input, DaoConstants.InParamSize);
            dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_GetCount");
            while (dr.Read())
            {
                _obj = new Notifications();
                _obj.HitCount = ((dr["HitCount"]).ToString());
            }
            dr.Close();
            return _obj;
        }
        //catch (Exception ex)
        //{
        //    if (dr != null)
        //        dr.Close();
        //    return null;
        //}
        //finally
        //{
        //    if (dr != null)
        //        dr.Close();
        //    dbManager.Dispose();
        //    dbManager = null;
        //}




        //public List<Notifications> GetHitCount()
        //{
        //    IDataReader dr = null;
        //    Notifications _obj = null;
        //    List<Notifications> _lst = null;
        //    dbManager.Open();
        //    dbManager.BeginTransaction();
        //    dbManager.CreateParameters(0);
        //    dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_GetCount");
        //    _lst = new List<Notifications>();
        //    while (dr.Read())
        //    {
        //        _obj = new Notifications();
        //        _obj.HitCount = ((dr["HitCount"]).ToString());
        //    }
        //    dr.Close();
        //    return _lst;
        //}

        #endregion

        #region DeleteNotifications
        public bool DeleteNotifications(Notifications N)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Id", N.ID, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Action", "D", ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Notifications"));
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
        #endregion

        #region InsertHacking
        //Insert Mediation
        public bool InsertHacking(ArbitrationDTO AR)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "HackingTitle", AR.Title, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "HackingDescription", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(2, "Action", 'I', ParameterDirection.Input, DaoConstants.InParamSize);
                // dbManager.AddParameters(2, "IpAddress", _accessor.HttpContext.Connection.RemoteIpAddress.ToString(), ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(3, "CreatedBy", AR.CreatedBy, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Hackingg"));
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
        #endregion

        #region GetHacking
        public List<ArbitrationDTO> GetHacking()
        {
            IDataReader dr = null;
            ArbitrationDTO _obj = null;
            List<ArbitrationDTO> _lst = null;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "Action", 'R', ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_Hackingg");
                _lst = new List<ArbitrationDTO>();
                while (dr.Read())
                {
                    _obj = new ArbitrationDTO();
                    _obj.Id = Convert.ToInt32((dr["Id"]));
                    _obj.Title = ((dr["HackingTitle"]).ToString());
                    _obj.Description = ((dr["HackingDescription"]).ToString());
                    _lst.Add(_obj);
                }
                dr.Close();
                return _lst;
            }
            catch
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
        #endregion

        #region GetHackingById
        public ArbitrationDTO GetHackingById(int Id, char val)
        {
            IDataReader dr = null;
            ArbitrationDTO _ld = null;
            val = 'E';
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Action", val, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Id", Id, ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_Hackingg");
                while (dr.Read())
                {
                    _ld = new ArbitrationDTO();
                    _ld.Id = Convert.ToInt32((dr["Id"]));
                    _ld.Title = ((dr["HackingTitle"]).ToString());
                    _ld.Description = ((dr["HackingDescription"]).ToString());
                }
                dr.Close();
                return _ld;
            }
            catch
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
        #endregion

        #region DeleteHacking
        public bool DeleteHacking(int id, string R)
        {
            bool _val = false;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Id", id, ParameterDirection.Input, DaoConstants.InParamSize);
                dbManager.AddParameters(1, "Action", R, ParameterDirection.Input, DaoConstants.InParamSize);
                Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_Hackingg"));
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
        #endregion


        #region GetCopyRights
        //To Get CopyRights
        public List<MastersDTO> GetCountries()
        {
            IDataReader dr = null;
            MastersDTO _obj = null;
            List<MastersDTO> _lst = null;
<<<<<<< HEAD

            dbManager.Open();
            dbManager.BeginTransaction();
            //dbManager.CreateParameters(1);
            //dbManager.AddParameters(0, "Action", 'R', ParameterDirection.Input, DaoConstants.InParamSize);
            dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_Countries");
            _lst = new List<MastersDTO>();
            while (dr.Read())
            {
                _obj = new MastersDTO();
                _obj.Id = Convert.ToInt32((dr["Id"]));
                _obj.CountryName = ((dr["CountryName"]).ToString());
                _obj.CountryCode = ((dr["CountryCode"]).ToString());
                _lst.Add(_obj);
            }
            dr.Close();
            return _lst;
        }

        public List<AdminMenu_DTO> GetMenus()
        {
            IDataReader dr = null;
            AdminMenu_DTO _obj = null;
            List<AdminMenu_DTO> _lst = null;

            dbManager.Open();
            dbManager.BeginTransaction();
            //dbManager.CreateParameters(1);
            //dbManager.AddParameters(0, "Action", 'R', ParameterDirection.Input, DaoConstants.InParamSize);
            dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "SubMenu_IUDR");
            _lst = new List<AdminMenu_DTO>();
            while (dr.Read())
            {
                _obj = new AdminMenu_DTO();
                _obj.MainMenuId = dr["MainMenuId"] == DBNull.Value ? default(int) : Convert.ToInt32((dr["MainMenuId"]));
                _obj.SubMenu = dr["SubMenu"] == DBNull.Value ? string.Empty : dr["SubMenu"].ToString();
                _obj.ParentId = dr["ParentId"] == DBNull.Value ? default(int) : Convert.ToInt32((dr["ParentId"]).ToString());
                _obj.SubMenuId = dr["SubMenuId"] == DBNull.Value ? default(int) : Convert.ToInt32((dr["SubMenuId"]).ToString());
                _obj.PageUrl = dr["PageUrl"] == DBNull.Value ? string.Empty : dr["PageUrl"].ToString();
                _lst.Add(_obj);
            }
            dr.Close();
            return _lst;
        }

        public bool InsertLaws(GliLaws AR)
        {
            bool _val = false;

            dbManager.Open();
            dbManager.BeginTransaction();
            dbManager.CreateParameters(9);
            dbManager.AddParameters(0, "Title", AR.Title, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(1, "Description", AR.Description, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(2, "MainMenuId", AR.MainMenuId, ParameterDirection.Input, DaoConstants.InParamSize);

            dbManager.AddParameters(3, "SubMenu", AR.SubMenu, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(4, "ParentId", AR.ParentId, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(5, "SubMenuId", AR.SubMenuId, ParameterDirection.Input, DaoConstants.InParamSize);

            dbManager.AddParameters(6, "PageUrl", AR.PageUrl, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(7, "Ip", Ip, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(8, "UserName", AR.UserName, ParameterDirection.Input, DaoConstants.InParamSize);

            Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_InsertLaws"));
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
            return _val;
        }


        public List<GliLaws> GetLaws(GliLaws gl)
        {
            IDataReader dr = null;
            List<GliLaws> _lst = null;
            GliLaws obj = null;

            dbManager.Open();
            dbManager.BeginTransaction();
            dbManager.CreateParameters(3);
            dbManager.AddParameters(0, "ParentId", gl.ParentId, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(1, "SubMenuId", gl.SubMenuId, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(2, "SubMenu",gl.SubMenu , ParameterDirection.Input, DaoConstants.InParamSize);
            dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_GetLaws");
            _lst = new List<GliLaws>();
            while (dr.Read())
            {
                obj = new GliLaws();
                obj.Title = dr["Title"] == DBNull.Value ? string.Empty : dr["Title"].ToString();
                obj.Description = dr["Title"] == DBNull.Value ? string.Empty : dr["Description"].ToString();
                _lst.Add(obj);
            }
            dr.Close();
            return _lst;
        }


        public bool SaveMyCode(SaveMyCode SC)
        {
            bool _val = false;

            dbManager.Open();
            dbManager.BeginTransaction();
            dbManager.CreateParameters(9);
            dbManager.AddParameters(0, "Title", SC.Title, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(1, "Description", SC.Description, ParameterDirection.Input, DaoConstants.InParamSize);
            dbManager.AddParameters(2, "Ip", SC.Ip, ParameterDirection.Input, DaoConstants.InParamSize);

            Int32 iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "GLI_SaveMyCode"));
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
            return _val;
        }
    }
    #endregion
}
=======
           
                dbManager.Open();
                dbManager.BeginTransaction();
                //dbManager.CreateParameters(1);
                //dbManager.AddParameters(0, "Action", 'R', ParameterDirection.Input, DaoConstants.InParamSize);
                dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "GLI_Countries");
                _lst = new List<MastersDTO>();
                while (dr.Read())
                {
                    _obj = new MastersDTO();
                    _obj.Id = Convert.ToInt32((dr["Id"]));
                    _obj.CountryName = ((dr["CountryName"]).ToString());
                    _obj.CountryCode = ((dr["CountryCode"]).ToString());
                    _lst.Add(_obj);
                }
                dr.Close();
                return _lst;
            }         
        }
        #endregion
    }
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975


