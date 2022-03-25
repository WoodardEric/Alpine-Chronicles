using System;
using UnityEngine;

namespace SAP2D {

    [System.Serializable]
    public class SAP_TileData
    {
        public int x => gridX;
        public int y => gridY;
        public int F => f;
        public int G => g;
        public int H => h;

        public bool isWalkable;
        public bool walkableLock;

        public SAP_TileData ParentTile => parentTile;

        public Vector3 WorldPosition
        {
            get
            {
                Vector3 offset = new Vector2(gridX * gridContainer.TileDiameter + gridContainer.TileDiameter * 0.5f, gridY * gridContainer.TileDiameter + gridContainer.TileDiameter * 0.5f);
                return gridContainer.MinPos + offset;
            }
        }

        private int f;
        private int g;
        private int h;
        private SAP_TileData parentTile;
        private SAP_GridSource gridContainer;

        [SerializeField] private int gridX;
        [SerializeField] private int gridY;

        public void SetParentTile(SAP_TileData parent, SAP_TileData target)
        {
            if (parent == null || target == null) return;
            parentTile = parent;

            CalculateValues(parent, target);
        }

        public SAP_TileData(int x, int y, SAP_GridSource grid)
        {
            gridX = x;
            gridY = y;
            gridContainer = grid;
            isWalkable = true;
        }

        private void CalculateValues(SAP_TileData parent, SAP_TileData target)
        {
            g = (parent.x != gridX && parent.y != gridY) ? parent.G + 14 : parent.G + 10;
            h = (Mathf.Abs(gridX - target.x) + Mathf.Abs(gridY - target.y)) * 10;
            f = g + h;
        }
    }
}
