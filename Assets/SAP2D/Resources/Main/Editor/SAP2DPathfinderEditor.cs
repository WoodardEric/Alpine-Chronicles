using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace SAP2D.Editors
{
    [CustomEditor(typeof(SAP2DPathfinder))]
    public class SAP2DPathfinderEditor : Editor
    {
        private SAP2DPathfinder pathfinder;
        private SAP_GridSource gridToEditName;

        private SerializedProperty grids;
        private SerializedProperty graphDrawers;

        private int selectedGridIndex = -1;

        private void OnEnable()
        {
            pathfinder = (SAP2DPathfinder)target;

            grids = serializedObject.FindProperty("grids");
            graphDrawers = serializedObject.FindProperty("graphDrawers");

            if(pathfinder.EditorSettings == null)
            {
                pathfinder.EditorSettings = (SAP2DEditorSettings)Resources.Load("Main/Editor/Settings/SAP2DEditorSettings");
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }
        }

        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            GenericMenuUpdate();
            DrawGridsList();
        }

        private void GenericMenuUpdate()
        {
            Event e = Event.current;
            string focusedControl = GUI.GetNameOfFocusedControl();

            if (focusedControl.Contains("grid_") == true)
            {
                int.TryParse(focusedControl.Substring(5), out selectedGridIndex);
            }
            else if (focusedControl == "")
            {
                gridToEditName = null;
                selectedGridIndex = -1;
            }
            if (e.isMouse && e.type == EventType.MouseDown)
            {
                if (e.button == 1)
                {
                    GenericMenu menu = new GenericMenu();
                    if (selectedGridIndex == -1)
                    {
                        menu.AddItem(new GUIContent("Add New Grid"), false, AddGridCallback);
                        if (pathfinder.gridsCount > 0)
                        {
                            menu.AddItem(new GUIContent("Open Grid Editor"), false, EditGridsModeCallback);
                        }
                    }
                    else
                    {
                        if (selectedGridIndex + 1 < pathfinder.gridsCount)
                        {
                            menu.AddItem(new GUIContent("Move Down"), false, MoveGridDownCallback);
                        }
                        if (selectedGridIndex - 1 >= 0)
                        {
                            menu.AddItem(new GUIContent("Move Up"), false, MoveGridUpCallback);
                        }
                        if (pathfinder.gridsCount > 0)
                        {
                            menu.AddItem(new GUIContent("Rename"), false, RenameGridCallback);
                            menu.AddItem(new GUIContent("Delete"), false, DeleteGridCallback);
                        }
                    }
                    menu.ShowAsContext();
                }
            }
        }

        private void AddGridCallback()
        {
            pathfinder.AddGrid();
            SAP_GraphDrawer newDrawer = new Editors.SAP_GraphDrawer();
            pathfinder.GraphDrawers.Add(newDrawer);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        private void DeleteGridCallback()
        {
            SAP_GridSource grid = pathfinder.GetGrid(selectedGridIndex);
            SAP_GraphDrawer drawer = pathfinder.GraphDrawers[selectedGridIndex];
            pathfinder.RemoveGrid(grid);
            pathfinder.GraphDrawers.Remove(drawer);
        }

        private void RenameGridCallback()
        {
            gridToEditName = pathfinder.GetGrid(selectedGridIndex);
        }

        private void MoveGridUpCallback()
        {
            pathfinder.SwapGrids(selectedGridIndex, selectedGridIndex - 1);
            SAP_GraphDrawer drawerA = pathfinder.GraphDrawers[selectedGridIndex];
            SAP_GraphDrawer drawerB = pathfinder.GraphDrawers[selectedGridIndex - 1];
            pathfinder.GraphDrawers[selectedGridIndex] = drawerB;
            pathfinder.GraphDrawers[selectedGridIndex - 1] = drawerA;
        }

        private void MoveGridDownCallback()
        {
            pathfinder.SwapGrids(selectedGridIndex, selectedGridIndex + 1);
            pathfinder.SwapGrids(selectedGridIndex, selectedGridIndex - 1);
            SAP_GraphDrawer drawerA = pathfinder.GraphDrawers[selectedGridIndex];
            SAP_GraphDrawer drawerB = pathfinder.GraphDrawers[selectedGridIndex - 1];
            pathfinder.GraphDrawers[selectedGridIndex] = drawerB;
            pathfinder.GraphDrawers[selectedGridIndex - 1] = drawerA;
        }

        private void EditGridsModeCallback()
        {
            SAP2DGridEditorWindow.Show();
        }

        private void DrawGridsList()
        {
            if (pathfinder.gridsCount == 0)
            {
                EditorGUILayout.HelpBox("SAP2D Manager has't none grids." +
                    "\nYou should create new grid by click right mouse button on inspector window and select 'Add New Grid'", MessageType.Info);
                return;
            }

            serializedObject.Update();

            for (int i = 0; i < pathfinder.gridsCount; i++)
            {
                SAP_GridSource grid = pathfinder.GetGrid(i);
                SAP_GraphDrawer drawer = pathfinder.GraphDrawers[i];

                SerializedProperty obstacleLayer = grids.GetArrayElementAtIndex(i).FindPropertyRelative("ObstaclesLayer");

                EditorGUILayout.BeginVertical("box");
                EditorGUI.indentLevel = 1;

                DrawHeaderPanel(grid, drawer);

                if (drawer.ShowGridInfo)
                {
                    #region GridParametersDrawing

                    EditorGUILayout.BeginVertical("box");
                    drawer.ShowGridParameters = EditorGUILayout.Foldout(drawer.ShowGridParameters, "Grid Parameters", true);
                    if (drawer.ShowGridParameters)
                    {
                        EditorGUI.indentLevel = 0;

                        EditorGUI.BeginChangeCheck();
                        int gridWidth = EditorGUILayout.IntField("Grid Width", grid.Width);
                        if (EditorGUI.EndChangeCheck())
                        {
                            grid.CreateGrid(gridWidth, grid.Height);
                            SceneView.RepaintAll();
                            if (grid.UserGridData != null)
                            {
                                grid.UserGridData.UnwalkableTiles.Clear();
                            }
                        }

                        EditorGUI.BeginChangeCheck();
                        int gridHeight = EditorGUILayout.IntField("Grid Height", grid.Height);
                        if (EditorGUI.EndChangeCheck())
                        {
                            grid.CreateGrid(grid.Width, gridHeight);
                            SceneView.RepaintAll();
                            if (grid.UserGridData != null)
                            {
                                grid.UserGridData.UnwalkableTiles.Clear();
                            }
                        }

                        EditorGUI.BeginChangeCheck();
                        float tileDiameter = EditorGUILayout.FloatField("Tile Diameter", grid.TileDiameter);
                        if (EditorGUI.EndChangeCheck())
                        {
                            grid.TileDiameter = tileDiameter;
                            SceneView.RepaintAll();
                        }

                        EditorGUI.BeginChangeCheck();
                        GridPivot pivot = (GridPivot)EditorGUILayout.EnumPopup("Grid Pivot", grid.GridPivot);
                        if (EditorGUI.EndChangeCheck())
                        {
                            grid.GridPivot = pivot;
                            SceneView.RepaintAll();
                        }

                        EditorGUI.BeginChangeCheck();
                        Vector3 gridPos = EditorGUILayout.Vector3Field("Grid Position", grid.Position);
                        if (EditorGUI.EndChangeCheck())
                        {
                            grid.Position = gridPos;
                            SceneView.RepaintAll();
                        }
                        EditorGUI.indentLevel = 1;
                    }
                    EditorGUILayout.EndVertical();

                    #endregion

                    #region PathfindingSettingsDrawing

                    EditorGUILayout.BeginVertical("box");
                    drawer.ShowPathfindingSettings = EditorGUILayout.Foldout(drawer.ShowPathfindingSettings, "Pathfinding Settings", true);
                    if (drawer.ShowPathfindingSettings)
                    {
                        EditorGUI.indentLevel = 0;
                        bool usePhysics2D = EditorGUILayout.Toggle("Use Physics 2D", grid.UsePhysics2D);
                        if (usePhysics2D != grid.UsePhysics2D)
                        {
                            grid.UsePhysics2D = usePhysics2D;
                            pathfinder.CalculateColliders();
                            SceneView.RepaintAll();
                        }
                        EditorGUI.BeginChangeCheck();
                        EditorGUILayout.PropertyField(obstacleLayer);
                        if (EditorGUI.EndChangeCheck())
                        {
                            serializedObject.ApplyModifiedProperties();
                        }
                        EditorGUI.indentLevel = 1;
                    }
                    EditorGUILayout.EndVertical();

                    #endregion
                }
                EditorGUILayout.EndVertical();
            }
            if (GUILayout.Button("Calculate Colliders (All Grids)", GUILayout.Height(25)))
            {
                for (int i = 0; i < pathfinder.gridsCount; i++)
                {
                    SAP_GridSource grid = pathfinder.GetGrid(i);
                }
                pathfinder.CalculateColliders();
                SceneView.RepaintAll();
            }
        }

        private void DrawHeaderPanel(SAP_GridSource grid, SAP_GraphDrawer drawer)
        {
            int index = pathfinder.GraphDrawers.IndexOf(drawer);
            string foldoutTxt = grid.GridName;
            string foldoutName = "grid_" + index;
            string textFieldName = "txtField_" + index;

            Rect r = EditorGUILayout.BeginHorizontal();

            if (gridToEditName == grid)
            {
                GUI.SetNextControlName(textFieldName);
                grid.GridName = EditorGUI.TextField(new Rect(r.x, r.y, r.width, 16), grid.GridName);
                foldoutTxt = "";
                if (GUI.GetNameOfFocusedControl() != textFieldName)
                {
                    GUI.FocusControl(textFieldName);
                }
            }
            else
            {
                drawer.ShowGrid = EditorGUI.Toggle(new Rect(r.xMax - 30, r.y, 30, 30), drawer.ShowGrid);
                EditorGUI.LabelField(new Rect(r.xMax - 55, r.y, 35, 35), "[" + pathfinder.GraphDrawers.IndexOf(drawer) + "]");
            }
            GUI.SetNextControlName(foldoutName);
            drawer.ShowGridInfo = EditorGUILayout.Foldout(drawer.ShowGridInfo, foldoutTxt, true);

            EditorGUILayout.EndHorizontal();
        }

        private void OnSceneGUI()
        {
            DrawHandles();
        }

        private void DrawHandles()
        {
            serializedObject.Update();
            for (int i = 0; i < pathfinder.gridsCount; i++)
            {
                SAP_GridSource grid = pathfinder.GetGrid(i);
                SAP_GraphDrawer drawer = pathfinder.GraphDrawers[i];

                if (drawer.ShowGrid == false)
                {
                    continue;
                }

                Vector3 gridPos = Handles.PositionHandle(grid.Position, Quaternion.identity);
                if (gridPos != grid.Position)
                {
                    grid.Position = gridPos;
                }
            }
        }

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawGizmos(SAP2DPathfinder manager, GizmoType gizmoType)
        {
            if (manager.GraphDrawers == null)
            {
                return;
            }

            for (int i = 0; i < manager.GraphDrawers.Count; i++)
            {
                SAP_GraphDrawer drawer = manager.GraphDrawers[i];
                if (drawer.ShowGrid == false || SceneView.lastActiveSceneView.camera.orthographic == false)
                {
                    continue;
                }

                SAP_GridSource grid = manager.GetGrid(i);
                drawer.Draw(grid);
            }
        }
    }
}

