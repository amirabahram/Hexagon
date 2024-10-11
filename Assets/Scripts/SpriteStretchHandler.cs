using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteStretchHandler : MonoBehaviour
{
    public bool isAspectRatio;

    // Start is called before the first frame update
    void Start()
    {
        var topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        var worldSpaceWidth = topRightCorner.x * 2;
        var worldSpaceHieght = topRightCorner.y * 2;
        var spriteSize = GetComponent<SpriteRenderer>().bounds.size;
        var scaleFactorX = worldSpaceWidth / spriteSize.x;
        var scaleFactorY = worldSpaceHieght / spriteSize.y;
        if (isAspectRatio)
        {
            if (scaleFactorX > scaleFactorY)
            {
                scaleFactorY = scaleFactorX;
            }
            else
            {
                scaleFactorX = scaleFactorY;
            }
            transform.localScale = new Vector3(scaleFactorX, -scaleFactorY, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
