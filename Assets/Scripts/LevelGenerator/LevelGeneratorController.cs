using System;
using Unity.Mathematics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace LevelGenerator
{
    public class LevelGeneratorController
    {
        private const int WALLS = 4;

        private int[,] _map;

        private LevelGeneratorView _view;

        public LevelGeneratorController(LevelGeneratorView view)
        {
            _view = view;
        }

        public void Awake()
        {
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            RandomFillMap();
        }

        private void RandomFillMap()
        {
            var random = new System.Random();
            for (int x = 0; x < _view.Height; x++)
            {
                for (int y = 0; y < _view.Wight; y++)
                {
                    if (x == 0 || x >= _view.Height - 1 || y == 0 || y >= _view.Wight - 1)
                    {
                        _map[x, y] = 1;
                    }
                    else
                    {
                        _map[x, y] = random.Next(0, 100) < _view.MapFillProcent ? 1 : 0;
                    }
                }
            }
            Debug.Log(_map);
        }
    }
}