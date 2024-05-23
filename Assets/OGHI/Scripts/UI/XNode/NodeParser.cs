using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XNode;

namespace OGHI.Editor
{
    public class NodeParser : MonoBehaviour
    {
        public ProcessStepsGraph graph;

        public Text stepName;
        public Text header;
        public Text subHeader;

        private Coroutine _parser;

        private void Start()
        {
            if (graph == null)
            {
                SceneGraph sceneGraph = GetComponent<SceneGraph>();
                graph = (ProcessStepsGraph)sceneGraph.graph;
            }

            foreach (ProcessStepNode p in graph.nodes)
            {
                if (p.GetName() == "Start")
                {
                    //Make this node the starting point
                    graph.current = p;
                    break;
                }
            }
            _parser = StartCoroutine(ParseNode());
        }

        IEnumerator ParseNode()
        {
            graph.current.ProcessStep.InitializeStep();
            StartCoroutine(graph.current.ProcessStep.UpdateStep());

            while (!graph.current.IsStepFinished)
            {
                yield return graph.current.ProcessStep.UpdateStep();
            }

            if (string.IsNullOrEmpty(graph.current.PortFieldName)) 
            {
                Debug.LogError("PortFieldName is empty!! Dont know in which direction to send the output");
            }
            StartNextNode(graph.current.PortFieldName);
        }

        public void StartNextNode(string fieldName)
        {
            if (_parser != null)
            {
                StopCoroutine(_parser);
                _parser = null;
            }

            foreach (NodePort p in graph.current.Ports)
            {
                //Check if this is the one we're looking for
                if (p.fieldName == fieldName)
                {
                    graph.current = p.Connection.node as ProcessStepNode;
                    break;
                }
            }
            if (graph.current is FinalNode)
            {
                Debug.Log("Finished training!");
                return;
            }
            _parser = StartCoroutine(ParseNode());

        }
    }
}
