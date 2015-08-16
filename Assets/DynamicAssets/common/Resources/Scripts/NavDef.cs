using UnityEngine;
using System.Collections;
using Vectrosity;



//this describes the inlet and outlet nodes, edge shape, and edge characteristics such as max speed, etc
//the road graph builder reads the objects from this script

public class NavDef : MonoBehaviour {

	public Lane firstLane;
	public Lane secondLane;
	public Lane thirdLane;
	public Lane fourthLane;
	
	// Use this for initialization
	void Start () {
		Vector3 startPt = transform.TransformPoint (firstLane.entryPt);
		Vector3 startCtrl = transform.TransformPoint (firstLane.entryPt + new Vector2(0,(firstLane.exitPt.y-firstLane.entryPt.y)*0.5519f));
		Vector3 endPt = transform.TransformPoint (firstLane.exitPt);
		Vector3 endCtrl = transform.TransformPoint (firstLane.exitPt - new Vector2((firstLane.exitPt.x-firstLane.entryPt.x)*0.5519f,0));
		VectorLine myLine = new VectorLine("Curve", new Vector2[61], null, 0.1f, LineType.Continuous, Joins.Weld);
		myLine.MakeCurve(startPt, startCtrl, endPt, endCtrl);
		myLine.Draw ();
		//VectorLine.SetLine (Color.green, startPt, endPt);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//weight is calculated by some function of length, max speed, and actual average speed (congestion factor)
	[System.Serializable]
	public class Lane {
		public Vector2 entryPt;
		public float entryAngle; //zero being due north, 90 being due east
		public Vector2 midPt;
		public float midAngle;
		public Vector2 exitPt;
		public float exitAngle;
		float weight;

	}
}

