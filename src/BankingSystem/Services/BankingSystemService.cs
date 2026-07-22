using BankingSystem.Models;
using BankingSystem.Repository;

namespace BankingSystem.Services
{
    /// <summary>
    /// Service layer to support Banking System task.
    /// </summary>
    internal class BankingSystemService
    {
        private readonly BankAccountRepository _accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankingSystemService"/> class.
        /// </summary>
        /// <param name="accountRepository">Repository to store all accounts.</param>
        public BankingSystemService(BankAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        /// <summary>
        /// Add a new Bank Account to the account repository.
        /// </summary>
        /// <param name="account">Bank Account to be added to the account repository.</param>
        public void AddAccount(BankAccount account)
        {
            this._accountRepository.AddAccount(account);
        }

        /// <summary>
        /// Retrieve bank account using the account number.
        /// </summary>
        /// <param name="accountNumber">Account number to search account from the repository.</param>
        /// <returns>BankAccount if account found, null otherwise.</returns>
        public BankAccount? GetAccount(string accountNumber)
        {
            return this._accountRepository.GetAccount(accountNumber);
        }

        /// <summary>
        /// Delete a Bank Account from the Repository with the Account Number.
        /// </summary>
        /// <param name="accountNumber">Account Number of the Bank Account to delete.</param>
        /// <returns>True if Bank Account deletion successful, false otherwise.</returns>
        public bool DeleteAccount(string accountNumber)
        {
            return this._accountRepository.RemoveAccount(accountNumber);
        }
    }
}
