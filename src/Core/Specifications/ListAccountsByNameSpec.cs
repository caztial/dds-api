using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class ListAccountsByNameSpec : Specification<Account>
    {
        public ListAccountsByNameSpec(string name)
        {
            Query.Where(a=>a.Name == name);
        }
    }
}
