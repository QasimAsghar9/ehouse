using System.Data;
using System.Data.SqlClient;
using eHouse.Models;
namespace eHouse.Models
{
    public class Rentdb
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ehouse;Integrated Security=True");

        public string Saverecord(RentModel rm)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO rent(tittle,descrip,areaUnit,area,province,city,stadress,p_type,furnished,price,bathroom,bedroom,garage) VALUES(@tittle,@descrip,@areaUnit,@area,@province,@city,@stadress,@p_type,@furnished,@price,@bathroom,@bedroom,@garage)", con);
               
                cmd.Parameters.AddWithValue("@tittle", rm.tittle);
                cmd.Parameters.AddWithValue("@descrip", rm.descrip);
                cmd.Parameters.AddWithValue("@areaUnit", rm.areaUnit);
                cmd.Parameters.AddWithValue("@area", rm.area);
                cmd.Parameters.AddWithValue("@province", rm.province);
                cmd.Parameters.AddWithValue("@city", rm.city);
                cmd.Parameters.AddWithValue("@stadress", rm.stadress);
                cmd.Parameters.AddWithValue("@p_type", rm.p_type);
                cmd.Parameters.AddWithValue("@furnished", rm.furnished);
                cmd.Parameters.AddWithValue("@bathroom", rm.bathroom);
                cmd.Parameters.AddWithValue("@bedroom", rm.bedroom);
                cmd.Parameters.AddWithValue("@price", rm.price);
                cmd.Parameters.AddWithValue("@garage", rm.garage);


