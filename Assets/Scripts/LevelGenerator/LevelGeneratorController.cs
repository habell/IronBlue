using System;
using Unity.Mathematics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace LevelGenerator
{
    public class LevelGeneratorController : MonoBehaviour
    {
        private LevelGeneratorModel _model;
        private LevelGeneratorView _view;

        public LevelGeneratorView View => _view;

        public LevelGeneratorModel Model => _model;

        private void Awake()
        {
            _view = GetComponent<LevelGeneratorView>();
            _model = new LevelGeneratorModel(_view);
            _model.Awake();
        }
    }
}