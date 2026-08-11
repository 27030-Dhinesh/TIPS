using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the available menu options for managing income entries.
    /// </summary>
    public enum IncomeMenu
    {
        /// <summary>
        /// Adds a new income record.
        /// </summary>
        AddIncome = 1,

        /// <summary>
        /// Displays existing income records.
        /// </summary>
        ViewIncome,

        /// <summary>
        /// Modifies an existing income record.
        /// </summary>
        EditIncome,

        /// <summary>
        /// Removes an existing income record.
        /// </summary>
        DeleteIncome,

        /// <summary>
        /// Switch back to the main menu.
        /// </summary>
        SwitchToMainMenu,
    }
}
