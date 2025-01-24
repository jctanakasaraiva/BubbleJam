using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("ChooseNiche");
        //Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ChoosePostScene(string buttonName)
    {
        PlayerPrefs.SetString("NichePlayer", buttonName);
        PlayerPrefs.Save();
        SceneManager.LoadScene("ChoosePost");
    }
    public void LoadMinigame()
    {
        SceneManager.LoadScene("MiniGame01");
    }
    public void LoadStatusScene()
    {
        SceneManager.LoadScene("Status");
    }
    public void LoadPostScene()
    {
        SceneManager.LoadScene("ChoosePost");
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
