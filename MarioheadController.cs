using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioheadController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //Contra que estoy colisionando
        var tag = other.gameObject.tag;
        if(tag == "Obstaculo")
        {
            Destroy(other.gameObject);
        }
    }
}
