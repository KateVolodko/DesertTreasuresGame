using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        GameObject[] control_object = GameObject.FindGameObjectsWithTag("Control");
        GameObject[] controlEmpty_object = GameObject.FindGameObjectsWithTag("ControlEmpty");
        var controlCout = control_object.Length + controlEmpty_object.Length;

        var totalCount = 0;
        foreach ( var obj in control_object)
            if (obj.gameObject.GetComponent<Renderer>().material.color == Color.green) totalCount++;
        foreach ( var obj in controlEmpty_object)
            if (obj.gameObject.GetComponent<Renderer>().material.color == Color.white) totalCount++;
        if (totalCount == controlCout)
            SceneManager.LoadScene(1);
    }
}
