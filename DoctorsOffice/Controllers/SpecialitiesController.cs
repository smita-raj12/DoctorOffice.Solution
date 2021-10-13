using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class SpecialitiesController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public SpecialitiesController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Specialty> model = _db.Specialities.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Specialty speciality)
    {
      _db.Specialities.Add(speciality);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSpeciality = _db.Specialities
          .Include(Speciality => Speciality.JoinEntities)
          .ThenInclude(join => join.Doctor)
          .FirstOrDefault(speciality => speciality.SpecialtyId == id);
      return View(thisSpeciality);
    }
    public ActionResult Edit(int id)
    {
      var thisSpeciality = _db.Specialities.FirstOrDefault(speciality => speciality.SpecialtyId == id);
      return View(thisSpeciality);
    }

    [HttpPost]
    public ActionResult Edit(Specialty speciality)
    {
      _db.Entry(speciality).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisSpeciality = _db.Specialities.FirstOrDefault(speciality => speciality.SpecialtyId == id);
      return View(thisSpeciality);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSpeciality = _db.Specialities.FirstOrDefault(speciality => speciality.SpecialtyId == id);
      _db.Specialities.Remove(thisSpeciality);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    // [HttpPost]
    // public ActionResult DeleteSpecialty(int joinId)
    // {
    //   var joinEntry = _db.SpecialtyDoctor.FirstOrDefault(entry => entry.SpecialtyDoctorId == joinId);
    //   _db.SpecialtyDoctor.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}