#pragma strict
var animator: Animator;
var speed: int;
var turningspeed:int;
var hp:int;
var force:float;
var rb:Rigidbody;
private var isJumping:boolean;
private var time:float;
var jumptimer:float;
var jumpspeed:float; 
var distToGround: float;
var isOnLadder:boolean;
var target:Transform;
var targetEnd:Transform;
var snappedOn:boolean;
var snappedOn2:boolean;
var menu: GameObject;

function Start () {
	time=0;
	snappedOn=false;
	snappedOn2=false;
//	if(GameObject.Find("SpawnPoint") == null)
//	{	
//		var doorManager = GameObject.Find("DoorManager").GetComponent(doorManagerScript);
//		transform.position=doorManager.positions[doorManager.currentDoor].position;
//		transform.rotation=doorManager.positions[doorManager.currentDoor].rotation;
//	}
//		
//	else
//		transform.position=GameObject.Find("SpawnPoint").transform.position;

}

function Update () {

	if(Input.GetKeyDown(KeyCode.Escape))
	{
		menu.GetComponent(MenuScript).toggle();
	}

	if(!isOnLadder){
		rb.useGravity=true;
		animator.speed=1;
		//WALKING
		if(Input.GetKey(KeyCode.W) && ! Input.GetKey(0))
		{
			animator.SetBool("isWalking", true);
			transform.position+=transform.forward*Time.deltaTime*speed;
		}

		else animator.SetBool("isWalking", false);

		if(Input.GetKey(KeyCode.A)&& !Input.GetKey(0))
			transform.Rotate(-Vector3.up * Time.deltaTime *turningspeed, Space.World);
		if(Input.GetKey(KeyCode.D)&& !Input.GetKey(0))
			transform.Rotate(Vector3.up * Time.deltaTime *turningspeed, Space.World);


		//FIGHTING
		if(Input.GetMouseButton(0) && !animator.GetBool("isWalking")){
			animator.SetBool("isFighting",true);
		}
		else 
			animator.SetBool("isFighting",false);

		//JUMPING
		if(Input.GetKey(KeyCode.Space)){
			if(Time.time-time>jumptimer)
			{
				time=Time.time;
				rb.AddForce(transform.up*force, ForceMode.Impulse);
				animator.SetBool("isJumping",true);
			}
		}
		else	animator.SetBool("isJumping",false);
	}
	else{
		//Move To Startposition
		if(!snappedOn){
			transform.position = target.position;
			transform.rotation = target.rotation;
			rb.useGravity=false;
			snappedOn=true;
			animator.SetBool("isOnLadder",true);
		}
		//Move UP
		if(!animator.GetBool("isOnLadderEnd")&& Input.GetKey(KeyCode.W)){
			animator.speed=1;
			transform.position+=transform.up*0.5*Time.deltaTime*speed;
			animator.SetFloat("isOnLadderDirection",1);
		}
		//Move DOWN
		else if(!animator.GetBool("isOnLadderEnd")&&Input.GetKey(KeyCode.S)){
			animator.speed=1;
			transform.position-=transform.up*0.5*Time.deltaTime*speed;
			animator.SetFloat("isOnLadderDirection",-1);

		}
		//STAND STILL
		else if(!animator.GetBool("isOnLadderEnd")){
			animator.SetFloat("isOnLadderDirection",0);	
			animator.speed=0;	
		}
	}


	if(hp<=0)
		animator.SetBool("isDead",true);
}


function IsGrounded(): boolean {
   return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1);
 }