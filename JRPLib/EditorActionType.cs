using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public enum EditorActionType
    {
        AddNewTileset,
        RemoveTileset,
        EditTileset,
        AddNewMap,
        RemoveMap,
        NewMap,
        CacheGenerated,
        CacheLayerGenerated,
        CacheLayerUpdated,
        NewLayer,
        EditLayer,
        RemoveLayer,
        TileAdded,
        AnimatedTileAdded,
        NewGame,
        LoadGame,
        SaveGame,
        EnabledTool,
        DisabledTool,
        TitleUpdated,
        GameClosed,
        TreeViewUpdated
    }
}
