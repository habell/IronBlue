using UnityEngine;

namespace BaseCode.Services.Input
{
    public abstract class InputService : IInputService
    {

        public abstract Vector2 Axis { get; }

        public bool IsDragInputUp() => throw new System.NotImplementedException();

        public bool  IsDragInputDown() => throw new System.NotImplementedException();
    }
}