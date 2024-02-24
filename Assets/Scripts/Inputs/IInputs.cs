using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public interface IInputs
{
    public Vector3 Directions();
    public bool Jumping();
}
