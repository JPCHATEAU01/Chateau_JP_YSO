using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    Vector2 startPoint, endPoint, initialPosition;
    bool isTouch;
    bool isTouchMove;
    
    void Start()
    {
        initialPosition = transform.position;
        isTouchMove = false;
        isTouch = false;
    }

    void Update()
    {
        if (!GameManager.Instance().GetPaused() && !LevelManager.Instance().IsEnded())
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (!isTouch)
                {
                    startPoint = touch.deltaPosition;
                    isTouch = true;
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    isTouchMove = true;
                    endPoint = touch.deltaPosition;
                }
            }
            else
            {
                SetInitialPosition();
            }

            if (isTouchMove)
            {
                Vector2 offset = endPoint - startPoint;
                //Debug.Log("Joystick2_FixedUpdate" + offset);
                Vector2 direction = Vector2.ClampMagnitude(offset, 0.3f);
                transform.position = new Vector2(initialPosition.x + direction.x, initialPosition.y + direction.y);
                MovePlayer(direction);
            }
        }
        else
        {
            SetInitialPosition();
        }
    }

    void SetInitialPosition()
    {
        isTouch = false;
        isTouchMove = false;
        transform.position = initialPosition;
    }
    void MovePlayer(Vector2 direction)
    {
        LevelManager.Instance().MovePlayer(direction);
    }
}