    using UnityEngine;
using UnityEngine.Networking; 
using System.Collections;

public class Playercontrols : MonoBehaviour
{
    public Transform UpperLim;

    public Transform BottomLim;
    public float speed;
    private Rigidbody2D rbody;
    private bool p2touched;

    public KeyCode UP;
    public KeyCode Down;
   // Touch touch;
   


    void Start()
    {
      //  Debug.Log(Screen.height);
        p2touched = false;
        rbody = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame

    void Update()
    {
     /*
        
                if (Input.GetMouseButtonDown(0))
           {
             
                if(Input.mousePosition.y > Screen.height/2)
               {
                   var vel = rbody.velocity;
                   vel.y = speed;
                   rbody.velocity = vel;
               }

                  if (Input.mousePosition.y < Screen.height / 2)
                   {
                        var vel = rbody.velocity;
               vel.y = -1 * speed;
               rbody.velocity = vel;
                   }
           }
          
    */

        if (Input.GetKey(UP))
        {
            var vel = rbody.velocity;
            vel.y = speed ; 
            rbody.velocity = vel;
        }
        else if (Input.GetKey(Down))
        {
            var vel = rbody.velocity;
            vel.y = -1 * speed;
            rbody.velocity = vel;
        }
        else if (!Input.anyKey)
        {
            var vel = rbody.velocity;
            vel.y = 0.0f; 
            rbody.velocity = vel;
        }



        if (transform.position.y > UpperLim.position.y)
            transform.position = new Vector2(transform.position.x, UpperLim.position.y);
        if (transform.position.y < BottomLim.position.y)
            transform.position = new Vector2(transform.position.x, BottomLim.position.y);
   


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ball")
        {
            if (!p2touched)
            {
                //gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
                p2touched = true;
            }
            else
            {
                //gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
                p2touched = false;
            }
        }

    }

}