using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ObjectCutter : MonoBehaviour {

	public Material capMaterial;

	// Use this for initialization
	void Start () {

		
	}
	
	void Update(){

		if(Input.GetMouseButtonDown(0)){

		}
	}
	public void SliceGameobject(int sliceDepth, Transform tParent){

		// If the depth is still above 0, continue executing the code
		if (sliceDepth > 0) {
			Vector3 randomVector = new Vector3 (Random.Range (-5f, 5f), Random.Range (-5f, 5f), Random.Range (-5f, 5f));

			GameObject[] pieces = alexcmd.MeshCut.Cut (gameObject, transform.position, randomVector, capMaterial);

			foreach (GameObject piece in pieces) {
				// Remove any existing colliders and script references from the sliced objects
				if (piece.GetComponent<Collider> ()) {
					DestroyImmediate (piece.GetComponent<Collider> ());
				}
				if (!piece.GetComponent<ObjectCutter> ()) {
					piece.AddComponent<ObjectCutter> ();
				}
				
				if (!piece.GetComponent<Rigidbody> ()) {
					piece.AddComponent<Rigidbody> ();
				}
				if (!piece.GetComponent<MeshCollider> ()) {
					piece.AddComponent<MeshCollider> ();
				}

				piece.GetComponent<ObjectCutter> ().capMaterial = capMaterial;
				piece.GetComponent<MeshCollider> ().sharedMesh = piece.GetComponent<MeshFilter> ().sharedMesh;
				piece.GetComponent<MeshCollider> ().convex = true;

				piece.transform.parent = tParent;

				// Count down the depth
				sliceDepth -= 1;

				piece.GetComponent<ObjectCutter> ().SliceGameobject (sliceDepth, tParent);
			}
		}
		
		//DestroyImmediate(sliceThis);
	}

}
