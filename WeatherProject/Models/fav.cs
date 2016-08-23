using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WeatherProject.Models
{
    public class fav
    {

        public int fid { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
        public string Zipcode { get; set; }

        public DataSet GetAllPlaces()
        {
            SqlConnection con = new SqlConnection(@"Data Source=192.168.10.156\SQL2008;initial catalog=WeatherData;persist security info=True;user id=sa;password=admin@2008;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select CityName from favourites ", con);
            //cmd.ExecuteNonQuery();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);


            return ds;
        }
    }

    
}