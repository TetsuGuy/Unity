#pragma strict

var animator: Animator;


function Start () {
	
}

function Update () {
	
}

function toggle(){
	var open:boolean = animator.GetBool("isOpen");
	animator.SetBool("isOpen",!open);
}
