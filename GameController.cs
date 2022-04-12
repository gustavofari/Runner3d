using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject gameScene;

    void Start() {

        instance = this;
    }

    public void setGameOver() {

        gameScene.SetActive(true);
    }

    public void RestartGame() {

        SceneManager.LoadScene(0);
    }

    public void print() {
        print("hello");
    }

}
