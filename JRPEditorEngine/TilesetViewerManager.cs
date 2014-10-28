using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JRPLib;

namespace JRPEditorEngine
{
    public class TilesetViewerManager
    {
        int _focus;
        List<TilesetPickerForm> _tsPickerList;

        public TilesetViewerManager()
        {
            _tsPickerList = new List<TilesetPickerForm>();
            _focus = -1;
        }

        public void AddViewer(Tileset ts)
        {
            foreach (TilesetPickerForm f in _tsPickerList)
                if (f.Tileset == ts)
                    return;

            _tsPickerList.Add(new TilesetPickerForm(ts, _tsPickerList.Count) { Text = ts.Name });
        }

        public void RemoveViewer(TilesetPickerForm which)
        {
            int temp = which.ID;
            _tsPickerList.RemoveAt(temp);
            for (int i = temp; i < _tsPickerList.Count; i++)
                _tsPickerList[i].ID = i;

        }

        public List<TilesetPickerForm> List
        {
            get { return _tsPickerList; }
        }
    }
}
