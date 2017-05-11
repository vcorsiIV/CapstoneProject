using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ErieHack_TeamEdgwater.Models.Graph
{
    public class Lake
    {
        SqlConnection con = new SqlConnection();
        List<Lake> SQLList = new List<Lake>();
        public int ID { get; set; }

        public string Waterbody { get; set; }

        public string Site { get; set; }

        public DateTime SampleTime { get; set; }

        public string Parameter { get; set; }

        public string Code { get; set; }

        public float Result { get; set; }

        public string Units { get; set; }

        public string F9 { get; set; }

        public string F10 { get; set; }

        public string F11 { get; set; }

        Lake s = null;
        public List<Lake> GetData()
        {
            con.ConnectionString = "Data Source=DESKTOP-61R1K4E;Initial Catalog=ErieDataLocal;Integrated Security=True;MultipleActiveResultSets=True";



            con.Open();

            using (con)
            {

                SqlCommand cmd = new SqlCommand("Select * from Lake", con);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())

                {

                    s = new Lake();
                    s.Waterbody = Convert.ToString(rd.GetSqlValue(0));

                    s.ID = Convert.ToInt32(rd.GetInt32(0));

                    s.Site = Convert.ToString(rd.GetSqlValue(0));
                    s.Parameter = Convert.ToString(rd.GetSqlValue(0));
                    s.Code = Convert.ToString(rd.GetSqlValue(0));
                    s.Units = Convert.ToString(rd.GetSqlValue(0));
                    s.F9 = Convert.ToString(rd.GetSqlValue(0));
                    s.F10 = Convert.ToString(rd.GetSqlValue(0));
                    s.F11 = Convert.ToString(rd.GetSqlValue(0));
                    SQLList.Add(s);

                }
            }
            return SQLList;
        }
    }
}