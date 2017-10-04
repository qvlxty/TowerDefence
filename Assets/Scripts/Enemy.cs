using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	
	public int enemyspeed;
	public struct WayPoints{
		public Vector3 Pos;
		public WayPoints(float _x,float _z, float _y)
		{
			Pos = new Vector3(_x, _y, _z);
		}
	};
	public List <WayPoints> waypoints = new List<WayPoints>();
	void Start()
	{
	}

	public void addWayPoint(float x,float z, float y)
	{
		//Debug.Log(x+" "+z);
		WayPoints point = new WayPoints(x,z, y);
		waypoints.Add(point);
	}
	public bool startGoing = false;
	private int i = 0;
	public ParticleSystem blood;
	
	void Update() 
	{
		if (startGoing && i < waypoints.Count)
			{
				transform.position += transform.forward * Time.deltaTime * enemyspeed;
			 	transform.forward = (waypoints[i].Pos - transform.position).normalized;
				 int zazor = 5;
				if (transform.position.x >= waypoints[i].Pos.x - zazor && transform.position.x <= waypoints[i].Pos.x + zazor
				 && transform.position.y >= waypoints[i].Pos.y - zazor && transform.position.y <= waypoints[i].Pos.y + zazor
				 && transform.position.z >= waypoints[i].Pos.z - zazor && transform.position.z <= waypoints[i].Pos.z + zazor){
					i++;

				}
				// Оно начинает сыпать эрроры, когда проходится последний вейпоинт
				// Потому что оно пытается обращаться к последующему вейпоинту, но уже достигнут последний
				if (i>=4)
				{
					//Срыв покровов
					Destroy(this.gameObject);
					GameObject.Find("Player").GetComponent<PlayerParams>().hp-=3;

				}
			}
			
	}
}
