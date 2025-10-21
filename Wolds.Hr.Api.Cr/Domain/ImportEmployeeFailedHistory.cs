﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wolds.Hr.Api.Cr.Domain;

public class ImportEmployeeFailedHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Employee { get; set; } = string.Empty;

    public Guid ImportEmployeeHistoryId { get; set; }

    public required List<ImportEmployeeFailedErrorHistory> Errors { get; set; } = [];
}