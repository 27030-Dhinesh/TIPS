using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.TaskOne
{
    public class Divide
    {
        private int _num1;
        private int _num2;

        public Divide(int num1, int num2)
        {
            this._num1 = num1;
            this._num2 = num2;
        }

        public int Num1
        {
            get
            {
                return this._num1;
            }

            set
            {
                this._num1 = value;
            }
        }

        public int Num2
        {
            get
            {
                return this._num2;
            }

            set
            {
                this._num2 = value;
            }
        }

        public int Quotient => this.CalculateQuotient();

        private int CalculateQuotient()
        {
            return this.Num1 / this.Num2;
        }
    }
}
