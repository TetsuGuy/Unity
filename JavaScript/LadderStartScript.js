#pragma strict
var target: Transform;
var otherEnd: GameObject;
var myStopper:GameObject;
function Start () {
	
}

function Update () {
	
}

function OnTriggerEnter(other:Collider){
	if(other.gameObject.tag=="Player"){
		GameObject.Find("Player").GetComponent(sakuraScript).target=target;
		GameObject.Find("Player").GetComponent(sakuraScript).isOnLadder=true;
		otherEnd.SetActive(false);
		myStopper.SetActive(false);
	}

}