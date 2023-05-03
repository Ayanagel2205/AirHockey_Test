using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignSpecs : MonoBehaviour
{
    Vector2 getRectDimensions;
    Vector2 rectDimensions;
    Vector2 rectBreadth;
    Vector2 rectHeight;
    [SerializeField] float rectHeightValue;
    [SerializeField] float rectBreadthValue;

    private Vector3 rectBounds;

    [SerializeField] float obtainedH = 34.95097f;
    [SerializeField] float obtainedB = 25.40481f;

    [SerializeField] float obtainedHeight = 35.08f;
    [SerializeField] float obtainedBreadth = 24.80266f;
    [SerializeField] float obtainedRectHalfX = 12.40f;
    [SerializeField] float obtainedRectHalfY = 17.54f;

    [SerializeField] float obtainedPlayerBoundsX = 3.95f;
    [SerializeField] float obtainedPlayerBoundsY = 3.56f;

    [SerializeField] float obtainedPlayerPiecePosX = 8.451328f;
    [SerializeField] float obtainedPlayerPiecePosY = 13.98333f;
    [SerializeField] float obtainedBoundsNewY = 13.98333f / 2f;

    [SerializeField] float obtainedPuckX = 2f;
    [SerializeField] float obtainedPuckY = 2f;
    [SerializeField] float obtainedPuck = 1f;


    private GameObject playerCircle;
    private Vector2 getCircleDimensions;
    private float circleRadius;
    private float circleDiametre;
    private GameObject puckGObj;


    private void Awake()
    {
        playerCircle = GameObject.Find("AirHockeyOneBlack");
        getRectDimensions = gameObject.GetComponent<SpriteRenderer>().bounds.extents;

        getCircleDimensions = playerCircle.GetComponent<SpriteRenderer>().bounds.extents;
        puckGObj = GameObject.Find("MovingPuck");


    }



    void Start()
    {



        getRectTableInfo();
        getPlayerBounds();
        calcPositionXBounds();
        calcPositionYBounds();
        getPuckValues();






    }

    // Update is called once per frame
    void Update()
    {

    }


    private void getRectTableInfo()
    {



        rectBounds = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        Debug.Log("Bounds Literal Distance value i.e. half full length" + rectBounds);
        rectDimensions.x = transform.position.x + getRectDimensions.x;

        Debug.Log("Side posX from centre:" + rectDimensions.x);
        //rectBreadth.x = 2 * rectDimensions.x;
        rectBreadth.x = 2 * getRectDimensions.x;

        rectDimensions.y = transform.position.y + getRectDimensions.y;
        Debug.Log("Side posY from centre:" + rectDimensions.y);
        //rectHeight.y = 2* rectDimensions.y;
        rectHeight.y = 2 * getRectDimensions.y;

        rectHeightValue = rectHeight.y;
        rectBreadthValue = rectBreadth.x;
        Debug.Log("Width: " + rectBreadthValue + "Height: " + rectHeightValue);



    }

    private void getPlayerBounds()
    {


        Debug.Log(getCircleDimensions);


    }

    private void calcPositionXBounds()
    {

        float differenceXPos = getRectDimensions.x - getCircleDimensions.x;
        Debug.Log(differenceXPos);



    }

    private void calcPositionYBounds()
    {

        float differenceYPos = getRectDimensions.y - getCircleDimensions.y;
        Debug.Log(differenceYPos);

    }


    private void getPuckValues()
    {

        Vector3 puckBoundsValue = puckGObj.gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        Debug.Log("Puck X Value " +puckBoundsValue.x);
        Debug.Log("Puck Y Value "+ puckBoundsValue.y);
        Debug.Log("Puck RadiusX " + (puckBoundsValue.x / 2));
        Debug.Log("Puck RadiusY " + (puckBoundsValue.y / 2));


    }



}
