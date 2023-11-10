using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeInteraction : MonoBehaviour
{
    [SerializeField] private int dano = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Player"))
        {
            ScoreTracker.instance.loseLife(dano);
        }
    }
}
