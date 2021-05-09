
using Core.Entities;

namespace Infrastructure.TenantProvider
{
  public interface ITenantProvider
  {
    Tenant GetTenant();
  }
}