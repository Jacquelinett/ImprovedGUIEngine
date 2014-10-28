using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public class Tilemap
    {
        int _type;
        string _name;
        int _x;
        int _y;

        int _fringe;

        List<TileLayer> _myLayer;

        public Tilemap()
        {
            _type = (int)MapType.Normal;
            _name = "Map1";
            _x = 5;
            _y = 5;
            _fringe = 0;

            _myLayer = new List<TileLayer>();
        }

        public Tilemap(string name)
        {
            _type = (int)MapType.Normal;
            _name = name;
            _x = 5;
            _y = 5;
            _fringe = 0;

            _myLayer = new List<TileLayer>();
        }

        public Tilemap(string name, MapType type)
        {
            _type = (int)type;
            _name = name;
            _x = 5;
            _y = 5;
            _fringe = 0;

            _myLayer = new List<TileLayer>();
        }

        public Tilemap(string name, int x, int y, MapType type)
        {
            _type = (int)type;
            _name = name;
            _x = x;
            _y = y;
            _fringe = 0;

            _myLayer = new List<TileLayer>();
        }

        public int Fringe
        {
            get { return _fringe; }
            set { _fringe = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<TileLayer> MyLayer
        {
            get { return _myLayer; }
            set { _myLayer = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
