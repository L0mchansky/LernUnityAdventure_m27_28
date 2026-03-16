using System;

namespace m28_28_task_1
{
    public interface IChangeBalance
    {
        public event Action<string, int> ChangeBalance;
    }
}