using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    void Update()
    {
        Invoke("Scene", 5f);
    }

    void Scene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
