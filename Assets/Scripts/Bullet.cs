using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector3 direction;
	public float ballspeed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(Time.deltaTime);
        transform.position += direction * Time.deltaTime * ballspeed;
	}

	//Коллизия
	void OnTriggerEnter(Collider a){
		if (a.gameObject.tag == "enemy")
		{
			//Увеличим очки
			GameObject.Find("Player").GetComponent<PlayerParams>().score+=3;
			Destroy(a.gameObject);
			ParticleSystem newblood = Instantiate(a.gameObject.GetComponent<Enemy>().blood);
			newblood.GetComponent<Transform>().position = a.gameObject.GetComponent<Transform>().position;
			Destroy(newblood,5f);
			
		}
	}

}
