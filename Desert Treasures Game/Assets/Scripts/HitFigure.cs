using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class HitFigure : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        var controlColor = other.gameObject.GetComponent<ColorChangeComponent>();
        var emptyColor = other.gameObject.GetComponent<EmptyComponent>();
        if (controlColor != null)
        {
            controlColor.State = (controlColor.State == State.Enabled ? State.Disabled : State.Enabled);
        }
        if (emptyColor != null)
        {
            emptyColor.State = (emptyColor.State == State.Enabled ? State.Disabled : State.Enabled);
        } 
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var controlColor = other.gameObject.GetComponent<ColorChangeComponent>();
        var emptyColor = other.gameObject.GetComponent<EmptyComponent>();
        if (controlColor != null)
        {
            controlColor.State = (controlColor.State == State.Enabled ? State.Disabled : State.Enabled);
        }

        if (emptyColor != null)
        {
            emptyColor.State = (emptyColor.State == State.Enabled ? State.Disabled : State.Enabled);
        }  
    }
}
