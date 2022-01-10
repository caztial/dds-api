using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class ListAgentByIdSpec : Specification<Agent>, ISingleResultSpecification
    {
        public ListAgentByIdSpec(int agentId, bool withAssignemnts)
        {
            Query.Where(a => a.Id.Equals(agentId));
            if (withAssignemnts)
            {
                Query.Include(a => a.Assignments.Where(a=>a.AgentId.Equals(agentId)));
            }
           
        }
    }
}
