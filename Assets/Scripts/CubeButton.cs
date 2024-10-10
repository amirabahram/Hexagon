using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CubeButton : MonoBehaviour
{
    private static CubeButton _instance;
    public static CubeButton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<CubeButton>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<CubeButton>();
                }
            }
            return _instance;
        }
    }
    [SerializeField] private TMP_Text ctxt;
    [SerializeField] private Button ctextButton;
    [SerializeField] private GameObject plyrCtrl;
    [SerializeField] private GameObject tileSelectionObj;
    // Start is called before the first frame update
    private PlayerController playerController;
    private TileSelection tileSelection;
    private bool cubeWait = false;
    public bool CubeWait
    {
        get { return cubeWait; }
        set { cubeWait = value;
            tileSelection.cubeWait = value;
        }
    }
    void Start()
    {
        playerController = plyrCtrl.GetComponent<PlayerController>();
        tileSelection = tileSelectionObj.GetComponent<TileSelection>();
    }

    
    public void GenerateRandomNumber()
    {
        //Debug.Log(cubeDone);
        //Debug.Log(playerController.moveDone);
        if (!cubeWait)
        {
            ctextButton.gameObject.SetActive(true);
            int num = UnityEngine.Random.Range(1, 6);
            ctxt.text = num.ToString();
            cubeWait = true;
            playerController.cubeNumber = num;
            tileSelection.cubeNumber = num;
            tileSelection.cubeWait = true;
        }


    }
    public void FadeButton()
    {
        ctextButton.gameObject.SetActive(false);
    }
}
