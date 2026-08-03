namespace BankingSystem.Models
{
    /// <summary>
    /// Represents a customer's bank account and defines the base functionality
    /// for all bank account types.
    /// </summary>
    internal abstract class BankAccount
    {
        /// <summary>
        /// Gets or sets the name of the account holder.
        /// </summary>
        /// <value>
        /// The name of the account holder.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the account number associated with the customer's bank account.
        /// </summary>
        /// <value>
        /// The account number of the customer's bank account.
        /// </value>
        public string AccountNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the current balance of the customer's bank account.
        /// </summary>
        /// <value>
        /// The current account balance.
        /// </value>
        public decimal Balance { get; protected set; } = decimal.Zero;

        /// <summary>
        /// Withdraws the specified amount from the bank account.
        /// </summary>
        /// <param name="amount">
        /// The amount to withdraw.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the withdrawal is successful; otherwise, <see langword="false"/>.
        /// </returns>
        public abstract bool Withdraw(decimal amount);

        /// <summary>
        /// Deposits the specified amount into the bank account.
        /// </summary>
        /// <param name="amount">
        /// The amount to deposit.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the deposit is successful; otherwise, <see langword="false"/>.
        /// </returns>
        public abstract bool Deposit(decimal amount);

        /// <summary>
        /// Returns a string that contains the details of the bank account.
        /// </summary>
        /// <returns>
        /// A string representation of the bank account.
        /// </returns>
        public override string ToString()
        {
            return $@"This is a {this.GetType().Name}.
Account Holder Name: {this.Name}
Account Number: {this.AccountNumber}
Account Balance: {this.Balance}
";
        }
    }
}
