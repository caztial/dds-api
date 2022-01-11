using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class GetAccountByNameSpec : Specification<Account>, ISingleResultSpecification
    {
        public GetAccountByNameSpec(string name)
        {
            Query.Include(a => a.AgentAssignment).Where(a => a.Name == name);
        }
    }
}
