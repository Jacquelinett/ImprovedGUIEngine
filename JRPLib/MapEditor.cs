using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;

namespace JRPLib
{
    public class MapEditor
    {
        RenderWindow _screen;
        Tilemap _map;
        int _offsetX, _offsetY;
        View _myView;
        bool _debug;
        int _debugFont;
        bool _fringe;
        bool _ground;
        int _pickedX;
        int _pickedY;
        MapCache _cache;
        int _pickType;

        public MapEditor(IntPtr hdl, int w, int h , Tilemap map)
        {
            _screen = new RenderWindow(hdl);
            _map = map;
            _myView = new View(new FloatRect(0, 0, w, h));

            _offsetX = _offsetY = 0;

            _screen.SetView(_myView);
            _screen.SetFramerateLimit(60);

            _debug = true;
            _debugFont = -1;

            _ground = true;
            _fringe = true;

            _cache = new MapCache(_map);
        }

        public void Picked(TilesetPicker t, TileLayer l)
        {
            _pickedX = MouseLoc.X + _offsetX;
            _pickedY = MouseLoc.Y + _offsetY;
            if (_pickedX >= _map.X * Game.Instance.GFXEngine.TileSizeX)
                _pickedX = _map.X * Game.Instance.GFXEngine.TileSizeX - 1;
            if (_pickedY >= _map.Y * Game.Instance.GFXEngine.TileSizeY)
                _pickedY = _map.Y * Game.Instance.GFXEngine.TileSizeY - 1;
            _pickedX /= 32;
            _pickedY /= 32;

            Tile tile = new Tile(t.PickedX, t.PickedY, Game.Instance.GFXManager.TilesetPipeline.IndexOf(t.Tileset), _pickedX, _pickedY);

            if (_map.MyLayer.Count < 1)
                return;

            CheckCache();

            if (_cache.TileExisted(_map.MyLayer.IndexOf(l), _pickedX, _pickedY))
            {
                _map.MyLayer[_map.MyLayer.IndexOf(l)].MyTile[_cache.GetTile(_map.MyLayer.IndexOf(l), _pickedX, _pickedY) - 1] = tile;
            }
            else
            {
                _map.MyLayer[_map.MyLayer.IndexOf(l)].MyTile.Add(tile);
                _cache.PlaceTile(_map.MyLayer.IndexOf(l), _pickedX, _pickedY, _map.MyLayer[_map.MyLayer.IndexOf(l)].MyTile.Count);
            }
        }

        public void Picked(TilesetPicker t, TileLayer l, int x, int y)
        {
            /*if (x > _screen.Size.X / 32)
                return;
            if (y > _screen.Size.Y / 32)
                return;
            */
            Tile tile = new Tile(t.PickedX, t.PickedY, Game.Instance.GFXManager.TilesetPipeline.IndexOf(t.Tileset), x, y);

            if (_map.MyLayer.Count < 1)
                return;

            CheckCache();

            if (_cache.TileExisted(_map.MyLayer.IndexOf(l), x, y))
            {
                _map.MyLayer[_map.MyLayer.IndexOf(l)].MyTile[_cache.GetTile(_map.MyLayer.IndexOf(l), x, y) - 1] = tile;
            }
            else
            {
                _map.MyLayer[_map.MyLayer.IndexOf(l)].MyTile.Add(tile);
                _cache.PlaceTile(_map.MyLayer.IndexOf(l), x, y, _map.MyLayer[_map.MyLayer.IndexOf(l)].MyTile.Count);
            }
        }

        public void CheckCache()
        {
            if (_map.MyLayer.Count > _cache.CacheCount)
            {
                for (int i = _cache.CacheCount; i < _map.MyLayer.Count; i++)
                {
                    _cache.NewLayer(i);
                }
            }
        }

        public bool CacheWork
        {
            get { return Map.MyLayer.Count == _cache.CacheCount; }
        }

        public void NewLayer()
        {
            if (_map.MyLayer.Count <= _cache.CacheCount)
                return;
            _cache.NewLayer(_cache.CacheCount);
        }

        public void ResizeView(int w, int h, IntPtr hdl)
        {
            _screen.Dispose();
            _screen = new RenderWindow(hdl);
            _screen.Size = new Vector2u((uint)w, (uint)h);
            _myView.Size = new Vector2f(w, h);
        }

        public void Update()
        {
            _myView.Center = new Vector2f(_offsetX + ((int)_myView.Size.X / 2), _offsetY + ((int)_myView.Size.Y / 2));
            _screen.SetView(_myView);
        }

        public void Draw()
        {
            _screen.Clear();

            if (_ground)
                Game.Instance.GFXEngine.DrawGround(_map, _screen);
            if (_fringe)
                Game.Instance.GFXEngine.DrawFringe(_map, _screen);

            if (_debug)
                Game.Instance.GFXEngine.DrawBox(_map, _screen);

            _screen.Display();
        }

        public int CacheCount
        {
            get { return _cache.CacheCount; }
        }

        public RenderWindow Screen
        {
            get { return _screen; }
        }

        public Tilemap Map
        {
            get { return _map; }
        }

        public int OffsetX
        {
            get { return _offsetX; }
            set { _offsetX = value; }
        }

        public int OffsetY
        {
            get { return _offsetY; }
            set { _offsetY = value; }
        }

        public Vector2i MouseLoc
        {
            get { return Mouse.GetPosition(_screen); }
        }

        public int PickedX
        {
            get { return _pickedX; }
            set { _pickedX = value; }
        }

        public int PickedY
        {
            get { return _pickedY; }
            set { _pickedY = value; }
        }

        public View MyView
        {
            get { return _myView; }
        }
    }
}
