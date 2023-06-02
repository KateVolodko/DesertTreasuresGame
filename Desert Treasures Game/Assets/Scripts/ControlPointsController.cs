using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPointsController : MonoBehaviour
{
    private HashSet<int> figureIds;
    private int change;
    private NeedToBuildComponent controlColor;
    private EmptyComponent controlEmpty;

    private void Start()
    {
        var levelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        figureIds = new HashSet<int>();
        change = levelNumber * 2;
        controlColor = this.gameObject.GetComponent<NeedToBuildComponent>();
        controlEmpty = this.gameObject.GetComponent<EmptyComponent>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Figure1"))
        {
            int id = other.gameObject.GetInstanceID();
            figureIds.Add(id);
            if (controlColor != null) { CoinText.coin += change; }
            else if (controlEmpty != null) { CoinText.coin -= change; }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Figure1"))
        {
            int id = other.gameObject.GetInstanceID();
            figureIds.Remove(id);
            if (controlColor != null) { CoinText.coin -= change;}
        }
    }

    private void Update()
    {
        if (figureIds.Count > 0)
        {
            if (controlColor != null){ controlColor.State = State.Enabled;}
            else if (controlEmpty != null) { controlEmpty.State = State.Enabled;}
        }
        else
        {
            if (controlEmpty != null) { controlEmpty.State = State.Disabled; }
            if (controlColor != null) { controlColor.State = State.Disabled; }
        }
    }
   
}
