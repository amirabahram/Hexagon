using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CubeButton : MonoBehaviour
{
    private static CubeButton _instance;
    [SerializeField] private GameObject dice;
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
    private bool _cubeWait = false;
    public int cubeNumber = -1;
    public bool CubeWait
    {
        get { return _cubeWait; }
        set { _cubeWait = value;
            _cubeWait = value;
        }
    }

    public void GenerateRandomNumber()
    {
        //Debug.Log(cubeDone);
        //Debug.Log(playerController.moveDone);
        if (!_cubeWait)
        {
            ctextButton.gameObject.SetActive(true);
            int num = UnityEngine.Random.Range(1, 7);
            ctxt.text = num.ToString();
            _cubeWait = true;
            cubeNumber = num;
        }


    }
    public void FadeButton()
    {
        ctextButton.gameObject.SetActive(false);
    }
    public void DiceClicked()
    {
        Animator diceAnim = dice.GetComponent<Animator>();
        diceAnim.SetBool("Idle", false);

    }
}
