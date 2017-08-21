using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ballcontrol : MonoBehaviour
{ //public Sprite[] bcolors;
    private Rigidbody2D rbody;
    private Vector2 vel;
    public AudioSource aud;
    public AudioSource aud1;
    private bool p1touched;

    public Text time;




    public int ballIndex;
    public KeyCode ad;
    public GameObject playerParent;

    private bool hasstartd1 = false;
    private bool hasstartd2 = false;
  //  private bool cort1;
  //  private bool cort2;
   public int x = 5;
   


    void Goball()
    {

        float rand = Random.Range(0.0f, 2.0f);
        int rand2 = Random.Range(0, 2);
        float ySpeed = 0f;
        if (rand2 == 0)
            ySpeed = 10f;
        else
            ySpeed = -10f;
        if (rand < 1.0f)
        {
            rbody.AddForce(new Vector2(40.0f, ySpeed));


        }
        else
        {
            rbody.AddForce(new Vector2(-40.0f, ySpeed));
        }

    }

    void Resetball()
    {

        vel.x = 0;
        vel.y = 0;
        rbody.velocity = vel;
        if (gameObject.GetComponent<ballcontrol>().ballIndex == 1)
            rbody.transform.position = new Vector2(0, 0);
        else
            rbody.transform.position = new Vector2(0, 1);


        //gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

    }
    void Restartgame()
    {

        Resetball();
        Invoke("Goball", 1.5f);

    }
    // Use this for initialization
    void Start()
    {

       
        //bcolors = new Sprite[2];
        p1touched = false;
        rbody = GetComponent<Rigidbody2D>();
        Invoke("Goball", 1.5f);
        aud = GameObject.Find("padhit").GetComponent<AudioSource>();
        aud1 = GameObject.Find("wallhit").GetComponent<AudioSource>();

    }
    IEnumerator ball1time()
    {


        if (ballIndex == 0)
        {

            while (x > 0 && Sidewalls.p1b1)

            {
                time.text = " " + x;
                x--;
                Debug.Log("is work" + x + "ballindex" + ballIndex);

                yield return new WaitForSeconds(1);
                if(Sidewalls.p1b1 == false && hasstartd1 ==false)
                {
                    x = 5;
                    StopCoroutine("ball1time");
                }
             
            }

            x = 5;

            UIManager.score1++;

            UIManager.p1s = "" + UIManager.score1;
            if (Sidewalls.p1b1 == true)
            {            
                hasstartd1 = false;
                Sidewalls.p1b1 = false;
                rbody.isKinematic = false;
                Restartgame();

            }



        }


        if (ballIndex == 1)
        {

            while (x > 0 && Sidewalls.p2b2 )
            {
                time.text = " " + x;
                x--;
                Debug.Log("is work" + x + "ballindex" + ballIndex);
                yield return new WaitForSeconds(1);
                if (Sidewalls.p2b2 == false && hasstartd2 == false)
                {
                    x = 5;
                    StopCoroutine("ball1time");
                }


            }
            x = 5;

            UIManager.score2++;

            UIManager.p2s = "" + UIManager.score2;
            
            if (Sidewalls.p2b2 == true)
            {
                hasstartd2 = false;
                Sidewalls.p2b2 = false;
                rbody.isKinematic = false;
                Restartgame();

            }

        }
    }


    

    void Update()
    {
        if (!Sidewalls.p1b1 && !Sidewalls.p2b2)
        {
            x = 5;
            time.text = "5";
        }

      
       if ((Sidewalls.p1b1 || Sidewalls.p2b2))
        {

            if (Sidewalls.p1b1 && !hasstartd1 && ballIndex == 0)
            {
                Debug.Log("start"+x);
              hasstartd1 = true;
                StartCoroutine("ball1time");
                

            }
            if (Sidewalls.p2b2 && !hasstartd2 &&  ballIndex == 1  )
            {
                Debug.Log("start" + x + ballIndex);
               hasstartd2 = true;
               StartCoroutine("ball1time");
              
            }
            
        }
        
     if (Sidewalls.p1b1 && ballIndex == 0)        
           rbody.gameObject.transform.position = new Vector2(playerParent.transform.position.x + 0.5f, playerParent.transform.position.y);


       if (Sidewalls.p2b2 && ballIndex == 1)
            rbody.gameObject.transform.position = new Vector2(playerParent.transform.position.x - 0.5f, playerParent.transform.position.y);

        if (Input.GetKeyDown(ad) && Sidewalls.p2b2 && ballIndex == 1 )
        {
            shootBall();
            // StopCoroutine("ball1time");

            //Debug.Log("Player 2 - ball 2 ,parent is : " + rbody.transform.parent.name);
        }
        if (Input.GetKeyDown(ad) && Sidewalls.p1b1 && ballIndex == 0 )

        {
            rbody.isKinematic = false;
            rbody.AddForce(new Vector2(+70f, 0f));
            Sidewalls.p1b1 = false;
            hasstartd1 = false;
            // StopCoroutine("ball1time");


        }


     
    

}

    private void shootBall()
    {
        rbody.isKinematic = false;
        rbody.AddForce(new Vector2(-70f, 0f));
        Sidewalls.p2b2 = false;
        hasstartd2 = false;
    }

    public void shoot()

    {


        rbody.isKinematic = false;

        rbody.AddForce(new Vector2(+70f, 0f));
        //  Sidewalls.p1b1 = false;




    }

   public void shooter()
   {
        print("Pressing button");
        if (Sidewalls.p1b1)
                
shootBall();
} 

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
float racketHeight)
    {

        return (ballPos.y - racketPos.y) / racketHeight;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
       
        // 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider




        if (col.gameObject.name == "player01" || col.gameObject.name == "player02")
        {
            aud.Play();
            if (!p1touched)
            {
                //GetComponent<SpriteRenderer>().sprite = bcolors[0];
                
                   //gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                    p1touched = true;
                
            }
            else
            {
                //GetComponent<SpriteRenderer>().sprite = bcolors[1];
               // gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                p1touched = false;
            }

        }
        else
            aud1.Play();

        if (col.gameObject.name == "player01")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                  col.transform.position,
                  col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * (680 * Time.deltaTime);

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
            GetComponent<Rigidbody2D>().velocity = dir * (680 * Time.deltaTime);

        }

        {
            if (col.collider.CompareTag("Player"))
            {

                vel.x = rbody.velocity.x;
                vel.y = (rbody.velocity.y / 2.0f) + (col.collider.attachedRigidbody.velocity.y / 3.0f);
                rbody.velocity = vel;
            }
        }

    }
}



