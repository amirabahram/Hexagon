using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject settingPanel;
    public GameObject mainButtons;

    public void OnStartClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
    public void OnSettingClicked(bool status)
    {
        settingPanel.SetActive(status);
    }

    public void HideCredits()
    {
        ActiveMainButtons(true);
        creditsPanel.SetActive(false);
    }

    public void ShowCredit()
    {
        ActiveMainButtons(false);
        Invoke(nameof(CreditsDetailsMoveDown), 0f);
    }

    public void CreditsDetailsMoveDown()
    {
        creditsPanel.SetActive(true);
    }

    public void ActiveMainButtons(bool status)
    {
        mainButtons.SetActive(status);
    }
}
