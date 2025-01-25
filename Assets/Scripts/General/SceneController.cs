using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
      
    public void ChoosePostScene(string buttonName)
    {
        PlayerPrefs.SetString("NicheName", buttonName);
        switch (buttonName)
        {
            case "Gamer":
                PlayerPrefs.SetInt("Niche", 0);
                break;
            case "Culinaria":
                PlayerPrefs.SetInt("Niche", 1);
                break;
            case "Fitness":
                PlayerPrefs.SetInt("Niche", 2);
                break;
        }
       
        PlayerPrefs.SetInt("contLifes", 0);
        PlayerPrefs.SetInt("influenceLevel", 0);
        PlayerPrefs.SetInt("followers", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("ChoosePost");
    }
    public void LoadMinigame()
    {   
        switch (Random.Range(0, 3)) {
            case 0:
                SceneManager.LoadScene("MiniGame01");
            break;
            case 1:
                SceneManager.LoadScene("MiniGame02");
                break;
            case 2:
                SceneManager.LoadScene("MiniGame03");
                break;
        }
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
