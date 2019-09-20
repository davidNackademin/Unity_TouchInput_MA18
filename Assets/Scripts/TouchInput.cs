using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{

    SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }


    private void Update()
    {
        foreach( Touch touch in Input.touches)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject )
            {
                spriteRenderer.color = Color.yellow;
                return;
            }
        }

        spriteRenderer.color = Color.red;

    }






}
