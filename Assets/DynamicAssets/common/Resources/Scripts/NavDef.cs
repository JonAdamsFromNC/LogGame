using UnityEngine;
using System.Collections;




//this describes the inlet and outlet nodes, edge shape, and edge characteristics such as max speed, etc
//the road graph builder reads the objects from this script

public class NavDef : MonoBehaviour {

	public Lane firstLane;
	public Lane secondLane;
	public Lane thirdLane;
	public Lane fourthLane;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//weight is calculated by some function of length, max speed, and actual average speed (congestion factor)
	[System.Serializable]
	public class Lane {
		public Vector2 entryPt;
		public Vector2 midPt;
		public Vector2 exitPt;
		float weight;

	}
}

