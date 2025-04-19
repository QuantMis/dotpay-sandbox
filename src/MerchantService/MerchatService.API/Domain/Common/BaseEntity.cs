namespace MerchatService.API.Domain.Common;

public abstract class BaseEntity 
{
  public required Guid Id {get; init;}
  public DateTime CreatedAt {get; set;}
  public DateTime? UpdatedAt {get; set;}

}
