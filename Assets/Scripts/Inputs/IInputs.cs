using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public interface IInputs
{
    public float Directions();
    public bool Jumping();
    public bool Attacking();
}
