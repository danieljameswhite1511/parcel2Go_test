using System.Linq;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.TenantProvider
{
  public class TenantProvider : ITenantProvider
  {
    private readonly DataContext _dataContext;

    public TenantProvider(DataContext dataContext)
    {
      this._dataContext = dataContext;
      
    }

    public Tenant GetTenant()
    {
      return this._dataContext.GetTenant();
      
    }
  }
}