using MerchatService.API.Domain.Common;

namespace MerchatService.API.Domain.Entities;

public class ContactInformation : BaseEntity
{

    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Position { get; set; }
    public required string PhoneNumber { get; set; }
    public required Merchant Merchant { get; set; }
    public required int MerchantId { get; set; }

}

