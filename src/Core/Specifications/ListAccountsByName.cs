using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class ListAccountsByName : Specification<Account>
    {
        public ListAccountsByName(string name)
        {
            Query.Where(a=>a.Name == name);
        }
    }
}
