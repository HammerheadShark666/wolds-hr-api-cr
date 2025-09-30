namespace wolds_hr_api.Helper.Extensions;

public static class AppExtensions
{
    public static void AddCors(this WebApplication webApplication)
    {
        webApplication.UseCors("WoldsHrFrontendPolicy");
    }
}