using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform ShotPoint; public Transform ShotPoint1; public Transform ShotPoint2;
    public GameObject bullet;
    public GameObject Player;
    public bool isPlayer1;

    private float timebwshot;
    public float starttimebwshot;

    private float actualbulletNo;
    public float bulletNo;

    public string gunType;
    public float Knck, AirKnck;

    public KeyCode Fire1 , Fire2;

    private void Start()
    {
        actualbulletNo = bulletNo;
    }
    void Update()
    {
        MG();
        Pistol();
        Shotgun();

        /*if (isPlayer1 == true)
        {
            if (Player.GetComponent<Player1_Controller>().facingRight == true)
            { Knck = -Knck; }

        }
        if (isPlayer1 != true)
        {
            if (Player.GetComponent<Player2_Controller>().facingRight == true)
            { Knck = -Knck; }

        }*/

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lava"))
        {
            AudioManager.instance.Play("Burn");
        }
    }

    void MG()
    {
        if (gunType == "Auto")
        {
            if (timebwshot <= 0)
            {
                if (Input.GetKey(Fire1) || Input.GetKey(Fire2))
                {
                    if (actualbulletNo <= bulletNo)
                    {
                        timebwshot = starttimebwshot;
                        Instantiate(bullet, ShotPoint.position, ShotPoint.rotation);
                        AudioManager.instance.Play("Mgun");
                        CameraShake.Shake(0.08f, 0.01f);
                        actualbulletNo -= 1;
                        //Player.GetComponent<Rigidbody2D>().AddForce(new Vector3(Player.transform.position.x * Knck, Player.transform.position.y * -AirKnck, Player.transform.position.z));            
                    }
                    if (actualbulletNo <= 0)
                    {
                        actualbulletNo = bulletNo;
                        gameObject.SetActive(false);
                        AudioManager.instance.Play("GunDrop");
                    }
                }
            }
            else
            {
                timebwshot -= Time.deltaTime;
            }
        }
    }
    void Pistol()
    {
        if (gunType == "Non-Auto")
        {
            if (timebwshot <= 0)
            {
                if (Input.GetKeyDown(Fire1) || Input.GetKeyDown(Fire2))
                {
                    if (actualbulletNo <= bulletNo)
                    {
                        timebwshot = starttimebwshot;
                        Instantiate(bullet, ShotPoint.position, ShotPoint.rotation);
                        AudioManager.instance.Play("Pistol");
                        CameraShake.Shake(0.1f, 0.05f);
                        actualbulletNo -= 1;
                        //Player.GetComponent<Rigidbody2D>().AddForce(new Vector3(Player.transform.position.x * Knck, Player.transform.position.y * -AirKnck, Player.transform.position.z));
                    }
                    if (actualbulletNo == 0)
                    {
                        actualbulletNo = bulletNo;
                        gameObject.SetActive(false);
                        AudioManager.instance.Play("GunDrop");
                    }
                }
            }
            else
            {
                timebwshot -= Time.deltaTime;
            }
        }
    }
    void Shotgun()
    {
        if (gunType == "Shotty")
        {
            if (timebwshot <= 0)
            {
                if (Input.GetKeyDown(Fire1) || Input.GetKeyDown(Fire2))
                {
                    if (actualbulletNo <= bulletNo)
                    {
                        timebwshot = starttimebwshot;
                        Instantiate(bullet, ShotPoint.position, ShotPoint.rotation);
                        Instantiate(bullet, ShotPoint.position, ShotPoint1.rotation);
                        Instantiate(bullet, ShotPoint.position, ShotPoint2.rotation);
                        AudioManager.instance.Play("Shotty");
                        CameraShake.Shake(0.2f, 0.2f);
                        actualbulletNo -= 1;
                        //Player.GetComponent<Rigidbody2D>().AddForce(new Vector3(Player.transform.position.x * Knck, Player.transform.position.y * -AirKnck, Player.transform.position.z));
                    }
                    if (actualbulletNo == 0)
                    {
                        actualbulletNo = bulletNo;
                        gameObject.SetActive(false);
                        AudioManager.instance.Play("GunDrop");
                    }
                }
            }
            else
            {
                timebwshot -= Time.deltaTime;
            }
        }
    }
}
