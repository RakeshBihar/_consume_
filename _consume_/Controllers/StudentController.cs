using _consume_.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace _consume_.Controllers
{
    public class StudentController : Controller
    {
        Uri apiuri = new Uri("http://localhost:54591/");
        HttpClient Client;

        public StudentController()
        {
            Client = new HttpClient();
            Client.BaseAddress = apiuri;
        }
        // GET: Student
        public ActionResult Index()
        {
            List<tbl_model> obj = new List<tbl_model>();
            HttpResponseMessage obj1 = Client.GetAsync(Client.BaseAddress + "Account/Index").Result;
            if (obj1.IsSuccessStatusCode)
            {
                string res = obj1.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<List<tbl_model>>(res);
            }
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_model a)
        {
            string res = JsonConvert.SerializeObject(a);
            StringContent content = new StringContent(res, Encoding.UTF8, "Application/json");
            HttpResponseMessage listobj = Client.PostAsync(Client.BaseAddress + "Account/Create", content).Result;
            if (listobj.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            tbl_model obj = new tbl_model();

            HttpResponseMessage listobj = Client.GetAsync(Client.BaseAddress + "Account/GetEdit" + "?id=" + id).Result;
            if (listobj.IsSuccessStatusCode)
            {
                string res = listobj.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<tbl_model>(res);
            }
            return View(obj);


        }
        [HttpPost]
        public ActionResult Edit(tbl_model a)
        {
            string res = JsonConvert.SerializeObject(a);
            StringContent content = new StringContent(res, Encoding.UTF8, "application/json");
            HttpResponseMessage listobj = Client.PutAsync(Client.BaseAddress + "Account/PostEdit", content).Result;
            if (listobj.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(listobj);
        }
        public ActionResult Delete(int id)
        {
            tbl_model obj = new tbl_model();
            HttpResponseMessage listobj = Client.GetAsync((Client.BaseAddress + "Account/Delete" + "?id=" + id).ToString()).Result;
            if (listobj.IsSuccessStatusCode)
            {
                string res = listobj.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<tbl_model>(res);
                TempData["delete"] = "<script>alert('Emp deleted successfully')</script";
            }
            return RedirectToAction("Index");


        }
    }
}