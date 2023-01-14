using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int player1Score = 0;
    public static int player2Score = 0;
    public Camera mainCam;
    public Transform player1;
    public Transform player2;
    GameObject ball;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public GUISkin skin;



    // Update is called once per frame
    public static void Score(string wall)
    {
        if (wall == "RightWall")
        {
            player1Score += 1;
        }
        if (wall == "LeftWall")
        {
            player2Score += 1;
        }


    }
    public void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 18, 20, 100, 100), "" + player1Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 - 18, 20, 100, 100), "" + player2Score);


        if (GUI.Button(new Rect(Screen.width / 2 - 121 / 2, 20, 121, 53), "RESET"))
        {
            player1Score = 0;
            player2Score = 0;
            ball.gameObject.SendMessage("ResetBall");
            player1.position = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(75f, 0f, 0f)).x, 0f, 0f);
            player2.position = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75f, 0f, 0f)).x, 0f, 0f);
        }
    }
}
