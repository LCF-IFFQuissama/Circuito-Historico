#pragma strict
var wheelFL : WheelCollider;
var wheelFR : WheelCollider;
var wheelRL : WheelCollider;
var wheelRR : WheelCollider;
var maxTorque : float = 50;
/*
var wheelFLTrans : Transform;
var wheelFRTrans : Transform;
var wheelRLTrans : Transform;
var wheelRRTrans : Transform;
*/
var carroRB: Rigidbody;

//var centerOfMass : Vector3;
function Start () {
carroRB = GetComponent.<Rigidbody>();
carroRB.centerOfMass.y = -0.9;
//rigidbody.centerOfMass.y = -0.9;
}
function FixedUpdate () {
wheelRR.motorTorque = maxTorque * Input.GetAxis("Vertical");
wheelRL.motorTorque = maxTorque * Input.GetAxis("Vertical");
wheelFL.steerAngle = 10 * Input.GetAxis("Horizontal");
wheelFR.steerAngle = 10 * Input.GetAxis("Horizontal");
}
function Update(){
/*
wheelFLTrans.Rotate(wheelFL.rpm/60*360*Time.deltaTime,0,0);
wheelFRTrans.Rotate(wheelFR.rpm/60*360*Time.deltaTime,0,0);
wheelRLTrans.Rotate(wheelRL.rpm/60*360*Time.deltaTime,0,0);
wheelRRTrans.Rotate(wheelRR.rpm/60*360*Time.deltaTime,0,0);
*/

}