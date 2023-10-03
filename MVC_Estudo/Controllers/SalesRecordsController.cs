using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MVC_Estudo.Services;

namespace MVC_Estudo.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(2018, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("dd/MM/yyyy");
            ViewData["maxDate"] = minDate.Value.ToString("dd/MM/yyyy");

            var result = await _salesRecordService.FindBydateAsync(minDate, maxDate);

            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(2018, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("dd/MM/yyyy");
            ViewData["maxDate"] = minDate.Value.ToString("dd/MM/yyyy");

            var result = await _salesRecordService.FindBydateGroupingAsync(minDate, maxDate);

            return View(result);
        }
    }
}
