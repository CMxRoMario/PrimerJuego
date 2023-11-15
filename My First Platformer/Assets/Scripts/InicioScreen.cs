using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InicioScreen : MonoBehaviour
{
    
    public string jugar;

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Jugar()
    {
        SceneManager.LoadScene(jugar);
    }
    
}
