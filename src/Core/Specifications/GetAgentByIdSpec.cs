using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class GetAgentByIdSpec : Specification<Agent>, ISingleResultSpecification
    {
        public GetAgentByIdSpec(int agentId, bool withAssignemnts)
        {
            Query.Where(a => a.Id.Equals(agentId));
            if (withAssignemnts)
            {
                Query.Include(a=>a.Group)
                    .Include(a => a.Assignments.Where(a=>a.AgentId.Equals(agentId)))
                    .ThenInclude(a=>a.Account);
            }
           
        }
    }

    public class ListAgentWithGroupSpec : Specification<Agent>
    {
        public ListAgentWithGroupSpec()
        {
            Query.Include(a => a.Group);                   
        }
    }
}
