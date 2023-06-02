using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FigureDrop : MonoBehaviour
{
    public GameObject parentObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (parentObject.transform.childCount > 1)
            {
                Transform childToRemove = parentObject.transform.GetChild(1);
                childToRemove.parent = null;
                childToRemove.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
    }
}
