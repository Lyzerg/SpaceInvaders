using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlayer : MonoBehaviour {

	bool dodging;
	[SerializeField] int dodgeSpeed;
	[SerializeField] bool blue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (blue) {
			if (Input.GetKeyDown (KeyCode.A) && transform.position.x >= -1.5f) {						
				StartCoroutine (ChangeLane (false));
			}
			if (Input.GetKeyDown (KeyCode.D) && transform.position.x <= -1.5f) {						
				StartCoroutine (ChangeLane (true));
			}

		} 
		else {

			//movimiento
			if (Input.GetKeyDown (KeyCode.LeftArrow) && transform.position.x >= 1.5f) {
				StartCoroutine (ChangeLane (false));
			}

			if (Input.GetKeyDown (KeyCode.RightArrow) && transform.position.x <= 1.5f) {
				StartCoroutine (ChangeLane (true));
			}
				
		}
	}

	IEnumerator ChangeLane(bool right)
	{
		if (!dodging) {
			dodging = true;
			float currentX = transform.position.x;

			if (!right) {
				while (transform.position.x >= currentX - 1.2f) {
					transform.Translate (Vector2.left * Time.deltaTime * dodgeSpeed);
					yield return new WaitForEndOfFrame ();
				}
			} else {
				while (transform.position.x <= currentX + 1.2f) {
					transform.Translate (Vector2.right * Time.deltaTime * dodgeSpeed);
					yield return new WaitForEndOfFrame ();
				}
			}

		}
		dodging = false;
	}
}
