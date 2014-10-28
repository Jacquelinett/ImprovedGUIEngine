using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public class Game
    {
        static Game _instance;

        string _title;
        string _subtitle;

        string _gamepath;

        bool _changeMade;

        GraphicManager _gfxmanager;
        GraphicEngine _gfxengine;
        DataManager _datamanager;

        //Credit
        List<string> _programmers;
        List<string> _artists;
        List<string> _composers;

        public Game()
        {
            _instance = this;

            _programmers = new List<string>();
            _artists = new List<string>();
            _composers = new List<string>();

            _gfxmanager = new GraphicManager();
            _gfxengine = new GraphicEngine();
            _datamanager = new DataManager();
        }

        public static Game Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Subtitle
        {
            get { return _subtitle; }
            set { _subtitle = value; }
        }

        public GraphicManager GFXManager
        {
            get { return _gfxmanager; }
        }

        public GraphicEngine GFXEngine
        {
            get { return _gfxengine; }
        }

        public DataManager DataManager
        {
            get { return _datamanager; }
        }

        public string Path
        {
            get { return _gamepath; }
            set { _gamepath = value; }
        }

        public bool ChangeMade
        {
            get { return _changeMade; }
            set { _changeMade = value; }
        }

        public void GameLoop()
        {

        }

        public string GameFullName
        {
            get { return _title + ": " + _subtitle; }
        }

        public string GameFullNameFormat
        {
            get { return _title + " - " + _subtitle; }
        }
    }
}
