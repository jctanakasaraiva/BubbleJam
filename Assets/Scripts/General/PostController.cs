using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostController : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public TMP_Text displayText;
    void Start(){

        string lastButtonClicked = PlayerPrefs.GetString("NichePlayer", "Nenhum botão foi clicado");
        displayText.text = "Seu nicho é: " + lastButtonClicked;
        /*
        string[] options = { "Option 1", "Option 2", "Option 3", "Option 4", "Option 5" };

        int randomIndex1 = Random.Range(0, options.Length);
        int randomIndex2;

        do
        {
            randomIndex2 = Random.Range(0, options.Length);
        } while (randomIndex2 == randomIndex1);

        button1.GetComponentInChildren<Text>().text = options[randomIndex1];
        button2.GetComponentInChildren<Text>().text = options[randomIndex2];
        */
    }
}
