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
        /// <param name="name">Name of the Account holder.</param>
        /// <param name="balance">Initial Balance for when creating a new Savings Account.</param>
        public SavingsAccount(string name, decimal balance)
        {
            this.Name = name;
            this.Balance = balance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="name">Name of the Account holder.</param>
        /// <param name="accountNumber">Account number for the Savings Account.</param>
        /// <param name="balance">Initial Balance for when creating a new Savings Account.</param>
        public SavingsAccount(string name, string accountNumber, decimal balance)
            : this(name, balance)
        {
            this.AccountNumber = accountNumber;
        }

        /// <summary>
        /// Withdraw money from the customer's bank account.
        /// </summary>
        /// <param name="amount">Amount to withdraw into the customer's bank account.</param>
        /// <returns>True if withdraw successful, false otherwise.</returns>
        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > this.Balance)
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
            if (amount <= 0)
            {
                return false;
            }

            this.Balance += amount;
            return true;
        }

        /// <summary>
        /// Creates a new <see cref="SavingsAccount"/> instance by copying core details from the current bank account.
        /// </summary>
        /// <returns>
        /// A new <see cref="BankAccount"/> reference pointing to the cloned <see cref="SavingsAccount"/> instance.
        /// </returns>
        public override BankAccount Clone()
        {
            // Cast is required because MemberwiseClone returns 'object'
            return (SavingsAccount)this.MemberwiseClone();
        }
    }
}
