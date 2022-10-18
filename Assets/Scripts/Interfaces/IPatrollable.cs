using UnityEngine;

namespace DefaultNamespace
{
    public interface IPatrollable
    {
        public void StartHunt(Transform victim);
        public void StopHunt();
        public void StartPatrol();
        public void NextPatrolPosition();
    }
}