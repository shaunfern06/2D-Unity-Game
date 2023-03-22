using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Animator anim;

    public void entry()
    {
        anim.SetBool("isPaused", true);
    }
    public void exit()
    {
        anim.SetBool("isPaused", false);
    }
}
