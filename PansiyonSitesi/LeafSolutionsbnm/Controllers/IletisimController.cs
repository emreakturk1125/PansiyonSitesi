﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LeafSolutionsbnm.Models;

namespace LeafSolutionsbnm.Controllers
{
    public class IletisimController : Controller
    {
        //
        // GET: /İletişim/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(IletisimModel model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine("Kullanıcı Adı: " + model.NickName);
                body.AppendLine("İsim: " + model.FullName);
                body.AppendLine("Tel: " + model.Phone);
                body.AppendLine("Eposta: " + model.Email);
                body.AppendLine("Konu: " + model.Message);
                Gmail.SendMail(body.ToString());
                ViewBag.Success = true;
            }
            return View();
        }          

    }
}
