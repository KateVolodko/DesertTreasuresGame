using System.Collections;
using UnityEngine;

public class TeleportPointController : MonoBehaviour
{
    public GameObject teleport;
    private GameObject figure;

    private void Start()
    {
        figure = GameObject.FindWithTag("Figure1");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Figure1")
        {
            collision.transform.position = new Vector2(teleport.transform.position.x, teleport.transform.position.y);
        }
    }
}
