using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int walkersKilled { get; private set; }

    public UnityEvent OnWalkerKilled;

    public void WalkerKilled()
    {
        walkersKilled += 1;
        OnWalkerKilled.Invoke();
    }

}
