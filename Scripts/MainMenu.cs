using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainPanel;
    public GameObject shopPanel;
    public GameObject settingsPanel;

    public GameObject resetButton;
    public GameObject noButton;
    public GameObject yesButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void settingsMenu()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void ShopMenu()
    {
        mainPanel.SetActive(false);
        shopPanel.SetActive(true);
    }
    public void BackToMain()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
    }
    public void ResetButton()
    {
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }
    public void NoButton()
    {
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
