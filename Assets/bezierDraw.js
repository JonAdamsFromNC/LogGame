@script ExecuteInEditMode()
#pragma strict
public var start : GameObject;
public var middle : GameObject;
public var end : GameObject;
public var color : Color = Color.white;
public var width : float = 0.2;
public var numberOfPoints : int = 20;
function Start()
{
   // initialize line renderer component
   var lineRenderer : LineRenderer =
      GetComponent(LineRenderer);
   if (null == lineRenderer)
   {
      gameObject.AddComponent(LineRenderer);
   }
   lineRenderer = GetComponent(LineRenderer);
   lineRenderer.useWorldSpace = true;
   lineRenderer.material = new Material(
      Shader.Find("Particles/Additive"));
}
function Update()
{
   // check parameters and components
   var lineRenderer : LineRenderer =
      GetComponent(LineRenderer);
   if (null == lineRenderer || null == start
      || null == middle || null == end)
   {
      return; // no points specified
   }
   // update line renderer
   lineRenderer.SetColors(color, color);
   lineRenderer.SetWidth(width, width);
   if (numberOfPoints > 0)
   {
      lineRenderer.SetVertexCount(numberOfPoints);
   }
   // set points of quadratic Bezier curve
   var p0 : Vector3 = start.transform.position;
   var p1 : Vector3 = middle.transform.position;
   var p2 : Vector3 = end.transform.position;
   var t : float;
   var position : Vector3;
   for(var i : int = 0; i < numberOfPoints; i++)
   {
      t = i / (numberOfPoints - 1.0);
      position = (1.0 - t) * (1.0 - t) * p0
         + 2.0 * (1.0 - t) * t * p1
         + t * t * p2;
      lineRenderer.SetPosition(i, position);
   }
}