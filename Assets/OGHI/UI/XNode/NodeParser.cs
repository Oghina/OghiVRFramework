using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class NodeParser : MonoBehaviour
{
    public ProcessStepsGraph graph;
    Coroutine _parser;

    public Text stepName;
    public Text header;
    public Text subHeader;

    List<ProcessStepNode> newNodes = new List<ProcessStepNode>();
    private List<ProcessStepNode> futureStepsReferences = new List<ProcessStepNode>();

    private ProcessStepNode processNode;

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
                graph.current = new List<ProcessStepNode>();
                graph.current.Add(p);

                break;
            }
        }

        _parser = StartCoroutine(ParseNode());
    }

    IEnumerator ParseNode()
    {
    //    ProcessStepNode p = graph.current;
    //    stepName.text = p.GetName();
    //    header.text = p.GetHeader();
     //   subHeader.text = p.GetSubHeader();

        foreach (ProcessStepNode p in graph.current)
        {
            Debug.Log(p.GetName());
        } 

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));

        NextNode("exit");
    }

    public void NextNode(string fieldName)
    {
        newNodes.Clear();
        if (_parser != null)
        {
            StopCoroutine(_parser);
            _parser = null;
        }
        for (int i = 0; i < graph.current.Count; i++)
        {
            foreach (NodePort p in graph.current[i].Ports)
            {
                // Check if this port is the one we're looking for
                if (p.fieldName == fieldName)
                {
                    processNode = p.Connection.node as ProcessStepNode;                    

                    if (processNode.GetName() == "Finish")
                    {
                        Debug.Log("Training finished!");
                        return;
                    }
                    else
                    {
                        newNodes.Add(processNode);
                        if (futureStepsReferences.Count > 1)
                        {
                            for (int j = 1; j < futureStepsReferences.Count; j++)
                            {
                                
                                newNodes.Add(futureStepsReferences[j]);
                            }
                        }
                        //         graph.current[i] = processNode;
                    //    break;
                    } 
                }
            }
        }

        futureStepsReferences.Clear();

        List<NodePort> nodes = processNode.GetPort(fieldName).GetConnections();
        foreach (NodePort p in nodes)
        {
            futureStepsReferences.Add(p.node as ProcessStepNode);
        }

        processNode = null;

        graph.current.Clear();
        graph.current.AddRange(newNodes);
        
        _parser = StartCoroutine(ParseNode());
    }
}
