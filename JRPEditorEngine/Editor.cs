using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using JRPLib;
using SFML.Graphics;

using System.IO;

using Font = SFML.Graphics.Font;

namespace JRPEditorEngine
{
    public partial class Editor : Form
    {
        static Editor _instance;

        Game _curGame;

        bool _temporaryEditor;
        bool _toolsetEnabled;

        int[] _focus;

        int _drawType;
        int _pickType;
        
        NewGame _newGameForm;
        NewMap _newMapForm;
        ProjectDirectory _projectDirectory;

        TilesetViewerManager _tsvManager;
        MapViewerManager _mvManager;
        ViewLayer _viewLayer;

        EditorActionLog _log;
        ActionLogViewer _logViewer;

        public Editor()
        {
            InitializeComponent();
            _instance = this;

            _log = new EditorActionLog();
            _logViewer = new ActionLogViewer();
            _newGameForm = new NewGame();
            _projectDirectory = new ProjectDirectory();
            _newMapForm = new NewMap();
            _tsvManager = new TilesetViewerManager();
            _mvManager = new MapViewerManager();
            _viewLayer = new ViewLayer();

            _logViewer.Show(dockPanel1, DockState.DockBottom);
            _projectDirectory.Show(dockPanel1, DockState.DockRight);
            _viewLayer.Show(dockPanel1, DockState.DockRight);

            _focus = new int[2];
            _pickType = 0;
            _drawType = 0;

            /*
            testgame = new Game();

            testgame.GFXManager.FontPipeline.Add(new Font("Georgia.ttf"));

            testgame.GFXManager.TilesetPipeline.Add(new Tileset("0.png"));
            if (testgame.GFXManager.TilesetPipeline[0].MyTileset == null)
                MessageBox.Show("error couldnt load your damn tileset fgt");

            _tsPickerForm = new TilesetPickerForm(testgame.GFXManager.TilesetPipeline[0]);
            _tsPickerForm.Show(dockPanel1, DockState.DockLeft);
             * */

            DisableTools();
        }

        public int DrawType
        {
            get { return _drawType; }
            set { _drawType = value; }
        }

        public int PickType
        {
            get { return _pickType; }
            set { _pickType = value; }
        }

        public EditorActionLog Log
        {
            get { return _log; }
        }

        public ActionLogViewer LogViewer
        {
            get { return _logViewer; }
        }

        public TileLayer CurrentLayer
        {
            get;
            set;
        }

        public void SetFocus(int which, int id)
        {
            _focus[which] = id;

            if (which == 1)
                _viewLayer.FocusChanged(id);
        }

        public void NewMapViewer(Tilemap tag)
        {
            _mvManager.AddViewer(tag);
            _mvManager.List[_mvManager.List.Count - 1].Show(dockPanel1, DockState.Document);
        }

        public List<TilesetPickerForm> TPF
        {
            get { return _tsvManager.List; }
        }

        public int[] CurrentFocus
        {
            get { return _focus; }
        }

        public void NewTSViewer(Tileset tag)
        {
            _tsvManager.AddViewer(tag);
            _tsvManager.List[_tsvManager.List.Count - 1].Show(dockPanel1, DockState.DockLeft);
            /*
             * foreach (MapViewerForm m in _mapViewFormList)
            {
                if (m.myMap == mv.myMap)
                    return;
            }

            _mapViewFormList.Add(mv);
            mv.Show(dockPanel1, DockState.Document);
             */
        }

        public void CloseMapViewer(MapEditorForm which)
        {
            _mvManager.RemoveViewer(which);
        }

        public void CloseTSViewer(TilesetPickerForm which)
        {
            _tsvManager.RemoveViewer(which);
        }

        public MapEditorForm GetCurMapViewer()
        {
            if (_mvManager.List.Count < 1)
                return null;

            return _mvManager.List[_focus[1]];
        }

