using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTransitionAnimation : MonoBehaviour {

    public Image image;
    private bool up = true;
    private float timer = 0;
    private float alpha = 0;

    void Update() {
        timer += Time.deltaTime;
        if(timer >= 0.01f) {
            if(up) {
                alpha += 0.01f;
                if(alpha >= 1f) {
                    up = false;
                    
                    if(GameObject.Find("Main Camera") != null) {
                        Destroy(GameObject.Find("Main Camera"));
                    }

                    if(GameObject.Find("Explosion") != null) {
                        Destroy(GameObject.Find("Explosion"));
                    }

                    GetComponent<Menus> ().MainMenu();
                }
            }else {
                alpha -= 0.01f;
                if(alpha <= 0) {
                    up = true;
                    alpha = 0;
                    image.color = new Color(0, 0, 0, 0);
                    GetComponent<MenuTransitionAnimation> ().enabled = false;
                }
            }
            image.color = new Color(0, 0, 0, alpha);
        }
       
    }
}
