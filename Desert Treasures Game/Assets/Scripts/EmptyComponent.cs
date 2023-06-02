using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EmptyComponent : MonoBehaviour
{
    public State State { get; set; }

    void Start()
    {
        State = State.Disabled;
    }

    void Update()
    {
        gameObject.GetComponent<Renderer>().material.color = State == State.Enabled ? Color.yellow : Color.red;

    }
}
