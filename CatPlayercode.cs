using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlayercode : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 5;
    public GameObject BulletPrefab;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Animator _animator;

    private static readonly string ANIMATOR_STATE = "estado";
    public static readonly int ANIMATION_JUMP = 2;
    private static readonly int ANIMATION_RUN = 1;
    private static readonly int ANIMATION_IDLE = 0;
    private static readonly int ANIMATION_SLICE = 3;

    private static readonly int RIGHT = 1;
    private static readonly int LEFT = -1;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //GetKey -> mientras presiono la tecla
        //GetKeyDown -> cuando presiono la tecla
        //GetKeyUp -> cuando suelto la tecla

        _rb.velocity = new Vector2(0, _rb.velocity.y);
        ChangeAnimation(ANIMATION_IDLE);

        if(Input.GetKey(KeyCode.RightArrow)) //si presiono flecha a la derecha
        {
            Desplazarse(RIGHT);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazarse(LEFT);
        }

        if(Input.GetKey(KeyCode.C))
        {
            Deslizarse();
        }

        if(Input.GetKeyUp(KeyCode.X))
        {
            Disparar();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            //Funciones para saltar
            //_rb.AddForce(fuerza hacia arriba * fuerza de salto, Modo de
            // fuerza impulso)
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_JUMP);
        }
    }  
    //OnCollisionEnter2D -> Cuando chocamos con algo.
    //OnCollisionExit2D -> Cuando dejamos de chocar con algo.
    //OnCollisionStay2D -> Mientras estamos chocando con algo.
    private void Deslizarse()
    {
        ChangeAnimation(ANIMATION_SLICE);
    }    

    private void Desplazarse(int position)
    {
        _rb.velocity = new Vector2(Velocity * position, _rb.velocity.y);
        _sr.flipX = position == LEFT;
        ChangeAnimation(ANIMATION_RUN); //Cambiamos el valor del atributo
        
    }
    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }

    private void Disparar()
    {
        //Crear gameObject en tiempo de ejecucion
        //Instantiate(objeto, posicion,rotacion)
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var bulletGO = Instantiate(BulletPrefab,new Vector2(x,y),Quaternion.identity) as GameObject;
        if(_sr.flipX)
        {
            var controller = bulletGO.GetComponent<bolaFuego_script>();
            controller.Velocidad *= -1;
        }

    }

}