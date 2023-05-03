using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerMovement : MonoBehaviour
{
    private GameObject puckPiece;
    private GameObject aiPlayerPiece;
    private bool isInZone = true;
    private float[] trickValues = { 3f, 2f, 1.5f };
    private float trickNum;
     
   




    [SerializeField] float playerSpeed =2f;
    private Rigidbody2D rgbAI;
    private Rigidbody2D rgbPuck;


    [SerializeField] float puckSpeed = 2f;
    private Vector3 targetPos;
    private Vector3 currentPos;
    


    private void Awake()
    {

        aiPlayerPiece = GameObject.Find("AirHockeyTwoBlue");
        rgbAI = GameObject.Find("AirHockeyTwoBlue").GetComponent<Rigidbody2D>();

        puckPiece = GameObject.Find("MovingPuck");
        rgbPuck = GameObject.Find("MovingPuck").GetComponent<Rigidbody2D>();

        

        





    }



    void Start()
    {
       
        
    }


    private void FixedUpdate()
    {

        
        

        targetPos = new Vector2(Mathf.Clamp(puckPiece.transform.position.x, -11.44f+3.95f, 11.44f-3.95f), Mathf.Clamp(puckPiece.transform.position.y, 3.56f, 13.07f));
        rgbPuck.transform.position = new Vector2(Mathf.Clamp(rgbPuck.transform.position.x, -11.44f + 2f, 11.44f - 2f), Mathf.Clamp(rgbPuck.transform.position.y, -17.54f + 2f,17.54f-2f));

       

        
        
        
        if(puckPiece.transform.position.y < 17.54 && puckPiece.transform.position.y > 0)
        {
            
            if (isInZone) {
            

            trickNum=  (float)trickValues.GetValue(Random.Range(0,trickValues.Length));
                isInZone = false;

        }
        

            targetPos.x += trickNum;
            



        }

        else
        {

            isInZone = true;


        }
        
        
        rgbAI.MovePosition(Vector2.MoveTowards(aiPlayerPiece.transform.position, targetPos, playerSpeed * Time.fixedDeltaTime));





    }




    // Update is called once per frame
    void Update()
    {
        



    }




}
