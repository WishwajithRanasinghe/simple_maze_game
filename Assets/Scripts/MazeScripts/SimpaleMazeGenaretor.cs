using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpaleMazeGenaretor : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _key;

    private int[,] _mazeGride = new int[10, 10] 
    {
        {1,1,1,1,1,1,1,1,1,1 },
        {0,0,1,0,0,0,0,0,1,1 },
        {1,0,1,1,1,0,1,0,1,1 },
        {1,0,0,1,0,0,1,0,0,2 },
        {1,1,0,1,0,1,1,0,1,1 },
        {1,0,0,1,0,1,1,0,1,1 },
        {1,0,1,1,0,1,0,0,1,1 },
        {1,0,1,0,0,1,1,0,1,1 },
        {1,0,0,0,1,1,0,3,0,1 },
        {1,1,1,1,1,1,1,1,1,1 },

    };

    void Start()
    {
       for(int row = 0; row < 10; row++)
        {
            for(int col = 0; col < 10; col++)
            {
                if(_mazeGride[row,col] == 1)
                {
                   GameObject wall = Instantiate(_cubePrefab);
                    wall.transform.position = new Vector3(row, 0.5f, col);
                }
                if(_mazeGride[row,col] == 2)
                {
                    GameObject door = Instantiate(_door);
                    door.transform.position = new Vector3(row, 0.5f, col);
                }
                if(_mazeGride[row,col] == 3)
                {
                    GameObject key = Instantiate(_key);
                    key.transform.position = new Vector3(row, 0.5f, col);
                }
            }
        }
    }

}
