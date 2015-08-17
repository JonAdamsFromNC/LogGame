using UnityEngine;
using System.Collections;
using Vectrosity;


//this describes the inlet and outlet nodes, edge shape, and edge characteristics such as max speed, etc
//the road graph builder reads the objects from this script

public class NavDef : MonoBehaviour {

	public Lane[] lanes;
	
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
		public float maxSpeed;

	}

	void OnDrawGizmos(){
		if (GameObject.FindGameObjectWithTag("GameController").GetComponent<RoadNetworkGraph>().debugLanesVisible == true)
		{
			for (int i = 0; i < lanes.Length; i++)
			{
				Vector3 startPt = transform.TransformPoint (lanes[i].entryPt);
				Vector3 middlePt = transform.TransformPoint (lanes [i].midPt);
				Vector3 endPt = transform.TransformPoint (lanes[i].exitPt);
				//now draw a circle with 20 pts using bezier approx
				float t;
				Vector3 position;
				int numberOfPoints = 10;
				Vector3[] path = new Vector3[numberOfPoints];
				for(int i2 = 0; i2 < numberOfPoints; i2++)
				{
					t = i2 / (numberOfPoints - 1.0f);
					position = (1.0f - t) * (1.0f - t) * startPt + 2.0f * (1.0f - t) * t * middlePt + t * t * endPt;
					path[i2] = position;
				}
				//iTween.DrawPath (new []{startPt,middlePt,endPt});
				iTween.DrawPath (path,Color.red);
			}
		}
	}
}

