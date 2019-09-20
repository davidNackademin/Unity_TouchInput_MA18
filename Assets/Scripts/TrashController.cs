using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    bool isDragging = false;
    int fingerId = -1;
    public LayerMask trashCanLayer;
    Rigidbody2D rigidbody;
    float initialGravityScale;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        rigidbody = GetComponent<Rigidbody2D>();
        initialGravityScale = rigidbody.gravityScale;
    }


    private void Update()
    {
       // ChangeColorOnPress();

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }


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
                        rigidbody.gravityScale = 0;
                        rigidbody.velocity = Vector2.zero;

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

                        RaycastHit2D trashCanHit = Physics2D.Raycast(transform.position, Vector2.zero,
                            Mathf.Infinity, trashCanLayer);

                        if (trashCanHit.collider != null)
                        {

                            TrashcanController trashcan = trashCanHit.collider.gameObject.GetComponent<TrashcanController>();
                            trashcan.Trashed();
                            Destroy(gameObject);

                        }
                        rigidbody.gravityScale = initialGravityScale;


                        // träffar vi papperskorgen
                        // ta bort trash
                        // ge en poäng
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
