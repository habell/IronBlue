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
            //ResetQuest();
        }

        public void ResetQuest()
        {
            if (_isActive) return;

            _isActive = true;
            IsCompleted = false;
            _view.ObjectContact += OnContact;
            _view.ProcessActivate();
        }

        public void Dispose()
        {
            _view.ObjectContact -= OnContact;
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
            var completed = _model.TryComplete(obj.gameObject);
            
            if(completed) Complete();
        }
    }
}