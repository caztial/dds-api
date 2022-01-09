using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ListAccountsSpec : Specification<Account>
    {
        public ListAccountsSpec(int take, int skip)
        {
            Query.Take(take).Skip(skip);
        }
    }
}
