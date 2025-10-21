﻿namespace Wolds.Hr.Api.Cr.Library.Dto.Requests;

public record EmployeePagedRequest
{
    public required string Keyword { get; init; }
    public required int PageNumber { get; init; }
    public required int PageSize { get; init; }

    public EmployeePagedRequest(string keyword, int pageNumber, int pageSize)
    {
        Keyword = keyword;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}