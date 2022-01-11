using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class GetAccountByIdSpec : Specification<Account>, ISingleResultSpecification
    {
        public GetAccountByIdSpec(int id)
        {
            Query.Include(a => a.AgentAssignment).Where(a => a.Id == id);
        }
    }
}
