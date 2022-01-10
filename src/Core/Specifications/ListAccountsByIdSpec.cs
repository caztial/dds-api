using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class ListAccountsByIdSpec : Specification<Account>, ISingleResultSpecification
    {
        public ListAccountsByIdSpec(int id)
        {
            Query.Include(a => a.AgentAssignment).Where(a => a.Id == id);
        }
    }
}
