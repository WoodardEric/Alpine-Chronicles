using UnityEngine;
using UnityEditor;

namespace SAP2D.Editors {

    public class SAP2DAboutWindow : EditorWindow
    {
        private float typingSpeed = 1;
        private int charIndex = -1;
        private string displayTxt;
        private string reviewBtnTxt = "Write Review";

        private TextAsset changeLog;
        private Texture2D sap2dLogo;
        private GUIStyle rivewBtn = new GUIStyle("button");

        [MenuItem("Tools/SAP2D/About")]
        new public static void Show()
        {
            GetWindow<SAP2DAboutWindow>("SAP2D About");
            GetWindow<SAP2DAboutWindow>("SAP2D About").minSize = new Vector2(500, 500);
            GetWindow<SAP2DAboutWindow>("SAP2D About").maxSize = new Vector2(500, 500);
        }

        private void OnEnable()
        {
            changeLog = Resources.Load("Main/ChangeLog") as TextAsset;
            sap2dLogo = Resources.Load("Main/Editor/GUI/Icons/sap2d_logo") as Texture2D;
            rivewBtn.fontSize = 15;
            rivewBtn.fontStyle = FontStyle.Italic;
            rivewBtn.alignment = TextAnchor.MiddleLeft;
        }

        private void Update()
        {
            if(charIndex + 1 >= reviewBtnTxt.ToCharArray().Length)
            {
                return;
            }
            typingSpeed -= 0.1f;
            if(typingSpeed <= 0)
            {
                charIndex++;
                displayTxt += reviewBtnTxt.ToCharArray()[charIndex];
                typingSpeed = 1;
                Repaint();
            }
        }

        private void OnGUI()
        {
            GUI.DrawTexture(new Rect(15, 15, 472, 118), sap2dLogo);
            GUILayout.BeginArea(new Rect(15, 140, position.width - 30, position.height - 120));
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Created by Michel Schneider. \nCurrent version: 2019.1.3b");
            if (GUILayout.Button("Forum"))
            {
                Application.OpenURL("https://forum.unity.com/threads/released-sap2d-system-03-2b-a-pathfinding-for-2d-games.525707");
            }
            if (GUILayout.Button("Documentation"))
            {
                Application.OpenURL("https://docs.google.com/document/d/19EHWHNtg6IVCvH8amks_r92F4WkGCKlTTMcD0CvYYrQ");
            }
            GUILayout.EndHorizontal();
            GUILayout.TextArea(changeLog.text, GUILayout.MinHeight(300));
            if(GUILayout.Button(displayTxt, rivewBtn, GUILayout.MaxWidth(110)))
            {
                Application.OpenURL("https://assetstore.unity.com/packages/tools/ai/sap2d-beta-109184");
            }
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}
