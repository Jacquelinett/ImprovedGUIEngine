using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public class MapCache
    {
        List<Cache> _layers;
        int _id;

        public MapCache(int id)
        {
            _layers = new List<Cache>();
            for (int l = 0; l < Game.Instance.DataManager.MyMap[id].MyLayer.Count; l++)
            {
                _layers.Add(new Cache(id, l));
            }

            _id = id;
        }

        public MapCache(Tilemap map)
        {
            _layers = new List<Cache>();
            for (int l = 0; l < map.MyLayer.Count; l++)
            {
                _layers.Add(new Cache(map, l));
            }
            _id = Game.Instance.DataManager.MyMap.IndexOf(map);
        }

        public void NewLayer(int l)
        {
            _layers.Add(new Cache(_id, l));
        }

        public void MapSizeChanged(int newx, int newy)
        {
            foreach (Cache c in _layers)
            {
                c.MapSizeChanged(newx, newy);
            }
        }

        public bool TileExisted(int l, int x, int y)
        {
            if (_layers[l].TileExisted(x, y))
                return true;
            return false;
        }

        public void PlaceTile(int l, int x, int y, int v)
        {
            _layers[l].PlaceTile(x, y, v);
        }

        public int GetTile(int l, int x, int y)
        {
            return _layers[l].GetTile(x, y);
        }

        public int CacheCount
        {
            get { return _layers.Count; }
        }
    }
}
