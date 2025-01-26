using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostController : MonoBehaviour
{
    public TextMeshProUGUI button1;
    public TextMeshProUGUI button2;
    public TMP_Text displayText;

    int categoria1 = 0, categoria2 = 0;
    private float[,] matriz = new float[,]
       {
            { 1.0f, 0.75f, 0.5f },
            { 0.75f, 1.0f, 0.5f },
            { 0.5f, 0.75f, 1.0f }
       };

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
        (string, int) GetRandomAction()
        {
            int randomCategory = UnityEngine.Random.Range(0, 3);
            string action = "";
            int category = 0;

            switch (randomCategory)
            {
                case 0:
                    action = gravarActions[UnityEngine.Random.Range(0, gravarActions.Length)];
                    category = 0;

                    break;
                case 1:
                    action = prepararActions[UnityEngine.Random.Range(0, prepararActions.Length)];
                    category = 1;
                    break;
                case 2:
                    action = treinarActions[UnityEngine.Random.Range(0, treinarActions.Length)];
                    category = 2;
                    break;
            }
            return (action, category);
        }

        string acao1 = "", acao2 = "";
        


        (acao1, categoria1) = GetRandomAction();


        do
        {
            (acao2, categoria2) = GetRandomAction();
        } while (categoria1 == categoria2);


        //Debug.Log("Ação 1: " + acao1);
        //Debug.Log("Ação 2: " + acao2);
        button1.text = acao1;
        button2.text = acao2;

    }

    public void getCategoryOne()
    {
        PlayerPrefs.SetFloat("multiply", matriz[PlayerPrefs.GetInt("Niche"), categoria1]);
        //Debug.Log("Multiplicador: " + matriz[PlayerPrefs.GetInt("Niche"), categoria1]);
        PlayerPrefs.Save();

    }
    public void getCategoryTwo()
    {
        PlayerPrefs.SetFloat("multiply", matriz[PlayerPrefs.GetInt("Niche"), categoria2]);
        //Debug.Log("Multiplicador: " + matriz[PlayerPrefs.GetInt("Niche"), categoria2]);
        PlayerPrefs.Save();
    }
    
    public void GetCalculatedInfluence()
     {
        /*
        string lastButtonClicked = PlayerPrefs.GetString("NichePlayer", "Nenhum botão foi clicado");
        displayText.text = "Seu nicho é: " + lastButtonClicked;
        Debug.Log("Categoria 1:: " + categoria1);
        Debug.Log("Categoria 2: " + categoria2);
        Debug.Log("Nome Nicho: " + PlayerPrefs.GetString("NicheName"));
        Debug.Log("Nicho PLayer: " + PlayerPrefs.GetInt("Niche"));
        Debug.Log("Ação 1: " + PlayerPrefs.GetInt("contLifes"));
        Debug.Log("Ação 1: " + PlayerPrefs.GetInt("influenceLevel"));
        Debug.Log("Ação 1: " + PlayerPrefs.GetInt("followers"));
        */
    }
    

}
