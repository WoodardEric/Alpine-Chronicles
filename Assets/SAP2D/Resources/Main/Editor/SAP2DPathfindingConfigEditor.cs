using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SAP2D.Editors
{
    [CustomEditor(typeof(SAP2DPathfindingConfig))]
    [CanEditMultipleObjects]
    public class SAP2DPathfindingConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }
    }
}