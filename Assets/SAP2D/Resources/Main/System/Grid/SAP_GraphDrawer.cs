using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SAP2D.Editors {

    [Serializable]
    public class SAP_GraphDrawer {

#if UNITY_EDITOR

        public bool ShowGrid = true;
        public bool ShowGridInfo;
        public bool ShowGridParameters;
        public bool ShowPathfindingSettings;
        public bool ShowGridGraphSettigs;
        public float ScaleLvl = 1;

        private Vector3 leftButtom;
        private Vector3 rightUp;
        private Vector3 leftButtomClamped;
        private Vector3 rightUpClamped;
        private Vector2 camLeftButtom;
        private Vector2 camRightUp;

        private SAP_GridSource grid;
        private SAP_TileData[,] tiles;

        private const float MIN_TILE_SIZE = 10;
        private const float MAX_TILE_SIZE = 20;
        private float tileDiameter;
        private int width;
        private int height;
        private int minX;
        private int minY;
        private int maxX;
        private int maxY;

        public void Draw(SAP_GridSource grid)
        {
            this.grid = grid;
            Camera cam = SceneView.lastActiveSceneView.camera;

            if(cam.orthographic == false)
            {
                return;
            }

            CalculcateGridView(cam);

            DrawGridFrame();
            DrawVerticalLines();
            DrawHorizontalLines();
            DrawTiles();
        }

        private void CalculcateGridView(Camera cam)
        {
            // Calculate the grid rendering angles from the camera in the SceneView window
            // we have to draw only the part of the grid that appears in the field of view of the camera in the SceneView window
            // calculate the position of the corners of the camera in the SceneView in the world space
            camLeftButtom = cam.ScreenToWorldPoint(new Vector2(cam.pixelRect.xMin, cam.pixelRect.yMin));
            camRightUp = cam.ScreenToWorldPoint(new Vector2(cam.pixelRect.xMax, cam.pixelRect.yMax));

            UpdateScaleLevel(cam);
            UpdateGridParameters();


            leftButtom = grid.MinPos;
            rightUp = grid.MaxPos;


            // for drawing the grid, we calculate the position of the coners accorrding to the position of the cam in the SceneView
            leftButtomClamped = new Vector3(
                 Mathf.Clamp(camLeftButtom.x, leftButtom.x, rightUp.x),
                 Mathf.Clamp(camLeftButtom.y, leftButtom.y, rightUp.y),
                 leftButtom.z
                );
            rightUpClamped = new Vector3(
                Mathf.Clamp(camRightUp.x, leftButtom.x, rightUp.x),
                Mathf.Clamp(camRightUp.y, leftButtom.y, rightUp.y),
                rightUp.z
                );

            minX = Mathf.FloorToInt((leftButtomClamped.x - leftButtom.x) / tileDiameter) + 1;
            maxX = width - Mathf.FloorToInt((rightUp.x - rightUpClamped.x) / tileDiameter);
            minY = Mathf.FloorToInt((leftButtomClamped.y - leftButtom.y) / tileDiameter) + 1;
            maxY = height - Mathf.FloorToInt((rightUp.y - rightUpClamped.y) / tileDiameter);
            maxY = height - Mathf.FloorToInt((rightUp.y - rightUpClamped.y) / tileDiameter);

            if (minX > width) minX = width;
            if (maxX < 0) maxX = 0;
            if (minY > height) minY = height;
            if (maxY < 0) maxY = 0;
        }

        private void UpdateGridParameters()
        {
            width = Mathf.CeilToInt(grid.Width / ScaleLvl);
            height = Mathf.CeilToInt(grid.Height / ScaleLvl);
            tileDiameter = grid.TileDiameter * ScaleLvl;
        }

        private void UpdateScaleLevel(Camera cam)
        {
            Vector3 pointA = leftButtom;
            Vector3 pointB = new Vector3(leftButtom.x + tileDiameter, leftButtom.y, leftButtom.z);
            float screenTileSize = cam.WorldToScreenPoint(pointB).x - cam.WorldToScreenPoint(pointA).x;

            if (screenTileSize < MIN_TILE_SIZE)
            {
                ScaleLvl *= 2;
            }
            else if (screenTileSize > MAX_TILE_SIZE)
            {
                if (ScaleLvl > 1)
                {
                    ScaleLvl /= 2;
                }
            }
        }

        private void DrawGridFrame()
        {
            Gizmos.color = SAP2DPathfinder.singleton.EditorSettings.gridColor;
            Vector3 center = grid.Center;
            Vector2 size = new Vector2(grid.Size.x, grid.Size.y);
            Gizmos.DrawWireCube(grid.Center, size);
        }

        private void DrawVerticalLines()
        {
            if (camLeftButtom.y > rightUp.y || camRightUp.y < leftButtom.y)
            {
                return;
            }

            Vector3 start = new Vector3(
                leftButtom.x,
                leftButtomClamped.y,
                leftButtom.z
                );
            Vector3 end = new Vector3(
                leftButtom.x,
                rightUpClamped.y,
                leftButtom.z
                );

            Gizmos.color = SAP2DPathfinder.singleton.EditorSettings.gridColor;
            for (int i = minX; i < maxX; i++)
            {
                start.x = leftButtom.x + tileDiameter * i;
                end.x = start.x;
                Gizmos.DrawLine(start, end);
            }
        }

        private void DrawHorizontalLines()
        {
            if (camLeftButtom.x > rightUpClamped.x || camRightUp.x < leftButtomClamped.x)
            {
                return;
            }

            Vector3 start = new Vector3(
                leftButtomClamped.x,
                leftButtom.y,
                leftButtom.z
                );
            Vector3 end = new Vector3(
                rightUpClamped.x,
                leftButtom.y,
                leftButtom.z
                );

            Gizmos.color = SAP2DPathfinder.singleton.EditorSettings.gridColor;
            for (int i = minY; i < maxY; i++)
            {
                start.y = leftButtom.y + tileDiameter * i;
                end.y = start.y;
                Gizmos.DrawLine(start, end);
            }
        }

        private void DrawTiles()
        {
            if (minX == maxX || minY == maxY)
            {
                return;
            }
            float tileRadius = tileDiameter / 2;

            for (int x = minX - 1; x < maxX; x++)
            {
                for (int y = minY - 1; y < maxY; y++)
                {
                    SAP_TileData tile = grid.GetTileDataAt(x * (int)ScaleLvl + (int)(ScaleLvl / 2), y * (int)ScaleLvl + (int)(ScaleLvl / 2));

                    if(tile == null) continue;

                    //drawing unwakable tiles
                    if (tile.isWalkable == false)
                    {
                        Vector3 position = new Vector3(
                        leftButtom.x + tileDiameter * x + tileRadius,
                        leftButtom.y + tileDiameter * y + tileRadius,
                        leftButtom.z
                        );
                        Gizmos.color = SAP2DPathfinder.singleton.EditorSettings.obstacleColor;
                        Gizmos.DrawCube(position, new Vector2(tileDiameter, tileDiameter));
                    }
                }
            }
        }
#endif
    }
}
