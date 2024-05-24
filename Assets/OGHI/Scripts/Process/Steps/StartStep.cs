using OGHI.Editor;
using System.Collections;
using UnityEngine;

namespace OGHI.Process
{
    public class StartStep : IProcessStep
    {
        private readonly ProcessStepNode node;
        public StartStep(ProcessStepNode node)
        {
            this.node = node;
        }

        public void InitializeStep()
        {
            Debug.Log("Start initialised");
        }

        public IEnumerator UpdateStep()
        {
            Debug.Log("Updated start");
            node.IsStepFinished = true;
            yield return null;
        }

        public void FinishStep(string fieldName)
        {
            throw new System.NotImplementedException();
        }
    }
}
