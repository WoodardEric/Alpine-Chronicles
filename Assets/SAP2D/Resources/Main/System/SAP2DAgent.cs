using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAP2D {

    [AddComponentMenu("Pathfinding 2D/SAP2D Agent")]
    public class SAP2DAgent : MonoBehaviour
    {
        public SAP2DPathfindingConfig Config;
        public bool MouseControl;
        public Transform Target;

        [Space(10)]
        public bool CanMove = true;
        [Range(0, 1000)]
        public float MovementSpeed = 5;
        [Range(0, 1000)]
        public float RotationSpeed = 500;


        [HideInInspector]
        public bool isMoving;
        [HideInInspector]
        public int pathIndex; //current tile index
        [HideInInspector]
        public Vector3 posInGrid;

        [Space(10)]
        public bool CanSearch = true;
        public float PathUpdateRate = 0.15f;
        public float GetNextPointDistance = 0.1f;

        [Header("Debug")]
        public bool ShowGraphic = true;
        public Color32 color = new Color32(0, 213, 225, 255);

        [HideInInspector]
        public Vector2[] path;     //array of path tiles
        private bool changeSearch; //true, if parameter CanSearch was changed
        private SAP2DPathfinder pathfinder;

        private SAP_GridSource grid;

        private void Start()
        {
            pathfinder = SAP2DPathfinder.singleton;
        }

        private void Update()
        {
            if (Target != null)
            {
                grid = pathfinder.GetGrid(Config.GridIndex);
                posInGrid = grid.GetTileDataAtWorldPosition(transform.position).WorldPosition;

                if (transform.hasChanged)
                {
                    isMoving = true;
                    transform.hasChanged = false;
                }
                else
                {
                    isMoving = false;
                }

                if (GetNextPointDistance < 0)
                {
                    GetNextPointDistance = 0.0001f;
                }

                if (MouseControl)
                {
                    if (Input.GetMouseButtonDown(0))
                        Target.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }

                if (!CanSearch && changeSearch)
                {

                    StopAllCoroutines();
                    path = null;

                    changeSearch = false;

                }
                else if (CanSearch && !changeSearch)
                {

                    StartCoroutine(FindPath());

                    changeSearch = true;
                }

                if (CanMove)
                    Move();

            }
        }

        private IEnumerator FindPath()
        { //path loop update

            if (isTargetWalkable())
                //if the object is already in the target point, the path should not be searched
                if (grid.GetTileDataAtWorldPosition(transform.position).WorldPosition != grid.GetTileDataAtWorldPosition(Target.position).WorldPosition)
                {
                    path = pathfinder.FindPath(transform.position, Target.position, Config);
                    pathIndex = 0;
                }
            yield return new WaitForSeconds(PathUpdateRate);

            StartCoroutine(FindPath());
        }

        private void Move()
        { //object movement
            if (Target != null)
            {
                Vector3 targetVector = grid.GetTileDataAtWorldPosition(Target.position).WorldPosition; //target tile position

                if (CanSearch)
                {
                    if (transform.position != targetVector)
                    {
                        if (path != null && path.Length > 0)
                        {

                            Vector3 currentTargetVector = grid.GetTileDataAtWorldPosition(path[pathIndex]).WorldPosition; //current tile position

                            Vector3 dir = currentTargetVector - transform.position; //direction of turn towards the current tile
                            Rotate(dir);

                            //line movement to current tile
                            transform.position = Vector2.MoveTowards(transform.position, currentTargetVector, Time.deltaTime * MovementSpeed);

                            if (Vector2.Distance(transform.position, currentTargetVector) < GetNextPointDistance)
                            { //if the object has approached a sufficient distance,
                                if (pathIndex < path.Length - 1)                                                     //to move to the next tile
                                    pathIndex++;
                            }
                        }
                    }
                }
                else
                {
                    if (transform.position != targetVector)
                    {
                        Vector3 dir = targetVector - transform.position; //the direction of the turn towards the target
                        Rotate(dir);

                        //line movement to target
                        transform.position = Vector2.MoveTowards(transform.position, targetVector, Time.deltaTime * MovementSpeed);
                    }
                }
            }
        }

        private void Rotate(Vector3 dir)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * RotationSpeed);
        }

        private bool isTargetWalkable()
        {
            return grid.GetTileDataAtWorldPosition(Target.position).isWalkable;
        }

        private void OnDrawGizmos()
        {
            if (ShowGraphic)
            {

                Gizmos.color = color;

                if (CanSearch)
                {
                    if (path != null)
                    {
                        for (int i = 0; i < path.Length; i++)
                        {
                            if (i + 1 < path.Length)
                                if (path[i] != Vector2.zero)
                                    Gizmos.DrawLine(path[i], path[i + 1]);
                        }
                    }
                }
                else
                {
                    Gizmos.DrawLine(transform.position, grid.GetTileDataAtWorldPosition(Target.position).WorldPosition);
                }

                Gizmos.DrawWireSphere(transform.position, GetNextPointDistance);
            }
        }
    }
}

