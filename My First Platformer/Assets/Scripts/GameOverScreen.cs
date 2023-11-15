using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    
    public string scene1;
    public string inicio;

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Jugar()
    {
        SceneManager.LoadScene(scene1);
    }
    public void Inicio()
    {
        SceneManager.LoadScene(inicio);
    }
    
}
