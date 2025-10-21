namespace Wolds.Hr.Api.Cr.Library.Dto.Requests.Department;

public class UpdateDepartmentRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
