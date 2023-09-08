using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using Timesheets.Models;
using Timesheets.Services;

namespace Timesheets.Controllers
{
    public class TimesheetController : Controller
    {
        private ITimesheetService _timesheetService;

        public TimesheetController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TimesheetEntry timesheetEntry)
        {
            if (ModelState.IsValid)
            {
                var timesheet = new Timesheet()
                {
                    TimesheetEntry = timesheetEntry,
                    TotalHours = timesheetEntry.Hours
                };
                _timesheetService.Add(timesheet);

                var timesheets = _timesheetService.GetAll();
                if (timesheets != null)
                {
                    // view all timesheets and logged the most hours against a project. so make it sort by project, then hours desc  
                    ViewBag.Timesheets = timesheets.OrderBy(x => x.TimesheetEntry.Project).ThenByDescending(x => Convert.ToDecimal(x.TimesheetEntry.Hours));                    
                }
            }
            return View();
        }

        // ExportCSV - Export all the timesheet data in CSV for user to download
        [HttpPost]
        public FileResult ExportCSV()
        {
            return File(Encoding.UTF8.GetBytes(_timesheetService.Export()), "text/csv", "Timesheets.csv");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}