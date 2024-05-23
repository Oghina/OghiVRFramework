using OGHI.Process;
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

        public abstract string PortFieldName { get; set; }
        public abstract bool IsStepFinished { get; set; }
        public abstract IProcessStep ProcessStep { get; }

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
    }
}
