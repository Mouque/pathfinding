using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement player))
            {
                gameObject.SetActive(false);

                ScoreManager.Singleton.Score++;

                Destroy(gameObject, 3f);





            }
        }
    }
}
