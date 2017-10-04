using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	private bool isPacanyGo;
	private int count;

	public struct WayPoints{
		public float x,z;
		public WayPoints(float _x,float _z)
		{
			x = _x;
			z = _z;
		}
	};
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		isPacanyGo = true;
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		goPacany();
	}

	//Когда скрипт начинает работу
	public void goPacany()
	{


		if ((int)(Time.time*100)%200 == 0 )	
		{
			//Генерим пацанов
			GameObject enm = Instantiate(enemy);

			float x = Random.Range(this.transform.position.x-20f,this.transform.position.x+20f);
			float z = Random.Range(this.transform.position.z-20f,this.transform.position.z+20f);
			
			enm.GetComponent<Transform>().position = new Vector3(x,0,z);
			count++;
			
			//Загенерить вейпойнты
			for (int i=0;i<3;i++)
			{
				x = Random.Range(218.5f-20f-i*41,218.5f+20f-i*41);
				z = Random.Range(230.1f-20f-i*47,230.1f+20f-i*47);
				//Добавление первой точки
				enm.GetComponent<Enemy>().addWayPoint(x,z, 0);
			}
			enm.GetComponent<Enemy>().addWayPoint(95.9f,88.8f, 5);
			enm.GetComponent<Enemy>().startGoing = true;
		}

		

	}

}
