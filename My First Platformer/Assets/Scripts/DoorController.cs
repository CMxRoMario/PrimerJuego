using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour
{
    private float vertical;
    public Transform puntoDeSalida; // Punto donde el jugador aparecerá al salir por la puerta
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Asegúrate de que el jugador tiene el tag "Jugador"
        {
            TeletransportarJugador(puntoDeSalida.position);
        }
    }

    private void TeletransportarJugador(Vector3 posicion)
    {
        GameObject Jugador = GameObject.FindGameObjectWithTag("Player");
        Jugador.transform.position = posicion;
    }
}