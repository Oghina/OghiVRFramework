using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using XNode;

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
        Debug.Log(graph.current.GetName());

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));

        StartNextNode("exit");
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
        if (graph.current is FinishNode)
        {
            Debug.Log("Finished training!");
            return;
        }
        _parser = StartCoroutine(ParseNode());
    }
}
