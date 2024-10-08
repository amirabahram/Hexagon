using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeButton : MonoBehaviour
{
    [SerializeField] private TMP_Text ctxt;
    [SerializeField] private Button ctextButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateRandomNumber()
    {
        ctextButton.gameObject.SetActive(true);
        int num = Random.Range(1, 6);
        ctxt.text = num.ToString();

    }
    public void FadeButton()
    {
        ctextButton.gameObject.SetActive(false);
    }
}
