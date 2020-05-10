using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Furny.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Furny.Services
{
    public class ExcelService : IExcelService
    {
        public string UpdateCell(string docName, string column, uint row, string text)
        {
            var path = $"{System.AppDomain.CurrentDomain.BaseDirectory}Export/{docName}.xlsx";
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(path, true))
            {
                WorksheetPart worksheetPart = RetrieveSheetPartByName(spreadsheet, "Munka1");

                if (worksheetPart != null)
                {
                    Cell cell = InsertCellInSheet(column, row, worksheetPart);
                    cell.CellValue = new CellValue(text);  
                    cell.DataType = new EnumValue<CellValues>(CellValues.String);           
                    worksheetPart.Worksheet.Save();
                }
            }

            return path;
        }

        private WorksheetPart RetrieveSheetPartByName(SpreadsheetDocument document, string sheetName)
        {
            IEnumerable<Sheet> sheets =
             document.WorkbookPart.Workbook.GetFirstChild<Sheets>().
            Elements<Sheet>().Where(s => s.Name == sheetName);
            if (sheets.Count() == 0)
                return null;

            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)
            document.WorkbookPart.GetPartById(relationshipId);
            return worksheetPart;
        }

        private Cell InsertCellInSheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            else
            {
                row = new Row()
                {
                    RowIndex = rowIndex
                };
                sheetData.Append(row);
            }
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            else
            {
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }
                Cell newCell = new Cell()
                {
                    CellReference = cellReference
                };
                row.InsertBefore(newCell, refCell);
                worksheet.Save();
                return newCell;
            }
        }
        private Cell RetreiveCell(Worksheet worksheet,
         string columnName, uint rowIndex)
        {
            Row row = RetrieveRow(worksheet, rowIndex);
            var newRow = new Row()
            {
                RowIndex = (uint)rowIndex + 1
            };
            worksheet.InsertAt(newRow, Convert.ToInt32(rowIndex + 1));
            Cell cell = new Cell();
            cell.CellValue = new CellValue("");
            cell.DataType =
             new EnumValue<CellValues>(CellValues.String);
            newRow.AddAnnotation(cell);
            worksheet.Save();

            row = newRow;
            if (row == null)
                return null;
            return row.Elements<Cell>().Where(c => string.Compare(c.CellReference.Value, columnName +
         (rowIndex + 1), true) == 0).First();
        }

        private Row RetrieveRow(Worksheet worksheet, uint rowIndex)
        {
            return worksheet.GetFirstChild<SheetData>().
            Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
        }
    }
}
