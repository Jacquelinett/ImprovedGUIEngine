using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public class TileLayer
    {
        string _name;
        int _opacity;
        bool _visible;
        int _order;

        List<Tile> _myTile;

        public TileLayer()
        {
            _name = "Layer1";
            _opacity = 100;
            _visible = true;
            _order = 0;

            _myTile = new List<Tile>();
        }

        public TileLayer(int order)
        {
            _name = "Layer1";
            _opacity = 100;
            _visible = true;
            _order = order;

            _myTile = new List<Tile>();
        }

        public TileLayer(string name, int order)
        {
            _name = name;
            _opacity = 100;
            _visible = true;
            _order = order;

            _myTile = new List<Tile>();
        }

        public TileLayer(string name, int opacity, bool visible, int order)
        {
            _name = name;
            _opacity = opacity;
            _visible = visible;
            _order = order;

            _myTile = new List<Tile>();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Opacity
        {
            get { return _opacity; }
            set { _opacity = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public List<Tile> MyTile
        {
            get { return _myTile; }
            set { _myTile = value; }
        }
    }
}
