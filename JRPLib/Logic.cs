using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public static class Logic
    {
        public static int SolveID(int clipsize, int locx, int locy, int maxx)
        {
            //s.TextureRect = new IntRect((theMap[i] % tileset.Width / 32) * 32, theMap[i] / (tileset.Height / 32) * 32, 32, 32);
            //s.Position = new Vector2f((theMap[i] % maxX) * 32, theMap[i] / maxY * 32);

            return ((locx / clipsize) + (locy / clipsize * maxx));
        }

        public static int GetXFromID(int clipsize, int id, int maxx)
        {
            return (id % maxx * clipsize);
        }

        public static int GetYFromID(int clipsize, int id, int maxy)
        {
            return (id / maxy & clipsize);
        }

    }
}
