using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] private GameObject _leftwall;
    [SerializeField] private GameObject _rightWall;
    [SerializeField] private GameObject _forntWal;
    [SerializeField] private GameObject _backWall;
    [SerializeField] private GameObject _unvitableBlock;

    public bool isVisited { get; private set; }

    public void Visit()
    {
        _unvitableBlock.SetActive(false);
        isVisited = true;
    }
    public void ClearLeftWall()
    {
        _leftwall.SetActive(false);
    }
    public void ClearRightWall()
    {
        _rightWall.SetActive(false);
    }
    public void ClearForntWall()
    {
        _forntWal.SetActive(false);
    }
    public void ClearBackWall()
    {
        _backWall.SetActive(false);
    }
    
}
