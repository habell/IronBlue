using System;

namespace Quests
{
    public interface IQuest
    {
        event Action<IQuest> Completed;
        bool IsCompleted { get; }
        public void ResetQuest();
    }
}