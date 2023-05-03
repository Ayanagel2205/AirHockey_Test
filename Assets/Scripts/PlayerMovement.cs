using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private Vector2 mouseWorldPos;
    private Vector2 overlapvalue;
    private Vector2 currentPlayerPos;
    [SerializeField] Vector2 pushValue = new Vector2(1,1);


    
   private bool wasClicked;
   private bool canDrag;
   private Vector2 playerSlider;
   private Vector3 screenMousePos;
   private Vector2 sliderHoriBound;
   private Vector2 sliderVertBound;

    private Rigidbody2D playerRB;
    private Collider2D dragCollider;
    private GameObject mainPlayer;
    private Vector3 offset;
    private Rigidbody2D dragRb;

   

    

    
    float test;




    private void Awake()
    {
        playerSlider = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        sliderHoriBound.x = transform.position.x + playerSlider.x;
        sliderVertBound.y = transform.position.y + playerSlider.y;
        mainPlayer = GameObject.Find("AirHockeyOneBlack");

        playerRB = mainPlayer.gameObject.GetComponent<Rigidbody2D>();
        //dragCollider = mainPlayer.GetComponent<Collider2D>();
        

        

        

        //getBoundariesInfo(boundaryConObj);
        //getBoundariesInfoInvert(boundaryConObj);

        



    }



    void Start()
    {
        
        
        

    }

    // Update is called once per frame
    void Update()
    {

       

        screenMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragCollider = Physics2D.OverlapPoint(screenMousePos);

        if (Input.GetMouseButtonDown(0) && dragCollider)
        {

                offset = playerRB.transform.position - screenMousePos;
            dragRb = mainPlayer.gameObject.GetComponent<Rigidbody2D>(); 

        }

        if (Input.GetMouseButtonUp(0) && mainPlayer) {

            dragRb = null;
        
        
        }







    }

    private void FixedUpdate()
    {

        if (dragRb) {
            Vector2 dragPos = screenMousePos + offset;

            playerRB.MovePosition( new Vector2(Mathf.Clamp(dragPos.x, -12.4f+ 3.95f, 12.4f - 3.95f),  Mathf.Clamp(dragPos.y, - 17.54f + 3.95f, -3.95f))  );/*screenMousePos + offset*/ 
        
        }

    }



    

    





    
    
    








}
