using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject player;
    [SerializeField] private int dano = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        player.transform.position = respawnPoint.transform.position;
        ScoreTracker.instance.loseLife(dano);
    }
}