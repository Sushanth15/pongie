using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject button;
    public AudioSource au;
    public AudioSource au1;

    public static int score1 = 0;
    public static int score2 = 0;
    public GameObject winText;


    public Text player1Score;
    public Text player2Score;
    // Use this for initialization

    public static string p1s="0";
    public static string p2s="0";

    void Awake()
    {
        au = GameObject.Find("au").GetComponent<AudioSource>();
        Time.timeScale = 0;

    }

    void Start () {

        button.SetActive(true);

        au.Play();

    winText.SetActive(false);
        player1Score.text = "0";
        player2Score.text = "0";
	}

void Update()
    {
        if (au.isPlaying)
            button.GetComponent<Button>().interactable = false;
        else
            button.GetComponent<Button>().interactable = true;



        player1Score.text = p2s;
    player2Score.text = p1s;


       
}
        
    public void restartbutton()
    {

       
        if (!au.isPlaying)
        {
            p1s = "0";
            p2s = "0";
            player1Score.text = "0";
            player2Score.text = "0";

            score1 = 0;
            score2 = 0;
            winText.SetActive(false);
            button.SetActive(false);
            Time.timeScale = 1f;
            
        }


        

    }

    public void exitbutton()
    {
        Application.Quit();
    }
}















