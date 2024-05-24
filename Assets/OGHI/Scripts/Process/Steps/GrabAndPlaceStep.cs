using BNG;
using OGHI.Editor;
using OGHI.Process;
using OGHI.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndPlaceStep : IProcessStep
{
    private readonly GameObject objectToPlace;
    private readonly Transform location;
    private readonly ProcessStepNode node;

    private GrabbableUnityEvents grabbableUnityEvents;
    private SnapZone snapZone;

    public GrabAndPlaceStep(GrabAndPlaceNode node)
    {
        this.objectToPlace = node.objectToPlace;
        this.location = node.location;
        this.node = node;
        node.IsStepFinished = false;
    }

    public void InitializeStep()
    {
        Grabbable grabbable = ResourcesController.Instance.CreateGrabbable(objectToPlace, out grabbableUnityEvents);
        snapZone = ResourcesController.Instance.CreateSnapzone(grabbable, location);
        grabbableUnityEvents.onSnapZoneEnter.AddListener(CoFinishStep);
    }

    public IEnumerator UpdateStep()
    {
        yield return null;
    }

    private void CoFinishStep()
    {
        FinishStep("exit");
    }

    public void FinishStep(string fieldName)
    {
        grabbableUnityEvents.onSnapZoneEnter.RemoveListener(CoFinishStep);

        ResourcesController.Instance.MakeUngrabbable(objectToPlace, snapZone);

        node.PortFieldName = fieldName;
        node.IsStepFinished = true;
    }
}
