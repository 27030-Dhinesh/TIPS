namespace BankingSystem.Models
{
    /// <summary>
    /// Class representing the Checking Account of an customer.
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">Account number for the Checking Account.</param>
        /// <param name="balance">Initial Balance for when creating a new Checking Account.</param>
        public CheckingAccount(string accountNumber, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

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
