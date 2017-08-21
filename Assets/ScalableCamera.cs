/*using UnityEngine;
using System.Collections;

public class ScalableCamera : MonoBehaviour
{
    public Camera mainCam;
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    public Transform Player01;
    public Transform Player02;



    void Start()
    {

      

        // Camera.main.projectionMatrix = Matrix4x4.Ortho(-5.0f * 1.6f, 5.0f * 1.6f, -5.0f, 0.5f, 0.3f, 1000f);
        float TARGET_WIDTH = 1536.0f;
 float TARGET_HEIGHT = 850.0f;
 int PIXELS_TO_UNITS = 10; // 1:1 ratio of pixels to units

 float desiredRatio = TARGET_WIDTH / TARGET_HEIGHT;
 float currentRatio = (float)Screen.width / (float)Screen.height;

 if (currentRatio >= desiredRatio)
 {
     // Our resolution has plenty of width, so we just need to use the height to determine the camera size
     Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS;
 }
 else
 {
     // Our camera needs to zoom out further than just fitting in the height of the image.
     // Determine how much bigger it needs to be, then apply that to our original algorithm.
     float differenceInSize = desiredRatio / currentRatio;
     Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS * differenceInSize;
 }
}
    // Vector3 newpos = Player01.position;


// Update is called once per frame/* 
/*
void Update()
    {
        topWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

       // leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.width * 2f, 0f)).y); ;
       // leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

       // rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y); ;
      //  rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        Vector3 newpos = Player01.position;
        newpos.x = mainCam.ScreenToWorldPoint(new Vector3(75f, 0f, 0f)).x;
        Vector3 newpos2 = Player02.position;
        newpos2.x = mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75f, 0f, 0f)).x;


    }*/



