#pragma strict

var drawCircle : GameObject;

function Start () {
	
}

function Update () {
	//thiccness can be changed by resizing the "Circle" prefab
	var fwd = transform.TransformDirection(Vector3.forward);
	var hit : RaycastHit;
	var distance = 100; //max distance from camera you can draw
	var destination = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 10));

//	if (Input.GetMouseButton(0) && Physics.Raycast(transform.position, fwd, hit, distance) && transform.hasChanged){ 
//		Instantiate(drawCircle, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
//		transform.hasChanged = false;
//	}
	if (Input.GetMouseButton(0) && transform.hasChanged){ 
		var newCircle = Instantiate(drawCircle, destination, Quaternion.identity);
		newCircle.transform.LookAt(Camera.main.transform);

		transform.hasChanged = false;
	}
}
