using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StartNode : ProcessStepNode
{
    [Output] public int exit;

    public override string GetName()
    {
        return "Start";
    }

    public override object GetValue(NodePort port)
    {
        return port.GetInputValue();
    }
}
