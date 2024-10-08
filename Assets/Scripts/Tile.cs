using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{
    public event Action<Vector3> onTileClicked;
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private GameObject highlight;
    //[SerializeField] private float hexHieght = 2f;
    //[SerializeField] private float hexWidth = 1.7f;
    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
    private void OnMouseDown()
    {
        onTileClicked?.Invoke(new Vector3(transform.position.x,transform.position.y,0));
    }
    public void Init(bool isOffset)
    {
        render.color = isOffset ? _offsetColor : _baseColor; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
