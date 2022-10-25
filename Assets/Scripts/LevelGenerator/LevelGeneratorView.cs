using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelGenerator
{
    [RequireComponent(typeof(LevelGeneratorController))]
    public class LevelGeneratorView : MonoBehaviour
    {
        [SerializeField]
        private Tilemap _tileMapGround;

        [SerializeField]
        private Tile _tileMap;

        [SerializeField]
        private int _wight;

        [SerializeField]
        private int _height;

        [SerializeField]
        private int _factorSmooth;

        [SerializeField, Range(0, 100)]
        private int _mapFillProcent;


        public Tilemap TileMapGround => _tileMapGround;

        public Tile TileMap => _tileMap;

        public int Wight => _wight;

        public int Height => _height;

        public int FactorSmooth => _factorSmooth;

        public int MapFillProcent => _mapFillProcent;
        
    }
}