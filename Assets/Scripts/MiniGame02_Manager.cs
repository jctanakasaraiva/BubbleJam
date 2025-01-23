using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame02_Manager : MonoBehaviour {

    public enum levels { Level_1, Level_2, Level_3, Level_4, Level_5 };
    public levels Dificuldade;

    public Image barImg;
    public GameObject target;
    public GameObject bubble;
    public GameObject explosion;

    float timeMax = 1.5f;
    float timeleft;
    float levelFactor = 1f;
    bool crescendo = false;
    bool clicavel = true;

    bool taNoTarget = false;
    bool loseFlag = false;
    float scaleFactor = 1f;
    Vector2 newScale;

    private ManagerMinigames manager;

    private void Awake() {

        switch (Dificuldade) {
            case levels.Level_1:
                levelFactor = 1f;
                break;
            case levels.Level_2:
                levelFactor = 1.25f;
                break;
            case levels.Level_3:
                levelFactor = 1.5f;
                break;
            case levels.Level_4:
                levelFactor = 1.75f;
                break;
            case levels.Level_5:
                levelFactor = 2f;
                break;
            default:
                Debug.Log("Ué");
                break;
        }

        //Muda o tamanho da zona verde conforme dificuldade do level
        target.transform.localScale = new Vector2(target.transform.localScale.x / levelFactor, target.transform.localScale.y);
        explosion.SetActive(false);
    }

    void Start() {
        manager = this.gameObject.GetComponent<ManagerMinigames>();

        newScale = bubble.transform.localScale;
        timeleft = timeMax;
    }

    private void FixedUpdate() {
        if (manager.Runnig) {

            if ( !crescendo ) {
                if (timeleft > 0) {
                    timeleft -= Time.deltaTime;
                } else crescendo = true;
            }
            else if (timeleft < timeMax) {
                timeleft += Time.deltaTime;
            } else crescendo= false;

        
            scaleFactor = timeleft / timeMax;
            barImg.transform.localScale = new Vector2( scaleFactor, barImg.transform.localScale.y );

            bubble.transform.localScale = Vector2.Lerp(bubble.transform.localScale, newScale, .1f);
        }
    }

    private void Update() {
        if (manager.Runnig) {

            if (Input.GetMouseButtonDown(0)) {
                if (taNoTarget & clicavel) {
                    newScale *= 1f + scaleFactor / levelFactor;
                    clicavel = false;

                    if (newScale.x > 3) loseFlag = true;
                }
                else {
                    newScale /= 1f + scaleFactor;
                }
            }

            if (newScale.x > 15) {
                Win();
            }
            else if ((newScale.x < 3 & loseFlag) || newScale.x < 0.5f) {
                Lose();
            }
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
}
