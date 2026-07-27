using BankingSystem.Models;

namespace BankingSystem.Repository
{
    /// <summary>
    /// In-memory repository to store Bank Accounts of the customers.
    /// </summary>
    internal class BankAccountRepository
    {
        private readonly List<BankAccount> _bankAccounts = new ();

        /// <summary>
        /// Check if BankAccount List is empty or not.
        /// </summary>
        /// <returns>true if Contacts list is empty, false otherwise.</returns>
        public bool IsEmpty() => this._bankAccounts.Count == 0;

        /// <summary>
        /// Add new Bank Account to the Repository.
        /// </summary>
        /// <param name="bankAccount">Bank Account of the customer to add.</param>
        public void AddAccount(BankAccount bankAccount)
        {
            this._bankAccounts.Add(bankAccount);
        }

        /// <summary>
        /// Retrieve Bank Account clone using the account number.
        /// </summary>
        /// <param name="accountNumber">Account number of the Account to retrieve.</param>
        /// <returns>Bank Account clone if found, null otherwise.</returns>
        public BankAccount? GetAccount(string accountNumber)
        {
            (bool foundAccount, int index) = this.FindAccount(accountNumber);

            if (foundAccount)
            {
                return this.Clone(this._bankAccounts[index]);
            }

            return null;
        }

        /// <summary>
        /// Delete a Bank Account from the Repository with the Account Number.
        /// </summary>
        /// <param name="accountNumber">Account Number of the Bank Account to delete.</param>
        /// <returns>True if Bank Account deletion successful, false otherwise. </returns>
        public bool RemoveAccount(string accountNumber)
        {
            (bool foundAccount, int index) = this.FindAccount(accountNumber);

            if (foundAccount)
            {
                this._bankAccounts.RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Update bank account after transactions.
        /// </summary>
        /// <param name="updatedAccount">Updated bank account object.</param>
        /// <returns>True if updation successful, false otherwise.</returns>
        public bool Update(BankAccount updatedAccount)
        {
            (bool isFound, int index) = this.FindAccount(updatedAccount.AccountNumber);
            if (isFound)
            {
                this._bankAccounts[index] = this.Clone(updatedAccount);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether an account exists in the system based on the provided account number.
        /// </summary>
        /// <param name="accountNumber">The unique identifier of the account to check.></param>
        /// <returns>True if the account exists; otherwise, false.</returns>
        public bool AccountExists(string accountNumber)
        {
            return this.FindAccount(accountNumber).isFound;
        }

        private (bool isFound, int index) FindAccount(string accountNumber)
        {
            for (int i = 0; i < this._bankAccounts.Count; ++i)
            {
                if (this._bankAccounts[i].AccountNumber == accountNumber)
                {
                    return (true, i);
                }
            }

            return (false, -1);
        }

        private BankAccount Clone(BankAccount account)
        {
            if (account is SavingsAccount savingsAccount)
            {
                return new SavingsAccount(account.Name, account.AccountNumber, account.Balance);
            }
            else
            {
                return new CheckingAccount(account.Name, account.AccountNumber, account.Balance);
            }
        }
    }
}
