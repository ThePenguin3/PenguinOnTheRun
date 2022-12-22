using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] public string nameScene;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nameScene, LoadSceneMode.Single);
    }
}

