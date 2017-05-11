using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ErieHack_TeamEdgwater.Models.Graph;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ErieHack_TeamEdgwater.Controllers
{
    public class GraphingController : Controller
    {
        LakeErie lakeErie = new LakeErie();

        // GET: Graphing
        public ActionResult Index()
        {
            String constring = ConfigurationManager.ConnectionStrings["ErieDataLocal"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query =
                "           select * " +
                "           From Lake" +
                "           Where Site = 'CW88'";
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            con.Close();
            IList<LakeData> model = new List<LakeData>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                model.Add(new LakeData()
                {
                    ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                    Waterbody = dt.Rows[i]["Waterbody"].ToString(),
                    Site = dt.Rows[i]["Site"].ToString(),
                    SampleTime = dt.Rows[i]["SampleTime"].ToString(),
                    Parameter = dt.Rows[i]["Parameter"].ToString(),
                    Code = dt.Rows[i]["Code"].ToString(),
                    Result = Convert.ToDouble(dt.Rows[i]["Result"]),
                    Units = dt.Rows[i]["Units"].ToString(),
                    F9 = dt.Rows[i]["F9"].ToString(),
                    F10 = dt.Rows[i]["F10"].ToString(),
                    F11 = dt.Rows[i]["F11"].ToString(),

                });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Exp()
        {
            var selected = Request.Form["Para"];
            var selectedList = selected.Split(',');
            string paraSelect = "";

            //String x = Convert.ToString(Request["P1"].ToString());

            selectedList.ToString();
            for (int i = 0; i < selectedList.Length; ++i)
            {
                if (selectedList.Length == 1)
                {
                    paraSelect = "('" + selectedList[i] + "')";
                    break;
                }
                else
                {
                    if (i == 0)
                    {
                        paraSelect = "('" + selectedList[i] + "'";
                    }
                    else if (i < (selectedList.Length - 1))
                    {
                        paraSelect += ", '" + selectedList[i] + "'";
                    }
                    else
                    {
                        paraSelect += ", '" + selectedList[i] + "')";
                    }
                }
            }
            String constring = ConfigurationManager.ConnectionStrings["ErieDataLocal"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query =
                "           select * " +
                "           From Lake" +
                "           Where Site = 'CW88'" +
                "           And Parameter In " + paraSelect;
            DataTable dtnew = new DataTable();

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dtnew);
            con.Close();
            IList<LakeData> model = new List<LakeData>();
            for (int i = 0; i < dtnew.Rows.Count; i++)
            {
                model.Add(new LakeData()
                {
                    ID = Convert.ToInt32(dtnew.Rows[i]["ID"]),
                    Waterbody = dtnew.Rows[i]["Waterbody"].ToString(),
                    Site = dtnew.Rows[i]["Site"].ToString(),
                    SampleTime = dtnew.Rows[i]["SampleTime"].ToString(),
                    Parameter = dtnew.Rows[i]["Parameter"].ToString(),
                    Code = dtnew.Rows[i]["Code"].ToString(),
                    Result = Convert.ToDouble(dtnew.Rows[i]["Result"]),
                    Units = dtnew.Rows[i]["Units"].ToString(),
                    F9 = dtnew.Rows[i]["F9"].ToString(),
                    F10 = dtnew.Rows[i]["F10"].ToString(),
                    F11 = dtnew.Rows[i]["F11"].ToString(),

                });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ExpTbl()
        {
            var selected = Request.Form["Para"];
            var selectedList = selected.Split(',');
            string paraSelect = "";

            //String x = Convert.ToString(Request["P1"].ToString());

            selectedList.ToString();
            for (int i = 0; i < selectedList.Length; ++i)
            {
                if (selectedList.Length == 1)
                {
                    paraSelect = "('" + selectedList[i] + "')";
                    break;
                }
                else
                {
                    if (i == 0)
                    {
                        paraSelect = "('" + selectedList[i] + "'";
                    }
                    else if (i < (selectedList.Length - 1))
                    {
                        paraSelect += ", '" + selectedList[i] + "'";
                    }
                    else
                    {
                        paraSelect += ", '" + selectedList[i] + "')";
                    }
                }
            }
            String constring = ConfigurationManager.ConnectionStrings["ErieDataLocal"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query =
                "           select * " +
                "           From Lake" +
                "           Where Site = 'CW88'" +
                "           And Parameter In " + paraSelect;
            DataTable dtnew = new DataTable();

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dtnew);
            con.Close();
            IList<LakeData> model = new List<LakeData>();
            for (int i = 0; i < dtnew.Rows.Count; i++)
            {
                model.Add(new LakeData()
                {
                    ID = Convert.ToInt32(dtnew.Rows[i]["ID"]),
                    Waterbody = dtnew.Rows[i]["Waterbody"].ToString(),
                    Site = dtnew.Rows[i]["Site"].ToString(),
                    SampleTime = dtnew.Rows[i]["SampleTime"].ToString(),
                    Parameter = dtnew.Rows[i]["Parameter"].ToString(),
                    Code = dtnew.Rows[i]["Code"].ToString(),
                    Result = Convert.ToDouble(dtnew.Rows[i]["Result"]),
                    Units = dtnew.Rows[i]["Units"].ToString(),
                    F9 = dtnew.Rows[i]["F9"].ToString(),
                    F10 = dtnew.Rows[i]["F10"].ToString(),
                    F11 = dtnew.Rows[i]["F11"].ToString(),

                });
            }
            return View(model);
        }

    }
}
