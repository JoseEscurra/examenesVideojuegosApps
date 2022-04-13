using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolaFuego_script : MonoBehaviour
{
    public float Velocidad = 10;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(Velocidad, _rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        var tag = other.gameObject.tag;
        if(tag == "Enemy")
        {
           Destroy(this.gameObject);
           Destroy(other.gameObject);
        }
    }
}