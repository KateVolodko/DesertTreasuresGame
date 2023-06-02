using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExtraBuildController : MonoBehaviour
{
    public GameObject extraBuild;
    public float unvisibleTime = 18f;
    public float speed = 4f;
    public float distance = 15f;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private bool hide = true;
    private bool movingRight = true;

    void Start()
    {
        if (hide)
        {
            Invoke("ShowObject", unvisibleTime);
            hide = false;
            startPosition = transform.position;
            endPosition = new Vector3(startPosition.x + distance, startPosition.y, startPosition.z);
        }
            
    }
    void Update()
    {
        if (!hide)
        {
            extraBuild.transform.position = movingRight ?
                Vector3.MoveTowards(extraBuild.transform.position, endPosition, speed * Time.deltaTime) :
                Vector3.MoveTowards(extraBuild.transform.position, startPosition, speed * Time.deltaTime);

            if (extraBuild.transform.position == endPosition || extraBuild.transform.position == startPosition)
            {
                movingRight = !movingRight;
            }
        }
    }

    void ShowObject()
    {
        extraBuild.SetActive(true);
    }
}