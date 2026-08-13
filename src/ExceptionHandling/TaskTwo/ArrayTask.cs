using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.TaskTwo
{
    public class ArrayTask
    {
        private int[] _numbers;

        public ArrayTask(int length)
        {
            _numbers = new int[length];
            Initialize();
        }

        public int GetAt(int index)
        {
            return _numbers[index];
        }

        private void Initialize()
        {
            for (int i = 0; i < _numbers.Length; ++i)
            {
                _numbers[i] = Random.Shared.Next(1, 101);
            }
        }
    }
}
