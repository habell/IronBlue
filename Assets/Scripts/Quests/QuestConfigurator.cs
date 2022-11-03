using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quests
{
    public class QuestConfigurator : MonoBehaviour
    {
        [SerializeField]
        private QuestStoryConfig[] _questStoryConfigs;

        [SerializeField]
        private QuestObjectView[] _questObjects;
        
        [SerializeField]
        private QuestObjectView _sigleQuestView;

        private Quest _quest;

        private List<IQuestStory> _questStories;

        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories =
            new Dictionary<QuestType, Func<IQuestModel>>()
            {
                {QuestType.Switch, () => new SwitchQuestModel()}
            };
        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories =
            new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>()
            {
                {QuestStoryType.Common, questsCollection => new QuestStory(questsCollection)}
            };
        private void Awake()
        {
            _quest = new Quest(_sigleQuestView, new SwitchQuestModel());
            _quest.ResetQuest();

            _questStories = new List<IQuestStory>();

            foreach (var questStoryConfig in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStoryConfig));
            }
        }

        private IQuestStory CreateQuestStory(QuestStoryConfig questStoryConfig)
        {
            var quests = new List<IQuest>();

            foreach (var questConfig in questStoryConfig.Quests)
            {
                var quest =  CreateQuest(questConfig);
                
                if(quest == null) continue;
                
                quests.Add(quest);
            }

            return _questStoryFactories[questStoryConfig.StoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig questConfig)
        {
            var questID = questConfig.QuestID;
            var questView = _questObjects.FirstOrDefault(value => value.ID == questID);

            if (questView == null) return null;

            if (!_questFactories.TryGetValue(questConfig.Type, out var factory)) return null;
            var questModel = factory.Invoke();
            return new Quest(questView, questModel);

        }

        private void OnDestroy()
        {
            _quest.Dispose();
        }
    }
}