using System.Collections.Generic;
using UnityEngine;

namespace SAP2D {

    public class SAP_UserData : ScriptableObject
    {
        [HideInInspector]
        public List<SAP_TileData> UnwalkableTiles = new List<SAP_TileData>();

        public void AddData(SAP_TileData tile)
        {
            for (int i = 0; i < UnwalkableTiles.Count; i++)
            {
                if (UnwalkableTiles[i].x == tile.x && UnwalkableTiles[i].y == tile.y) return;
            }
            UnwalkableTiles.Add(tile);
        }

        public void DeleteData(SAP_TileData tile)
        {
            for (int i = 0; i < UnwalkableTiles.Count; i++)
            {
                if (UnwalkableTiles[i].x == tile.x && UnwalkableTiles[i].y == tile.y)
                {
                    UnwalkableTiles.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
