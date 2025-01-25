using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogScript : MonoBehaviour
{
    [Header("Lines")]
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed = 0.07f;
    private int indexLines;
    public GameObject canvasStart;

    void Start()

    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[indexLines])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[indexLines];
            }
        }
    }
    void StartDialogue()
    {
        indexLines = 0;
        StartCoroutine(writeLine());
    }
    IEnumerator writeLine()
    {
        foreach (char letter in lines[indexLines])
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return null;
    }
    void NextLine()
    {
        if (indexLines < lines.Length - 1)
        {
            indexLines++;
            textComponent.text = string.Empty;
            StartCoroutine(writeLine());
        }
        else
        {
            //gameObject.SetActive(false);
            SceneManager.LoadScene("ChooseNiche");
        }
    }
    public void startGame()
    {
        canvasStart.SetActive(false);
        gameObject.SetActive(true);
    }
}
