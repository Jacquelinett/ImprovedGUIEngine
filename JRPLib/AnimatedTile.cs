using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public class AnimatedTile : Tile
    {
        int _frame;
        List<int> _animatedloc;

        public AnimatedTile()
        {
            _frame = 0;
            _animatedloc = new List<int>(); 
        }
    }
}
