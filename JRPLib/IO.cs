using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JRPLib
{
    public static class IO
    {
        static BinaryReader br; // dem binary
        static BinaryWriter bw;

        public static void SaveAllMaps()
        {
            for (int i = 0; i < Game.Instance.DataManager.MyMap.Count; i++)
                SaveMap(Game.Instance.DataManager.MyMap[i], i);
        }

        public static void SaveMap(Tilemap map, int id)
        {
            ExportMap(map, Game.Instance.Path + "\\" + Game.Instance.DataManager.DataPath + "\\" + Game.Instance.DataManager.MapPath + "\\" + "Map" + id);
        }

        public static void ExportMap(Tilemap map, string path)
        {
            using (bw = new BinaryWriter(File.Open(path + ".jrpm", FileMode.Create)))
            {
                bw.Write(map.Name);
                bw.Write(map.X);
                bw.Write(map.Y);
                bw.Write(map.Type);                
                bw.Write(map.Fringe);

                bw.Write(map.MyLayer.Count);

                foreach (TileLayer l in map.MyLayer)
                {
                    SaveLayer(l);
                }
            }
        }

        public static void LoadMap(string path)
        {
            using (br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                Tilemap m = new Tilemap(br.ReadString(), br.ReadInt32(), br.ReadInt32(), (MapType)br.ReadInt32());
                m.Fringe = br.ReadInt32();

                for (int i = 0; i < br.ReadInt32(); i++)
                    LoadLayer(m);

                Game.Instance.DataManager.MyMap.Add(m);
            }
        }

        public static void LoadMap(string path, List<Tilemap> l)
        {
            using (br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                Tilemap m = new Tilemap(br.ReadString(), br.ReadInt32(), br.ReadInt32(), (MapType)br.ReadInt32());
                m.Fringe = br.ReadInt32();
                int max = br.ReadInt32();
                for (int i = 0; i < max; i++)
                    LoadLayer(m);

                l.Add(m);
            }
        }

        public static void SaveLayer(TileLayer l)
        {
            bw.Write(l.Name);
            bw.Write(l.Opacity);
            bw.Write(l.Visible);
            bw.Write(l.Order);

            bw.Write(l.MyTile.Count);

            foreach (Tile t in l.MyTile)
            {
                SaveTile(t);
            }
        }

        public static void LoadLayer(Tilemap map)
        {
            TileLayer l = new TileLayer(br.ReadString(), br.ReadInt32(), br.ReadBoolean(), br.ReadInt32());
            int max = br.ReadInt32();
            for (int i = 0; i < max; i++)
                LoadTile(l);

            map.MyLayer.Add(l);
        }

        public static void SaveTile(Tile t)
        {
            bw.Write(t.TileX);
            bw.Write(t.TileY);
            bw.Write(t.TSID);
            bw.Write(t.MapX);
            bw.Write(t.MapY);
        }

        public static void LoadTile(TileLayer l)
        {
            Tile t = new Tile(br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
            l.MyTile.Add(t);
        }

        public static void LoadAllTileset()
        {
            string[] _tilesetfile = Directory.GetFiles(Game.Instance.Path + "\\" + Game.Instance.GFXManager.GraphicPath + "\\" + Game.Instance.GFXManager.TilesetPath, "*.PNG");
            foreach (string s in _tilesetfile)
            {
                LoadTileset(s);
            }
        }

        public static void LoadTileset(string path)
        {
            Tileset ts = new Tileset(Path.GetFileName(path));
            Game.Instance.GFXManager.TilesetPipeline.Add(ts);
        }

        public static void LoadAllMaps()
        {
            if (!Directory.Exists(Game.Instance.Path + "\\" + Game.Instance.DataManager.DataPath + "\\" + Game.Instance.DataManager.MapPath))
                    Directory.CreateDirectory(Game.Instance.Path + "\\" + Game.Instance.DataManager.DataPath + "\\" + Game.Instance.DataManager.MapPath);

            List<string> _mapfile = new List<string>();
            int count = 0;

            while (File.Exists(Game.Instance.Path + "\\" + Game.Instance.DataManager.DataPath + "\\" + Game.Instance.DataManager.MapPath + "\\Map" + count + ".jrpm"))
            {
                LoadMap(Game.Instance.Path + "\\" + Game.Instance.DataManager.DataPath + "\\" + Game.Instance.DataManager.MapPath + "\\Map" + count + ".jrpm", Game.Instance.DataManager.MyMap);
                count++;
            }
        }

        public static void SaveAllTilesets()
        {
        }

        public static void SaveAllSprites()
        {
        }

        public static void SaveAllActor()
        {
        }

        //...

        public static void SaveGame(Game which)
        {
            SaveGame(which, which.Path + "\\");
        }

        public static void SaveGame(Game which, string path)
        {
            //Make sure folder exist first
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            
            //Make sure subfolder exist
            if (!Directory.Exists(path + which.GFXManager.GraphicPath))
                Directory.CreateDirectory(path + which.GFXManager.GraphicPath);

            if (!Directory.Exists(path + which.GFXManager.GraphicPath + "\\" + which.GFXManager.TilesetPath))
                Directory.CreateDirectory(path + which.GFXManager.GraphicPath + "\\" + which.GFXManager.TilesetPath);

            if (!Directory.Exists(path + which.GFXManager.GraphicPath + "\\" + which.GFXManager.FontPath))
                Directory.CreateDirectory(path + which.GFXManager.GraphicPath + "\\" + which.GFXManager.FontPath);

            if (!Directory.Exists(path + "\\" + which.DataManager.DataPath))
                Directory.CreateDirectory(path + "\\" + which.DataManager.DataPath);

            if (!Directory.Exists(path + "\\" + which.DataManager.DataPath + "\\" + which.DataManager.MapPath))
                Directory.CreateDirectory(path + "\\" + which.DataManager.DataPath + "\\" + which.DataManager.MapPath);

            using (bw = new BinaryWriter(File.Open(path + "Game.jrpg", FileMode.Create)))
            {
                

                // Game information

                bw.Write(which.Title);
                bw.Write(which.Subtitle);

                // Paths

                bw.Write(which.GFXManager.GraphicPath);
                bw.Write(which.GFXManager.TilesetPath);
                bw.Write(which.GFXManager.FontPath);

                // List of Credit and such
            }
        }

        public static void LoadGame(Game which, string path)
        {
            which.Path = path;

            using (br = new BinaryReader(File.Open(path + "\\Game.jrpg", FileMode.Open)))
            {
                which.Title = br.ReadString();
                which.Subtitle = br.ReadString();

                which.GFXManager.GraphicPath = br.ReadString();
                which.GFXManager.TilesetPath = br.ReadString();
                which.GFXManager.FontPath = br.ReadString();

                //Make sure subfolder exist
                if (!Directory.Exists(path + "\\" + which.GFXManager.GraphicPath))
                    Directory.CreateDirectory(path + "\\" + which.GFXManager.GraphicPath);

                if (!Directory.Exists(path + "\\" + which.GFXManager.GraphicPath + "\\" + which.GFXManager.TilesetPath))
                    Directory.CreateDirectory(path + "\\" + which.GFXManager.GraphicPath + "\\" + which.GFXManager.TilesetPath);

                if (!Directory.Exists(path + "\\" + which.GFXManager.GraphicPath + "\\" + which.GFXManager.FontPath))
                    Directory.CreateDirectory(path + "\\" + which.GFXManager.GraphicPath + "\\" + which.GFXManager.FontPath);

                if (!Directory.Exists(path + "\\" + which.DataManager.DataPath))
                    Directory.CreateDirectory(path + "\\" + which.DataManager.DataPath);

                if (!Directory.Exists(path + "\\" + which.DataManager.DataPath + "\\" + which.DataManager.MapPath))
                    Directory.CreateDirectory(path + "\\" + which.DataManager.DataPath + "\\" + which.DataManager.MapPath);

                LoadAllTileset();
                LoadAllMaps();
                
            }
        }
    }
}
