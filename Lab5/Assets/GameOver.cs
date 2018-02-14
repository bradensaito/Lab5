using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void startGame()
    {

        MainMenu.lives = 1;
        MainMenu.score = 0;
        SceneManager.LoadScene(0);
    }
}
