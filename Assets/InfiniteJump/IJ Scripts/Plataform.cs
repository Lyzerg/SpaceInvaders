using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour {

	[SerializeField]GameObject platformPrefab;
	[SerializeField]IJUIManager ijuiManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		float rndY = Random.Range (1.5f, 4f);
		float rndZ = Random.Range (2.5f, 4f);
		Vector3 newPos = transform.position + new Vector3(0,rndY,rndZ);
		Instantiate (platformPrefab, newPos, Quaternion.identity);
		ijuiManager.UpdateCounter ();
	}


	void OnCollisionExit(){
		Destroy (gameObject);
	}
}





