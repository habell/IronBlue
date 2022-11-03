using UnityEngine;

namespace Quests
{
    public class SwitchQuestModel : IQuestModel
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.GetComponent<Player>();
        }
    }
}