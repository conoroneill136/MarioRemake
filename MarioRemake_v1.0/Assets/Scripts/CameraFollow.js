#pragma strict
var Player : Transform;
var DistanceFromPlayer : float =5;
var StaticCameraY : float = 4;

function Update () {
	transform.position.z = Player.position.z - DistanceFromPlayer;
	transform.position.x = Player.position.x;
}

function LateUpdate() {
	GetComponent.<Camera>().main.transform.position.y = StaticCameraY;
	}
