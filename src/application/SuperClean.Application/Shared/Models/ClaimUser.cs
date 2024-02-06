using System.Security.Claims;

namespace SuperClean.Application.Shared.Models
{
    public class ClaimUser
    {
        public IReadOnlyList<Claim> Claims { get; private set; }
    }
}
