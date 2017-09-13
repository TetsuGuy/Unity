using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Part of the Inventory Pack
//You have to have the following:
//-a text representing the cursor, that is 
//the same height as your item-list TextElement
//I use ">" to make a Text-based cursor and put 
//it inside the Text.text variable.  [cursor]
//-a Textbox on your inventory-canvas that has enough room for a description [description]
//-a textbox that saves the amount of each item (same height as itemlist) [amount]
//-a textbox that represents your inventory [menu]

//Navigations is handled by WASD
//As i open the inventory with Esc, updateMenu() will be called to update contents
//You can add Items, remove (use) Items and apply Items (is called inside the "use" Function)
//ApplyFunction will applay Item-Values to your character.

public class Inventory : MonoBehaviour {

	public Text cursor;
	private int cursorPos;
	public Text description;
	public Text menu;
	public Text amount;
	private List<Item> inventory;

	// Use this for initialization
	void Start () {
		inventory = new List<Item> ();
		inventory.Clear ();
		cursor.text = ">";
		cursorPos = 1;
		description.text = "...";
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			updateMenu ();
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			cursorDown ();
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			cursorUp ();
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			useItem ();
		}
	}	

	public void updateMenu(){
		menu.text = "";
		amount.text = "";
		foreach (Item i in inventory) {
			menu.text += i.name+"\n";
			amount.text += i.amount + "\n";
		}
		updateDescription ();
	}

	public void addItem(Item i){
		bool exists = false;
		foreach(Item item in inventory){
			if (item.nr == i.nr) {
				item.amount += i.amount;
				exists = true;
			}
		}
		if (!exists)
			inventory.Add (i);
		updateMenu ();
	}

	public void cursorDown(){
		if (cursorPos  < inventory.Count) {
			cursor.text = "\n" + cursor.text;
			cursorPos++;
		}
		updateDescription ();
	}

	public void cursorUp(){

		if(cursorPos>1){
			int i;
			cursor.text = "";
			for (i = 2; i < cursorPos; i++) {
				cursor.text += "\n";
			}
			cursor.text += ">";
			cursorPos--;
		}
		updateDescription ();
	}

	public void updateDescription(){
		if (inventory.Count > 0)
			description.text = inventory [cursorPos-1].descr;
		else
			description.text = "...";
	}

	public void useItem(){
		if (inventory.Count == 0)
			return;

		if (inventory [cursorPos - 1].amount > 1) 
		{
			inventory [cursorPos - 1].amount--;
			applyItem (inventory[cursorPos-1]);
		} 
		else 
		{
			applyItem (inventory[cursorPos-1]);
			inventory.Remove (inventory [cursorPos - 1]);
			if (inventory.Count > 0)
				cursorUp ();
		}
		updateMenu ();
		updateDescription ();
	}

	public void applyItem(Item item){
		GameObject.Find("Player").GetComponent<HealthScript>().changeHealth(item.hp);
	}
}
