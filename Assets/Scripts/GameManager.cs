using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time;
    public int InitialTime = 30;
    public int dificulty;
    int InitialDificulty = 1;
    int score;


    public enum GameState
    {
        GameOver,
        Pause,
        Play
    }

    public GameState State;
    public int Score
    {
        get => score; set
        {
            score = value;
            if (score % 1000 == 0) ;
        }
    }

    private void Awake()
    {
        if(Instance is null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        State = GameState.Play;
        dificulty = InitialDificulty;
        time = InitialTime;
        StartCoroutine(ConuntDownRoutine());
    }

    private void Dummy()
    {
        Console.WriteLine("Singleton");
    }
    IEnumerator ConuntDownRoutine()
    {
        while(time > 0)
        {
            
            yield return new WaitForSeconds(1);
            UIManager.Instanse.UpdateTime(time);
            time -= 1;
        }
        Console.WriteLine("GameOver");
        FindObjectOfType<Player>().Death();
        this.GameOver();

    }

    public void GameOver()
    {
        State = GameState.GameOver;
        UIManager.Instanse.ShowGameOverScreen();
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
    }

    public void Restart()
    {
        /* score = 0;
         State = GameState.Play;
         time = InitialTime;
         dificulty = InitialDificulty;
         UIManager.Instanse.UpdateHealth(5);
         UIManager.Instanse.UpdateTime(InitialTime);
         UIManager.Instanse.UpdateScore(0);
         FindObjectOfType<Player>().ResetStatus();*/
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

}
