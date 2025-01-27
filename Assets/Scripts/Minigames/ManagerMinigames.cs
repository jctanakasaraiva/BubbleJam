using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMinigames : MonoBehaviour {


    public GameObject disclaimer;
    public GameObject winScr;
    public GameObject loseScr;
    public GameObject pauseScr;

    private bool running = false;

    private void Awake() {
        Time.timeScale = 0f;
    }

    private void Start() {
        winScr.SetActive(false);
        loseScr.SetActive(false);
        disclaimer.SetActive(true);
        pauseScr.SetActive(false);
    }

    private void Update() {
        if ( (Input.GetKeyDown(KeyCode.P) | Input.GetKeyDown(KeyCode.Escape)) & Running )
            Pause();
    }

    public bool Running {
        get { return running; }
        set { running = value; }
    }

    public void Play() {
        pauseScr.SetActive(false);
        disclaimer.SetActive(false);
        running = true;
        Time.timeScale = 1f;
    }

    public void Win() {
        if (running) {
            running = false;
            winScr.SetActive(true);
        }
    }

    public void Lose() {
        if (running) {
            running = false;
            loseScr.SetActive(true);

            AudioFXController.Instance.DeathSound();
        }
    }

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void Pause() {
        Time.timeScale = 0f;
        running = false;
        pauseScr.SetActive(true);
    }

    public void WinContinue() {
        int newNumberInfluence = Mathf.RoundToInt(20 * PlayerPrefs.GetFloat("multiply"));
        PlayerPrefs.SetFloat("influenceLevel", PlayerPrefs.GetFloat("influenceLevel") + newNumberInfluence);
        int newNumber = Mathf.RoundToInt(30 * PlayerPrefs.GetFloat("multiply"));
        PlayerPrefs.SetInt("followers", PlayerPrefs.GetInt("followers") + newNumber);
        PlayerPrefs.Save();

        if (PlayerPrefs.GetFloat("influenceLevel") < 0 || PlayerPrefs.GetInt("followers") < 0) {
            SceneManager.LoadScene("GameOver");
        } else { //if(PlayerPrefs.GetFloat("influenceLevel") > 100) {
            SceneManager.LoadScene("Status");
            //vencer
        }
    }

    public void LoseContinue() {
        PlayerPrefs.SetInt("contLifes", PlayerPrefs.GetInt("contLifes") + 1);

        PlayerPrefs.SetInt("followers", PlayerPrefs.GetInt("followers") - 10);
        PlayerPrefs.SetFloat("influenceLevel", PlayerPrefs.GetFloat("influenceLevel") - 5);
        PlayerPrefs.Save();

        if (PlayerPrefs.GetInt("contLifes") > 2) {
            SceneManager.LoadScene("GameOver");

            if (PlayerPrefs.GetFloat("influenceLevel") < 0 || PlayerPrefs.GetInt("followers") < 0)
                SceneManager.LoadScene("GameOver");

        } else SceneManager.LoadScene("Status");
    }
}
