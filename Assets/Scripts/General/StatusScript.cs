using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatusScript : MonoBehaviour
{
    public TextMeshProUGUI textFollowers;
    public TextMeshProUGUI textInfluence;
    public GameObject sizeBubble;
    void Awake()
    {
        textFollowers.text = "Seguidores: " + PlayerPrefs.GetInt("followers");
        textInfluence.text = "Influencia: " + PlayerPrefs.GetFloat("influenceLevel") + "%";

        float influenceLevel = PlayerPrefs.GetFloat("influenceLevel");

 
        float size = 2f;
        if (influenceLevel >= 80)
        {
            size = 9f; // Tamanho máximo
        }
        else if (influenceLevel >= 60)
        {
            size = 6f;
        }
        else if (influenceLevel >= 40)
        {
            size = 4f;
        }
        else if (influenceLevel >= 20)
        {
            size = 3f;
        }
        sizeBubble.transform.localScale = new Vector3(size, size, size);

        Debug.Log("InfluenceLevel: " + influenceLevel);  // Verifique se o valor é 85 aqui

        if (influenceLevel >= 30)
        {
            SceneManager.LoadScene("Congrats");
            return;
        }
    }
}
