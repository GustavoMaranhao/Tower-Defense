using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float enemyHP;
	public float enemySpeed;
	public float walkStopTime;
	public Transform[] wayPoints;

	private int currentWayPoint;
	private float walkTimer;
	private NavMeshAgent nav;

	void Awake() {
		nav = GetComponent<NavMeshAgent>();
		currentWayPoint = 0;
	}

	void Update () {
		nav.speed = enemySpeed;
		
		if(nav.remainingDistance <= nav.stoppingDistance){
			walkTimer += Time.deltaTime;
			
			if(walkTimer >= walkStopTime){
				if(currentWayPoint == wayPoints.Length)
					GameObject.Destroy(this.gameObject, 0);
				else
					currentWayPoint++;
				
				walkTimer = 0;
			}
		}
		else
			walkTimer = 0;

		if(currentWayPoint != wayPoints.Length)
			nav.destination = wayPoints[currentWayPoint].position;
	}
}
