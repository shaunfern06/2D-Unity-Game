using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class TakeDamage : MonoBehaviour
{
    private float health, max = 100f;
    public GameObject D_particle;
    public Image HealthBar;
    public bool isPlayer1;
    public GameObject Pmenu;
    public void Start()
    {
        health = max;          
    }
    public void Takedamage(float damage)
    {
        health -= damage;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        Invoke("NormalColor", 0.2f);
        AudioManager.instance.Play("Hurt");


        HealthBar.GetComponent<Image>().fillAmount = health / max;
        if (health <= 0)
        {

            if(isPlayer1 == true)
            { Pmenu.GetComponent<PauseButton>().Blue(); }
            else
            { Pmenu.GetComponent<PauseButton>().Red(); }

            Destroy(gameObject);
            Instantiate(D_particle, transform.position, Quaternion.identity);           
        }

        if(health <= 20)
        {
            
        }
    }
    void NormalColor()
    {
        if (isPlayer1 == true)
        { gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.3254f, 0.3254f); }
        else
        { gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0.6432805f, 1f); }
    }

}
