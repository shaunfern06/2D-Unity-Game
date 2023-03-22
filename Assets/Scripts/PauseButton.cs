using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    bool isPaused = false;
    public GameObject b1;
    public GameObject b2;
    public GameObject bg;
    public GameObject b3;
    public GameObject b4;
    public GameObject win;
    public GameObject NameInputRED;
    public GameObject NameInputBLUE;

    public GameObject pc;


    private void Update()
    {

        if (isPaused)
        {
            pc.GetComponent<Transition>().entry();
        }
        else
        {
            pc.GetComponent<Transition>().exit();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();               
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        b1.SetActive(false); b2.SetActive(false); bg.SetActive(false); b3.SetActive(false); b4.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause()
    {
        b2.SetActive(true); b1.SetActive(true); bg.SetActive(true); b3.SetActive(true); b4.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void NewLevel()
    {
        string Sname="";
        int Index = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Index = 5;
            Sname =  Index.ToString();
        }
        else
        {
            Index -= 1;
            Sname = Index.ToString();
        }
        Time.timeScale = 1f;
        Initiate.Fade(Sname, Color.white, 5f);
    }
    public void Restart()
    {
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.white, 5f);
        Time.timeScale = 1f;
    }
    public void ButtonSound()
    {
        AudioManager.instance.Play("Button");
    }
    public void Red()
    {
        b1.SetActive(true); bg.SetActive(true); b3.SetActive(true); b4.SetActive(true);
        win.GetComponent<TMPro.TextMeshProUGUI>().text = "RED PLAYER WINS!";
        win.SetActive(true);
        isPaused = true;
        Invoke("Freeze", 2f);
    }
    public void Blue()
    {
        b1.SetActive(true); bg.SetActive(true); b3.SetActive(true); b4.SetActive(true);
        win.GetComponent<TMPro.TextMeshProUGUI>().text = "BLUE PLAYER WINS!";
        win.SetActive(true);
        isPaused = true;
        Invoke("Freeze", 2f);

    }
    void Freeze()
    {
        Time.timeScale = 0f;
    }
}
