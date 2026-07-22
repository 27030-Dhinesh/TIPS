namespace BankingSystem.Models
{
    /// <summary>
    /// Model class representing the Bank Account of an customer.
    /// </summary>
    internal abstract class BankAccount
    {
        /// <summary>
        /// Gets or sets the Account Number for the customer's bank account.
        /// </summary>
        /// <value>Account number of the customer's bank account.</value>
        public string AccountNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Balance of the customer's bank account initially.
        /// </summary>
        /// <value>Account balance of the customer's bank account.</value>
        public decimal Balance { get; protected set; } = decimal.Zero;

        /// <summary>
        /// Withdraw money from the customer's bank account.
        /// </summary>
        /// <param name="amount">Amount to withdraw into the customer's bank account.</param>
        /// <returns>True if withdraw successful, false otherwise.</returns>
        public abstract bool Withdraw(decimal amount);

        /// <summary>
        /// Deposit money to the customer's bank account.
        /// </summary>
        /// <param name="amount">Amount to deposit into the customer's bank account.</param>
        /// <returns>True if deposit successful, false otherwise.</returns>
        public abstract bool Deposit(decimal amount);
    }
}
