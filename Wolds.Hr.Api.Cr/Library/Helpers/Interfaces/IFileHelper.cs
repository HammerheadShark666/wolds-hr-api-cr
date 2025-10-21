namespace Wolds.Hr.Api.Cr.Library.Helpers.Interfaces;

internal interface IFileHelper
{
    string GetGuidFileName(string extension);
    bool FileHasContent(IFormFile? file);
    Task<IFormFile?> GetFileAsync(HttpRequest request);
    Task<List<string>> ReadAllLinesAsync(IFormFile file);
}
