using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalExam.Models;

namespace FinalExam.Controllers;

public class HomeController : Controller
{

    private IEntertainersRepository _repo { get; set; }
    private EntertainmentDbContext _entertainmentContext { get; set; }

    public HomeController(IEntertainersRepository temp, EntertainmentDbContext entertainmentDbContext)
    {
        _repo = temp;
        _entertainmentContext = entertainmentDbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult StageNames()
    {
        var blah = _repo.Entertainers.ToList();

        return View(blah);
    }

    public IActionResult Detail(int entid)
    {
        ViewBag.EntData = _entertainmentContext.Entertainers.ToList();

        var record = _entertainmentContext.Entertainers.Single(data => data.EntertainerID == entid);

        return View(record);
    }

    // GET - Edit
    [HttpGet]
    public IActionResult Edit(int entid)
    {
        ViewBag.EntData = _entertainmentContext.Entertainers.ToList();

        var record = _entertainmentContext.Entertainers.Single(data => data.EntertainerID == entid);

        return View(record);
    }

    // POST - Edit
    [HttpPost]
    public IActionResult Edit(Entertainer e, int entid)
    {
        if (ModelState.IsValid)
        {
            _entertainmentContext.Update(e);
            _entertainmentContext.SaveChanges();

            return RedirectToAction("StageNames");
        }
        else
        {
            ViewBag.EntData = _entertainmentContext.Entertainers.ToList();

            var record = _entertainmentContext.Entertainers.Single(data => data.EntertainerID == entid);

            return View("Edit", record);
        }
    }

    // GET - Record
    [HttpGet]
    public IActionResult AddEntertainer()
    {
        ViewBag.Entertainer = _entertainmentContext.Entertainers
            .ToList();

        return View();
    }

    // POST - Record
    [HttpPost]
    public IActionResult AddEntertainer(Entertainer e)
    {
        if (ModelState.IsValid)
        {
            _entertainmentContext.Add(e);
            _entertainmentContext.SaveChanges();

            return View("Confirmation", e);
        }
        else
        {
            ViewBag.MummyData = _entertainmentContext.Entertainers
                .ToList();

            return View();
        }
    }

    // GET - Delete
    [HttpGet]
    public IActionResult Delete(int entid)
    {
        var form = _entertainmentContext.Entertainers.Single(data => data.EntertainerID == entid);

        return View(form);
    }

    // POST- Delete
    [HttpPost]
    public IActionResult Delete(Entertainer e)
    {
        _entertainmentContext.Entertainers.Remove(e);
        _entertainmentContext.SaveChanges();

        return RedirectToAction("StageNames");
    }
}