                cmd.ExecuteNonQuery();
                con.Close();
                return "ok";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public string Saveimg( gallery gr)
        {
            try
            {
                con.Open();
                
                SqlCommand cd = new SqlCommand("INSERT INTO gallery(Name,URL,rid)VALUES(@NAME,@URL,rid)", con);
               
                cd.Parameters.AddWithValue("@NAME", gr.Name);
                cd.Parameters.AddWithValue("@URL", gr.URL);
                cd.Parameters.AddWithValue("@rid", gr.Bookid);
                cd.ExecuteNonQuery();

             
                con.Close();
                return "ok";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public string favlist(int id)
        {
            try
            {
                con.Open();

                SqlCommand cd = new SqlCommand("IF NOT EXISTS (SELECT * FROM favoritelist f WHERE f.favid=@favid) INSERT INTO favoritelist(favid)VALUES(@favid)", con);

                cd.Parameters.AddWithValue("@favid",id);
                
                cd.ExecuteNonQuery();


                con.Close();
                return "ok";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public string dellist(int id)
        {
            try
            {
                con.Open();

                SqlCommand cd = new SqlCommand("DELETE FROM rent WHERE id=@id", con);

                cd.Parameters.AddWithValue("@id", id);
                cd.CommandType = CommandType.Text;

                cd.ExecuteNonQuery();


                con.Close();
                return "ok";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public string delimg(int id)
        {
            try
            {
                con.Open();

                SqlCommand cd = new SqlCommand("DELETE FROM img WHERE id=@id", con);

                cd.Parameters.AddWithValue("@id", id);
                cd.CommandType = CommandType.Text;

                cd.ExecuteNonQuery();


                con.Close();
                return "ok";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public List<RentModel> Getfavlist()
        {
            List<RentModel> dataList = new List<RentModel>();
            SqlCommand command = new SqlCommand("SELECT * FROM favoritelist ", con);
            //SqlCommand cmd = new SqlCommand("Select Count(id) as CityCount, city\r\nfrom rent\r\nGROUP BY city;", con);
            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            //SqlDataAdapter sqlad = new SqlDataAdapter(cmd);
            DataTable dtdata = new DataTable();
            con.Open();
            sqlda.Fill(dtdata);
            //sqlad.Fill(dtdata);
            con.Close();
            foreach (DataRow dr in dtdata.Rows)
            {
                dataList.Add(new RentModel
                {


                    favid = (dr["favid"] as int?) ?? 0,
                   
                });
            }





            return dataList;
        }
        public List<RentModel>GetDataHouse()
        {
            List<RentModel> dataList = new List<RentModel>();
            SqlCommand command = new SqlCommand("SELECT *,img.pic1 FROM rent FULL OUTER JOIN img ON rent.id=img.id  WHERE p_type = 'House'", con);
           
            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            
            DataTable dtdata= new DataTable();
            con.Open();
            sqlda.Fill(dtdata);
           
            con.Close();
            foreach(DataRow dr in dtdata.Rows)
            {
                dataList.Add(new RentModel
                {

                    
                    id = (dr["ID"] as int?)?? 0,
                    tittle = dr["tittle"]as string,
                    descrip = dr["descrip"]as string,
                    area = (dr["area"] as int?)?? 0,
                    areaUnit = dr["areaUnit"] as string,
                    bathroom = dr["bathroom"]as string,
                    bedroom = dr["bedroom"] as string,
                    province= dr["province"] as string,
                    city= dr["city"] as string,
                    stadress = dr["stadress"] as string,
                    furnished = dr["furnished"] as string,
                    p_type = dr["p_type"] as string,
                    price = (dr["price"] as int?)?? 0,
                    pic1 = dr["pic1"] as string,
                    garage = dr["garage"] as string
                    
                });
            }
             
            



            return dataList;
        }
        public string imagedb(RentModel img)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO img(pic1,pic2,pic3,pic4,pic5,pic6,pic7,pic8,pic9,pic10) VALUES(@pic1,@pic2,@pic3,@pic4,@pic5,@pic6,@pic7,@pic8,@pic9,@pic10)", con);

                cmd.Parameters.AddWithValue("@pic1", img.pic1);
                cmd.Parameters.AddWithValue("@pic2", img.pic2);

                cmd.Parameters.AddWithValue("@pic3", img.pic3);
                cmd.Parameters.AddWithValue("@pic4", img.pic4);

                cmd.Parameters.AddWithValue("@pic5", img.pic5);
                cmd.Parameters.AddWithValue("@pic6", img.pic6);
                cmd.Parameters.AddWithValue("@pic7", img.pic7);
                cmd.Parameters.AddWithValue("@pic8", img.pic8);
                cmd.Parameters.AddWithValue("@pic9", img.pic9);
                cmd.Parameters.AddWithValue("@pic10", img.pic10);




                cmd.ExecuteNonQuery();
                con.Close();
                return "ok";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        //cmd.Parameters.AddWithValue("@pic2", img.pic2);
        //cmd.Parameters.AddWithValue("@pic3", img.pic3);
        //cmd.Parameters.AddWithValue("@pic4", img.pic4);
        //cmd.Parameters.AddWithValue("@pic5", img.pic5);

        //cmd.Parameters.AddWithValue("@pic6", img.pic6);
        //cmd.Parameters.AddWithValue("@pic7", img.pic7);
        //cmd.Parameters.AddWithValue("@pic8", img.pic8);
        //cmd.Parameters.AddWithValue("@pic9", img.pic9);
        //cmd.Parameters.AddWithValue("@pic10",img.pic10);
        public List<RentModel> GetDataBuilding()
        {
            List<RentModel> dataList = new List<RentModel>();
            SqlCommand command = new SqlCommand("SELECT *,img.pic1 FROM rent FULL OUTER JOIN img ON rent.id=img.id WHERE p_type = 'Building'", con);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM img", con);
            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            //SqlDataAdapter sqlad = new SqlDataAdapter(cmd);
            DataTable dtdata = new DataTable();
            con.Open();
            sqlda.Fill(dtdata);
            /*sqlad.Fill(dtdata)*/
            ;
            con.Close();
            foreach (DataRow dr in dtdata.Rows)
            {
                dataList.Add(new RentModel
                {


                    id = (dr["ID"] as int?) ?? 0,
                    tittle = dr["tittle"] as string,
                    descrip = dr["descrip"] as string,
                    area = (dr["area"] as int?) ?? 0,
                    areaUnit = dr["areaUnit"] as string,
                    bathroom = dr["bathroom"] as string,
                    bedroom = dr["bedroom"] as string,
                    province = dr["province"] as string,
                    city = dr["city"] as string,
                    stadress = dr["stadress"] as string,
                    furnished = dr["furnished"] as string,
                    p_type = dr["p_type"] as string,
                    price = (dr["price"] as int?) ?? 0,
                    pic1 = dr["pic1"] as string
                });
            }





            return dataList;
        }
        public List<RentModel> GetDataVillas()
        {
            List<RentModel> dataList = new List<RentModel>();
            SqlCommand command = new SqlCommand("SELECT *,img.pic1 FROM rent FULL OUTER JOIN img ON rent.id=img.id WHERE p_type = 'Villas'", con);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM img", con);
            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            //SqlDataAdapter sqlad = new SqlDataAdapter(cmd);
            DataTable dtdata = new DataTable();
            con.Open();
            sqlda.Fill(dtdata);
            /*sqlad.Fill(dtdata)*/
            ;
            con.Close();
            foreach (DataRow dr in dtdata.Rows)
            {
                dataList.Add(new RentModel
                {


                    id = (dr["ID"] as int?) ?? 0,
                    tittle = dr["tittle"] as string,
                    descrip = dr["descrip"] as string,
                    area = (dr["area"] as int?) ?? 0,
                    areaUnit = dr["areaUnit"] as string,
                    bathroom = dr["bathroom"] as string,
                    bedroom = dr["bedroom"] as string,
                    province = dr["province"] as string,
                    city = dr["city"] as string,
                    stadress = dr["stadress"] as string,
                    furnished = dr["furnished"] as string,
                    p_type = dr["p_type"] as string,
                    price = (dr["price"] as int?) ?? 0,
                    
                    pic1 = dr["pic1"] as string
                });
            }





            return dataList;
        }
        public List<RentModel> GetDataBanglow()
        {
            List<RentModel> dataList = new List<RentModel>();
            SqlCommand command = new SqlCommand("SELECT *,img.pic1 FROM rent FULL OUTER JOIN img ON rent.id=img.id WHERE p_type = 'Banglow'", con);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM img", con);
            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            //SqlDataAdapter sqlad = new SqlDataAdapter(cmd);
            DataTable dtdata = new DataTable();
            con.Open();
            sqlda.Fill(dtdata);
            /*sqlad.Fill(dtdata)*/
            ;
            con.Close();
            foreach (DataRow dr in dtdata.Rows)
            {
                dataList.Add(new RentModel
                {


                    id = (dr["ID"] as int?) ?? 0,
                    tittle = dr["tittle"] as string,
                    descrip = dr["descrip"] as string,
                    area = (dr["area"] as int?) ?? 0,
                    areaUnit = dr["areaUnit"] as string,
                    bathroom = dr["bathroom"] as string,
                    bedroom = dr["bedroom"] as string,
                    province = dr["province"] as string,
                    city = dr["city"] as string,
                    stadress = dr["stadress"] as string,
                    furnished = dr["furnished"] as string,
                    p_type = dr["p_type"] as string,
                    price = (dr["price"] as int?) ?? 0,
                    pic1 = dr["pic1"] as string
                });
            }





            return dataList;
        }
        public List<RentModel> GetDataIndustrial()
        {
            List<RentModel> dataList = new List<RentModel>();
            SqlCommand command = new SqlCommand("SELECT *,img.pic1 FROM rent FULL OUTER JOIN img ON rent.id=img.id WHERE p_type = 'Industrial'", con);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM img", con);
            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            //SqlDataAdapter sqlad = new SqlDataAdapter(cmd);
            DataTable dtdata = new DataTable();
            con.Open();
            sqlda.Fill(dtdata);
            /*sqlad.Fill(dtdata)*/
            ;
            con.Close();
            foreach (DataRow dr in dtdata.Rows)
            {
                dataList.Add(new RentModel
                {


                    id = (dr["ID"] as int?) ?? 0,
                    tittle = dr["tittle"] as string,
                    descrip = dr["descrip"] as string,
                    area = (dr["area"] as int?) ?? 0,
                    areaUnit = dr["areaUnit"] as string,
                    bathroom = dr["bathroom"] as string,
                    bedroom = dr["bedroom"] as string,
                    province = dr["province"] as string,
                    city = dr["city"] as string,
                    stadress = dr["stadress"] as string,
                    furnished = dr["furnished"] as string,
                    p_type = dr["p_type"] as string,
                    price = (dr["price"] as int?) ?? 0,
                    
                    pic1 = dr["pic1"] as string
                });
            }





            return dataList;
        }
        public List<RentModel> GetDataApartment()
        {
            List<RentModel> dataList = new List<RentModel>();
            SqlCommand command = new SqlCommand("SELECT *,img.pic1 FROM rent FULL OUTER JOIN img ON rent.id=img.id WHERE p_type = 'Apartment'", con);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM img", con);
            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            //SqlDataAdapter sqlad = new SqlDataAdapter(cmd);
            DataTable dtdata = new DataTable();
            con.Open();
            sqlda.Fill(dtdata);
            /*sqlad.Fill(dtdata)*/
            ;
            con.Close();
            foreach (DataRow dr in dtdata.Rows)
            {
                dataList.Add(new RentModel
                {


                    id = (dr["ID"] as int?) ?? 0,
                    tittle = dr["tittle"] as string,
                    descrip = dr["descrip"] as string,
                    area = (dr["area"] as int?) ?? 0,
                    areaUnit = dr["areaUnit"] as string,
                    bathroom = dr["bathroom"] as string,
                    bedroom = dr["bedroom"] as string,
                    province = dr["province"] as string,
                    city = dr["city"] as string,
                    stadress = dr["stadress"] as string,
                    furnished = dr["furnished"] as string,
                    p_type = dr["p_type"] as string,
                    price = (dr["price"] as int?) ?? 0,
                    pic1 = dr["pic1"] as string
                });
               
            }





            return dataList;
        }
    }
    
}
