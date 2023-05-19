using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FigureHold : MonoBehaviour
{
    public GameObject parentObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform childToRemove = parentObject.transform.GetChild(1);
            childToRemove.parent = null;
            childToRemove.GetComponent<Rigidbody2D>().simulated = true;
        }
    }
}
