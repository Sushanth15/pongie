using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ball2controls : MonoBehaviour
{
    private Rigidbody2D rbody1;
    private Vector2 vel1;
    public AudioSource aud2;
    public AudioSource aud3;
    private bool p3touched;


    void Goball1()
    {
        float rand3 = Random.Range(0.0f, 2.0f);
        int rand4 = Random.Range(0, 2);
        float ySpeed1 = 0f;

        if (rand4 == 0)
            ySpeed1 = 15f;
        else
            ySpeed1 = -15f;
        if (rand3 < 1.0f)
        {
            rbody1.AddForce(new Vector2(50.0f, ySpeed1));


        }
        else
        {
            rbody1.AddForce(new Vector2(-50.0f, ySpeed1));
        }

    }

    void Resetball1()
    {

        vel1.x = 0;
        vel1.y = 0;
        rbody1.velocity = vel1;
        rbody1.transform.position = new Vector2(0, 0);
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

    }
    void Restartgame1()
    {

        Resetball1();
        Invoke("Goball1", 1.5f);
    }
    // Use this for initialization
    void Start()
    {
        p3touched = false;
        rbody1 = GetComponent<Rigidbody2D>();
        Invoke("Goball1", 1.5f);
        aud2 = GameObject.Find("padhit").GetComponent<AudioSource>();
        aud3 = GameObject.Find("wallhit").GetComponent<AudioSource>();




    }
    /* void OnCollisionEnter2D(Collision2D col)
     {
         if (col.collider.CompareTag("Player"))
         {

             vel.x = rbody.velocity.x;
             vel.y = (rbody.velocity.y / 2.0f) + (col.collider.attachedRigidbody.velocity.y / 3.0f);
             rbody.velocity = vel;
         }
       */
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
float racketHeight)
    {

        return (ballPos.y - racketPos.y) / racketHeight;
    }




    void OnCollisionEnter2D(Collision2D col)
    {


        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?



        if (col.gameObject.name == "player01" || col.gameObject.name == "player02")
        {
            aud2.Play();
            if (!p3touched)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
                p3touched = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
                p3touched = false;
            }

        }
        else
            aud3.Play();

        if (col.gameObject.name == "player01")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                  col.transform.position,
                  col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * (700 * Time.deltaTime);

        }

        // Hit the right Racket?
        if (col.gameObject.name == "player02")
        {
            // Calculate hit Factor










            float y = hitFactor(transform.position,
                  col.transform.position,
                  col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * (700 * Time.deltaTime);

        }


        if (col.collider.CompareTag("Player"))
        {

            vel1.x = rbody1.velocity.x;
            vel1.y = (rbody1.velocity.y / 2.0f) + (col.collider.attachedRigidbody.velocity.y / 3.0f);
            rbody1.velocity = vel1;
        }




    }


}
