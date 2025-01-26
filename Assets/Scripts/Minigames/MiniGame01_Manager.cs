using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame01_Manager : MonoBehaviour {

    public enum levels { Level_1, Level_2, Level_3, Level_4, Level_5 };
    public levels Dificuldade;

    public GameObject[] spawnPoints;
    public GameObject bubble;

    public GameObject plataforma;

    float bForca;
    ArrayList bubblesList;

    private ManagerMinigames manager;
    public int countTouch = 0;

    private void Awake() {
        bubblesList = new ArrayList();

        switch (Dificuldade) {
            case levels.Level_1:
                SpawnBubble(spawnPoints[0].transform, 0.75f);
                bForca = 15f;
                break;
            case levels.Level_2:
                SpawnBubble(spawnPoints[0].transform, 1f);
                bForca = 13f;
                break;
            case levels.Level_3:
                SpawnBubble(spawnPoints[1].transform, 0.45f);
                SpawnBubble(spawnPoints[2].transform, 0.5f);
                bForca = 15f;
                break;
            case levels.Level_4:
                SpawnBubble(spawnPoints[1].transform, 0.45f);
                SpawnBubble(spawnPoints[2].transform, 0.5f);
                plataforma.transform.localScale = new Vector2 ( 1f, plataforma.transform.localScale.y);
                bForca = 10f;
                break;
            case levels.Level_5:
                SpawnBubble(spawnPoints[0].transform, 0.75f);
                SpawnBubble(spawnPoints[1].transform, 0.45f);
                SpawnBubble(spawnPoints[2].transform, 0.5f);
                plataforma.transform.localScale = new Vector2(1f, plataforma.transform.localScale.y);
                bForca = 12f;
                break;
            default:
                Debug.Log("Ué");
                break;
        }
    }

    private void Start() {
        manager = this.gameObject.GetComponent<ManagerMinigames>();
    }

    void Update() {
        if (manager.Running) {

            float newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            newPosition = Mathf.Clamp(newPosition, -Screen.height, Screen.height);
            plataforma.transform.position = new Vector2(newPosition, plataforma.transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Bolha")) {
            Vector2 newDirection = col.transform.position - transform.position;
            newDirection = newDirection.normalized;
            newDirection = new Vector2(newDirection.x*2, newDirection.y);
            Rigidbody2D rbBubble = col.GetComponent<Rigidbody2D>();
            rbBubble.AddForce(newDirection * bForca);
            
            countTouch++;

            AudioFXController.Instance.CollisionSound();
        }

        if(countTouch >= 4) {
            Win();
        }
    }

    void SpawnBubble(Transform posT, float gS) {
        GameObject _bubble = Instantiate(bubble, posT) as GameObject;
        _bubble.GetComponent<Rigidbody2D>().gravityScale = gS;
        bubblesList.Add(_bubble);
    }

    void Win() {
        Debug.Log("Venceu!");
        foreach (GameObject b in bubblesList) {
            b.SetActive(false);
        }
        manager.Win();
    }
}
