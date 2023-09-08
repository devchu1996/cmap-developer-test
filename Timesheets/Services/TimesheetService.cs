using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Text;
using Timesheets.Infrastructure;
using Timesheets.Models;
using Timesheets.Repositories;

namespace Timesheets.Services
{
    public interface ITimesheetService
    {
        void Add(Timesheet timesheet);
        IList<Timesheet> GetAll();

        string Export();
    }

    public class TimesheetService : ITimesheetService
    {
        private readonly ITimesheetRepository _timesheetRepository;

        public TimesheetService(ITimesheetRepository timesheetRepository)
        {
            _timesheetRepository = timesheetRepository;
        }

        public void Add(Timesheet timesheet)
        {
            _timesheetRepository.AddTimesheet(timesheet);
        }

        public IList<Timesheet> GetAll()
        {
            var timesheets = _timesheetRepository.GetAllTimesheets();
            return timesheets;
        }


        // Export - Export all the timesheet data in CSV
        public string Export()
        {
            var timesheets = _timesheetRepository.GetAllTimesheets();

            // to do: may be change to use helper function later
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Work Date, First Name, Last Name, Project, Work Hours");
            foreach (Timesheet timesheet in timesheets)
            {
                sb.AppendLine(timesheet.TimesheetEntry.Date + ","
                    + timesheet.TimesheetEntry.FirstName + ","
                    + timesheet.TimesheetEntry.LastName + ","
                    + timesheet.TimesheetEntry.Project + ", "
                    + timesheet.TimesheetEntry.Hours
                    );
            }
            return sb.ToString();
        }

    }
}
