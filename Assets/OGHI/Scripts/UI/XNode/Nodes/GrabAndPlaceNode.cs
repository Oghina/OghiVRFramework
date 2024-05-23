using OGHI.Editor;
using OGHI.Process;
using System.Collections;
using UnityEngine;

namespace OGHI.Editor
{
    public class GrabAndPlaceNode : ProcessStepNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.None, false)] public int entry;
        [Output(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.None, false)] public int exit;

        public GameObject objectToPlace;
        public Transform location;

        private GrabAndPlaceStep step;
        public override string PortFieldName { get; set; }
        public override bool IsStepFinished { get; set; }
        public override IProcessStep ProcessStep 
        {
            get
            {
                if (step == null)
                {
                    step = new GrabAndPlaceStep(this); 
                }
                return step;
            }
        }
    }
}
