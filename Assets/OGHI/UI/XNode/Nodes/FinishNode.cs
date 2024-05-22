using System.Collections;
using UnityEngine;

namespace OGHI.Editor
{
    public class FinishNode : ProcessStepNode
    {
        [Input] public int entry;

        public override string GetName()
        {
            return "Finish";
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
