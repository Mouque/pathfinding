using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;

    public static ScoreManager Singleton;



    void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
        }

        print(Score);
    }

    void Update()
    {
        
    }
}
