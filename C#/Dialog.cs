using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Part of the Dialog-Package
//DialogType

[System.Serializable]

public class Dialog {
	public string name;

	// Min. 3 Lines, Max. 10 Lines
	[TextArea(1,10)]
	public string[] sentences;

}
