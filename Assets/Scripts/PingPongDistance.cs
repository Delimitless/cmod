using UnityEngine;
using System.Collections;

public class PingPongDistance : MonoBehaviour {

    public Vector3 moveDir = Vector3.zero;
    public float speed = 0.0f;
    public float travelDistance = 0.0f;
    private Transform thisTransform = null;

	// Use this for initialization
	IEnumerator Start () {
	    thisTransform = transform;

	    while (true) {
	        moveDir = moveDir*-1;

	        yield return StartCoroutine(Travel());
	    }
	}

    IEnumerator Travel() {
        float distanceTraveled = 0;

        while (distanceTraveled < travelDistance) {
            Vector3 distToTravel = moveDir * speed * Time.deltaTime;

            thisTransform.position += distToTravel;

            distanceTraveled += distToTravel.magnitude;

            yield return null;
        }
    }
}
