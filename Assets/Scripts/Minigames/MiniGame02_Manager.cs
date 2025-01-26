using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame02_Manager : MonoBehaviour {

    public enum levels { Level_1, Level_2, Level_3, Level_4, Level_5 };
    public levels Dificuldade;

    public Transform pointA;
    public Transform pointB;
    private float soapSpeed = 5f;

    public GameObject target;
    public GameObject bubble;
    public GameObject explosion;
    public GameObject mouse;

    public ParticleSystem explosionParticle;

    float levelFactor = 1f;
    bool clicavel = true;

    bool taNoTarget = false;
    bool loseFlag = false;
    Vector2 newScale;

    private Vector3 nextPosition;

    private ManagerMinigames manager;

    public AudioSource bubblesSound;
    public AudioClip clip;

    private void Awake() {

        switch (Dificuldade) {
            case levels.Level_1:
                levelFactor = 2.25f;
                break;
            case levels.Level_2:
                levelFactor = 2f;
                break;
            case levels.Level_3:
                levelFactor = 1.75f;
                break;
            case levels.Level_4:
                levelFactor = 1.5f;
                break;
            case levels.Level_5:
                levelFactor = 1.25f;
                break;
            default:
                Debug.Log("Ué");
                break;
        }

        //Muda o tamanho do target conforme dificuldade do level
        target.transform.localScale = new Vector2(target.transform.localScale.x / (2/levelFactor), target.transform.localScale.y);
        explosion.SetActive(false);
    }

    void Start() {
        manager = this.gameObject.GetComponent<ManagerMinigames>();

        newScale = bubble.transform.localScale;
        nextPosition = pointB.position;
        soapSpeed *= 2 / levelFactor;
    }

    private void Update() {
        if (manager.Runnig) {

            if (Input.GetMouseButtonDown(0)) {
                if (taNoTarget) {
                    if (clicavel) {
                        newScale *= 1 + 1/levelFactor;
                        clicavel = false;

                        if (newScale.x > 3) loseFlag = true;
                        BubbleSpawn();
                        bubblesSound.PlayOneShot(clip, 1f);
                    }
                }
                else {
                    newScale /= 1 + 1/levelFactor;

                }
            }

            if (newScale.x > 15) {
                Win();
            }
            else if ((newScale.x < 3 & loseFlag) || newScale.x < 0.5f) {
                Lose();
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPosition, soapSpeed * Time.deltaTime);
            if(new Vector2(transform.position.x, transform.position.y) == new Vector2(nextPosition.x, nextPosition.y) ) {
                nextPosition = (nextPosition.x == pointA.position.x) ? pointB.position : pointA.position;
            }

            //Escala a bolha
            bubble.transform.localScale = Vector2.Lerp(bubble.transform.localScale, newScale, .1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == target.name) {
            taNoTarget = true;
            clicavel = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name == target.name) {
            taNoTarget = false;
        }
    }

    void Win() {
        Debug.Log("Venceu!");
        bubble.SetActive(false);
        explosion.SetActive(true);

        manager.Win();
    }

    void Lose() {
        Debug.Log("Perdeu!");
        manager.Lose();
    }

    private void BubbleSpawn()
    {
        explosion.SetActive(true);
        explosionParticle.Play();
    }
}
