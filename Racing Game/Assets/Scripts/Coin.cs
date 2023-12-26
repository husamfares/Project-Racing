using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") & !hasTriggered)
        {

            hasTriggered = true;
            // give score to player;
            Destroy(gameObject);
        }
    }


}
