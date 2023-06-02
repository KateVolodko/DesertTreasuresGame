using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FigureController : MonoBehaviour
{

    public static int levelNumber;
    private int bonus;
    private bool canRotate;
    private float timeElapsed = 0f;
    public float delay = 5f;
    private HashSet<string> tagsTrigger = new HashSet<string>() { "Control", "ControlEmpty"};
    private HashSet<string> tagsCollision = new HashSet<string>() { "Figure1", "Grid" };
    void Start()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        bonus = 100;
        canRotate = true;
    }

    void Update()
    {
        NeedToBuildComponent[] colorChangeComponents = FindObjectsOfType<NeedToBuildComponent>();
        timeElapsed += Time.deltaTime;
        bool allGreen = true;

        if (canRotate)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) { transform.Rotate(Vector3.forward, 90f); }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { transform.Rotate(Vector3.forward, -90f); }
        }
        

        foreach (NeedToBuildComponent colorChangeComponent in colorChangeComponents)
        {
            if (colorChangeComponent.State != State.Enabled)
            {
                allGreen = false;
                break;
            }
        }

        if (allGreen && timeElapsed >= delay)
        {
            CoinText.coin += bonus;
            if (levelNumber != 11)
                SceneManager.LoadScene(12);
            else
                SceneManager.LoadScene(13);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tagsCollision.Contains(collision.gameObject.tag)) 
            canRotate = false;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {        
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            CoinText.coin += 1;
        }
        else if (other.gameObject.tag =="FineArea") 
        { 
            CoinText.coin -= 10;
            canRotate = false;
        }
        if (tagsTrigger.Contains(other.gameObject.tag)) 
            canRotate = false;
    }
}
