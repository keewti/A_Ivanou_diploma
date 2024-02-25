using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class KeyboardInputs : InputBehavoiurs
{
    public override Vector3 Directions()
    {
        var inputs = new Vector3
        {
            x = Input.GetAxis("Horizontal"),
            y = 0,
            z = 0
        };
        return inputs;
    }
    public override bool Jumping()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    public override bool Attacking()
    {
        return Input.GetKeyDown(KeyCode.W);
    }
}
