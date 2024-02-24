using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputBehavoiurs : MonoBehaviour, IInputs
{
    public abstract bool Jumping();
    public abstract Vector3 Directions();
}
