using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Sidewalls : MonoBehaviour
{
    public GameObject winText;
    public GameObject button;

    public GameObject leftSide, rightSide;

    public GameObject b1;
    public GameObject b2;
    public static bool p1b1;
    public static bool p2b2;


    void Start()
    {
        p1b1 = false;
        p2b2 = false;


        
    }

     void Update()
    {

    }




    void OnTriggerEnter2D(Collider2D hit)
    {
       
       if (name == "leftwall")
        {


            if (hit.gameObject == b1)
            {
                // p = true;
                p1b1 = true;
                Vector2 Correct = new Vector2(b1.transform.position.x + 0.5f, b1.transform.position.y);
                hit.GetComponent<Rigidbody2D>().isKinematic = true;
                hit.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                hit.transform.position = Correct;

                print("Was attached correctly");

                //hit.transform.SetParent(b1.transform);
            }
               else if (hit.gameObject == b2)
                   {
                       hit.gameObject.SendMessage("Restartgame", 0.5f, SendMessageOptions.DontRequireReceiver);
                       UIManager.score1++;
                       UIManager.p1s = "" + UIManager.score1;
                       if (UIManager.score1 >= 10)
                       {
                           button.SetActive(true);

                           winText.SetActive(true);
                           winText.GetComponent<Text>().text = "Player 2 WON!!";
                           Time.timeScale = 0f;

                       }
                   }
               }
               else
               {
                   if (hit.gameObject == b2)
                   {
                       //    p = true;
                       p2b2 = true;
                       Vector2 Correct1 = new Vector2(b2.transform.position.x - 0.5f, b2.transform.position.y);
                       hit.GetComponent<Rigidbody2D>().isKinematic = true;
                       hit.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                       hit.transform.position = Correct1;

                       //hit.transform.SetParent(b2.transform);
                   }
                   else if (hit.gameObject == b1)
                   {
                       hit.gameObject.SendMessage("Restartgame", 0.5f, SendMessageOptions.DontRequireReceiver);
                       UIManager.score2++;
                       UIManager.p2s = "" + UIManager.score2;
                       if (UIManager.score2 >= 10)
                       {

                           button.SetActive(true);

                           winText.SetActive(true);
                           winText.GetComponent<Text>().text = "Player 1 WON!!";
                           Time.timeScale = 0f;
                       }
                   }
               }

           } 
        }
    






