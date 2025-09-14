using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour {

    public AudioSource buttonClick;
    public AudioSource levelCompletedSound;
    public AudioSource explosionSound;

    public GameObject mainMenu;
    public GameObject soundOff;
    public GameObject levelCompletedMenu;
    public GameObject gameOverMenu;
    public GameObject levelSelectMenu;
    public GameObject trailsParticle;
    public MenuTransitionAnimation menuTransitionAnimation;
    public Text currentLevelNumber;
    public Text nextLevelNumber;
 
    void Awake() {
        if(PlayerPrefs.GetInt("currentLevel") < 1) {
            PlayerPrefs.SetInt("currentLevel", 1);
        }
        currentLevelNumber.text = "" + PlayerPrefs.GetInt("currentLevel");
        nextLevelNumber.text = "" + (PlayerPrefs.GetInt("currentLevel") + 1);
        Destroy(GameObject.Find("Level"));
        GameObject newLevel = Instantiate(Resources.Load("Level" + PlayerPrefs.GetInt("currentLevel"), typeof(GameObject))) as GameObject;
        newLevel.name = "Level";
    }

    public void Play() {
        buttonClick.Play();
        mainMenu.SetActive(false);
        GameObject.Find("Ball").transform.Find("Trails").GetComponent<ParticleSystemRenderer>().enabled = true;
        GameObject.Find("Ball").GetComponent<PlayerMovement> ().enabled = true;
        currentLevelNumber.text = "" + PlayerPrefs.GetInt("currentLevel");
        nextLevelNumber.text = "" + (PlayerPrefs.GetInt("currentLevel") + 1);
        GetComponent<LevelProgressIndicator> ().Init();
    }

    public void SoundOnOff() {
        if(AudioListener.volume == 0) {
            soundOff.SetActive(false);
            AudioListener.volume = 1;
        }else {
            soundOff.SetActive(true);
            AudioListener.volume = 0;
        }
        buttonClick.Play();
    }

    public void MainMenu() {
        mainMenu.SetActive(true);
        levelCompletedMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Destroy(GameObject.Find("Level"));
        GameObject newLevel = Instantiate(Resources.Load("Level" + PlayerPrefs.GetInt("currentLevel"), typeof(GameObject))) as GameObject;
        newLevel.name = "Level";

        currentLevelNumber.text = "" + PlayerPrefs.GetInt("currentLevel");
        nextLevelNumber.text = "" + (PlayerPrefs.GetInt("currentLevel") + 1);
    }

    public void ShowLevelSelectMenu() {
        buttonClick.Play();
        levelSelectMenu.SetActive(true);
    }

    public void CloseLevelSelectMenu() {
        buttonClick.Play();
        currentLevelNumber.text = "" + PlayerPrefs.GetInt("currentLevel");
        nextLevelNumber.text = "" + (PlayerPrefs.GetInt("currentLevel") + 1);
        levelSelectMenu.SetActive(false);
    }

    public void LevelCompleted() {
        levelCompletedSound.Play();
        
        PlayerPrefs.SetInt("currentLevel", (PlayerPrefs.GetInt("currentLevel") + 1));
        
        if(PlayerPrefs.GetInt("currentLevel") > Vars.numberOfLevels) {
            PlayerPrefs.SetInt("currentLevel", Vars.numberOfLevels);
        }

        if(PlayerPrefs.GetInt("LatestLevel") < PlayerPrefs.GetInt("currentLevel")) {
            PlayerPrefs.SetInt("LatestLevel", PlayerPrefs.GetInt("currentLevel"));
        }
        
        levelCompletedMenu.SetActive(true);
        Invoke("MenuTransition", 1f);
    }

    public void GameOver() {
        explosionSound.Play();
        gameOverMenu.SetActive(true);
        Invoke("MenuTransition", 1f);
    }

    private void MenuTransition () {
        menuTransitionAnimation.enabled = true;
    }
}
