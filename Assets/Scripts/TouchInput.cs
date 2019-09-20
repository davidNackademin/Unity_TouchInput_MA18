using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    bool isDragging = false;
    int fingerId = -1;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }


    private void Update()
    {
       // ChangeColorOnPress();

        foreach( Touch touch  in Input.touches)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            switch(touch.phase)
            {

                case TouchPhase.Began:
                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        isDragging = true;
                        fingerId = touch.fingerId;


                    }
                    break;
                case TouchPhase.Moved:
                    if (isDragging && touch.fingerId == fingerId)
                    {
                        transform.position = touchPosition;
                    }


                    break;
                case TouchPhase.Ended:
                    if (isDragging && touch.fingerId == fingerId)
                    {
                        isDragging = false;
                        fingerId = -1;
                    }


                    break;
            }



        }


    }






    void ChangeColorOnPress()
    {
        foreach (Touch touch in Input.touches)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                spriteRenderer.color = Color.yellow;
                return;
            }
        }

        spriteRenderer.color = Color.red;
    }




}
