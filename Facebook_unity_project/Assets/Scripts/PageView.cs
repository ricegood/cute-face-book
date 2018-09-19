using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PageView : MonoBehaviour {
	public GameObject NextButton;
	public GameObject PrevButton;
	public GameObject Character;
	public Text Name;

	private int page;
	private int lastPage;

	// Use this for initialization
	void Start () {
		page = 1;
		lastPage = PlayerPrefs.GetInt ("numOfCharacter");
		setPage ();
	}

	public void next () {
		page++;
		setPage ();
	}

	public void prev () {
		page--;
		setPage ();
	}

	private void setPage () {
		if (page > 1)
			PrevButton.SetActive (true);
		else
			PrevButton.SetActive (false);
		
		if (page < lastPage)
			NextButton.SetActive (true);
		else
			NextButton.SetActive (false);

		// set name text
		Name.text = page.ToString();

		// set character sprite
		Character.GetComponent<Character>().loadCharacter(page);
	}

}
