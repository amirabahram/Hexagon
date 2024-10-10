using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer render;
    [SerializeField] public GameObject highlight;
    [SerializeField] public GameObject redHighlight;
    
    //[SerializeField] private float hexHieght = 2f;
    //[SerializeField] private float hexWidth = 1.7f;

    public void Init(bool isOffset)
    {
        render.color = isOffset ? _offsetColor : _baseColor; 
    }



}
