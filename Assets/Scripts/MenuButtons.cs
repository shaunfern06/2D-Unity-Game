using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject StartScene;
    public GameObject bg;

    private void Start()
    {
        Time.timeScale = 0f; 
    }
    private void Awake()
    {
    }
    public void PlayGame()
    {
        int Index = Random.Range(1, 5);
        string Sname = Index.ToString();
        Time.timeScale = 1f;
        StartScene.SetActive(false);
        Initiate.Fade(Sname, Color.white, 5f);
        bg.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ButtonSound()
    {
        AudioManager.instance.Play("Button");
    }

}
