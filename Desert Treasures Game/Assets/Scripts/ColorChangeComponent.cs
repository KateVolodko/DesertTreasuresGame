using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ColorChangeComponent : MonoBehaviour
{
    public State State { get;  set; }

    // Start is called before the first frame update
    void Start()
    {
        State = State.Disabled;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.color = State == State.Enabled ? Color.green : Color.white;

    }
}
