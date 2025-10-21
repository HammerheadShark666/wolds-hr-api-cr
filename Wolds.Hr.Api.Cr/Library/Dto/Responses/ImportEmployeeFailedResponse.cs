﻿namespace Wolds.Hr.Api.Cr.Library.Dto.Responses;

public class ImportEmployeeFailedResponse
{
    public Guid Id { get; set; }

    public string Employee { get; set; } = string.Empty;

    public required List<string> Errors { get; set; } = [];
}
