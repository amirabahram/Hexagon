using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelection : MonoBehaviour
{
    public event Action<List<GameObject>> onTilesSelected;
    Touch touch;
    private Tile tile;
    public List<GameObject> selectedTiles = new List<GameObject>();
    public int cubeNumber=-1;
    private GameObject prevGameObject;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
        else
        {
            // Simulate touch began with left mouse button click
            if (Input.GetMouseButtonDown(0))
            {
                DragStart();
            }
            // Simulate touch move with mouse drag
            else if (Input.GetMouseButton(0))
            {
                Dragging();
            }
            // Simulate touch end with mouse button release
            else if (Input.GetMouseButtonUp(0))
            {
                DragRelease();
            }
        }

    }

    private void DragRelease()
    {
        onTilesSelected?.Invoke(selectedTiles);
    }

    private void Dragging()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Perform the 2D raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        // Check if the raycast hit any 2D collider
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            if (prevGameObject == null)
            {
                prevGameObject = hitObject;
            }

            tile = hitObject.GetComponent<Tile>();
            if (selectedTiles.Contains(hitObject) && prevGameObject != hitObject)
            {
                int index = selectedTiles.FindIndex(a => a == hitObject);
                tile = selectedTiles[index + 1].GetComponent<Tile>();
                tile.highlight.SetActive(false);
                selectedTiles.RemoveAt(index + 1);
            }
            if (!selectedTiles.Contains(hitObject) && selectedTiles.Count<=cubeNumber && cubeNumber !=0)
            {
                
                tile.highlight.SetActive(true);
                selectedTiles.Add(hitObject);
            }
            if (prevGameObject != hitObject)
            {
                prevGameObject = hitObject;
            }

        }
    }
        private void DragStart()
    {
        Debug.Log("Drag Start");
    }
}
