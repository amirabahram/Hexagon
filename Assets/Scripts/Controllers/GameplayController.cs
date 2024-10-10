using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{

    [SerializeField] private GameObject player1Obj;
    [SerializeField] private GameObject player2Obj;
    public GameObject currentPlayer;
    [SerializeField]
    private Text coinText, lifeText, scoreText, gameoverScoreText, gameoverCoinText;
    [SerializeField]
    private GameObject pausePanel, gameOverPanel;
    [SerializeField]
    private GameObject readyButton;
    private static GameplayController _instance;
    public static GameplayController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameplayController>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameplayController>();
                }
            }
            return _instance;
        }
    }

    private void Start()
    {
        currentPlayer = player1Obj;
        player1Obj.transform.position =  Grid.Instance._tiles.FirstOrDefault().Value.transform.position;
        player2Obj.transform.position = Grid.Instance._tiles.LastOrDefault().Value.transform.position;
        Time.timeScale = 0;
    }
    public void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == player1Obj) ? player2Obj : player1Obj;
    }
    public void SetScore(int score)
    {
        scoreText.text = "x" + score;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel("MainMenu");
    }
}