        public void CloseProject()
        {
            if (_curGame != null && _curGame.ChangeMade == true)
            {
                DialogResult dialogResult = MessageBox.Show("Changes had been made; Would you like to save?", "Unsaved Data", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    SaveProject();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            _curGame = new Game();
            DisableTools();

            _logViewer.AddLog(CurrentTime + "; Game closed", (int)EditorActionType.GameClosed);
        }

        public void StatePicked(int value)
        {
            _pickType = value;
        }

        public void DrawPicked(int value)
        {
            _drawType = value;
        }

        public void NewProject()
        {
            CloseProject();
            _curGame = new Game();
            _curGame.Title = _newGameForm.GameName;
            _curGame.Subtitle = _newGameForm.SubName;
            _curGame.GFXEngine.TileSizeX = _newGameForm.SizeX;
            _curGame.GFXEngine.TileSizeY = _newGameForm.SizeY;
            _curGame.Path = _newGameForm.Path + _curGame.GameFullNameFormat;

            EnableTools();

            SaveProject();

            _logViewer.AddLog(CurrentTime + "; Game created at path: " + _curGame.Path, (int)EditorActionType.NewGame);
        }

        public void NewMap()
        {
            Tilemap map = new Tilemap(_newMapForm.MapName, _newMapForm.X, _newMapForm.Y, (MapType)_newMapForm.Type);
            map.Fringe = _newMapForm.Fringe;

            _curGame.DataManager.MyMap.Add(map);
            RefreshTreeView();

            //_curGame.ChangeMade = true;
            //UpdateTitle();

            IO.SaveMap(map, _curGame.DataManager.MyMap.Count - 1);

            _logViewer.AddLog(CurrentTime + "; New map created (" + map.Name + ")", (int)EditorActionType.NewMap);
        }

        public void LoadProject()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = @"Select game file";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Jackie's RPG Maker\Project\";

                var result = dialog.ShowDialog(this);

                if (result != DialogResult.OK) return;

                var path = Path.GetDirectoryName(dialog.FileName);

                if ( _curGame != null && path.Equals(_curGame.Path))
                {
                    MessageBox.Show(@"This game is already open.", @"Error opening game");
                    return;
                }

                CloseProject();

                IO.LoadGame(_curGame, path);
                _curGame.Path = path;
                //LoadAllTexture();

                EnableTools();

                _logViewer.AddLog(CurrentTime + "; Game loaded at path: " + _curGame.Path, (int)EditorActionType.LoadGame);

            }
        }

        public void SaveProjectAs()
        {
            if (_curGame == null)
                return;

            string _path = "";

            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = @"Select folder to create game in.";
                folderDialog.SelectedPath = _path;

                var folderResult = folderDialog.ShowDialog();

                if (folderResult == DialogResult.OK)
                {
                    _path = folderDialog.SelectedPath + "\\";
                }
            }
            _path += _curGame.GameFullNameFormat;

            _curGame.ChangeMade = false;
            IO.SaveGame(_curGame, _path + "\\");
            _curGame.Path = _path;
        }

        public void SaveProject()
        {
            if (_curGame == null)
                return;

            _curGame.ChangeMade = false;
            IO.SaveGame(_curGame);

            _logViewer.AddLog(CurrentTime + "; Game saved at path: " + _curGame.Path, (int)EditorActionType.SaveGame);
        }

        

