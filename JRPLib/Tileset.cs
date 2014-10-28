using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace JRPLib
{
    public class Tileset
    {
        Texture _tileset;
        string _name;
        bool _loaded;

        public Tileset()
        {
            _tileset = null;
            _name = "";
            _loaded = false;
        }

        public Tileset(string name)
        {
            _name = name;
            _tileset = new Texture(Game.Instance.Path + "\\" + Game.Instance.GFXManager.GraphicPath + "\\" + Game.Instance.GFXManager.TilesetPath + "\\" + _name);

            if (_tileset != null)
                _loaded = true;
            else
            {
                _loaded = false;
            }
        }

        public void ReloadTileset()
        {
            _tileset = new Texture(Game.Instance.GFXManager.GraphicPath + Game.Instance.GFXManager.TilesetPath + _name);

            CheckLoaded();
        }

        public bool CheckLoaded()
        {
            if (_tileset != null)
                _loaded = true;
            else
                _loaded = false;
            return _loaded; 
        }

        public Texture MyTileset
        {
            get { return _tileset; }
        }

        public string Name
        {
            get { return _name; }
        }

        public bool Loaded
        {
            get { return _loaded; }
        }
    }
}
