using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class LeverNode : ProcessStepNode
{
    [Input] public List<int> entry;
    [Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)] public int exit;

    public Transform objectToRotate;
    public float rotationAngle;
    public RotationAxis rotationAxis;

    public enum RotationAxis { x, y, z };

    
    public override object GetValue(NodePort port)
    {
        return this;
    } 
}
