using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    //public Animator animator;
    [SerializeField] GameObject gridObj;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject tileSelectionObj;
    private Grid grid;
    private CubeButton cubeButton;
    private TileSelection tileSelection;
    private Tile selectedTile;
    private bool moveDone = true;
    public int cubeNumber =-1;
    private bool corutineStart = true;
    private bool playerIsMoving = false;
    public bool MoveDone
    {
        get { return moveDone; }
         private set { moveDone = value; }
    }
    private void Awake()
    {
        
    }
    void Start()
    {
        cubeButton = cube.GetComponent<CubeButton>();
        grid = gridObj.GetComponent<Grid>();
        tileSelection = tileSelectionObj.GetComponent<TileSelection>();
        tileSelection.onTilesSelected += movePlayer;
        foreach(var i in grid._tiles)
        {
            i.Value.onTileClicked += movePlayer;
        }
    }

    public void movePlayer(Vector3 v)
    {
        if (cubeButton.CubeWait)
        {
            transform.position = v;
            cubeButton.CubeWait = false;
        }
    }
    public void movePlayer(List<GameObject> tiles)
    {
        if (tiles.Count > 0 && cubeButton.CubeWait)
        {
            float playerAndFirstTileDistance = Vector3.Distance(tiles[0].transform.position,transform.position);
            if (playerAndFirstTileDistance <2 && !playerIsMoving) ///// This Should Be Corrected................
            {
                corutineStart = true;
                StartCoroutine(MoveToTiles(tiles));
            }
        }
        if (!corutineStart)
        {
            foreach (var t in tiles)
            {
                selectedTile = t.GetComponent<Tile>();
                selectedTile.highlight.SetActive(false);
            }
            tiles.Clear();
        }


    }
    private IEnumerator MoveToTiles(List<GameObject> tiles)
    {
        int posibbleMoves = Math.Min(tiles.Count, cubeNumber);
        if (cubeNumber == 0)
        {
            posibbleMoves = -1;
        }

        for(int i=0;i<= posibbleMoves; i++)
        {
            // animator.SetBool("isMoving", true);

            // Move the player to the tile's position
            if (tiles.ElementAtOrDefault(i) != null)
            {
                playerIsMoving = true;
                selectedTile = tiles[i].GetComponent<Tile>();
                selectedTile.highlight.SetActive(false);


                Vector3 startPosition = transform.position;
                Vector3 targetPosition = tiles[i].transform.position;

                float journeyLength = Vector3.Distance(startPosition, targetPosition);
                float startTime = Time.time;

                while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
                {
                    // Calculate the fraction of journey completed
                    float distCovered = (Time.time - startTime) * moveSpeed;
                    float fractionOfJourney = distCovered / journeyLength;
                    fractionOfJourney = Mathf.Clamp01(fractionOfJourney);
                    transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
                    if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
                    {
                        transform.position = targetPosition;
                        break;
                    }
                    yield return null; // Wait for the next frame
                }

                // Ensure the player reaches the exact target position
                transform.position = targetPosition;
            }
        }
        corutineStart = false;
        playerIsMoving = false;
        cubeButton.CubeWait = false;
        tiles.Clear();

        //animator.SetBool("isMoving", false);
    }
}
