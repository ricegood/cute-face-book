using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {
	public List<GameObject> Eyes = new List<GameObject>();
	public List<GameObject> Lips = new List<GameObject>();
	public GameObject Skin;

	private int eyeNumber = -1;
	private int lipNumber = -1;
	private float skinColor_r = -1;
	private float skinColor_g = -1;
	private float skinColor_b = -1;

	public void setRandomEyes() {
		chooseRandomItem (Eyes, ref eyeNumber);
	}

	public void setRandomLips() {
		chooseRandomItem (Lips, ref lipNumber);
	}

	public void setRandomSkinColor() {
		skinColor_r = Random.value;
		skinColor_g = Random.value;
		skinColor_b = Random.value;
		Color newColor = new Color( skinColor_r, skinColor_g, skinColor_b, 1.0f );
		Skin.GetComponent<SpriteRenderer> ().color = newColor;
	}

	public int getEyeNumber() {
		return eyeNumber;
	}

	public int getLipNumber() {
		return lipNumber;
	}

	public Color getColor() {
		return Skin.GetComponent<SpriteRenderer>().color;
	}

	public void saveCharacter() {
		int numOfCharacter = PlayerPrefs.GetInt ("numOfCharacter");
		numOfCharacter++;

		PlayerPrefs.SetInt ("numOfCharacter", numOfCharacter);
		PlayerPrefs.SetInt ("eye"+numOfCharacter, eyeNumber);
		PlayerPrefs.SetInt ("lip"+numOfCharacter, lipNumber);
		PlayerPrefs.SetFloat ("skinColor_r"+numOfCharacter, skinColor_r);
		PlayerPrefs.SetFloat ("skinColor_g"+numOfCharacter, skinColor_g);
		PlayerPrefs.SetFloat ("skinColor_b"+numOfCharacter, skinColor_b);

		Debug.Log ("SAVED!");
	}

	public void loadCharacter(int n) {
		if (eyeNumber >= 0)
			Eyes [eyeNumber].SetActive (false);
		if (lipNumber >= 0)
			Lips [lipNumber].SetActive (false);

		eyeNumber = PlayerPrefs.GetInt ("eye"+n);
		lipNumber = PlayerPrefs.GetInt ("lip"+n);
		skinColor_r = PlayerPrefs.GetFloat ("skinColor_r"+n);
		skinColor_g = PlayerPrefs.GetFloat ("skinColor_g"+n);
		skinColor_b = PlayerPrefs.GetFloat ("skinColor_b"+n);

		Eyes [eyeNumber].SetActive (true);
		Lips [lipNumber].SetActive (true);
		Color newColor = new Color( skinColor_r, skinColor_g, skinColor_b, 1.0f );
		Skin.GetComponent<SpriteRenderer> ().color = newColor;
	}

	private void chooseRandomItem(List<GameObject> itemList, ref int savedNumber) {
		int randomNumber = savedNumber;

		while (randomNumber == savedNumber)
			randomNumber = Random.Range(0, itemList.Count);

		if (savedNumber >= 0)
			itemList [savedNumber].SetActive (false);

		savedNumber = randomNumber;
		itemList [savedNumber].SetActive (true);
	}
}
