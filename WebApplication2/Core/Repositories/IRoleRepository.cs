using WebApplication2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
