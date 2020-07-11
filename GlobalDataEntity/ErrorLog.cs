
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace GLI.GlobalEntity
{
    public class ErrorLog
    {
        //public static void WriteToErrorLog(Exception ex, string UserId, string Methodname, IHttpContextAccessor _accessor) // TypeId: 1 for Mvc & 2 for Api
        //{
        //    try
        //    {

        //        if (ex.Message.Trim() == "Thread was being aborted.".Trim())
        //            return;

        //        var configurationBuilder = new ConfigurationBuilder();
        //        var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
        //        configurationBuilder.AddJsonFile(path, false);
        //        var root = configurationBuilder.Build();
        //        SqlConnection con = new SqlConnection(root.GetSection("Data").GetSection("ConnectionString").Value);
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = UserId;
        //        cmd.Parameters.Add("@IP", SqlDbType.VarChar).Value = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        //        cmd.Parameters.Add("@RequestURL", SqlDbType.VarChar).Value = _accessor.HttpContext.Request.GetDisplayUrl();
        //        cmd.Parameters.Add("@ErrorDesc", SqlDbType.VarChar).Value = ex.Message;
        //        cmd.Parameters.Add("@Methodname", SqlDbType.Text).Value = Methodname;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "USP_ErrorLog";

        //        if (con.State == ConnectionState.Closed)
        //            con.Open();
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //        con.Close();
        //    }
        //    catch
        //    {

        //    }
        //}
    }
}
