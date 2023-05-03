using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDisturbance : MonoBehaviour
{
    private GameObject firstPortal;
    private GameObject secondPortal;
    private Vector3 portFirstPos;
    private Vector3 portSecondPos;
    private Collider2D secondCollison;
    Vector2 puckCurPos;

    private GameObject movedPuck;
    private float beginTime;


    private void Awake()
    {
        firstPortal = GameObject.Find("PortalOne");
        secondPortal = GameObject.Find("PortalTwo");
        movedPuck = GameObject.Find("MovingPuck");
        secondCollison = GameObject.Find("PortalTwo").GetComponent<Collider2D>();
        puckCurPos = movedPuck.transform.position;







    }


    void Start()
    {
        beginTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        float portXNegClamp = Random.Range(-9.4f, 0f);
        float portXPosClamp = Random.Range(0, 9.4f);
        float portYNegClamp = Random.Range(-14.54f, -1);
        float portYPosClamp = Random.Range(1,14.54f);

        bool isLeaving = true;
        float currTime = 0f;

        secondCollison = Physics2D.OverlapPoint(puckCurPos);

        collision = Physics2D.OverlapPoint(puckCurPos);



        if (Time.time - beginTime > 15f && Time.time - beginTime < 20)
        {
            portFirstPos = new Vector2(Mathf.Clamp(portFirstPos.x, portXNegClamp, portXPosClamp), Mathf.Clamp(portFirstPos.y, portYNegClamp, 0));

             portSecondPos = new Vector2(Mathf.Clamp(portFirstPos.x, portXNegClamp, portXPosClamp), Mathf.Clamp(portFirstPos.y, 0, portYPosClamp));

            if (collision && isLeaving)
            {
                movedPuck.transform.position = portSecondPos;


                isLeaving = false;

            }

            else if (secondCollison && isLeaving)
            {
                movedPuck.transform.position = portFirstPos;

                isLeaving = false;

            }






        }

        else if (Time.time > 20)
        {



            currTime = Time.time;
           portFirstPos = new Vector2(Mathf.Clamp(portFirstPos.x, portXNegClamp, portXPosClamp), Mathf.Clamp(portFirstPos.y, portYNegClamp, 0));

            portSecondPos = new Vector2(Mathf.Clamp(portFirstPos.x, portXNegClamp, portXPosClamp), Mathf.Clamp(portFirstPos.y, 0, portYPosClamp));

            isLeaving = true;


            if(Time.time -currTime > 15f && Time.time - currTime < 20)
            {
                if (collision && isLeaving)
                {
                    movedPuck.transform.position = portSecondPos;


                    isLeaving = false;

                }

                else if (secondCollison && isLeaving)
                {
                    movedPuck.transform.position = portFirstPos;

                    isLeaving = false;

                }





            }



        }






        
        if (collision)
        {
            movedPuck.transform.position = portSecondPos;



        }






    }


}
