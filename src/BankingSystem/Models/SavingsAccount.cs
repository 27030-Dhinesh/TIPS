namespace BankingSystem.Models
{
    /// <summary>
    /// Class representing the Savings Account of an customer.
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">Account number for the Savings Account.</param>
        /// <param name="balance">Initial Balance for when creating a new Savings Account.</param>
        public SavingsAccount(string accountNumber, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        /// <summary>
        /// Withdraw money from the customer's bank account.
        /// </summary>
        /// <param name="amount">Amount to withdraw into the customer's bank account.</param>
        /// <returns>True if withdraw successful, false otherwise.</returns>
        public override bool Withdraw(decimal amount)
        {
            if (amount < 0 || this.Balance - amount < 0)
            {
                return false;
            }

            this.Balance -= amount;
            return true;
        }

        /// <summary>
        /// Deposit money to the customer's bank account.
        /// </summary>
        /// <param name="amount">Amount to deposit into the customer's bank account.</param>
        /// <returns>True if deposit successful, false otherwise.</returns>
        public override bool Deposit(decimal amount)
        {
            if (amount < 0)
            {
                return false;
            }

            this.Balance += amount;
            return true;
        }
    }
}
