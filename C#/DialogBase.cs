using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBase : MonoBehaviour {

	public AudioSource sfx;
	public int pitch;
	private Queue<string> sentences; 
	public Animator animator;
	public Text dialogText;

	// Use this for initialization
	void Start () {
		pitch = 1;
		sentences = new Queue<string> ();
		animator.SetBool ("isOpen", false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (animator.GetBool("isOpen") && Input.GetMouseButtonDown(1)) {
			DisplayNextSentence ();
		}
	}

	public void StartDialog(Dialog d, int p){

		sfx.pitch = p;

		sentences.Clear ();

		animator.SetBool ("isOpen", true);

		foreach (string sentence in d.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	IEnumerator TypeSentence(string sentence){
		dialogText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogText.text += letter;
			sfx.Play ();
			yield return new WaitForSeconds(0.025F);
		}
		sfx.Pause();
	}

	public void DisplayNextSentence(){
		if (sentences.Count == 0) {
			EndDialog ();
			return;
		}
		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}

	public void EndDialog(){
		animator.SetBool ("isOpen", false);
	}

}
