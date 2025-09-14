using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float[] speed = {5, 5.5f, 6, 7, 7, 7.5f, 7.5f, 7.5f, 8, 8, 8, 8, 8, 9, 9, 9, 10, 11, 11, 12, 13, 14, 15, 15, 16, 16, 16, 15, 17};//Ball movement speed in every level (speed[0] is the speed in level 1...)
    private float currentSpeed;
    public Rigidbody rb;
    public GameObject explosionParticle;

    void Start() {
        currentSpeed = speed[PlayerPrefs.GetInt("currentLevel")];
    }

    void FixedUpdate() {
        rb.MovePosition(transform.position + transform.forward * currentSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision col) {
        if(transform.Find("Main Camera") != null) {
            transform.Find("Main Camera").transform.parent = null;
        }
        explosionParticle.transform.parent = null;
        explosionParticle.SetActive(true);
        GameObject.Find("GameManager").GetComponent<Menus> ().GameOver();
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.name == "HiddenObstacleTrigger") return;
        GetComponent<PlayerMovement> ().enabled = false;
        Destroy(GameObject.Find("Trails"), 2f);
        GameObject.Find("GameManager").GetComponent<Menus> ().LevelCompleted();
    }
}
