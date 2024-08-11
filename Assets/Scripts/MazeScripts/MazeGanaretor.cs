using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGanaretor : MonoBehaviour
{
    [SerializeField] private int _mazeWidth;
    [SerializeField] private int _mazeHight;
    [SerializeField] private MazeCell _mazeCellPrefab;
    private MazeCell[,] _mazeGrid;

    private void Start()
    {
        _mazeGrid = new MazeCell[_mazeWidth, _mazeHight];

        for(int  x = 0; x < _mazeWidth; x++)
        {
            for(int z= 0; z < _mazeHight; z++)
            {
                _mazeGrid[x, z] = Instantiate(_mazeCellPrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }
    }
    private void Ganaretor(MazeCell previousCell,MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);
        MazeCell nextCell;
        
       
    }
    private void GetaNextUnvisitedCell(MazeCell currentCell)
    {

    }
   //private void GetUnVisitCell(MazeCell currentCell)
   //{
   //    int x = (int)currentCell.transform.position.x;
   //    int z = (int)currentCell.transform.position.z;
   //
   //    foreach ()
   //    {
   //        if (x + 1 < _mazeWidth)
   //        {
   //            var cellToRight = _mazeGrid[x + 1, z];
   //            if (cellToRight.isVisited == false)
   //            {
   //                yield return cellToRight;
   //            }
   //        }
   //
   //        if (x - 1 >= 0)
   //        {
   //            var cellToLeft = _mazeGrid[x - 1, z];
   //
   //            if (cellToLeft.isVisited == false)
   //            {
   //                yield return cellToLeft;
   //            }
   //        }
   //
   //        if (z + 1 < _mazeHight)
   //        {
   //            var cellToFront = _mazeGrid[x, z + 1];
   //            if (cellToFront.isVisited == false)
   //            {
   //               yield return cellToFront;
   //            }
   //        }
   //        if (z - 1 >= 0)
   //        {
   //            var cellToBack = _mazeGrid[x, z - 1];
   //            if (cellToBack.isVisited == false)
   //            {
   //                yield return cellToBack;
   //            }
   //        }
   //    }
   //}

    private void ClearWalls(MazeCell previousCell,MazeCell currentCell)
    {
        if(previousCell == null)
        {
            return;
        }
        if(previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }
        if(previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }
        if(previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearForntWall();
            currentCell.ClearBackWall();
            return;
        }
        if(previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearForntWall();
            return;
        }
    }
}
