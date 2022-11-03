using System;
using UnityEngine;

namespace Quests
{
    public class QuestConfigurator : MonoBehaviour
    {
        [SerializeField]
        private QuestObjectView _sigleQuestView;

        private Quest _quest;

        private void Awake()
        {
            _quest = new Quest(_sigleQuestView, new SwitchQuestModel());
        }

        private void OnDestroy()
        {
            _quest.Dispose();
        }
    }
}