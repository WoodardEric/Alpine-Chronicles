using System.Collections.Generic;
using UnityEngine;

namespace SAP2D {

    [AddComponentMenu("Pathfinding 2D/SAP2D Pathfinder")]
    public class SAP2DPathfinder : Singleton<SAP2DPathfinder> 
    {
        public int gridsCount => grids.Count;

        #if UNITY_EDITOR
        //editor data
        public List<SAP2D.Editors.SAP_GraphDrawer> GraphDrawers = new List<Editors.SAP_GraphDrawer>();
        public SAP2D.Editors.SAP2DEditorSettings EditorSettings;
        #endif

        [SerializeField] private List<SAP_GridSource> grids = new List<SAP_GridSource>();

        public void AddGrid(int width = 10, int height = 10)
        {
            SAP_GridSource newGrid = new SAP_GridSource(width, height);
            grids.Add(newGrid);
            newGrid.GridName += " " + grids.IndexOf(newGrid);
        }

        public void SwapGrids(int indexA, int indexB)
        {
            SAP_GridSource gridA = grids[indexA];
            SAP_GridSource gridB = grids[indexB];
            grids[indexA] = gridB;
            grids[indexB] = gridA;
        }

        public void RemoveGrid(SAP_GridSource grid)
        {
            grids.Remove(grid);
        }

        public SAP_GridSource GetGrid(int index) 
        {
            if (index < 0 || index > grids.Count)
            {
                Debug.LogError("Grid at index " + index + " not found");
                return null;
            }
            return grids[index];
        }

        public void CalculateColliders(SAP_TileData startTile = null, SAP_TileData endTile = null)
        {
            foreach (SAP_GridSource grid in grids) 
                grid.CalculateColliders(startTile, endTile);
        }

        public Vector2[] FindPath(Vector2 from, Vector2 to, SAP2DPathfindingConfig config)
        {
            SAP_GridSource grid = GetGrid(config.GridIndex);
            SAP_TileData startTile = grid.GetTileDataAtWorldPosition(from);
            SAP_TileData targetTile = grid.GetTileDataAtWorldPosition(to);
            SAP_TileData currentTile = startTile;

            if (targetTile.isWalkable == false) return null;

            List<SAP_TileData> openList = new List<SAP_TileData>();
            List<SAP_TileData> closedList = new List<SAP_TileData>();

            while(closedList.Contains(targetTile) == false)
            {
                List<SAP_TileData> neighbors = grid.GetNeighborTiles(currentTile, config.CutCorners);

                foreach(SAP_TileData neighbor in neighbors)
                {
                    if (neighbor.isWalkable == false || closedList.Contains(neighbor) == true) continue;
                    if (openList.Contains(neighbor) == true)
                    {
                        SAP_TileData oldParent = neighbor.ParentTile;
                        int oldG = neighbor.G;
                        neighbor.SetParentTile(currentTile, targetTile);
                        if (neighbor.G >= oldG)
                            neighbor.SetParentTile(oldParent, targetTile);
                    }
                    else
                    {
                        neighbor.SetParentTile(currentTile, targetTile);
                        openList.Add(neighbor);
                    }
                }
                openList.Remove(currentTile);
                closedList.Add(currentTile);

                currentTile = FindNextTile(openList);

                if (currentTile == null)
                {
                    Debug.LogError("Path not found");
                    return null;
                }
            }
            return PathRecovery(startTile, targetTile);
        }

        private Vector2[] PathRecovery(SAP_TileData startTile, SAP_TileData targetTile)
        { 
            SAP_TileData current = targetTile;

            List<Vector2> path = new List<Vector2>();

            while (current != startTile)
            {
                path.Add(current.WorldPosition);
                current = current.ParentTile;
            }
            path.Reverse();
            return path.ToArray();
        }

        private SAP_TileData FindNextTile(List<SAP_TileData> openList)
        {
            if (openList.Count == 0) return null;

            SAP_TileData result = openList[0];
            foreach(SAP_TileData tile in openList)
            {
                if(tile.F < result.F) result = tile;
            }
            return result;
        }

        private void OnEnable()
        {
            CalculateColliders();
        }
    }
}
