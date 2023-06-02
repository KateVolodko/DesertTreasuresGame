using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 30f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingRight = true;
    private bool facingRight = true;
    private float timeElapsed = 0f;
    private bool isFirst = true;
    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x + distance, startPosition.y, startPosition.z);
    }

    void Update()
    {
        timeElapsed += Time.deltaTime; 

        if (timeElapsed >= 5f) 
        {
            if (isFirst)
            {
                DestroySpawns();
                isFirst = false;
            }
            var targetPosition = movingRight ? endPosition : startPosition;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                movingRight = !movingRight;
                Flip();
                DestroySpawns();
            }
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void DestroySpawns()
    {
        if (this.transform.GetChild(0).childCount > 1)
        {
            Destroy(this.transform.GetChild(0).GetChild(1).gameObject);
        }
    }
}
