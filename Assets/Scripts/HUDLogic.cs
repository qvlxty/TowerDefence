using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	//Player
	public GameObject player;
	//UIelements
	public GameObject scoretext;
	public GameObject hptext;
	// Update is called once per frame
	void Update () {
		//Отображаем ХП
		hptext.GetComponent<Text>().text = player.GetComponent<PlayerParams>().hp.ToString()+"%";
		scoretext.GetComponent<Text>().text = "Очки: "+player.GetComponent<PlayerParams>().score.ToString()+" pts";
	}
}
