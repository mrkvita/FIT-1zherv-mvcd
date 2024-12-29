using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScoreIncrement : MonoBehaviour
{
    private GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TriggerScore()
    {
        gameManager.WalkerKilled();
    }
    
}
