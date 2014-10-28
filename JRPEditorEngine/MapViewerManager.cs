using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JRPLib;

namespace JRPEditorEngine
{
    public class MapViewerManager
    {
        List<MapEditorForm> _mefList;
        public MapViewerManager()
        {
            _mefList = new List<MapEditorForm>();
        }

        public void AddViewer(Tilemap m)
        {
            foreach (MapEditorForm f in _mefList)
                if (f.Map == m)
                    return;

            _mefList.Add(new MapEditorForm(m, _mefList.Count) { Text = m.Name });
        }

        public void RemoveViewer(MapEditorForm which)
        {
            int temp = which.ID;
            _mefList.RemoveAt(temp);
            for (int i = temp; i < _mefList.Count; i++)
                _mefList[i].ID = i;

        }

        public List<MapEditorForm> List
        {
            get {return _mefList;}
        }
    }
}
