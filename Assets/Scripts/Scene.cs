using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    public void Play(string cena)
    {
        SceneManager.LoadScene(cena);
        
    }

}
