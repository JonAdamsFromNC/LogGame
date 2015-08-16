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


	public class Node {
		Edge[] outgoingEdges;
	}


	public class Edge {
		Node entryNode;
		Node exitNode;
	}
}

