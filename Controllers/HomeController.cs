﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Foro.Models;
using Microsoft.EntityFrameworkCore;

namespace Foro.Controllers {
 public class HomeController: Controller {
  private readonly MvcContext _context;

  public HomeController(MvcContext context) {
   _context = context;
  }

  public async Task < IActionResult > Login(String name, String password) {

   if (name == null || password == null) {
    return RedirectToAction(nameof(Index));
   }

   var user = await _context.User.SingleOrDefaultAsync(m => m.Name == name && m.Password == password);
   if (user == null) {

    //TempData["Error"]= "Mejorar";

    return RedirectToAction(nameof(Index));

   }
    Session.idSingin = user.ID;
   Session.isSingin = true;
   Session.isAdmin = "Permissions".Equals(user.Account) ? true : false;
   return RedirectToAction(nameof(Principal));


  }
  public IActionResult Index() {
   Session.idSingin = 0;
   Session.isSingin = false;
   return View();
  }
  
  public IActionResult Principal() {

   return View();
  }

  public IActionResult Error() {
   return View(new ErrorViewModel {
    RequestId = Activity.Current? .Id ?? HttpContext.TraceIdentifier
   });
  }

 }
}