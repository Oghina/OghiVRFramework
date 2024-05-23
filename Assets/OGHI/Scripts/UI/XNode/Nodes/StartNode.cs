using OGHI.Process;
using System.Collections;
using XNode;

namespace OGHI.Editor
{
    public class StartNode : ProcessStepNode
    {
        [Output] public int exit;

        public override string PortFieldName { get => "exit"; set => throw new System.NotImplementedException(); }
        public override bool IsStepFinished { get; set; }

        private IProcessStep step;
        public override IProcessStep ProcessStep
        {
            get
            {
                if (step == null)
                {
                    step = new StartStep(this);
                }
                return step;
            }
        }

        public override string GetName()
        {
            return "Start";
        }
    }
}
