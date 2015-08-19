using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RoadNetworkGraph : MonoBehaviour {

	public bool debugLanesVisible = true;

	// Use this for initialization
	void Start () {
		//read in info from all road entities to build graph


		//define your dicts
		Dictionary<int, Node> nodesDict = new Dictionary<int, Node>();
		Dictionary<int, Edge> edgesDict = new Dictionary<int, Edge>();

		//find the roads

		//extract the travel lanes

		//loop through the travel lines and define two nodes and an edge

		//find travel lanes
		List<GameObject> foundRoads = new List<GameObject>();
		foundRoads = GameObject.FindGameObjectsWithTag ("road").ToList();
		List<NavDef.Lane> foundLanes = new List<NavDef.Lane> ();
		foreach (GameObject foundRoad in foundRoads){
			//for (int i = 0; i < foundRoad.GetComponent<NavDef>().lanes.Length; i++){
			foreach (NavDef.Lane thisLane in foundRoad.GetComponent<NavDef>().lanes){
				foundLanes.Add (thisLane);
			}
		}

		int nodeIterator = 0;
		int edgeIterator = 0;
		foreach (NavDef.Lane foundLane in foundLanes)
		{
			//Debug.Log (foundLane.GetComponent<NavDef>().lanes[0].entryPt);
			//Debug.Log (foundLane.transform.TransformPoint(foundLane.GetComponent<NavDef>().lanes[0].entryPt));

			//first add an edge, and a new node at both ends
			Edge thisEdge = new Edge ();
			thisEdge.maxSpeed = foundLane.maxSpeed;
			thisEdge.midSpan = foundLane.midPt;
			Node thisEntryNode = new Node ();
			Node thisExitNode = new Node ();
			thisEntryNode.outgoingEdges.Add (thisEdge);
			thisEntryNode.worldCoords = foundLane.entryPt;
			thisEdge.entryNode = thisEntryNode;
			thisEdge.exitNode = thisExitNode;
			
			nodesDict.Add (nodeIterator, thisEntryNode);
			thisEntryNode.nodeID = nodeIterator;
			nodeIterator ++;
			nodesDict.Add (nodeIterator, thisExitNode);
			thisExitNode.nodeID = nodeIterator;
			nodeIterator ++;
			edgesDict.Add (edgeIterator, thisEdge);
			thisEdge.edgeID = edgeIterator;
			edgeIterator ++;
		}

		//after looping through all edges, loop back through the nodes list and eliminate down to only unique nodes on worldcoords
//		foreach(KeyValuePair<int, Node> entry in nodesDict)
//		{
//			foreach(KeyValuePair<int, Node> entry2 in nodesDict)){
//				// do something with entry.Value or entry.Key
//				if (entry.Key != entry2.key){
//					if (entry.Value.worldCoords == entry2.value.worldcoords){
//
//					}
//				}
//			}
//		}

		///WORKING ON THIS
		nodesDict.GroupBy(


		//debug print each node with outgoing edges to test our combining strat
		foreach(KeyValuePair<int, Node> entry in nodesDict)
		{
			if (entry.Value.outgoingEdges.Count != 0){
			// do something with entry.Value or entry.Key
				Debug.Log ("Node ID: " + entry.Key + ". Number of Outgoing edges: " + entry.Value.outgoingEdges.Count);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public class Node 
	{
		public List<Edge> outgoingEdges = new List<Edge>();
		public Vector2 worldCoords;
		public int nodeID;
	}


	public class Edge {
		public Node entryNode;
		public Node exitNode;
		public Vector2 midSpan; //to give enough information to calculate length, and to draw debug path lines
		public float maxSpeed;
		public int edgeID;
	}
}

