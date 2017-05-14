using UnityEngine;
using System.Collections;


public class ToolUser : MonoBehaviour {

	public Material capMaterial;

	// Use this for initialization
	void Start () {

		
	}
	
	void Update(){

		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;

			if(Physics.Raycast(transform.position, transform.forward, out hit)){

				GameObject victim = hit.collider.gameObject;

				GameObject[] pieces = alexcmd.MeshCut.Cut(victim, victim.transform.position, transform.right, capMaterial);

				if(!pieces[1].GetComponent<Rigidbody>())
					pieces[1].AddComponent<Rigidbody>();

				Destroy(pieces[1], 1);
			}

		}
	}

}
