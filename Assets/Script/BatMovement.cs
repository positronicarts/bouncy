using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour {

  public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
  {
    var dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

    transform.position += new Vector3(dx, 0, 0);
	}
}
