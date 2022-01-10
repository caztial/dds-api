using SharedKernal;
using SharedKernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Account:  IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public AgentAssignment AgentAssignment { get; set; }
        public Account(string name, bool verified=false)
        {
            Name = name;
            IsVerified = verified;
            CreatedOn = DateTimeOffset.UtcNow;
        }        

        private Account() { }

        public void VerifyAccount()
        {
            IsVerified = true;
        }

        public static implicit operator List<object>(Account? v)
        {
            throw new NotImplementedException();
        }
    }
}
