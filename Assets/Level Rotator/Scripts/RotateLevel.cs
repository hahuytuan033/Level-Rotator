using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour {
    
    public Rigidbody rb;
    float mouseDragStartPosX = 0;
    bool start = true;
    float rot = 0;

    void Update() {
        if(Input.GetMouseButton(0)) {
            if(start) {
                Vector3 worldStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
                mouseDragStartPosX = worldStartPosition.x - rot;
                start = false;
            }
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10)); 
            rot = worldPosition.x - mouseDragStartPosX;
            transform.rotation = Quaternion.Euler(transform.rotation.x + -rot * 30, 90, 90);
        }else {
            start = true;
        }
    }
}
