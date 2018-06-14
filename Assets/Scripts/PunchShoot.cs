using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PunchShoot : MonoBehaviour {

	public GameObject punchFab;
	public Button punchButton;

	public float x;
	
	void Start(){
		Button btn = punchButton.GetComponent<Button>();
		btn.onClick.AddListener(makePunch);

		x = -2.5f;
	}

	void makePunch(){
		Instantiate(punchFab, new Vector3(x, 2, 90), transform.rotation);
		x += 0.2f;
	}
}
