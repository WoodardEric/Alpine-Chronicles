using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SAP2D.Editors
{
    public class SAP2DGridEditorWindow : EditorWindow
    {
        public static bool utility;

        private int toolIndex;
        private int gridIndex;
        private int brushSize = 1;
        private bool mouseDrag;

        private SAP2DPathfinder pathfinder;
        private SAP_GridSource grid;
        private SAP_GraphDrawer drawer;
        private SAP_TileData startDragTile;
        private SAP_TileData endDragTile;
        private GUISkin customGUISkin;

        private Vector2 scrollPosition;
        private Vector2 mouseWorlPosition
        {
            get {
                Vector3 screenMousePosition = Event.current.mousePosition;
                return HandleUtility.GUIPointToWorldRay(screenMousePosition).origin;
            }
        }

        [MenuItem("Tools/SAP2D/Grid Editor _#Z")]
        new public static void Show ()
        {
            EditorWindow window = EditorWindow.GetWindow(typeof(SAP2DGridEditorWindow), utility, "SAP2D Grid Editor");
            window.minSize = new Vector2(200, 200);
        }

        private void OnEnable()
        {
            pathfinder = SAP2DPathfinder.singleton;
            LoadGuiSkin();
            SceneView.duringSceneGui += OnSceneGUI;
        }

        private void OnDisable()
        {
            SceneView.duringSceneGui -= OnSceneGUI;
        }

        private void OnGUI()
        {
            if (pathfinder == null) return;
            if (pathfinder.gridsCount == 0) return;

            if (EditorApplication.isPlaying == true)
            {
                GUILayout.Label("Grid editor can be used in editor mode only.");
                return;
            }

            GUI.skin = customGUISkin;

            DrawBackground();
            DrawToolbar();

            switch (toolIndex)
            {
                case 0:
                    DrawGridSelector();
                    DrawPencilToolSettings();
                    break;
                case 1:
                    DrawGridSelector();
                    DrawPencilToolSettings();
                    break;
                case 2:
                    DrawGridSelector();
                    break;
                case 3:
                    DrawGeneralSettings();
                    break;
            }
            ShortcutsHandler();
            GenericMenuHandler();
        }

        private void OnSceneGUI(SceneView sceneView)
        {
            if (pathfinder == null) return;
            if (pathfinder.gridsCount == 0) return;
            if (EditorApplication.isPlaying == true) return;
            

            grid = pathfinder.GetGrid(gridIndex);
            drawer = pathfinder.GraphDrawers[gridIndex];

            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

            switch (toolIndex)
            {
                case 0:
                    PencilToolHandler();
                    break;
                case 1:
                    PencilToolHandler();
                    break;
                case 2:
                    RectangleToolHandler();
                    break;
            }
            ShortcutsHandler();
            SceneView.RepaintAll();
        }

        private void DrawBackground()
        {
            Texture2D tex = customGUISkin.GetStyle("FlatBackground").normal.background;
            GUI.DrawTexture(new Rect(0, 0, position.width, position.height), tex);
        }

        private void DrawToolbar()
        {
            string path = "Main/Editor/GUI/Icons/"; 
            int iconStyle = (EditorGUIUtility.isProSkin) ? 1 : 0;

            GUIContent[] toolbarContent = new GUIContent[4]
            {
                new GUIContent((Texture2D)Resources.Load(path + "pencil_icon"+iconStyle), "Pencil Tool \n\nShortcut: 'Shift + A'"),
                new GUIContent((Texture2D)Resources.Load(path + "rubber_icon"+iconStyle), "Rubber Tool \n\nShortcut: 'Shift + S'"),
                new GUIContent((Texture2D)Resources.Load(path + "rectangle_icon"+iconStyle), "Rectangle Tool \n\nShortcut: 'Shift + D'"),
                new GUIContent((Texture2D)Resources.Load(path + "settings_icon"+iconStyle), "General Settings")
            };
            
            GUILayout.BeginArea(new Rect(position.width * 0.5f - 20 * toolbarContent.Length, 10, 40 * toolbarContent.Length, 40));
            toolIndex = GUILayout.Toolbar(toolIndex, toolbarContent, "FlatToolbar");
            GUILayout.EndArea();
        }

        private void DrawGridSelector()
        {
            GUILayout.BeginArea(new Rect(0, 55, position.width * 0.4f, position.height - 55));
            string[] gridNames = new string[pathfinder.gridsCount];
            for (int i = 0; i < gridNames.Length; i++)
            {
                gridNames[i] = pathfinder.GetGrid(i).GridName;
            }
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false, GUIStyle.none, customGUISkin.verticalScrollbar);
            gridIndex = GUILayout.SelectionGrid(gridIndex, gridNames, 1, "GridSelector");
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }

        private void DrawPencilToolSettings()
        {
            GUILayout.BeginArea(new Rect(position.width * 0.4f + 5, 55, position.width * 0.6f - 10, position.height - 55));
            if (toolIndex != 0 && toolIndex != 1) return;

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(new GUIContent("Brush Size", "Shortcut: 'Shift + Mouse Wheel'"), "FlatLabel", GUILayout.MaxWidth(65));
            brushSize = (int)GUILayout.HorizontalSlider(brushSize, 1, 10, GUILayout.MinWidth(15));
            brushSize = EditorGUILayout.IntField(brushSize, "FlatBox", GUILayout.MaxWidth(30));
            brushSize = Mathf.Clamp(brushSize, 1, 10);
            EditorGUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        private void DrawGeneralSettings()
        {
            GUI.skin = null;

            GUILayout.BeginArea(new Rect(5, 55, position.width - 10, position.height - 55));
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Editor Settings", "FlatLabel", GUILayout.MaxWidth(146));
            SAP2DEditorSettings editorSettings = (SAP2DEditorSettings)EditorGUILayout.ObjectField(pathfinder.EditorSettings, typeof(SAP2DEditorSettings), false);
            if (editorSettings != pathfinder.EditorSettings)
            {
                Debug.Log("d");
                pathfinder.EditorSettings = editorSettings;
                EditorUtility.SetDirty(pathfinder.EditorSettings);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            if (pathfinder.EditorSettings != null)
            {
                EditorGUILayout.TextField("Grid Data Folder Path", pathfinder.EditorSettings.UserDataFolder);
                Color gridColor = EditorGUILayout.ColorField("Grid", pathfinder.EditorSettings.gridColor);
                if (gridColor != pathfinder.EditorSettings.gridColor)
                {
                    pathfinder.EditorSettings.gridColor = gridColor;
                    SceneView.RepaintAll();
                }

                Color obstacleColor = EditorGUILayout.ColorField("Obstacles", pathfinder.EditorSettings.obstacleColor);
                if (obstacleColor != pathfinder.EditorSettings.obstacleColor)
                {
                    pathfinder.EditorSettings.obstacleColor = obstacleColor;
                    SceneView.RepaintAll();
                }

                Color selectingColor = EditorGUILayout.ColorField("Selecting", pathfinder.EditorSettings.selectingColor);
                if (selectingColor != pathfinder.EditorSettings.selectingColor)
                {
                    pathfinder.EditorSettings.selectingColor = selectingColor;
                    SceneView.RepaintAll();
                }
            }
            GUILayout.EndArea();
        }
        
        private void DrawSelectionRectangle(Vector2 p1, Vector2 p2, Color faceColor, Color outlineColor)
        {
            Vector2 leftDown = new Vector2(Mathf.Min(p1.x, p2.x), Mathf.Min(p1.y, p2.y));
            Vector2 rightUp = new Vector2(Mathf.Max(p1.x, p2.x), Mathf.Max(p1.y, p2.y));

            float tileRadius = grid.TileDiameter / 2;

            Vector3[] verts = new Vector3[4] {
                new Vector2(leftDown.x - tileRadius, leftDown.y - tileRadius),
                new Vector2(leftDown.x - tileRadius, rightUp.y + tileRadius),
                new Vector2(rightUp.x + tileRadius, rightUp.y + tileRadius),
                new Vector2(rightUp.x + tileRadius, leftDown.y - tileRadius)
            };
            Handles.DrawSolidRectangleWithOutline(verts, faceColor, outlineColor);
        }

        private void PencilToolHandler()
        {
            if (IsMouseAboveGrid(mouseWorlPosition) == false) return;

            bool rubberMode = false;
            if (toolIndex == 1) rubberMode = true;

            SAP_TileData tileUnderMouse = grid.GetTileDataAtWorldPosition(mouseWorlPosition);

            Event e = Event.current;

            if (e.type == EventType.MouseDown || e.type == EventType.MouseDrag)
            {
                if(e.button == 0)
                {
                    List<SAP_TileData> selectedTiles = grid.GetNeighborTiles(tileUnderMouse, true, brushSize - 1);
                    selectedTiles.Add(tileUnderMouse);

                    foreach (SAP_TileData tile in selectedTiles)
                    {
                        if(rubberMode == false)
                        {
                            tile.isWalkable = false;
                            tile.walkableLock = true;
                            UserGridDataLoader.WriteData(grid, tile);
                        }
                        else
                        {
                            tile.isWalkable = true;
                            tile.walkableLock = false;
                            UserGridDataLoader.DeleteData(grid, tile);
                        }
                    }
                }
            }
            //draw brush 
            Vector2 point1 = new Vector2(tileUnderMouse.WorldPosition.x - grid.TileDiameter * (brushSize - 1), tileUnderMouse.WorldPosition.y - grid.TileDiameter * (brushSize - 1));
            Vector2 point2 = new Vector2(tileUnderMouse.WorldPosition.x + grid.TileDiameter * (brushSize - 1), tileUnderMouse.WorldPosition.y + grid.TileDiameter * (brushSize - 1));

            DrawSelectionRectangle(point1, point2, Color.clear, pathfinder.EditorSettings.selectingColor);
        }

        private void RectangleToolHandler()
        {
            if (mouseDrag == false && IsMouseAboveGrid(mouseWorlPosition) == false) return;

            Event e = Event.current;

            if(e.type == EventType.MouseDrag)
            {
                if(e.button == 0)
                {
                    mouseDrag = true;
                }
            }
            if(e.type == EventType.MouseUp)
            {
                if (e.button == 0)
                {
                    int startX = Mathf.Min(startDragTile.x, endDragTile.x);
                    int startY = Mathf.Min(startDragTile.y, endDragTile.y);
                    int endX = Mathf.Max(startDragTile.x, endDragTile.x);
                    int endY = Mathf.Max(startDragTile.y, endDragTile.y);

                    for(int x = startX; x <= endX; x++)
                    {
                        for(int y = startY; y <= endY; y++)
                        {
                            SAP_TileData tile = grid.GetTileDataAt(x, y);

                            tile.isWalkable = false;
                            tile.walkableLock = true;
                            UserGridDataLoader.WriteData(grid, tile);
                        }
                    }
                }
                mouseDrag = false;
            }
            endDragTile = grid.GetTileDataAtWorldPosition(mouseWorlPosition);
            if (mouseDrag == false) startDragTile = endDragTile;

            DrawSelectionRectangle(startDragTile.WorldPosition, endDragTile.WorldPosition, pathfinder.EditorSettings.obstacleColor, pathfinder.EditorSettings.selectingColor);
        }

        private void ShortcutsHandler()
        {
            Event e = Event.current;

            switch (e.type)
            {
                case EventType.ScrollWheel:
                    if (e.modifiers == EventModifiers.Shift)
                    {
                        if (toolIndex != 0 && toolIndex != 1) break;
                        brushSize = Mathf.Clamp((e.delta.y < 0) ? brushSize - 1 : brushSize + 1, 1, 10);
                        e.Use();
                        Repaint();
                    }
                    break;

                case EventType.KeyDown:
                    if(e.modifiers == EventModifiers.Shift)
                    {
                        if(e.keyCode == KeyCode.A)   toolIndex = 0;
                        if (e.keyCode == KeyCode.S)  toolIndex = 1;
                        if (e.keyCode == KeyCode.D)  toolIndex = 2;
                        e.Use();
                       Repaint();
                    }
                    break;
            }
        }

        private void GenericMenuHandler()
        {
            Event e = Event.current;
            if(e.button == 1)
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Open as Floating Window"), utility, () => {
                    Close();
                    utility = true;
                    Show();
                });
                menu.AddItem(new GUIContent("Open as Dockable Window"), !utility, () => {
                    Close();
                    utility = false;
                    Show();
                });
                menu.ShowAsContext();
            }
        }

        private bool IsMouseAboveGrid(Vector2 mousePosition)
        {
            if (mousePosition.x < grid.MinPos.x || mousePosition.y < grid.MinPos.y ||
                mousePosition.x > grid.MaxPos.x || mousePosition.y > grid.MaxPos.y)
                return false;
            return true;
        }

        private void LoadGuiSkin()
        {
            string skinSyle = (EditorGUIUtility.isProSkin) ? "Dark" : "Light";
            customGUISkin = (GUISkin)Resources.Load("Main/Editor/GUI/SAP2DGridEditor" + skinSyle);
        }
    }
}