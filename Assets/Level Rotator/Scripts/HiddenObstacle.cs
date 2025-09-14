using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObstacle : MonoBehaviour {

    private bool startScaling = false;
    private float timer = 0;

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.name == "Ball") {
            startScaling = true;
        }
    }

    void Update() {
        
        if(startScaling) {
            timer += Time.deltaTime;
            if(timer >= 0.01f) {
                timer = 0;
                Transform pt = transform.parent;
                if(pt.localScale.x < 1) {
                pt.localScale = new Vector3(pt.localScale.x + 0.02f + Time.deltaTime, pt.localScale.x + 0.02f * Time.deltaTime, pt.localScale.z);
                }else {
                    Destroy(this.gameObject);
                }
            }
            
        }
    }
}
