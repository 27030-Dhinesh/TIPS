using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Delete a Bank Account from the Repository with the Account Number.
        /// </summary>
        /// <param name="accountNumber">Account Number of the Bank Account to delete.</param>
        /// <returns>True if Bank Account deletion successful, false otherwise. </returns>
        public bool RemoveAccount(string accountNumber)
        {
            bool foundAccount = this.FindAccount(accountNumber);

            if (foundAccount)
            {
                for (int i = this._bankAccounts.Count - 1; i >= 0; --i)
                {
                    if (this._bankAccounts[i].AccountNumber.Equals(accountNumber))
                    {
                        this._bankAccounts.RemoveAt(i);
                        return true;
                    }
                }
            }

            return false;
        }

        private bool FindAccount(string accountNumber)
        {
            foreach (BankAccount bankAccount in this._bankAccounts)
            {
                if (bankAccount.AccountNumber == accountNumber)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
