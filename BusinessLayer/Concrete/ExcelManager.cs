﻿using BusinessLayer.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExcelManager : IExcelService
    {
        public byte[] ExcelList<T>(List<T> t) where T : class
        {
            ExcelPackage excel = new ExcelPackage();
            var data = excel.Workbook.Worksheets.Add("Page1");
            data.Cells["A1"].LoadFromCollection(t, true, OfficeOpenXml.Table.TableStyles.Light8);
            return excel.GetAsByteArray();
        }
    }
}
