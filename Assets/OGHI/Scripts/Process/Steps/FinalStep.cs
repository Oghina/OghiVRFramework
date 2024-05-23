using OGHI.Editor;
using System.Collections;
using UnityEngine;

namespace OGHI.Process
{
    public class FinalStep : IProcessStep
    {
        private ProcessStepNode node;

        public FinalStep(ProcessStepNode node)
        {
            this.node = node;
        }

        public void InitializeStep()
        {
            Debug.Log("Finished training");
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
}
