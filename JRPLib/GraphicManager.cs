using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace JRPLib
{
    public class GraphicManager
    {
        List<Tileset> _tilesetPipeline;
        List<Font> _fontPipeline;
        string _graphicPath;
        string _fontPath;
        string _tilesetpath;


        public GraphicManager()
        {
            _graphicPath = "Graphic";
            _tilesetpath = "Tileset";
            _fontPath = "Font";
            _tilesetPipeline = new List<Tileset>();
            _fontPipeline = new List<Font>();
        }

        public string GraphicPath
        {
            get { return _graphicPath; }
            set { _graphicPath = value; }
        }

        public string TilesetPath
        {
            get { return _tilesetpath; }
            set { _tilesetpath = value; }
        }

        public string FontPath
        {
            get { return _fontPath; }
            set { _fontPath = value; }
        }

        public List<Font> FontPipeline
        {
            get { return _fontPipeline; }
            set { _fontPipeline = value; }
        }

        public List<Tileset> TilesetPipeline
        {
            get { return _tilesetPipeline; }
            set { _tilesetPipeline = value; }
        }
    }
}
