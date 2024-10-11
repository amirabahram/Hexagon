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
    [SerializeField] private Button diceButton;
    [SerializeField] private GameObject diceAnimation;
    [SerializeField] private Sprite[] diceNumbers;
    private bool _cubeWait = false;
    public int cubeNumber = -1;
    public bool CubeWait
    {
        get { return _cubeWait; }
        set { _cubeWait = value;
            _cubeWait = value;
        }
    }
    private Animator anim;
    private void Start()
    {
        anim = diceAnimation.GetComponent<Animator>();

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
            DiceClicked();
        }


    }
    public void FadeButton()
    {
        ctextButton.gameObject.SetActive(false);
    }
    public void DiceClicked()
    {
        anim.SetBool("Idle", false);
        StartCoroutine(SetIcon());

    }
    IEnumerator SetIcon()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("Idle", true);
        switch (cubeNumber)
        {
            case 1:
                anim.SetInteger(1, 1);
                break;
            case 2:
                anim.SetInteger(2, 2);
                break;
            case 3:
                anim.SetInteger(3, 3);
                break;
            case 4:
                anim.SetInteger(4, 4);
                break;
            case 5:
                anim.SetInteger(5, 5);
                break;
            case 6:
                anim.SetInteger(6, 6);
                break;
        }
    }
}
