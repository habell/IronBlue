using UnityEngine;

namespace DefaultNamespace
{
    public interface IPatrollable
    {
        public void StartHunt(Transform victim);
        protected void StopHunt();
        protected void StartPatrol();
    }
}