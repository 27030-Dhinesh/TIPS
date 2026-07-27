using System.Security.Cryptography;
using System.Text;
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
        /// <returns>The unique account number of the newly generated bank account.</returns>
        public string AddAccount(BankAccount account)
        {
            string accountNumber;
            do
            {
                accountNumber = this.GenerateAccountNumber();
                if (!this._accountRepository.AccountExists(accountNumber))
                {
                    break;
                }
            }
            while (true);

            account.AccountNumber = accountNumber;
            this._accountRepository.AddAccount(account);

            return accountNumber;
        }

        /// <summary>
        /// Retrieve bank account clone using the account number.
        /// </summary>
        /// <param name="accountNumber">Account number to search account from the repository.</param>
        /// <returns>BankAccount clone if account found, null otherwise.</returns>
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

        /// <summary>
        /// Withdraw or Deposit amount in Bank Account.
        /// </summary>
        /// <param name="accountNumber">Account Number of the Bank Account to withdraw/deposit.</param>
        /// <param name="type">Transaction type [ Deposit, Withdraw ]</param>
        /// <param name="amount">Amount to either deposit or withdraw.</param>
        /// <returns>True if transaction successful, false otherwise.</returns>
        public bool Transaction(string accountNumber, TransactionType type, decimal amount)
        {
            BankAccount? account = this.GetAccount(accountNumber);

            if (account == null)
            {
                return false;
            }

            switch (type)
            {
                case TransactionType.Withdraw:
                    if (account.Withdraw(amount))
                    {
                        return this._accountRepository.Update(account);
                    }

                    break;

                case TransactionType.Deposit:
                    if (account.Deposit(amount))
                    {
                        return this._accountRepository.Update(account);
                    }

                    break;
            }

            return false;
        }

        private string GenerateAccountNumber()
        {
            const int LENGTH = 12;
            const string CHARS = "0123456789";
            StringBuilder result = new StringBuilder(LENGTH);

            // Use the cryptographic random number generator
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[sizeof(uint)];

                while (result.Length < LENGTH)
                {
                    rng.GetBytes(buffer);
                    uint num = BitConverter.ToUInt32(buffer, 0);

                    // Map the random number to a valid digit index
                    int index = (int)(num % (uint)CHARS.Length);
                    result.Append(CHARS[index]);
                }
            }

            return result.ToString();
        }
    }
}
