using OGHI.Process;
using System.Collections;
using UnityEngine;

namespace OGHI.Editor
{
    public class FinalNode : ProcessStepNode
    {
        [Input] public int entry;

        public override string PortFieldName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override bool IsStepFinished { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override IProcessStep ProcessStep => throw new System.NotImplementedException();

        public override string GetName()
        {
            return "Finish";
        }

    }
}
