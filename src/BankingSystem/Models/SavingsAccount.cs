using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    /// <summary>
    /// Class representing the Savings Account of an user.
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Gets or sets the Account Number for the user's savings account.
        /// </summary>
        /// <value>Account number of the user's bank account.</value>
        public override string AccountNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Balance of the user's bank account initially.
        /// </summary>
        /// <value>Account balance of the user's bank account.</value>
        public override decimal Balance { get; set; } = decimal.Zero;

        /// <summary>
        /// Withdraw money from the user's bank account.
        /// </summary>
        /// <param name="amount">Amount to withdraw into the user's bank account.</param>
        /// <returns>True if withdraw successful, false otherwise.</returns>
        public override bool Withdraw(decimal amount)
        {
            if (Balance - amount > 0)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deposit money to the user's bank account.
        /// </summary>
        /// <param name="amount">Amount to deposit into the user's bank account.</param>
        /// <returns>True if deposit successful, false otherwise.</returns>
        public override bool Deposit(decimal amount)
        {
            Balance += amount;
            return true;
        }
    }
}
