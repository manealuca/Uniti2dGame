using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text [] hudArray;
    [SerializeField] string[] hudText;
    [SerializeField] GameObject GameOverScreen;
    int finaleScore;
    public static UIManager Instanse;

    private void Awake()
    {
        if (Instanse is null) Instanse = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void UpdateScore(int score)
    {
        hudArray[0].text = score.ToString();
    }

    public void UpdateHealth( int health)
    {
        hudArray[1].text = "  " + health.ToString();
    }

    public void UpdateTime(int time)
    {
        hudArray[2].text = time.ToString();
    }

    public void ShowGameOverScreen()
    {
        GameOverScreen.gameObject.SetActive(true);
        hudArray[3].text = "  "+GameManager.Instance.Score.ToString();
    }
    public void PlayAgain()
    {
        GameOverScreen.gameObject.SetActive(false);
        GameManager.Instance.Restart();
    }


}