        public void EnableTools()
        {
            UpdateTitle();
            projectToolStripMenuItem1.Enabled = true;
            buildToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            btnSaveGame.Enabled = true;
            btnSaveAll.Enabled = true;
            btnUndo.Enabled = true;
            btnRedo.Enabled = true;
            btnCopy.Enabled = true;
            btnCut.Enabled = true;
            btnPaste.Enabled = true;
            btnDelete.Enabled = true;
            btnSNormal.Enabled = true;
            btnSA1.Enabled = true;
            btnSA2.Enabled = true;
            btnSEvent.Enabled = true;
            btnDrawPencil.Enabled = true;
            btnDrawLine.Enabled = true;
            btnDrawRect.Enabled = true;
            btnDrawEllipse.Enabled = true;

            btnDrawPencil.Checked = true;
            btnDrawLine.Checked = false;
            btnDrawRect.Checked = false;
            btnDrawEllipse.Checked = false;

            _projectDirectory.Enabled = true;
            _projectDirectory.RefreshTreeView();
            _viewLayer.EnableTool();
            _logViewer.AddLog(CurrentTime + "; Enabled tool", (int)EditorActionType.EnabledTool);
            _toolsetEnabled = true;
        }

        public void RefreshTreeView()
        {
            _projectDirectory.RefreshTreeView();
        }

        public void DisableTools()
        {
            UpdateTitle();
            projectToolStripMenuItem1.Enabled = false;
            buildToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            btnSaveGame.Enabled = false;
            btnSaveAll.Enabled = false;
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;
            btnCopy.Enabled = false;
            btnCut.Enabled = false;
            btnPaste.Enabled = false;
            btnDelete.Enabled = false;
            btnSNormal.Enabled = false;
            btnSA1.Enabled = false;
            btnSA2.Enabled = false;
            btnSEvent.Enabled = false;
            btnDrawPencil.Enabled = false;
            btnDrawLine.Enabled = false;
            btnDrawRect.Enabled = false;
            btnDrawEllipse.Enabled = false;
            _projectDirectory.Enabled = false;
            _viewLayer.DisableTool();

            _logViewer.AddLog(CurrentTime + "; Disabled tool", (int)EditorActionType.DisabledTool);
            _toolsetEnabled = false;
        }

        public void UpdateTitle()
        {
            if (_curGame == null)
                this.Text = EngineName;
            else
                this.Text = Title;

            _logViewer.AddLog(CurrentTime + "; Title updated", (int)EditorActionType.TitleUpdated);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public static Editor Instance
        {
            get { return _instance; }
        }

        public ProjectDirectory Project_Directory
        {
            get { return _projectDirectory; }
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newGameForm = new NewGame();
            _newGameForm.ShowDialog();
        }

        public Game CurGame
        {
            get { return _curGame; }
        }

        public string EngineName
        {
            get { return "Jackie's RPG Maker"; }
        }

        public string Title
        {
            get { return EngineName + " - " + _curGame.GameFullName; }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadProject();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newMapForm = new JRPEditorEngine.NewMap();
            _newMapForm.ShowDialog();
            _projectDirectory.RefreshTreeView();
        }

        public string CurrentTime
        {
            get { return DateTime.Now.ToString("HH:mm:ss tt"); }
        }

        private void btnDrawPencil_Click(object sender, EventArgs e)
        {
            if (_toolsetEnabled)
            {
                _drawType = 0;
                btnDrawPencil.Checked = true;
                btnDrawLine.Checked = false;
                btnDrawRect.Checked = false;
                btnDrawEllipse.Checked = false;
            }
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            if (_toolsetEnabled)
            {
                _drawType = 1;
                btnDrawPencil.Checked = false;
                btnDrawLine.Checked = true;
                btnDrawRect.Checked = false;
                btnDrawEllipse.Checked = false;
            }
        }

        private void btnDrawRect_Click(object sender, EventArgs e)
        {
            if (_toolsetEnabled)
            {
                _drawType = 2;
                btnDrawPencil.Checked = false;
                btnDrawLine.Checked = false;
                btnDrawRect.Checked = true;
                btnDrawEllipse.Checked = false;
            }
        }

        private void btnDrawEllipse_Click(object sender, EventArgs e)
        {
            if (_toolsetEnabled)
            {
                _drawType = 3;
                btnDrawPencil.Checked = false;
                btnDrawLine.Checked = false;
                btnDrawRect.Checked = false;
                btnDrawEllipse.Checked = true;
            }
        }
    }
}
