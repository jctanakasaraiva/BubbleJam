using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;

public class MiniGame03_Manager : MonoBehaviour {

    public enum levels { Level_1, Level_2, Level_3, Level_4, Level_5 };
    public levels Dificuldade;

    public GameObject bubble;
    public GameObject espetos;
    public GameObject espetosSpawn;

    public float bForce = 5f;
    public float velocity = 5f;
    public float timeSpawn = 3f;
    public int count = 7;

    float levelFactor = 1f;
    float currentTime;
    ArrayList espetosList;

    public TextMeshProUGUI disclaimerText;

    private ManagerMinigames manager;

    private void Awake() {

        switch (Dificuldade) {
            case levels.Level_1:
                levelFactor = 1f;
                break;
            case levels.Level_2:
                levelFactor = 1.5f;
                break;
            case levels.Level_3:
                levelFactor = 2f;
                break;
            case levels.Level_4:
                levelFactor = 2.5f;
                break;
            case levels.Level_5:
                levelFactor = 3f;
                break;
            default:
                Debug.Log("Ué");
                break;
        }

        disclaimerText.text = "Clique com o mouse para mover a bolha para cima e evite " + count + " espinhos para ganhar!";
    }

    private void Start() {
        manager = this.gameObject.GetComponent<ManagerMinigames>();

        espetosList = new ArrayList();
        count = (int)(count * levelFactor);
    }

    private void Update() {
        if (manager.Running) {
            //Conta os espetos spawnados
            if (count > 0) {
                //Condicional de tempo
                if (currentTime <= 0f) {
                    //Spawn os espetos
                    var y = Random.Range(-2, 2);
                    var spawnTransform = new Vector3(espetosSpawn.transform.position.x, y, 0);
                    espetosList.Add(Instantiate(espetos, spawnTransform, Quaternion.identity) as GameObject);
                    currentTime = timeSpawn;
                    count--;
                }
            }
            else Win();

            //Move a bolha para cima ao clicar
            if (Input.GetMouseButtonDown(0)) {
                bubble.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bForce);
                AudioFXController.Instance.CollisionSound();
            }

            //Adiciona velocidade aos espetos
            foreach (GameObject e in espetosList) {
                e.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocity, 0f);
            }

            currentTime -= Time.deltaTime;
        } else
            foreach (GameObject e in espetosList) {
                //Pára os espetos se o jogo não estiver rodando
                e.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            }
    }

    void Win() {
        Debug.Log("Venceu!");
        bubble.SetActive(false);
        manager.Win();
    }
}
