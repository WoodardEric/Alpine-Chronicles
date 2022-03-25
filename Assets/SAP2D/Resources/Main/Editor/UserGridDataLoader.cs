using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace SAP2D
{
    public static class UserGridDataLoader
    {
        public static void WriteData(SAP_GridSource grid, SAP_TileData tileData)
        {
            string filePath = SAP2DPathfinder.singleton.EditorSettings.UserDataFolder;

            if(grid.UserGridData == null)
            {
                //create new user grid data
                string folderPath = filePath.Substring(0, filePath.LastIndexOf('/'));
                string folderName = filePath.Remove(0, folderPath.Length + 1);

                if (!AssetDatabase.IsValidFolder(filePath))
                {
                    AssetDatabase.CreateFolder(folderPath, folderName);
                }
                string fileName = "UserGridData (" + grid.GridName + ")";
                string path = AssetDatabase.GenerateUniqueAssetPath(filePath + "/" + fileName + ".asset");

                SAP_UserData data = ScriptableObject.CreateInstance<SAP_UserData>();
                AssetDatabase.CreateAsset(data, path);

                grid.UserGridData = AssetDatabase.LoadAssetAtPath(path, typeof(SAP_UserData)) as SAP_UserData;
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }
            //write data
            grid.UserGridData.AddData(tileData);
            EditorUtility.SetDirty(grid.UserGridData);
        }

        public static void DeleteData(SAP_GridSource grid, SAP_TileData tileData)
        {
            if(grid.UserGridData == null) return;

            //delete data
            grid.UserGridData.DeleteData(tileData);
            EditorUtility.SetDirty(grid.UserGridData);
        }

        public static void RemoveUserData(SAP_UserData userData)
        {
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());

            if (userData == null) return;

            string path = AssetDatabase.GetAssetPath(userData);
            AssetDatabase.DeleteAsset(path);
        }
    }
}
