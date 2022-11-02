using System;
using UnityEngine;

namespace Quests
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class QuestObjectView : MonoBehaviour
    {
        [SerializeField]
        private Color _completeColor;

        [SerializeField]
        private int _id;
        
        private Color _defaultColor;

        public int ID => _id;

        public Action<Player> ObjectContact;

        private void Awake()
        {
            _defaultColor = GetComponent<SpriteRenderer>().color;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            var contactObject = col.gameObject.GetComponent<Player>();
            ObjectContact?.Invoke(contactObject);
        }

        public void ProcessComplete()
        {
            
        }

        public void ProcessActivate()
        {
            
        }
    }
}