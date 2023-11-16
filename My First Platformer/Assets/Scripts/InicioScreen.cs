using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InicioScreen : MonoBehaviour
{
    public string scene1;
    
    public void OnClick()
    {
        SceneManager.LoadScene(scene1);
    }
    
}
