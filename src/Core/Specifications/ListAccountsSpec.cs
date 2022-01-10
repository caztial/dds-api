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
        public ListAccountsSpec(bool? status,int take, int skip)
        {
            if(status != null)
            {
                Query.Where(a => a.IsVerified.Equals(status)).Take(take).Skip(skip);
            }
            else
            {
                Query.Take(take).Skip(skip);
            }
            
        }
    }
}
