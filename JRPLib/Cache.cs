using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public class Cache
    {
        int[,] _cache;

        public Cache()
        {
        }

        public Cache(Tilemap m, int l)
        {
            _cache = new int[m.X, m.Y];
            for (int x = 0; x < m.X; x++)
                for (int y = 0; y < m.Y; y++)
                    _cache[x, y] = -1;

            foreach (Tile t in m.MyLayer[l].MyTile)
            {
                _cache[t.MapX, t.MapY] = m.MyLayer[l].MyTile.IndexOf(t);
            }
        }

        public Cache(int id, int l)
        {
            _cache = new int[Game.Instance.DataManager.MyMap[id].X, Game.Instance.DataManager.MyMap[id].Y];
            for (int x = 0; x < Game.Instance.DataManager.MyMap[id].X; x++)
                for (int y = 0; y < Game.Instance.DataManager.MyMap[id].Y; y++)
                    _cache[x, y] = -1;

            foreach (Tile t in Game.Instance.DataManager.MyMap[id].MyLayer[l].MyTile)
            {
                _cache[t.MapX, t.MapY] = Game.Instance.DataManager.MyMap[id].MyLayer[l].MyTile.IndexOf(t);
            }
        }

        public bool TileExisted(int x, int y)
        {
            if (_cache[x, y] > -1)
                return true;
            return false;
        }

        public void PlaceTile(int x, int y, int value)
        {
            _cache[x, y] = value;
        }

        public int GetTile(int x, int y)
        {
            return _cache[x, y];
        }

        public void MapSizeChanged(int newX, int newY)
        {
            int[,] _temp = new int[_cache.GetLength(0), _cache.GetLength(1)];
            for (int x = 0; x < _temp.GetLength(0); x++)
            {
                for (int y = 0; y < _temp.GetLength(1); y++)
                {
                    _temp[x, y] = _cache[x, y];
                }
            }

            _cache = new int[newX, newY];
            for (int x = 0; x < newX; x++)
            {
                for (int y = 0; y < newY; y++)
                {
                    _cache[x, y] = _temp[x, y];
                }
            }
        }
    }
}
