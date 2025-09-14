using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour {

    int rotationSpeed;

    void Start() {
        if(Random.Range(0, 2) == 0) {
            rotationSpeed = Random.Range(40, 70);
        }else {
            rotationSpeed = Random.Range(-40, -70);
        }
    }

    void Update() {
        transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);
    }
}
