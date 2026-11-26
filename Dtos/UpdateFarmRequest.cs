using System.ComponentModel.DataAnnotations;

namespace Umuhinzi.Dtos;

public record UpdateFarmRequest
{
    [Required, StringLength(150)]
    public string Name { get; init; } = string.Empty;

    [Required, StringLength(250)]
    public string Location { get; init; } = string.Empty;

    [StringLength(100)]
    public string? CertificationId { get; init; }

    public long? OwnerId { get; init; }
}
