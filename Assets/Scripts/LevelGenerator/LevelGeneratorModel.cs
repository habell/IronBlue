using UnityEngine;

namespace LevelGenerator
{
    public class LevelGeneratorModel
    {
        private const int WALLS = 4;

        private int[,] _map;

        private LevelGeneratorView _view;

        public LevelGeneratorModel(LevelGeneratorView view)
        {
            _view = view;
            _map = new int[_view.Height, _view.Wight];
        }

        public void Awake()
        {
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            RandomFillMap();

            PaintMap();
        }

        private void PaintMap()
        {
            for (int x = 0; x < _view.Height; x++)
            {
                for (int y = 0; y < _view.Wight; y++)
                {
                    if (_map[x, y] > 0)
                    {
                        _view.TileMapGround.SetTile(new Vector3Int(y, x), _view.TileMap);
                    }
                }
            }
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
        }
    }
}