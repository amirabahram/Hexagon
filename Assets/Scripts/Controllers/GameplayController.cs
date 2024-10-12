using JetBrains.Annotations;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{

    [SerializeField] private GameObject player1Obj;
    [SerializeField] private GameObject player2Obj;
    [SerializeField] private GameObject readyPanel;
    public GameObject currentPlayer;
    [SerializeField]
    private Text scoreText, lifeText, turnText, gameoverScoreText, gameoverCoinText;
    [SerializeField] private Image turnImage;
    [SerializeField]
    private GameObject pausePanel, gameOverPanel;
    [SerializeField] private GameObject readyButton;
    public int player1Score;
    public int player2Score;
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
        turnText.text = "Turn: Player1";
        currentPlayer = player1Obj;
        player1Obj.transform.position =  Grid.Instance._tiles.FirstOrDefault().Value.transform.position;
        player2Obj.transform.position = Grid.Instance._tiles.LastOrDefault().Value.transform.position;
        TileSelection.Instance.onPlayerLost += PlayerLost;

        Time.timeScale = 0;
    }
    void PlayerLost(GameObject loser)
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gameoverScoreText.text = (player1Score > player2Score) ? "Player1 Wins!" + "Score: " + player1Score : "Player2 Wins!" + "Score: " + player2Score;
    }
    public void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == player1Obj) ? player2Obj : player1Obj;
        turnText.text = (currentPlayer == player1Obj) ? "Turn: Player1" : "Turn: Player2";

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
        Time.timeScale = 0;
        Application.LoadLevel("Main");
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        readyButton.SetActive(false);
        readyPanel.SetActive(false);

    }
    public void StartFromScratch()
    {
        Time.timeScale = 0;
        readyButton.SetActive(true);
        readyPanel.SetActive(true);
        pausePanel.SetActive(false);
        player1Score = 0;
        player2Score = 0;
        Application.LoadLevel("Gameplay");
    }
    public void UpdatePlayerScore(int playerIndex)
    {
        if (playerIndex == 1)
        {
            player1Score++;
            scoreText.text = "Player1: " + player1Score+ "   Player2: " + player2Score;
            return;
        }
        player2Score++;
        scoreText.text = "Player1: " + player1Score + "   Player2: " + player2Score;
    }
}
