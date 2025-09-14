using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressIndicator : MonoBehaviour
{
    public GameObject ball;
    public GameObject finish;
    public Slider slider;

    void Start() {
        Init();
    }

    public void Init() {
         ball = GameObject.Find("Ball");
         finish = GameObject.Find("Finish");
         slider.maxValue = finish.transform.position.z;
    }

    void Update() {
        if(ball != null) {
            slider.value = ball.transform.position.z;
        }else {
            ball = GameObject.Find("Ball");
        }
    }
}
