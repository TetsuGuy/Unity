#pragma strict


//Select Menu-Text or -Element
//Go to "Animation"-Tab and click "Create Animation for [Menu-Element]"
//Make an Animation where the Menu is at its place
//Make a second Animation where the Menu is outside the Viewport/Camera
//Connect both with Transitions
//Make a Transistion Variable (bool) called "isOpen" that is true if the menu is open and false if menu is hidden
//Attach this script to your Text/Element and call:  [YourMenuElementName].GetComponent(MenuScript).toggle() when 
//The Player hits "Escape" or whatever your preference key is. 

var animator: Animator;


function Start () {
	
}

function Update () {
	
}

function toggle(){
	var open:boolean = animator.GetBool("isOpen");
	animator.SetBool("isOpen",!open);
}
