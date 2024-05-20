using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ProcessStepNode : Node {

    public string stepName;
	public string header;
	public string subHeader;

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
}