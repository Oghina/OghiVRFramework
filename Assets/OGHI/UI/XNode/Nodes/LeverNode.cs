using System.Collections;
using UnityEngine;
using XNode;

namespace OGHI.Editor
{
    public class LeverNode : ProcessStepNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)] public int entry;
        [Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)] public int exit;
        [Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)] public int exit2;

        public Transform objectToRotate;
        public float rotationAngle;
        public RotationAxis rotationAxis;

        public enum RotationAxis { x, y, z };

        public override object GetValue(NodePort port)
        {
            return this;
        }

        public override void InitializeStep()
        {
            Debug.Log(GetName() + " initialized");
        }

        public override IEnumerator UpdateStep()
        {
            Debug.Log(GetName() + " updating");
            yield return new WaitForSeconds(3f);
            PortFieldName = "exit2";
            Debug.Log(GetName() + " finished");
        }
    }
}
