using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    /// <summary>
    /// Enum to represent the deposit and withdraw transaction types.
    /// </summary>
    internal enum TransactionType
    {
        /// <summary>
        /// Deposit amount to the Bank Account.
        /// </summary>
        Deposit,

        /// <summary>
        /// Withdraw amount from the Bank Account.
        /// </summary>
        Withdraw,
    }
}
