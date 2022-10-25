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

            for (var i = 0; i < _view.FactorSmooth; i++)
                SmoothMap();
            
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

        private void SmoothMap()
        {
            for (var x = 0; x < _view.Height; x++)
            {
                for (var y = 0; y < _view.Wight; y++)
                {
                    var neighbourWallTiles = GetSurroundingWallCount(x, y);
                    if (neighbourWallTiles > WALLS)
                        _map[x, y] = 1;
                    else if (neighbourWallTiles < WALLS)
                        _map[x, y] = 0;
                }
            }
        }

        private int GetSurroundingWallCount(int gridX, int gridY)
        {
            var wallCount = 0;
            for (var neighbourX = gridX - 1;
                 neighbourX <= gridX + 1;
                 neighbourX++)
            {
                for (var neighbourY = gridY - 1;
                     neighbourY <= gridY + 1;
                     neighbourY++)
                {
                    if (neighbourX >= 0 && neighbourX < _view.Height && neighbourY
                        >= 0 && neighbourY < _view.Wight)
                    {
                        if (neighbourX != gridX || neighbourY != gridY)
                            wallCount += _map[neighbourX, neighbourY];
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
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