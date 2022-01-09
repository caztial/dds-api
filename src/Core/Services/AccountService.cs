using Core.Entities;
using Core.Specifications;
using SharedKernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _repository;
        public AccountService(IRepository<Account> repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsDuplicateAccount(string accountName)
        {
            var listAccountSpec = new ListAccountsByName(accountName);
            var accounts = await _repository.ListAsync(listAccountSpec);
            return accounts.Count > 0;
        }

    }
}
