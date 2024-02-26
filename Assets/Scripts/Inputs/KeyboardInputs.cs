using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class KeyboardInputs : InputBehavoiurs
{
    public override float Directions()
    {
        return Input.GetAxis("Horizontal");
    }
    public override bool Jumping()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    public override bool Attacking()
    {
        return Input.GetKeyDown(KeyCode.LeftControl);
    }
}
