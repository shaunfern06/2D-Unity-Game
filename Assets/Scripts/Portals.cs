using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public bool isPortal_1;   
    private Transform portalPos;
    public float distance = 0.3f;
    public bool isLava;

    void Start()
    {
        if (isLava != true)
        {
            if (isPortal_1 != true)
            { portalPos = GameObject.FindGameObjectWithTag("Portal1").GetComponent<Transform>(); }
            if (isPortal_1 == true)
            { portalPos = GameObject.FindGameObjectWithTag("Portal2").GetComponent<Transform>(); }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isLava == true)
        {
            if (other.CompareTag("Guns"))
            {
                Destroy(other.gameObject);
                AudioManager.instance.Play("Burn");
            }
        }
        else
        {
            if (other.CompareTag("Player") || other.CompareTag("Guns") || other.CompareTag("Bullet"))
            {
                if (Vector2.Distance(transform.position, other.transform.position) > distance)
                    other.transform.position = new Vector2(portalPos.position.x, portalPos.position.y);
                AudioManager.instance.Play("Portal");
            }
        }
    }
    

}
