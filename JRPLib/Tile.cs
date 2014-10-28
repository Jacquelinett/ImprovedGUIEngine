using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public class Tile
    {
        int _tsX;
        int _tsY;
        int _tsid;
        int _mapX;
        int _mapY;

        public Tile()
        {
            _tsX = 0;
            _tsY = 0;
            _mapX = 0;
            _mapY = 0;
            _tsid = 0;
        }

        public Tile(int tsx, int tsy, int tsid, int mapx, int mapy)
        {
            _tsX = tsx;
            _tsY = tsy;
            _mapX = mapx;
            _mapY = mapy;
            _tsid = tsid;
        }

        public int TileX
        {
            get { return _tsX; }
        }

        public int TileY
        {
            get { return _tsY; }
        }

        public int MapX
        {
            get { return _mapX; }
        }

        public int MapY
        {
            get { return _mapY; }
        }

        public int TSID
        {
            get { return _tsid; }
        }

    }
}
