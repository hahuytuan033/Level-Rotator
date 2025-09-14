using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {

    int level;
    void OnEnable() {
        level = Int32.Parse(this.gameObject.name);
        if(PlayerPrefs.GetInt("LatestLevel") < 1) {
            PlayerPrefs.SetInt("LatestLevel", 1);
        }
        if(level <= PlayerPrefs.GetInt("LatestLevel")){
            GetComponent<Button>().interactable = true;
            transform.Find("Lock").GetComponent<Image> ().enabled = false;
            transform.Find("Text").GetComponent<Text> ().enabled = true;
        }else {
            GetComponent<Button>().interactable = false;
            transform.Find("Lock").GetComponent<Image> ().enabled = true;
            transform.Find("Text").GetComponent<Text> ().enabled = false;
        }
    }
    public void LoadLevel() {
        Destroy(GameObject.Find("Level"));
        PlayerPrefs.SetInt("currentLevel", level);
        GameObject newLevel = Instantiate(Resources.Load("Level" + this.gameObject.name, typeof(GameObject))) as GameObject;
        newLevel.name = "Level";
        GameObject.Find("GameManager").GetComponent<Menus> ().CloseLevelSelectMenu();
    }
}
