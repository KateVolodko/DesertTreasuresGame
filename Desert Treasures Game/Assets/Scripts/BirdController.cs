using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 30f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingRight = true;
    private bool facingRight = true;

    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x + distance, startPosition.y, startPosition.z);
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            if (transform.position == endPosition)
            {
                movingRight = false;
                Flip();
                DestroySpawns();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (transform.position == startPosition)
            {
                movingRight = true;
                Flip();
                DestroySpawns();
            }
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void DestroySpawns()
    {
        if (this.transform.GetChild(0).childCount > 1)
            Destroy(this.transform.GetChild(0).GetChild(1).gameObject);
    }
}
