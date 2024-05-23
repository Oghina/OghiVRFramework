using OGHI.Editor;
using OGHI.Process;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndPlaceStep : IProcessStep
{
    private GameObject objectToPlace;
    private Transform location;
    private ProcessStepNode node;
    public GrabAndPlaceStep(GrabAndPlaceNode node)
    {
        this.objectToPlace = node.objectToPlace;
        this.location = node.location;
        this.node = node;
        node.IsStepFinished = false;
    }

    public void InitializeStep()
    {
        Debug.Log(node.GetName() + " initialized!");
    }

    public IEnumerator UpdateStep()
    {
        Debug.Log(node.GetName() + " updating!");
        yield return null;
    }

    public void FinishStep(string fieldName)
    {
        node.PortFieldName = fieldName;
        node.IsStepFinished = true;
    }
}
