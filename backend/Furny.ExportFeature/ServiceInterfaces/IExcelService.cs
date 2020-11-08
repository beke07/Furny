namespace Furny.ExportFeature.ServiceInterfaces
{
    public interface IExcelService
    {
        string UpdateCell(string docName, string column, uint row, string text);
    }
}
