using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayer : MonoBehaviour
{

    private float speed = 2;
    private Touch touch;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
        if (Input.touchCount > 0) 
        {
            Debug.Log("hehehe");
            touch = Input.GetTouch(0);
            if(touch.phase==TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z);
                    
            }

        }
    }
    //bool swipeRight = false;
    //bool swipeLeft = false;
    //bool touchBlock = true;
    //bool canTouchRight = true;
    //bool canTouchLeft = true;

    //void Update()
    //{

    //    TouchControl();

    //}

    //void TouchControl()
    //{

    //    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && touchBlock == true)
    //    {
    //        touchBlock = false;
    //        // Get movement of the finger since last frame
    //        var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
    //        Debug.Log("touchDeltaPosition " + touchDeltaPosition);

    //        if (touchDeltaPosition.x > 0 && canTouchRight == true)
    //        {
    //            //rightMove
    //            swipeRight = true; canTouchRight = false;
    //            Invoke("DisableSwipeRight", 0.2f);
    //        }
    //        else if (touchDeltaPosition.x < 0 && canTouchLeft == true)
    //        {
    //            //leftMove
    //            swipeLeft = true; canTouchLeft = false;
    //            Invoke("DisableSwipeLeft", 0.2f);
    //        }
    //    }
    //}
    //void DisableSwipeLeft()
    //{
    //    swipeLeft = false;
    //    touchBlock = true;
    //    canTouchLeft = true;
    //}
    //void DisableSwipeRight()
    //{
    //    swipeRight = false;
    //    touchBlock = true;
    //    canTouchRight = true;
    //}
}