using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

namespace JRPLib
{
    public class TilesetPicker
    {
        RenderWindow _screen;
        Tileset _ts;
        int _offsetX, _offsetY;
        View _myView;
        int _pickedX;
        int _pickedY;
        bool _debug;
        int _debugfont;

        public TilesetPicker(IntPtr hdl, int w, int h, Tileset ts)
        {
            _ts = ts;

            _screen = new RenderWindow(hdl);
            _myView = new View(new FloatRect(0, 0, w, h));
            _screen.SetView(_myView);

            _offsetX = _offsetY = 0;
            _debug = false;
            _debugfont = -1;

            _screen.SetFramerateLimit(60);
        }

        public void Picked()
        {
            _pickedX = MouseLoc.X + _offsetX;
            _pickedY = MouseLoc.Y + _offsetY;
            if (_pickedX >= _ts.MyTileset.Size.X)
                _pickedX = (int)_ts.MyTileset.Size.X - 1;
            if (_pickedY >= _ts.MyTileset.Size.Y)
                _pickedY = (int)_ts.MyTileset.Size.Y - 1;
            _pickedX /= 32;
            _pickedY /= 32;
        }

        public void ResizeView(int w, int h, IntPtr hdl)
        {
            _screen.Dispose();
            _screen = new RenderWindow(hdl);
            _screen.Size = new Vector2u((uint)w, (uint)h);
            //_screen.
            //_screen.Position = new Vector2i(0, 0);
            _myView.Size = new Vector2f(w, h);
            //_screen.SetView(_myView);
            //_myView.Viewport = new FloatRect(0, 0, w, h);
            
            //Update();
        }

        public void Update()
        {
            _myView.Center = new Vector2f(_offsetX + ((int)_myView.Size.X / 2), _offsetY + ((int)_myView.Size.Y / 2));
            _screen.SetView(_myView);
        }

        public void Draw()
        {
            _screen.Clear();

            Game.Instance.GFXEngine.Draw(_ts, _screen);

            if (_debug)
                Game.Instance.GFXEngine.DrawBox(_ts, _screen);

            if (_debug != false && _debugfont > -1)
            {
                Game.Instance.GFXEngine.Draw(new Text("Tileset Name: " + _ts.Name , Game.Instance.GFXManager.FontPipeline[_debugfont], 12) {Position = new Vector2f(0 + OffsetX, 0 + OffsetY)}, _screen);
                Game.Instance.GFXEngine.Draw(new Text("Tileset Width: " + _ts.MyTileset.Size.X, Game.Instance.GFXManager.FontPipeline[_debugfont], 12) { Position = new Vector2f(0 + OffsetX, 30 + OffsetY) }, _screen);
                Game.Instance.GFXEngine.Draw(new Text("Tileset Height: " + _ts.MyTileset.Size.Y, Game.Instance.GFXManager.FontPipeline[_debugfont], 12) { Position = new Vector2f(0 + OffsetX, 60 + OffsetY) }, _screen);
                Game.Instance.GFXEngine.Draw(new Text("View Width: " + _myView.Size.X, Game.Instance.GFXManager.FontPipeline[_debugfont], 12) { Position = new Vector2f(0 + OffsetX, 90 + OffsetY) }, _screen);
                Game.Instance.GFXEngine.Draw(new Text("View Height: " + _myView.Size.Y, Game.Instance.GFXManager.FontPipeline[_debugfont], 12) { Position = new Vector2f(0 + OffsetX, 120 + OffsetY) }, _screen);
                Game.Instance.GFXEngine.Draw(new Text("Mouse X: " + MouseLoc.X, Game.Instance.GFXManager.FontPipeline[_debugfont], 12) { Position = new Vector2f(0 + OffsetX, 150 + OffsetY) }, _screen);
                Game.Instance.GFXEngine.Draw(new Text("Mouse Y: " + MouseLoc.Y, Game.Instance.GFXManager.FontPipeline[_debugfont], 12) { Position = new Vector2f(0 + OffsetX, 180 + OffsetY) }, _screen);
                Game.Instance.GFXEngine.Draw(new Text("Picked X: " + _pickedX, Game.Instance.GFXManager.FontPipeline[_debugfont], 12) { Position = new Vector2f(0 + OffsetX, 210 + OffsetY) }, _screen);
                Game.Instance.GFXEngine.Draw(new Text("Picked Y: " + _pickedY, Game.Instance.GFXManager.FontPipeline[_debugfont], 12) { Position = new Vector2f(0 + OffsetX, 240 + OffsetY) }, _screen);
            }

            Game.Instance.GFXEngine.DrawBox(_pickedX * Game.Instance.GFXEngine.TileSizeX, _pickedY * Game.Instance.GFXEngine.TileSizeY, Color.Red, _screen);

            _screen.Display();
        }

        public Tileset Tileset
        {
            get { return _ts; }
            set { _ts = value; }
        }

        public RenderWindow Screen
        {
            get { return _screen; }
        }

        public View MyView
        {
            get { return _myView; }
            set { _myView = value; }
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

        public bool Debug
        {
            get { return _debug; }
            set { _debug = value; }
        }

        public int DebugFont
        {
            get { return _debugfont; }
            set { _debugfont = value; }
        }
    }
}
