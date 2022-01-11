using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class GetAgentByUsernameSpec : Specification<Agent>, ISingleResultSpecification
    {
        public GetAgentByUsernameSpec(string username, bool withAssignemnts)
        {
            Query.Where(a => a.Username.Equals(username));
            if (withAssignemnts)
            {
                Query.Include(a=>a.Group)
                    .Include(a => a.Assignments)
                    .ThenInclude(a => a.Account);
            }

        }
    }
}
