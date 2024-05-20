using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : ProcessStepNode
{
    [Output] public int exit;

    public override string GetName()
    {
        return "Start";
    }
}
