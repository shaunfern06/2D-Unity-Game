using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeapon : MonoBehaviour
{
    private int gunNo, point;
    private float actfreq;
    public float freq;
    public GameObject[] guns;
    public GameObject[] spawnPoints;
    void Start()
    {
        actfreq = freq;
    }

    void Update()
    {
        point = Random.Range(0, spawnPoints.Length);
        gunNo = Random.Range(0, guns.Length);
        if (actfreq <= 0)
        {
            Instantiate(guns[gunNo], spawnPoints[point].transform.position, Quaternion.identity);
            actfreq = freq;
        }
        else
        { actfreq -= Time.deltaTime; }
            
    }

}
   
