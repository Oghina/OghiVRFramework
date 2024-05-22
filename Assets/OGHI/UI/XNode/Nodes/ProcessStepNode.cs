using System.Collections;
using UnityEngine;
using XNode;

namespace OGHI.Editor
{
    public abstract class ProcessStepNode : Node
    {
        public string stepName;
        public string header;
        public string subHeader;

        public string PortFieldName { get; protected set; }

        public virtual string GetName()
        {
            return stepName;
        }

        public virtual string GetHeader()
        {
            return header;
        }

        public virtual string GetSubHeader()
        {
            return subHeader;
        }

        public virtual void LogTest()
        {
            Debug.Log("Lever " + GetName());
        }

        public abstract void InitializeStep();

        public abstract IEnumerator UpdateStep();
    }
}
