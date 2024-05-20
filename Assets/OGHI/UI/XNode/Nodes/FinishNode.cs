using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishNode : ProcessStepNode
{
    [Input] public int entry;

    public override string GetName()
    {
        return "Finish";
    }

    public void LogFinish()
    {
        Debug.Log("Finished: " + this.GetName());
    }
}
