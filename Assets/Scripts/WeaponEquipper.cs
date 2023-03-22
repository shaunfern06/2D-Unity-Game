using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipper : MonoBehaviour
{
    public GameObject[] weapon;
    public GameObject[] collectibles;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Guns"))
        {
            for (int lv = 0; lv < collectibles.Length; lv++)
            {

                if (other.GetComponent<SpriteRenderer>().sprite == collectibles[lv].GetComponent<SpriteRenderer>().sprite)
                {
                    for (int i = 0; i < collectibles.Length; i++)
                    {
                        weapon[i].SetActive(false);
                        AudioManager.instance.Play("Equip");
                    }
                    Destroy(other.gameObject);
                    weapon[lv].SetActive(true);
                    break;
                }
                       
            }
            
        }

    }

}
