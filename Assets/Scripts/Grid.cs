using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
//using static System.IO.Enumeration.FileSystemEnumerable<TResult>;

public class Grid : MonoBehaviour
{
    //public Transform hexPrefab;
    //public GameObject hexPrefabb;
    //Camera maincamera = GameObject.FindWithTag("Camera").GetComponent<Camera>();
    //Canvas mainCanvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
    public int gridWidth = 10;
    public int gridLength = 10;
    float hexWidth = 1.7f;
    float hexHieght = 2.0f;
    public float gap = 0.0f;
    Dictionary<Vector2, Tile> _tiles = new Dictionary<Vector2, Tile>();
    [SerializeField] private Transform cam;
    [SerializeField] private Tile hexPrefabb;

    Vector3 startPos;
    void SetWidthandHieght()
    {
        hexHieght = transform.localScale.y;
        hexWidth = transform.localScale.x;
    }
    void Start()
    {
        SetWidthandHieght();
        AddGap();
        calcStartPos();
        CreateGrid();
    }
    void AddGap()
    {
        hexHieght += hexHieght * gap;
        hexWidth += hexWidth*gap;
    }
    void calcStartPos()
    {
        float offset = 0;
        if(gridLength / 2 % 2 != 0)
        {
            offset = hexWidth / 2;
        }
        float x = -hexWidth * (gridWidth / 2) - offset;
        float z = hexHieght * 0.75f * (gridLength / 2);
        startPos = new Vector3(x, 0,z);
    }
    Vector3 calcWorldPos(Vector2 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;
        float x = startPos.x + gridPos.x * hexWidth + offset;
        float y = startPos.y - gridPos.y * hexHieght * 0.75f;
        return new Vector3(x, y, 0);
    }
    void CreateGrid()
    {
        //var canvasTransform = mainCanvas.GetComponent<RectTransform>();
        //float minX = canvasTransform.position.x + canvasTransform.rect.xMin;
        //float maxY = canvasTransform.position.y + canvasTransform.rect.yMax;
        //float z = canvasTransform.position.z;

        //Vector3 topLeft = new Vector3(minX, maxY, z);
        bool isOffset;
        for (int y = 0; y < gridLength; y++)
        {
            for(int x = 0; x < gridWidth; x++)
            {
                float offset = 0;
                if (x % 2 != 0)
                {
                    offset = hexPrefabb.transform.localScale.y / 2;
                }
                float xx = transform.position.x + x * hexWidth;
                float yy =transform.position.y - y * hexHieght+offset;
                Tile hex = Instantiate(hexPrefabb,new Vector3(xx,yy,0),Quaternion.identity) as Tile;
                //Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridPos = new Vector2(x, y);
                //hex.position = calcWorldPos(gridPos);
                //hex.parent = this.transform;
                hex.name = "Hexagon" + x + "|" + y;

                isOffset = (x % 2 == 0 && y % 2 != 0);
                hex.Init(isOffset);
                _tiles[new Vector2(x, y)] = hex;

            }
        }
        cam.transform.position = new Vector3(gridWidth / 2 * hexWidth, -1 * gridLength / 2 * hexHieght,-10);
    }
   public Tile GetTileAtPosition(Vector2 v)
    {
        if(_tiles.TryGetValue(v,out var t))
        {
            return t;
        }
        return null;
    }
    void Update()
    {
        
    }
}
