using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text scoreText;

    void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    public void UpdateUI(GameManager gameManager)
    {
       scoreText.text = gameManager.walkersKilled.ToString(); 
    }
}
