using eHouse.Models;
using System.Data.SqlClient;
namespace eHouse.Data
{
    public class rent
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3E4S3VB\\SQLEXPRESS;Initial Catalog=ehouse;Integrated Security=True");

        public rent()
        {
           
        }
        public string addrent(RentModel rm)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("addrent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tittle", rm.tittle);
                cmd.Parameters.AddWithValue("@descrip", rm.descrip);
                cmd.Parameters.AddWithValue("@areaUnit", rm.areaUnit);
                cmd.Parameters.AddWithValue("@area", rm.area);
                cmd.Parameters.AddWithValue("@province", rm.province);
                cmd.Parameters.AddWithValue("@city", rm.city);
                cmd.Parameters.AddWithValue("@stadress", rm.stadress);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "ok";
            }
            catch(Exception ex)
            {
                if (con.State==System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }


            

        }
    }
}
