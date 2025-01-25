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
        textFollowers.text = "Seguidores: "+PlayerPrefs.GetInt("followers");
        textInfluence.text = "Influencia: "+PlayerPrefs.GetFloat("influenceLevel") + "%";


        float influenceLevel = PlayerPrefs.GetFloat("influenceLevel");
        if (influenceLevel >= 100)
        {
            //SceneManager.LoadScene("Venceu");
            //return;  Garantir que o restante do código não será executado após a vitória
        }

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
    }

   
}
