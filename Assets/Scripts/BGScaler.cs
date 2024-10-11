using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var hieght = Camera.main.orthographicSize;
        var width = hieght * Screen.width / Screen.height;
 
        transform.localScale = new Vector3(width, hieght, -1);

    }

    
}
