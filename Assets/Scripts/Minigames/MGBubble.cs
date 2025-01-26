using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class MGBubble : MonoBehaviour {

    private ManagerMinigames manager;

    private void Start() {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerMinigames>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        //Condição de derrota
        if (col.gameObject.CompareTag("Espinho")) {
            Perdeu();
        }
    }

    void Perdeu() {
        manager.GetComponent<ManagerMinigames>().Lose();
        Destroy(this.gameObject);
    }
}
