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
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out Player ply))
            {
                ObjectContact?.Invoke(ply);
            }
        }

        public void ProcessComplete()
        {
            print("Quest COMPLETE!");
            GetComponent<SpriteRenderer>().color = _completeColor;
        }

        public void ProcessActivate()
        {
            print("START QUEST!");
        }
    }
}