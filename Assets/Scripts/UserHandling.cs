using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHandling : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform transform = GetComponent<Transform>();
		//Тема для клика

        if (Input.GetMouseButtonDown(0))
			SpawnFireball();


		//Тема для тача
		for (int i=0;i<Input.touchCount;i++)
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				SpawnFireball();
			}
	}
	public GameObject fireball;
    public GameObject Cam;
	public void SpawnFireball()
    {
        GameObject obj = Instantiate(fireball);
        obj.GetComponent<Bullet>().direction = Cam.transform.transform.forward;
        obj.transform.position = Cam.transform.position;
        Destroy(obj, 5f);
    }
}
