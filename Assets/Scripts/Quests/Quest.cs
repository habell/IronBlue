using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Quests
{
    public class Quest : IQuest, IDisposable
    {
        private readonly QuestObjectView _view;
        private readonly IQuestModel _model;

        private bool _isActive;
        
        public event Action<IQuest> Completed;
        public bool IsCompleted { get; private set; }

        public Quest(QuestObjectView view, IQuestModel model)
        {
            _view = view;
            _model = model;
        }

        public void ResetQuest()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void Complete()
        {
            if(!_isActive)return;
            _isActive = false;
            IsCompleted = true;
            _view.ObjectContact -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this);
        }

        private void OnContact(Player obj)
        {
            //TODO:
            Debug.Log("print");
        }
    }
}