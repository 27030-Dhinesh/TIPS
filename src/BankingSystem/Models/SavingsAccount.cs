using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    /// <summary>
    /// Class representing the Savings Account of an customer.
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Gets or sets the Account Number for the customer's savings account.
        /// </summary>
        /// <value>Account number of the customer's bank account.</value>
        public override string AccountNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Balance of the customer's bank account initially.
        /// </summary>
        /// <value>Account balance of the customer's bank account.</value>
        public override decimal Balance { get; set; } = decimal.Zero;

        /// <summary>
        /// Withdraw money from the customer's bank account.
        /// </summary>
        /// <param name="amount">Amount to withdraw into the customer's bank account.</param>
        /// <returns>True if withdraw successful, false otherwise.</returns>
        public override bool Withdraw(decimal amount)
        {
            if (this.Balance - amount > 0)
            {
                this.Balance -= amount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deposit money to the customer's bank account.
        /// </summary>
        /// <param name="amount">Amount to deposit into the customer's bank account.</param>
        /// <returns>True if deposit successful, false otherwise.</returns>
        public override bool Deposit(decimal amount)
        {
            this.Balance += amount;
            return true;
        }
    }
}
