using OGHI.Editor;
using OGHI.Process;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class LeverStep: IProcessStep
{
    public Transform objectToRotate;
    public float angle;

    private ProcessStepNode node;
    public LeverStep (ProcessStepNode node)
    {
        this.node = node;
    } 

    public void InitializeStep()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator UpdateStep()
    {
        throw new System.NotImplementedException();
    }

    public void FinishStep(string fieldName)
    {
        throw new System.NotImplementedException();
    }
}
