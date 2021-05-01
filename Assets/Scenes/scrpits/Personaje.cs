using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 8;
    public bool puedeSalto = true;
    public float maxSpeed = 6;
    //el lado al que voy true derecha left izq
    public bool lado ;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("up") && puedeSalto)
        {
            puedeSalto = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,320f));            
        }
    }
    void FixedUpdate() {
        
        if(Input.GetKey("left"))
        {
            if(rb2d.velocity.x > 0 && lado){
                rb2d.velocity = new Vector2(2f, rb2d.velocity.y);
            }

            rb2d.AddForce(new Vector2(-velocidad,0));
            gameObject.GetComponent<Animator>().SetBool("moving",true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true; 
            Debug.Log(-rb2d.velocity.x);
            Debug.Log(maxSpeed);

            if(-rb2d.velocity.x > maxSpeed){
                rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);

            }
            lado= false;
        }
        if(Input.GetKey("right"))
        {
            if(rb2d.velocity.x < 0 && !lado){
                rb2d.velocity = new Vector2(2f, rb2d.velocity.y);
            }

            rb2d.AddForce(new Vector2(velocidad,0));   
            gameObject.GetComponent<Animator>().SetBool("moving",true);         
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //Debug.Log(rb2d.velocity); 
            Debug.Log(rb2d.velocity.x);
            Debug.Log(maxSpeed);
            
            if(rb2d.velocity.x > maxSpeed){
                rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
            }
            lado= true;
        }
        if(!Input.GetKey("right") && !Input.GetKey("left")){
            gameObject.GetComponent<Animator>().SetBool("moving",false);         

        }





        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "Suelo"){
            puedeSalto = true;
        }

        
    }
}
