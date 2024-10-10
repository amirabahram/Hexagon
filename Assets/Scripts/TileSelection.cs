using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileSelection : MonoBehaviour
{
    private static TileSelection _instance;
    public static TileSelection Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindAnyObjectByType<TileSelection>();
                if(_instance == null)
                {
                    _instance = new GameObject().AddComponent<TileSelection>();
                }
            }
            return _instance;
        }
    }
    public GameObject currentPlayer;
    public event Action<GameObject,List<GameObject>> onTilesSelected;
    Touch touch;
    private Tile tile;
    public List<GameObject> selectedTiles = new List<GameObject>();
    public List<GameObject> redTiles = new List<GameObject>();
    public int cubeNumber=-1;
    public bool cubeWait = false;
    private GameObject prevGameObject;
    [SerializeField] Transform playerTransform;
    private bool selectStartFromPlayerPos;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
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
            // Simulate touch move with mouse drag
             if (Input.GetMouseButton(0))
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
        prevGameObject = null;
        foreach(var t in redTiles)
        {
            tile = t.GetComponent<Tile>();
            tile.redHighlight.SetActive(false);
        }
        if (selectedTiles.Count > 0)
        {
            currentPlayer = GameplayController.Instance.currentPlayer;
            onTilesSelected?.Invoke(currentPlayer,selectedTiles);
        }

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
                tile = hitObject.GetComponent<Tile>();
                if(tile != null)
                {
                    selectStartFromPlayerPos = playerTransform.position == tile.transform.position ? true : false;
                    prevGameObject = hitObject;
                }

            }

            tile = hitObject.GetComponent<Tile>();
            if (tile != null)
            {
                if (selectedTiles.Contains(hitObject) && prevGameObject != hitObject)
                {
                    int index = selectedTiles.FindIndex(a => a == hitObject);
                    if (selectedTiles.ElementAtOrDefault(index + 1) != null)
                    {
                        tile = selectedTiles[index + 1].GetComponent<Tile>();
                        tile.highlight.SetActive(false);
                        selectedTiles.RemoveAt(index + 1);
                    }

                }
                if (!selectedTiles.Contains(hitObject) && selectedTiles.Count <= cubeNumber && cubeNumber != 0 && selectStartFromPlayerPos && cubeWait)
                {

                    tile.highlight.SetActive(true);
                    selectedTiles.Add(hitObject);
                }
                if (!selectedTiles.Contains(hitObject) && selectedTiles.Count < cubeNumber && cubeNumber != 0 && !selectStartFromPlayerPos && cubeWait)
                {

                    tile.highlight.SetActive(true);
                    selectedTiles.Add(hitObject);
                }
                if (( selectedTiles.Count > cubeNumber && selectStartFromPlayerPos) || (selectedTiles.Count >= cubeNumber) || !cubeWait)
                {
                    tile.redHighlight.SetActive(true);
                    redTiles.Add(hitObject);
                }
                if (prevGameObject != hitObject)
                {
                    prevGameObject = hitObject;
                }
            }
            

        }
    }
}
