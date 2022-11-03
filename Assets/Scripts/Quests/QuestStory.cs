using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quests
{
    public class QuestStory : IQuestStory, IDisposable
    {
        private readonly List<IQuest> _questsCollection;
        public bool IsDone => _questsCollection.All(value => value.IsCompleted);

        public QuestStory(List<IQuest> questsCollection)
        {
            _questsCollection = questsCollection;
            Subscribe();
            ResetQuest(0);
        }

        private void ResetQuest(int questIndex)
        {
            if (questIndex < 0 || questIndex >= _questsCollection.Count) return;

            var newQuest = _questsCollection[questIndex];

            if (newQuest.IsCompleted)
            {
                OnQuestCompleted(newQuest);
            }
            else
            {
                newQuest.ResetQuest();
            }
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

        public void Dispose()
        {
            UnSubscribe();
        }
    }
}