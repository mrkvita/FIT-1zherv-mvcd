using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int walkersKilled { get; private set; }
    public float sceneDelay;

    public UnityEvent OnWalkerKilled;
    
    public void WalkerKilled()
    {
        walkersKilled += 1;
        OnWalkerKilled.Invoke();
    }
    public void GameOver()
    {
        StartCoroutine(DelaySceneLoad());
    }

    private IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(sceneDelay);
        SceneManager.LoadScene("MainMenu");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    } 

}
