using System.Collections;
using UnityEngine;
using XNode;

namespace OGHI.Editor
{
    public class StartNode : ProcessStepNode
    {
        [Output] public int exit;

        public override string GetName()
        {
            return "Start";
        }

        public override object GetValue(NodePort port)
        {
            return port.GetInputValue();
        }

        public override void InitializeStep()
        {
            Debug.Log(GetName() + " initialized");
        }

        public override IEnumerator UpdateStep()
        {
            Debug.Log(GetName() + " updating");
            yield return new WaitForSeconds(3f);
            PortFieldName = "exit";
            Debug.Log(GetName() + " finished");
        }
    }
}
