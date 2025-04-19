using MerchatService.API.Domain.Common;

namespace MerchatService.API.Domain.Entities;

public class Merchant : BaseEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required ContactInformation ContactInformation { get; set; }
}


