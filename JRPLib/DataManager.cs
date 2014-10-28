using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public class DataManager
    {
        List<Tilemap> _myMap;
        string _dataPath;
        string _mapPath;
        public DataManager()
        {
            _myMap = new List<Tilemap>();
            _dataPath = "Data";
            _mapPath = "Map";
        }

        public List<Tilemap> MyMap
        {
            get { return _myMap; }
        }

        public string DataPath
        {
            get { return _dataPath; }
            set { _dataPath = value; }
        }

        public string MapPath
        {
            get { return _mapPath; }
            set { _mapPath = value; }
        }


    }
}
