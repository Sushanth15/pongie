/*using UnityEngine;
using System.Collections;

public class GameM : MonoBehaviour
{
    public static int plyrscore1 = 0;
    public static int plyrscore2 = 0;
    public GUISkin layout;
    Transform theBall;

    public static void Score(string wall)
    {
        if (wall == "rightwall")
            plyrscore1++;
        else
            plyrscore2++;

    }
   void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + plyrscore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + plyrscore2);
        if(GUI.Button(new Rect(Screen.width/ 2 - 60 , 35 , 120 ,53),"RESTART"))
        {
            plyrscore1 = 0;
            plyrscore2 = 0;
            theBall.gameObject.SendMessage("Restartgame", 0.5f, SendMessageOptions.RequireReceiver);
        }
        if (plyrscore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.gameObject.SendMessage("Resetball", null, SendMessageOptions.RequireReceiver);
        }
        else if (plyrscore2  == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.gameObject.SendMessage("Resetball", null, SendMessageOptions.RequireReceiver);

        }

    }

}
*/