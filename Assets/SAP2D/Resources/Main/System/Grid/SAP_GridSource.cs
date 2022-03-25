using System;
using System.Collections.Generic;
using UnityEngine;

namespace SAP2D {

    public enum GridPivot
    {
        BottomLeft,
        UpLeft,
        Center,
        UpRight,
        BottomRight,
    }

    [Serializable]
    public class SAP_GridSource
    {
        public int Width => width;
        public int Height => height;
        public Vector2 Size => gridBounds.size;
        public Vector3 Center => gridBounds.center;
        public Vector3 MinPos => gridBounds.min;
        public Vector3 MaxPos => gridBounds.max;

        public string GridName = "Default Grid";
        public bool UsePhysics2D = true;
        public LayerMask ObstaclesLayer = 1;
        public SAP_UserData UserGridData;

        private Bounds gridBounds;

        public Vector3 Position
        {
            get
            {
                return gridPosition;
            }
            set
            {
                gridPosition = value;
                SetCenterPosAccordingToPivot();
            }
        }

        public float TileDiameter
        {
            get
            {
                return tileDiameter;
            }
            set
            {
                tileDiameter = Mathf.Clamp(value, 0.01f, value);
                SetGridSize();
                SetCenterPosAccordingToPivot();
            }
        }

        public GridPivot GridPivot
        {
            get
            {
                return gridPivot;
            }
            set
            {
                gridPivot = value;
                if (gridPivot == GridPivot.Center)      gridPosition = gridBounds.center;
                if (gridPivot == GridPivot.BottomLeft)  gridPosition = gridBounds.min;
                if (gridPivot == GridPivot.UpRight)     gridPosition = gridBounds.max;
                if (gridPivot == GridPivot.UpLeft)      gridPosition = new Vector2(gridBounds.min.x, gridBounds.max.y);
                if (gridPivot == GridPivot.BottomRight) gridPosition = new Vector2(gridBounds.max.x, gridBounds.min.y);
                SetCenterPosAccordingToPivot();
            }
        }

        [SerializeField] private Vector3 gridPosition;
        [SerializeField] private GridPivot gridPivot;
        [SerializeField] private int width;
        [SerializeField] private int height;
        [SerializeField] private float tileDiameter = 1;

        private SAP_TileData[,] tiles;

        public SAP_GridSource(int width = 10, int height = 10)
        {
            CreateGrid(width, height);
        }

        public SAP_TileData GetTileDataAt(int x, int y)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                return null;
            }
            if (tiles == null)
            {
                CreateGrid(width, height);
                CalculateColliders();
                ReadUserData();
            }
            return tiles[x, y];
        }

        public SAP_TileData GetTileDataAtWorldPosition(Vector3 worldPosition)
        {
            if (tiles == null)
            {
                CreateGrid(width, height);
                CalculateColliders();
                ReadUserData();
            }
            int x = Mathf.FloorToInt((worldPosition.x - MinPos.x) / tileDiameter);
            int y = Mathf.FloorToInt((worldPosition.y - MinPos.y) / tileDiameter);

            x = Mathf.Clamp(x, 0, width - 1);
            y = Mathf.Clamp(y, 0, height - 1);

            return tiles[x, y];
        }

        public void CreateGrid(int width, int height)
        {
            width = Mathf.Clamp(width, 1, width);
            height = Mathf.Clamp(height, 1, height);
            this.width = width;
            this.height = height;
            tiles = new SAP_TileData[width, height];

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    tiles[x,y] = new SAP_TileData(x, y, this);
                }
            }
            SetGridSize();
            SetCenterPosAccordingToPivot();
        }

        public void CalculateColliders(SAP_TileData startTile = null, SAP_TileData endTile = null)
        {
            if(startTile == null)
            {
                startTile = GetTileDataAt(0, 0);
            }
            if(endTile == null)
            {
                endTile = GetTileDataAt(Width - 1, Height - 1);
            }
            for (int x = startTile.x; x <= endTile.x; x++)
            {
                for (int y = startTile.y; y <= endTile.y; y++)
                {
                    SAP_TileData tile = GetTileDataAt(x, y);

                    Collider2D[] colls = Physics2D.OverlapCircleAll(tile.WorldPosition, tileDiameter / 4, ObstaclesLayer);

                    if (tile.walkableLock == true)
                        continue;

                    if (UsePhysics2D == true)
                    {
                        if (colls.Length > 0)
                        {
                            tile.isWalkable = GetWalkableState(colls);
                        }
                        else
                        {
                            tile.isWalkable = true;
                        }
                    }
                    else
                    {
                        tile.isWalkable = true;
                    }
                }
            }
        }

        public List<SAP_TileData> GetNeighborTiles(SAP_TileData tile, bool cutCorners, int radius = 1)
        {
            List<SAP_TileData> neighbors = new List<SAP_TileData>();
            for(int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    if (x == 0 && y == 0) continue;
                    int currX = tile.x + x;
                    int currY = tile.y + y;
                    if (currX >= 0 && currY >= 0 && currX < width && currY < height)
                    {
                        SAP_TileData currTile = GetTileDataAt(currX, currY);
                        if(cutCorners == false)
                        if (CheckCorner(tile, currTile) == true) continue;
                        neighbors.Add(currTile);
                    }
                }
            }
            return neighbors;
        }

        private void ReadUserData()
        {
            if(UserGridData == null)
            {
                return;
            }
            foreach(SAP_TileData t in UserGridData.UnwalkableTiles)
            {
                int x = t.x;
                int y = t.y;
                SAP_TileData tile = GetTileDataAt(x, y);
                tile.isWalkable = false;
                tile.walkableLock = true;
            }
        }

        private bool GetWalkableState(Collider2D[] colls)
        {
            foreach (Collider2D coll in colls)
            {
                if (coll.isTrigger == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckCorner(SAP_TileData centerTile, SAP_TileData conerTile)
        {
            if (centerTile.x != conerTile.x && centerTile.y != conerTile.y)
            {
                int mixX = Math.Min(centerTile.x, conerTile.x);
                int maxX = Math.Max(centerTile.x, conerTile.x);
                int minY = Math.Min(centerTile.y, conerTile.y);
                int maxY = Math.Max(centerTile.y, conerTile.y);
                for (int x = mixX; x <= maxX; x++)
                {
                    for (int y = minY; y <= maxY; y++)
                    {
                        SAP_TileData tile = GetTileDataAt(x, y);
                        if (tile.isWalkable == false)
                            return true;
                    }
                }
            }
            return false;
        }

        private void SetGridSize()
        {
            gridBounds.size = new Vector2(width * tileDiameter, height * tileDiameter);
        }

        private void SetCenterPosAccordingToPivot()
        {
            if (GridPivot == GridPivot.Center)      gridBounds.center = Position;
            if (GridPivot == GridPivot.BottomLeft)  gridBounds.center = new Vector2(Position.x + gridBounds.extents.x, Position.y + gridBounds.extents.y);
            if (GridPivot == GridPivot.UpLeft)      gridBounds.center = new Vector2(Position.x + gridBounds.extents.x, Position.y - gridBounds.extents.y);
            if (GridPivot == GridPivot.UpRight)     gridBounds.center = new Vector2(Position.x - gridBounds.extents.x, Position.y - gridBounds.extents.y);
            if (GridPivot == GridPivot.BottomRight) gridBounds.center = new Vector2(Position.x - gridBounds.extents.x, Position.y + gridBounds.extents.y);
        }
    }
}
