using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public enum MapType
    {
        Normal, // No pvp, no building allow
        NormalPVP, // PVP allowed, no building allow
        Free, // PVP allowed, building allowed
        Sandbox // no PVP, building allowed
    }
}
