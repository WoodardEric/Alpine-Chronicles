using UnityEngine;
using UnityEditor;

namespace SAP2D.Editors
{
    [CustomEditor(typeof(SAP2DDynamicObstacle))]
    public class SAP2DDynamicObstacleEditor : Editor
    {
        private SAP2DPathfinder pathfinder;
        private SAP2DDynamicObstacle dunamicObstacle;

        private void OnEnable()
        {
            pathfinder = SAP2DPathfinder.singleton;
            dunamicObstacle = (SAP2DDynamicObstacle)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if(pathfinder == null)
            {
                EditorGUILayout.HelpBox("To create Dynamic Obstacle also you should have SAP2D Manager script on the scene. " +
                    "SAP2D Manager wasn't found. ", MessageType.Error);
                if(GUILayout.Button("Try to find SAP2D Manager"))
                {
                    pathfinder = SAP2DPathfinder.singleton;
                }
            }
        }
    }
}
