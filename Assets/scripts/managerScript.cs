using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class managerScript : MonoBehaviour {

    bool pauseBool = true;
    public GameObject gameOverScreen;
    public GameObject startScreen;

    void Pause() {
        if (pauseBool)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }

    public void GameOver() {
        gameOverScreen.SetActive(true);
        pauseBool = true;
        Pause();
    }

    public void restartLevel() {
        gameOverScreen.SetActive(false);
        pauseBool = false;
        Pause();
        SceneManager.LoadScene("default");
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        pauseBool = false;
        Pause();
    }

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
