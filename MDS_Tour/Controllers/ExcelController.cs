using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using MDS_Tour.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace MDS_Tour.Controllers
{
    public class ExcelController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using(var c =new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }

        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var data = excel.Workbook.Worksheets.Add("Page1");
            data.Cells[1, 1].Value = "Destination";
            data.Cells[1, 2].Value = "Guide";
            data.Cells[1, 3].Value = "Capcity";


            data.Cells[2, 1].Value = "Afyonkarahisar";
            data.Cells[2, 2].Value = "Ali Rıza";
            data.Cells[2, 3].Value = "40";

            data.Cells[3, 1].Value = "Bodrum";
            data.Cells[3, 2].Value = "Gamze Kalem";
            data.Cells[3, 3].Value = "100";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "tourr2.xlsx");
        }

        public IActionResult DestinationExcelReport()
        {
            using (var data = new XLWorkbook())
            {
                var workdata = data.Worksheets.Add("Tour List");
                workdata.Cell(1, 1).Value = "City";
                workdata.Cell(1, 2).Value = "Day - Night";
                workdata.Cell(1, 3).Value = "Price";
                workdata.Cell(1, 4).Value = "Capacity";

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workdata.Cell(rowCount,1).Value = item.City;
                    workdata.Cell(rowCount, 2).Value = item.DayNight;
                    workdata.Cell(rowCount, 3).Value = item.Price;
                    workdata.Cell(rowCount, 4).Value = item.Capacity;
                      rowCount++;

                }
                using (var stream = new MemoryStream())
                {
                    data.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "NewTourList.xlsx"); 
                }
            }
        }
    }
}
