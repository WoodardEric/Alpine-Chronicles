using UnityEngine;

namespace SAP2D
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Collider2D))]
    [AddComponentMenu("Pathfinding 2D/SAP2D Dynamic Obstacle")]
    public class SAP2DDynamicObstacle : MonoBehaviour
    {
        public SAP2DPathfindingConfig Config;

        private SAP_GridSource grid;
        private Collider2D coll2D;
        private SAP2DPathfinder pathfinder;
        private Bounds currentBounds;
        private Bounds lastBounds;
        private bool isMoving;
        private bool isTrigger;

        private void Reset()
        {
            Config = Resources.Load("Main/Configs/Default") as SAP2DPathfindingConfig;
        }

        private void OnEnable()
        {
            pathfinder = SAP2DPathfinder.singleton;
            coll2D = GetComponent<Collider2D>();
            CalculateObstacle(currentBounds);
        }

        private void OnDisable()
        {
            CalculateObstacle(currentBounds);
        }

        private void Update()
        {
            if (transform.hasChanged == true)
            {
                isMoving = true;
                transform.hasChanged = false;
            }
            else
            {
                isMoving = false;
            }
            if (isMoving == true)
            {
                currentBounds = coll2D.bounds;

                CalculateObstacle(currentBounds);
                CalculateObstacle(lastBounds);

                lastBounds = currentBounds;
            }
            if (isTrigger != coll2D.isTrigger)
            {
                CalculateObstacle(currentBounds);
            }
            isTrigger = coll2D.isTrigger;
        }

        public void CalculateObstacle(Bounds bounds)
        {
            if (Config == null || pathfinder == null)
            {
                return;
            }

            grid = pathfinder.GetGrid(Config.GridIndex);

            float tileRadius = grid.TileDiameter / 2;

            Vector3 minPos = new Vector3
            (
                bounds.min.x - tileRadius,
                bounds.min.y - tileRadius,
                bounds.min.z
            );
            Vector3 maxPos = new Vector3
            (
                bounds.max.x + tileRadius,
                bounds.max.y + tileRadius,
                bounds.max.z
            );

            SAP_TileData minTile = grid.GetTileDataAtWorldPosition(minPos);
            SAP_TileData maxTile = grid.GetTileDataAtWorldPosition(maxPos);

            grid.CalculateColliders(minTile, maxTile);
        }

        private void OnDestroy()
        {
            CalculateObstacle(lastBounds);
        }
    }
}
