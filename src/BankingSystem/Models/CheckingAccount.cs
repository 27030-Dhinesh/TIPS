using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    /// <summary>
    /// Class representing the Checking Account of an customer.
    /// </summary>
    internal class CheckingAccount : BankAccount
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
        public override decimal Balance { get; set; }

        /// <summary>
        /// Gets the Debt amount for the customer's checking account.
        /// </summary>
        /// <value>Debt amount borrowed by the customer.</value>
        public decimal Debt { get; private set; }

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

        /// <summary>
        /// Withdraw money from the customer's bank account.
        /// </summary>
        /// <param name="amount">Amount to withdraw into the customer's bank account.</param>
        /// <returns>True if withdraw successful, false otherwise.</returns>
        public override bool Withdraw(decimal amount)
        {
            this.Balance -= amount;
            return true;
        }
    }
}
