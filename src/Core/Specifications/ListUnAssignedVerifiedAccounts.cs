using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class ListUnAssignedVerifiedAccounts : Specification<Account>
    {
        public ListUnAssignedVerifiedAccounts(int limit)
        {
            Query.Include(a => a.AgentAssignment)
                .Where(a => a.AgentAssignment == null && a.IsVerified)
                .Take(limit);
        }
    }
}
