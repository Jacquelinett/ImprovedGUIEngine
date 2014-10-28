using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

namespace JRPLib
{
    public class GraphicEngine
    {
        RenderWindow _screen;
        int _tilesizeX;
        int _tilesizeY;
        uint _width;
        uint _height;

        public GraphicEngine()
        {
            _tilesizeX = _tilesizeY = 32;
            _width = 800;
            _height = 600;

            //Initialize();
        }

        public int TileSizeX
        {
            get { return _tilesizeX; }
            set { _tilesizeX = value; }
        }

        public int TileSizeY
        {
            get { return _tilesizeY; }
            set { _tilesizeY = value; }
        }

        public void Initialize()
        {
            _screen = new RenderWindow(new VideoMode(_width, _height), Game.Instance.GameFullName);
        }

        public void Initialize(int w, int h, string title)
        {
            _screen = new RenderWindow(new VideoMode((uint) w, (uint) h), title);
        }

        public void DrawBox(int boxw, int boxh, int x, int y, RenderWindow toDraw)
        {
            Vertex[] line1 = 
            {
                new Vertex(new Vector2f(x, y)),
                new Vertex(new Vector2f(x + boxw, y)),
            };

            Vertex[] line2 = 
            {
                new Vertex(new Vector2f(x + boxw, y)),
                new Vertex(new Vector2f(x + boxw, y + boxh))
            };

            Vertex[] line3 = 
            {
                new Vertex(new Vector2f(x, y + boxh)),
                new Vertex(new Vector2f(x + boxw, y + boxh))
            };

            Vertex[] line4 = 
            {
                new Vertex(new Vector2f(x, y)),
                new Vertex(new Vector2f(x, y + boxh)),
            };

            toDraw.Draw(line1, SFML.Graphics.PrimitiveType.Lines);
            toDraw.Draw(line2, SFML.Graphics.PrimitiveType.Lines);
            toDraw.Draw(line3, SFML.Graphics.PrimitiveType.Lines);
            toDraw.Draw(line4, SFML.Graphics.PrimitiveType.Lines);
        }

        public void DrawBox(int boxw, int boxh, int x, int y, RenderWindow toDraw, Color color)
        {
            Vertex[] line1 = 
            {
                new Vertex(new Vector2f(x, y), color),
                new Vertex(new Vector2f(x + boxw, y), color),
            };

            Vertex[] line2 = 
            {
                new Vertex(new Vector2f(x + boxw, y), color),
                new Vertex(new Vector2f(x + boxw, y + boxh), color)
            };

            Vertex[] line3 = 
            {
                new Vertex(new Vector2f(x, y + boxh), color),
                new Vertex(new Vector2f(x + boxw, y + boxh), color)
            };

            Vertex[] line4 = 
            {
                new Vertex(new Vector2f(x, y), color),
                new Vertex(new Vector2f(x, y + boxh), color),
            };

            toDraw.Draw(line1, SFML.Graphics.PrimitiveType.Lines);
            toDraw.Draw(line2, SFML.Graphics.PrimitiveType.Lines);
            toDraw.Draw(line3, SFML.Graphics.PrimitiveType.Lines);
            toDraw.Draw(line4, SFML.Graphics.PrimitiveType.Lines);
        }

        public void DrawBox(Tilemap map, RenderWindow rw)
        {
            for (int x = 0; x < map.X; x++)
            {
                for (int y = 0; y < map.Y; y++)
                {
                    DrawBox(_tilesizeX, _tilesizeY, x * _tilesizeX, y * _tilesizeY, rw);

                }
            }
        }

        public void DrawBox(Tileset ts, RenderWindow rw)
        {
            for (int x = 0; x < ts.MyTileset.Size.X / _tilesizeX; x++)
            {
                for (int y = 0; y < ts.MyTileset.Size.Y / _tilesizeY; y++)
                {
                    DrawBox(_tilesizeX, _tilesizeY, x * _tilesizeX, y * _tilesizeY, rw);

                }
            }
        }

        public void DrawBox(int x, int y, Color color)
        {
            DrawBox(_tilesizeX, _tilesizeY, x, y, _screen, color);
        }

        public void DrawBox(int x, int y, int w, int h, Color color)
        {
            DrawBox(w, h, x, y, _screen, color);
        }

        public void DrawBox(int x, int y, Color color, RenderWindow rw)
        {
            DrawBox(_tilesizeX, _tilesizeY, x, y, rw, color);
        }

        public void DrawBox(int x, int y, int w, int h, Color color, RenderWindow rw)
        {
            DrawBox(w, h, x, y, rw, color);
        }

        public void Draw()
        {
        }

        public void Draw(Tile t)
        {
            if (t.TSID >= Game.Instance.GFXManager.TilesetPipeline.Count)
                return;

            Sprite s;

            s = new Sprite(Game.Instance.GFXManager.TilesetPipeline[t.TSID].MyTileset);
            s.TextureRect = new IntRect(t.TileX * 32, t.TileY * 32, _tilesizeX, _tilesizeY);
            s.Position = new Vector2f(t.MapX * _tilesizeX, t.MapY * _tilesizeY);
            _screen.Draw(s);
        }

