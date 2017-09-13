using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Item-Type
//Part of inventory package
//applying/using an item applies these variables to the player

[System.Serializable]
public class Item : MonoBehaviour {
	public int nr;
	public string name;
	public int amount;
	public int hp;
	public int exp;
	public int atk;
	public int def;
	public string descr;

	public Item(int n, string s, int x, int h, int e, int a, int d, string s2){
		this.nr = n;
		this.name = s;
		this.amount = x;
		this.hp = h;
		this.exp = e;
		this.atk = a;
		this.def = d;
		this.descr = s2;
	}
}
