using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObjective : MonoBehaviour
{
    public string nextScene;


    private void OnTriggerEnter( Collider other )
    {
        if ( other != null )
        {
            if ( other.gameObject.TryGetComponent( out PlayerMovement player ) )
            {
                SceneManager.LoadScene( nextScene );
            }
        }

    }
}
