using GlobalDal;
using GlobalDal.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeblandDal.DataLayer
{
   public class ProformaDal : CommonMethods
    {
        IDBManager dbManager = null;
        public ProformaDal()
        {
            if (dbManager == null)
                dbManager = new DBManager();
        }
        //To Get Data From Button Click in Proforma1 
        //public List<ListProforma1Details> GetProforma1Details(int? villageCode, string baseSurveyNumber)
        //{
        //    IDataReader dr = null;
        //    List<ListProforma1Details> proformaList = new List<ListProforma1Details>();
        //    try
        //    {
        //        dbManager.Open();
        //        ListProforma1Details obj = null;
        //        dbManager.CreateParameters(2);
        //        dbManager.AddParameters(0, "VillageCode", GetDBNullOrValue(villageCode), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(1, "BaseSurveyNo", GetDBNullOrValue(baseSurveyNumber), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dr = dbManager.ExecuteReader(CommandType.StoredProcedure, "USP_WL_Prof1_GETRSRBaseSurvey_SubDivisions");
        //        while (dr.Read())
        //        {
        //            obj = new ListProforma1Details();
        //            //obj.DistrictCode = dr["dist_code"] == DBNull.Value ? default(int) : Convert.ToInt32(dr["dist_code"]);
        //            //obj.MandalCode = dr["mand_code"] == DBNull.Value ? default(int) : Convert.ToInt32(dr["mand_code"]);
        //            obj.VillageNameTelugu = dr["vill_name"] == DBNull.Value ? string.Empty : dr["vill_name"].ToString();
        //            obj.VillageNameEnglish  = dr["Evill_name"] == DBNull.Value ? string.Empty : dr["Evill_name"].ToString();
        //            obj.BaseSurveyNo = dr["base"] == DBNull.Value ? string.Empty : dr["base"].ToString();
        //            obj.SubDivNo = dr["subdivno"] == DBNull.Value ? string.Empty : dr["subdivno"].ToString();
        //            obj.TotalExtent = dr["area"] == DBNull.Value ? string.Empty : dr["subdivno"].ToString();
        //            obj.LandNature = dr["wlnature"] == DBNull.Value ? string.Empty : dr["wlnature"].ToString();
        //            obj.LandClassification = dr["wlclassification"] == DBNull.Value ? string.Empty : dr["wlclassification"].ToString();
        //            obj.PattadarName = dr["wlpattadar"] == DBNull.Value ? string.Empty : dr["wlpattadar"].ToString();
        //            obj.OfficerRemarks = dr["wlremarks"] == DBNull.Value ? string.Empty : dr["wlremarks"].ToString();
        //            proformaList.Add(obj);
        //            obj = null;
        //        }
        //        dr.Close();
        //        return proformaList;

        //    }
        //    catch (Exception ex)
        //    {
        //        if (dr != null)
        //            dr.Close();
        //        return null;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //            dr.Close();
        //        dbManager.Dispose();
        //        dbManager = null;
        //    }
        //}
        //To Insert Proforma1 Details to Db
        //public bool InsertProforma1Details(Proforma1 entity)
        //{
        //    bool val = false;
        //    IDataReader dr = null;
        //    try
        //    {
        //        dbManager.Open();
        //        dbManager.BeginTransaction();
        //        dbManager.CreateParameters(28);
        //        dbManager.AddParameters(0, "", GetDBNullOrValue(entity.districts.DistrictCode), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(1, "", GetDBNullOrValue(entity.mandals.MandalCode), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(2, "", GetDBNullOrValue(entity.villages.VillageCode), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(3, "", GetDBNullOrValue(entity.WlRsrBaseSurveyNo), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(4, "", GetDBNullOrValue(entity.WlRsrSubDivNo), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(5, "", GetDBNullOrValue(entity.WlRsrExtent), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(6, "", GetDBNullOrValue(entity.OriginalBaseSurveyNo), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(7, "", GetDBNullOrValue(entity.OriginalSubDivNo), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(8, "", GetDBNullOrValue(entity.OriginalExtent), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(9, "", GetDBNullOrValue(entity.OriginalRsrExtentType), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(10,"", GetDBNullOrValue(entity.OriginalClasfctn), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(11,"", GetDBNullOrValue(entity.OriginalLandNature), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(12,"", GetDBNullOrValue(entity.WebLandLandNature), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(13,"", GetDBNullOrValue(entity.PattadarCategory), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(14,"", GetDBNullOrValue(entity.IsExtentSame), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(15,"", GetDBNullOrValue(entity.IsClassificationSame), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(16,"", GetDBNullOrValue(entity.IsLandNatureSame), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(17,"", GetDBNullOrValue(entity.IsRecordTallied), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(18,"", GetDBNullOrValue(entity.ExtentDiffEntered), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(19,"", GetDBNullOrValue(entity.RectificationReasonType), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(20,"", GetDBNullOrValue(entity.PendingReasonType), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(21,"", GetDBNullOrValue(entity.WeblandClasfctn), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(22,"", GetDBNullOrValue(entity.WebLandRsrRemarks), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(23,"", GetDBNullOrValue(entity.OriginalRsrRemarks), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(24,"", GetDBNullOrValue(entity.FilePath), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(25,"", GetDBNullOrValue(entity.BaseFrom), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(26,"", GetDBNullOrValue(entity.Recordstatus), ParameterDirection.Input, DaoConstants.InParamSize);
        //        dbManager.AddParameters(27,"", GetDBNullOrValue(entity.RecordApprovedStatus), ParameterDirection.Input, DaoConstants.InParamSize);
        //        int iResult = Convert.ToInt32(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "USP_InsertScrollingTextInfo"));
        //        if (iResult > 0)
        //        {
        //            dbManager.CommitTransaction();
        //            val = true;
        //        }
        //        else
        //        {
        //            dbManager.RollBackTransaction();
        //            val = false;
        //        }
        //        return val;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (dr != null)
        //            dr.Close();
        //        val = false;
        //        //Errorlog.WriteToErrorLog(ex, "", "", "Class : CommonDal, Method : InsertScrollingText,SP : USP_InsertScrollingTextInfo");
        //        dbManager.RollBackTransaction();
        //        return false;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //            dr.Close();
        //        if (entity != null)
        //        {
        //            dbManager.Dispose();
        //            dbManager = null;
        //        }
        //    }
        //}
    }
}
