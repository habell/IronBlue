using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quests
{
    public class QuestStory : IQuestStory
    {
        private readonly List<IQuest> _questsCollection;
        public bool IsDone => _questsCollection.All(value => value.IsCompleted);

        public QuestStory(List<IQuest> questsCollection)
        {
            _questsCollection = questsCollection;
            Subscribe();
            ResetQuest(0);
        }

        private void ResetQuest(int i)
        {
            _questsCollection[i].ResetQuest();
        }

        private void Subscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed += OnQuestCompleted;
            }
        }

        private void UnSubscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }

        private void OnQuestCompleted(IQuest completedQuest)
        {
            var questIndex = _questsCollection.IndexOf(completedQuest);

            if (IsDone)
            {
                Debug.Log("Quests Completed!");
            }
            else
            {
                ResetQuest(++questIndex);
            }
        }
    }
}