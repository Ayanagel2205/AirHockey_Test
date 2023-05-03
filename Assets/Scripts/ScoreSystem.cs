using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject playerUser;
    private GameObject playerOpp;
    private GameObject puckObj;
    private Rigidbody2D puckObjRb;
    private string collTag;

    [SerializeField] TMP_Text userScore;
    [SerializeField] TMP_Text oppScore;

    private GameObject scoreCheckTop;
    private GameObject scoreCheckBottom;

    private int scoreValuePlayer =0;
    private int scoreValueOpponent =0;
    private int topScore = 7;
    private Collider2D collisionTop;
    private Collider2D collisionBot;

   /* private GameObject firstPortal;
    private GameObject secondPortal;
    private Vector3 portFirstPos;
    private Vector3 portSecondPos;*/



    private void Awake()
    { 
        
        playerUser = GameObject.Find("AirHockeyOneBlack");
        playerOpp = GameObject.Find("AirHockeyTwoBlue");
        puckObj = GameObject.Find("MovingPuck");

        puckObjRb = puckObjRb.GetComponent<Rigidbody2D>();

        scoreCheckBottom = GameObject.Find("ScoreTrigDown");
        scoreCheckTop = GameObject.Find("ScoreTrigUp");

        collisionTop = scoreCheckTop.GetComponent<Collider2D>();
        collisionBot = scoreCheckBottom.GetComponent<Collider2D>();

       /* firstPortal = GameObject.Find("PortalOne");
        secondPortal = GameObject.Find("PortalTwo");*/

    }



    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collisionPuck)
    {

        //Collider2D collidePuck = puckObj.GetComponent<Collider2D>();



        // if(collisionPuck.gameObject.CompareTag)

        if (collisionPuck.gameObject.CompareTag("userPaddle"))
        {

            //collTag = gameObject.tag;
            collTag = "userPaddle";

        }

        if (collisionPuck.gameObject.CompareTag("opponentPaddle"))
        {

            //collTag = gameObject.tag;
            collTag = "opponentPaddle";
        }


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        bool isWinner = false;
        bool isHit = true;
        int tapNum = 0;
        int oppTapNum = 0;


        if (collision.CompareTag("userPaddle"))
        {

            tapNum++;
            isHit = false;

            if (!isHit && tapNum==1)
            {
                isHit = true;
                tapNum = 0;
                userScore.text += $"{ scoreValuePlayer-1}";





            }


        }

        if (collision.CompareTag("opponentPaddle"))
        {
            oppTapNum++;
            isHit = false;

            if(!isHit && oppTapNum == 1)
            {
                isHit = true;
                oppTapNum = 0;
                userScore.text += $"{scoreValueOpponent -1}";


            }



        }

       
        
        
        
        int cleanPrint;
        

        if (collision.CompareTag("UpTrig") && collTag.Equals("userPaddle"))
        {
            

            while (isWinner== false)
            {
                scoreValuePlayer++;
                cleanPrint= scoreValuePlayer;

                userScore.text += $" {cleanPrint}";

            }

            



        }

        else if (collision.CompareTag("DownTrig") && collTag.Equals("opponentPaddle")) {


            scoreValueOpponent++;
            cleanPrint = scoreValueOpponent;

            oppScore.text += $" {cleanPrint}";
        
        
        }
        else if(collision.CompareTag("UpTrig") && collTag.Equals("opponentPaddle"))
        {
            scoreValueOpponent -= 2;
            cleanPrint = scoreValueOpponent;
            oppScore.text += $" {cleanPrint} -2 +\n+ Opponent Own Goal!";



        }

        else if(collision.CompareTag("DownTrig") && collTag.Equals("userPaddle"))
        {
            
            
            scoreValuePlayer -= 2;
            cleanPrint = scoreValueOpponent;
            userScore.text += $" {cleanPrint} -2 +\n+  Player Own Goal!";




        }







    }

    private void resetPositions()
    {
        playerUser.transform.position = new Vector2(0, -17.54f / 2);
        playerOpp.transform.position = new Vector2(0, 17.54f / 2);
        puckObj.transform.position = new Vector2(0, 0);


    }












}
