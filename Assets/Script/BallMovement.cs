using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

  public Vector3 velocity;
  public float speed;

	// Use this for initialization
	void Start () 
  {
    float angle = Random.Range(-Mathf.PI / 4, Mathf.PI / 4);

    velocity = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);
	}
	
	// Update is called once per frame
	void Update () {
    transform.position += velocity.normalized * Time.deltaTime * speed;


    if (transform.position.y < -2.0f)
    {
      Debug.Log("You died!");
      Application.LoadLevel(0);
      ScoreManager.score = 0;
    }
	}

  void OnTriggerEnter(Collider other)
  {
    Debug.Log("Hit!");

    float dx = velocity.normalized.x * Time.deltaTime * speed;
    float dy = velocity.normalized.y * Time.deltaTime * speed;
    float delta = 0.2f;

    if ((transform.position.y - dy + transform.localScale.y / 2 - delta) <
        (other.transform.position.y - other.transform.localScale.y / 2))
    {
       velocity = new Vector3(velocity.x, -velocity.y, velocity.z);
    }

    if ((transform.position.y - dy - transform.localScale.y / 2 + delta) >
    (other.transform.position.y + other.transform.localScale.y / 2))
    {
      velocity = new Vector3(velocity.x, -velocity.y, velocity.z);
    }

    if ((transform.position.x - dx + transform.localScale.x / 2 - delta) <
    (other.transform.position.x - other.transform.localScale.x / 2))
    {
      velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
    }

    if ((transform.position.x - dx - transform.localScale.x / 2 + delta) >
    (other.transform.position.x + other.transform.localScale.x / 2))
    {
      velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
    }

    if (other.gameObject.layer == LayerMask.NameToLayer("Block"))
    {
      other.gameObject.active = false;
      ScoreManager.score += 50;
      ScoreManager.numBlocks--;

      if (ScoreManager.numBlocks == 0)
      {
        Debug.Log("You win!");
        ScoreManager.score += 10000000;
      }

    }
  }
}