        public void Draw(Tile t, int x, int y)
        {
            if (t.TSID >= Game.Instance.GFXManager.TilesetPipeline.Count)
                return;

            Sprite s;

            s = new Sprite(Game.Instance.GFXManager.TilesetPipeline[t.TSID].MyTileset);
            s.TextureRect = new IntRect(t.TileX * 32, t.TileY * 32, _tilesizeX, _tilesizeY);
            s.Position = new Vector2f(t.MapX * _tilesizeX + x, t.MapY * _tilesizeY + y);
            _screen.Draw(s);
        }

        public void Draw(Tile t, RenderWindow rw)
        {
            if (t.TSID >= Game.Instance.GFXManager.TilesetPipeline.Count)
                return;

            Sprite s;

            s = new Sprite(Game.Instance.GFXManager.TilesetPipeline[t.TSID].MyTileset);
            s.TextureRect = new IntRect(t.TileX * 32, t.TileY * 32, _tilesizeX, _tilesizeY);
            s.Position = new Vector2f(t.MapX * _tilesizeX, t.MapY * _tilesizeY); 
            rw.Draw(s);
        }

        public void Draw(Tile t, RenderWindow rw, int x, int y)
        {
            if (t.TSID >= Game.Instance.GFXManager.TilesetPipeline.Count)
                return;

            Sprite s;

            s = new Sprite(Game.Instance.GFXManager.TilesetPipeline[t.TSID].MyTileset);
            s.TextureRect = new IntRect(t.TileX * 32, t.TileY * 32, _tilesizeX, _tilesizeY);
            s.Position = new Vector2f(t.MapX * _tilesizeX + x, t.MapY * _tilesizeY + y);
            rw.Draw(s);
        }

        public void DrawGround(Tilemap map)
        {
            int max = map.Fringe;

            if (map.Fringe > map.MyLayer.Count)
                max = map.MyLayer.Count;

            for (int i = 0; i < max; i++)
                foreach (Tile t in map.MyLayer[i].MyTile)
                {
                    Draw(t);
                }
        }

        public void DrawGround(Tilemap map, int x, int y)
        {
            int max = map.Fringe;

            if (map.Fringe > map.MyLayer.Count)
                max = map.MyLayer.Count;

            for (int i = 0; i < max; i++)
                foreach (Tile t in map.MyLayer[i].MyTile)
                {
                    Draw(t, x, y);
                }
        }

        public void DrawGround(Tilemap map, RenderWindow rw)
        {
            int max = map.Fringe;

            if (map.Fringe > map.MyLayer.Count)
                max = map.MyLayer.Count;

            for (int i = 0; i < max; i++)
                foreach (Tile t in map.MyLayer[i].MyTile)
                {
                    Draw(t, rw);
                }
        }

        public void DrawGround(Tilemap map, RenderWindow rw, int x, int y)
        {
            //if (map.Fringe > map.MyLayer.Count)
            //    return;
            int max = map.Fringe;

            if (map.Fringe > map.MyLayer.Count)
                max = map.MyLayer.Count;

            for (int i = 0; i < max; i++)
                foreach (Tile t in map.MyLayer[i].MyTile)
                {
                    Draw(t, rw, x, y);
                }
        }

        public void DrawFringe(Tilemap map)
        {
            if (map.Fringe > map.MyLayer.Count)
                return;

            for (int i = map.Fringe; i < map.MyLayer.Count; i++)
                foreach (Tile t in map.MyLayer[i].MyTile)
                {
                    Draw(t);
                }
        }

        public void DrawFringe(Tilemap map, int x, int y)
        {
            if (map.Fringe > map.MyLayer.Count)
                return;

            for (int i = map.Fringe; i < map.MyLayer.Count; i++)
                foreach (Tile t in map.MyLayer[i].MyTile)
                {
                    Draw(t, x, y);
                }
        }

        public void DrawFringe(Tilemap map, RenderWindow rw)
        {
            if (map.Fringe > map.MyLayer.Count)
                return;

            for (int i = map.Fringe; i < map.MyLayer.Count; i++)
                foreach (Tile t in map.MyLayer[i].MyTile)
                {
                    Draw(t, rw);
                }
        }

        public void DrawFringe(Tilemap map, RenderWindow rw, int x, int y)
        {
            if (map.Fringe > map.MyLayer.Count)
                return;

            for (int i = map.Fringe; i < map.MyLayer.Count; i++)
                foreach (Tile t in map.MyLayer[i].MyTile)
                {
                    Draw(t, rw, x, y);
                }
        }

        public void Draw(Tileset ts, RenderWindow rw)
        {
            Sprite s = new Sprite(ts.MyTileset);

            s.Position = new Vector2f(0, 0);
            s.TextureRect = new IntRect(0, 0, (int)ts.MyTileset.Size.X, (int)ts.MyTileset.Size.Y);
            rw.Draw(s);
        }

        public void Draw(Tileset ts, RenderWindow rw, int x, int y)
        {
            Sprite s = new Sprite(ts.MyTileset);
            s.TextureRect = new IntRect(0, 0, (int)ts.MyTileset.Size.X, (int)ts.MyTileset.Size.Y);
            s.Position = new Vector2f(x, y);
            rw.Draw(s);
        }

        public void Draw(Text stuffs)
        {
            _screen.Draw(stuffs);
        }

        public void Draw(Text stuffs, RenderWindow rw)
        {
            rw.Draw(stuffs);
        }

        
    }
}
