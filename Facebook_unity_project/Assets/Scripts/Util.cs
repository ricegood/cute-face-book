using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Util : MonoBehaviour {
	private int numOfCharacter;

	void Start() {
		//PlayerPrefs.DeleteAll ();
		numOfCharacter = PlayerPrefs.GetInt ("numOfCharacter");
		Debug.Log ("# of character : " + numOfCharacter);
	}

	public void moveScene(string name){
		SceneManager.LoadScene(name);
	}
}