using UnityEngine;

namespace SAP2D.Editors
{
    [CreateAssetMenu(fileName = "SAP2DEditorSettings", menuName = "SAP2D/Editor Settings", order = 2)]
    public class SAP2DEditorSettings : ScriptableObject
    {
        [HideInInspector] public string UserDataFolder = "Assets/SAP2D/UserData";
        [HideInInspector] public Color32 gridColor = new Color32(255, 255, 255, 150);
        [HideInInspector] public Color32 obstacleColor = new Color32(255, 0, 0, 50);
        [HideInInspector] public Color32 selectingColor = new Color32(255, 255, 0, 255);
    }
}
