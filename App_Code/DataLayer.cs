using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer
{
	public DataLayer()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static SqlDataReader runQuery(string sqlQuery)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BBCITDB"].ToString());
        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
        conn.Open();

        return cmd.ExecuteReader();
    }

    public static int runUpDelIns(string sqlQuery)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BBCITDB"].ToString());
        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
        conn.Open();
        return cmd.ExecuteNonQuery();
    }

    public static DataSet runQueryDataset(string sqlQuery)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BBCITDB"].ToString());
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(sqlQuery,conn);
        da.SelectCommand.CommandType = CommandType.Text;
        da.Fill(ds);
        return ds;
    }

    public static int runQueryReturnRowCount(string sqlQuery)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BBCITDB"].ToString());
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
        da.SelectCommand.CommandType = CommandType.Text;
        da.Fill(ds);
        return ds.Tables[0].Rows.Count;
        
    }
}