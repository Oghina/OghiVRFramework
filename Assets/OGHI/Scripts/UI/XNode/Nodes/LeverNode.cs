using OGHI.Process;
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

        private LeverStep step;
        public override string PortFieldName { get; set; }
        public override bool IsStepFinished { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public enum RotationAxis { x, y, z };

        public override IProcessStep ProcessStep
        {
            get
            {
                if (step == null)
                {
                    step = new LeverStep(this);
                }
                return step;
            }
        }
    }
}
