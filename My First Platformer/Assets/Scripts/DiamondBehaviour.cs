using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBehaviour : MonoBehaviour
{
    [SerializeField] private int valor = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreTracker.instance.addScore(valor);
            Destroy(this.gameObject);
        }   
    }
}
