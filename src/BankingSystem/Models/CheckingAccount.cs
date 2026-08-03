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
        /// <param name="name">Name of the Account holder.</param>
        /// <param name="balance">Initial Balance for when creating a new Checking Account.</param>
        public CheckingAccount(string name, decimal balance)
        {
            this.Name = name;
            this.Balance = balance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="name">Name of the Account holder.</param>
        /// <param name="accountNumber">Account number for the Checking Account.</param>
        /// <param name="balance">Initial Balance for when creating a new Checking Account.</param>
        public CheckingAccount(string name, string accountNumber, decimal balance)
            : this(name, balance)
        {
            this.AccountNumber = accountNumber;
        }

        /// <summary>
        /// Gets the Debt amount for the customer's checking account.
        /// </summary>
        /// <value>Debt amount borrowed by the customer.</value>
        public decimal Debt => this.Balance < 0 ? Math.Abs(this.Balance) : 0;

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
        /// Withdraw money from the customer's bank account.
        /// </summary>
        /// <param name="amount">Amount to withdraw into the customer's bank account.</param>
        /// <returns>True if withdraw successful, false otherwise.</returns>
        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            this.Balance -= amount;
            return true;
        }

        /// <summary>
        /// Details of the Bank Account.
        /// </summary>
        /// <returns>Account details.</returns>
        public override string ToString()
        {
            return base.ToString() + $"Debt Amount: {this.Debt}";
        }

        /// <summary>
        /// Creates a new <see cref="CheckingAccount"/> instance by copying core details from the current bank account.
        /// </summary>
        /// <returns>
        /// A new <see cref="BankAccount"/> reference pointing to the cloned <see cref="CheckingAccount"/> instance.
        /// </returns>
        public override BankAccount Clone()
        {
            // Cast is required because MemberwiseClone returns 'object'
            return (CheckingAccount)this.MemberwiseClone();
        }
    }
}
