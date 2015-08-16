using UnityEngine;
using System.Collections;

public class RoadNetworkGraph : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//read in info from all road entities to build graph
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	[System.Serializable]
	public class Node {
		Edge[] outgoingEdges;
	}
	[System.Serializable]
	public class Edge {
		Node entryNode;
		Node exitNode;
	}
}

