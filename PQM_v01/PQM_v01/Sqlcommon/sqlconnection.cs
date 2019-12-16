﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace PQM_v01.Sqlcommon
{
    public class sqlconnection
    {
        public SqlConnection conn = DBUtils.GetDBConnection(); //get from user database

        public string sqlExecuteScalarString(string sql)
        {

            String outstring;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                outstring = cmd.ExecuteScalar().ToString();
                conn.Close();
                return outstring;
            }
            catch (Exception ex)
            {

               
                return String.Empty;
            }


        }
        //public void getComboBoxData(string sql, ref combox cmb)
        //{
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = conn;
        //        cmd.CommandText = sql;
        //        SqlDataAdapter adapter = new SqlDataAdapter();
        //        adapter.SelectCommand = cmd;
        //        DataSet ds = new DataSet();
        //        adapter.Fill(ds);
        //        adapter.Dispose();
        //        cmd.Dispose();
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            cmb.Items.Add(row[0].ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //       // MessageBox.Show(ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //    }
        //    conn.Close();
        //}
        public void sqlDataAdapterFillDatatable(string sql, ref DataTable dt)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                {
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        public bool sqlExecuteNonQuery(string sql, bool result_message_show)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                int response = cmd.ExecuteNonQuery();
                if (response >= 1)
                {
                    if (result_message_show) 
                    conn.Close();
                    return true;
                }
                else
                {
                 //   MessageBox.Show("Not successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
             
                conn.Close();
                return false;
            }
        }

        public void sqlDatatablePermision(string buttonText, Button btn_common)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                {
                    cmd.CommandText = "select  button , status from m_permission where permission =  '";//+ Class.valiballecommon.GetStorage().Permission + "'";
                    cmd.Connection = conn;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == buttonText)
                        {
                            if (dt.Rows[i][1].ToString() == "True")
                            { btn_common.Enabled = true; }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
             //  MessageBox.Show(ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
    }
}