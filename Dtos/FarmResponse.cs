
namespace Umuhinzi.Dtos;

public record FarmResponse(
    long Id,
    string Name,
    string Location,
    string? CertificationId,
    bool Verified,
    long? OwnerId,
    string? OwnerUsername
);