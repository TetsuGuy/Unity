#pragma strict

var self: GameObject;
var ReactivateEnd:GameObject;
var ReactivateStopper:GameObject;
var isCoolDown:boolean;
private var time:float;
private var timer:float;
function Start () {	
	timer=3;
}

function Update () {
	if(isCoolDown && Time.time-time>timer)
	{
		isCoolDown=false;
		ReactivateEnd.SetActive(true);
		ReactivateStopper.SetActive(true);
	}
}

function OnTriggerEnter(other:Collider){
	if(other.gameObject.tag=="Player"){
		GameObject.Find("Player").GetComponent(sakuraScript).isOnLadder=false;
		GameObject.Find("Player").GetComponent(sakuraScript).snappedOn=false;
		GameObject.Find("Player").GetComponent(sakuraScript).animator.SetBool("isOnLadder",false);
		isCoolDown=true;
		time=Time.time;
	}

}