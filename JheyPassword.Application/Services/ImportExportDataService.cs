using JheyPassword.Business.Entities;
using JheyPassword.Business.Interfaces.Repositories;
using JheyPassword.Business.Interfaces.Services;
using OfficeOpenXml;
using System.Xml.Linq;

namespace JheyPassword.Application.Services;

public class ImportExportDataService(IPasswordRepository passwordRepository) : IImportExportDataService
{
    public async Task ImportExcel(Stream excelStream)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var data = new List<PasswordEntity>();

        using var package = new ExcelPackage(excelStream);
        var worksheet = package.Workbook.Worksheets[0]; 
        var rowCount = worksheet.Dimension.Rows;

        for (var row = 2; row <= rowCount; row++)
        {
            var item = new PasswordEntity()
            {
                Title = worksheet.Cells[row, 1].Text,
                User = worksheet.Cells[row, 2].Text,
                Password = worksheet.Cells[row, 3].Text
            };

            data.Add(item);
        }

        await passwordRepository.CreateAsync(data);
    }

    public byte[] ExportToExcel(List<PasswordEntity> data)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Dados Exportados");

        worksheet.Cells[1, 1].Value = "Title";
        worksheet.Cells[1, 2].Value = "User";
        worksheet.Cells[1, 3].Value = "Password";

        // Dados
        for (int i = 0; i < data.Count; i++)
        {
            worksheet.Cells[i + 2, 1].Value = data[i].Title;
            worksheet.Cells[i + 2, 2].Value = data[i].User;
            worksheet.Cells[i + 2, 3].Value = data[i].Password;
        }

        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

        return package.GetAsByteArray();
    }
}