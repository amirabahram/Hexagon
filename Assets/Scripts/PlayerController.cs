using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Grid grid;
    [SerializeField] GameObject gridObj;
    private void Awake()
    {
        
    }
    void Start()
    {

        grid = gridObj.GetComponent<Grid>();
        foreach(var i in grid._tiles)
        {
            i.Value.onTileClicked += movePlayer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void movePlayer(Vector3 v)
    {
        transform.position = v;
    }
}
