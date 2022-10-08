using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 30;
    public int dificulty = 1;
    int score;

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
            time -= 1;
        }
        Console.WriteLine("GameOver");

    }
}
