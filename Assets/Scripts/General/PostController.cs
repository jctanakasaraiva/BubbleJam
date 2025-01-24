using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostController : MonoBehaviour
{
    public TextMeshProUGUI button1;
    public TextMeshProUGUI button2;
    public TMP_Text displayText;
    void Start()
    {
        string[] gravarActions = {
            "Gravar game play Arcade",
            "Gravar game play Corrida",
            "Gravar game play Puzzle",
            "Gravar game play Terror",
            "Gravar game play RPG",
            "Gravar game play FPS",
            "Gravar game play RTS",
            "Gravar game play Moba",
            "Gravar game play Visual Novel",
            "Gravar game play Plataforma"
        };
        string[] prepararActions = {
            "Preparar Bolo",
            "Preparar Feijoada",
            "Preparar pizza",
            "Preparar Macarronada",
            "Preparar Lasanha",
            "Preparar Hamburger",
            "Preparar Cachorro Quente",
            "Preparar Salada",
            "Preparar Pudin",
            "Preparar Sushi"
        };
        string[] treinarActions = {
            "Treinar Aerobico",
            "Treinar Cardio",
            "Treinar Prancha",
            "Treinar Supino",
            "Treinar agachamento",
            "Treinar Levantamento Terra",
            "Treinar Remada Curvada",
            "Treinar Abdominais",
            "Treinar Flexão de braços",
            "Treinar Rosca Direta"
        };
        (string, string) GetRandomAction()
        {
            int randomCategory = UnityEngine.Random.Range(0, 3);
            string action = "";
            string category = "";

            switch (randomCategory)
            {
                case 0:
                    action = gravarActions[UnityEngine.Random.Range(0, gravarActions.Length)];
                    category = "Gravar";
                    break;
                case 1:
                    action = prepararActions[UnityEngine.Random.Range(0, prepararActions.Length)];
                    category = "Preparar";
                    break;
                case 2:
                    action = treinarActions[UnityEngine.Random.Range(0, treinarActions.Length)];
                    category = "Treinar";
                    break;
            }
            return (action, category);
        }

        string acao1 = "", acao2 = "";
        string categoria1 = "", categoria2 = "";


        (acao1, categoria1) = GetRandomAction();


        do
        {
            (acao2, categoria2) = GetRandomAction();
        } while (categoria1 == categoria2);


        //Debug.Log("Ação 1: " + acao1);
        //Debug.Log("Ação 2: " + acao2);
        button1.text = acao1;
        button2.text = acao2;
        GetCalculatedInfluence();
    }

    
    public void GetCalculatedInfluence()
     {
        string lastButtonClicked = PlayerPrefs.GetString("NichePlayer", "Nenhum botão foi clicado");
        displayText.text = "Seu nicho é: " + lastButtonClicked;
        switch (lastButtonClicked)
        {
            case "Gamer":
                displayText.text = "Case gamer " + lastButtonClicked;
                break;
            case "Culinaria":
                break;
            case "Fitness":
                break;
        }
    }
    
}
