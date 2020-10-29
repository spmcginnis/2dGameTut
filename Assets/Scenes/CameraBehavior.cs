using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    //max distance from player
    //max distance from center
    //some way to define the camera bounds
    //2d position in the world ie transform
    //confiner
    Vector3 StartPos;

    [SerializeField]
    bool WiggleTestOn = false;

    // Start is called before the first frame update
    void Awake()
    {
        //find ball
        StartPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //follow ball
        Vector2 PlayerPos = FindBall();
        FollowBall(PlayerPos);
        if (WiggleTestOn) { WiggleTest(); }
    }

    void WiggleTest()
    {
        //find and get the position of the camera
        //attach the x-position of the camera to the cosign of the frame count or something for oscillation
        Vector3 CamPosition = Camera.main.transform.position;

        CamPosition.x = StartPos.x + (2* Mathf.Cos( Time.frameCount / 250 ));
        print("Current x " + CamPosition.x);

        Camera.main.transform.position = CamPosition;
    }

    Vector2 FindBall()
    {
        Vector2 PlayerPos = GameObject.Find("PlayerCharacter").transform.position;

        
        return PlayerPos;
    }

    void FollowBall(Vector2 PlayerPos)
    {
        //float StartPosY = StartPos.y;
        Vector3 CamPosition = Camera.main.transform.position;


        //float DeltaFromStart = Mathf.Abs(CamPosition.y) - Mathf.Abs(StartPos.y);


        if (PlayerPos.y > StartPos.y || PlayerPos.y < 0)
        {
            float DeltaFromCurrent = PlayerPos.y - CamPosition.y;
            CamPosition.y += DeltaFromCurrent / 10;
            Camera.main.transform.position = CamPosition;

        } else
        {
            float DeltaFromStart = StartPos.y - CamPosition.y;
            CamPosition.y += DeltaFromStart / 25;
            Camera.main.transform.position = CamPosition;
        }








        /*
                if (Mathf.Abs(DeltaFromStart) < 1.6)
                {
                    CamPosition.y = StartPos.y;
                }
                else
                {
                    CamPosition.y += DeltaFromCurrent / 25;
                }
                */

        /*        if (Mathf.Abs(PlayerPos.y) > (StartPosY + 2))
                {

                }*/
        /*        else
                {
                    CamPosition.y = StartPos.y;
                }*/


    }















}
