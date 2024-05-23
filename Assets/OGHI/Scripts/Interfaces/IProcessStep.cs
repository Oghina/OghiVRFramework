using OGHI.Editor;
using System;
using System.Collections;

namespace OGHI.Process
{
    public interface IProcessStep
    {
        public void InitializeStep();

        public IEnumerator UpdateStep();

        public void FinishStep(string fieldName);
    }
}
