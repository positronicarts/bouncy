using UnityEngine;
using System.Collections;

public class BlockCreation : MonoBehaviour {

  public GameObject prefab;

  public int numBlocksPerRow;
  public int numRows;

  public float firstRowY;
  public float rowY;

	// Use this for initialization
	void Start () {

    float width = 10.0f/numBlocksPerRow;
    ScoreManager.numBlocks = 0;

    for (int ii = 0; ii < numBlocksPerRow; ii++)
    {
      for (int jj = 0; jj < numRows; jj++)
      {
        var block = Instantiate(prefab, new Vector3(-5.0f + width / 2 + ii * width,
                                        firstRowY + jj * rowY,
                                        0), Quaternion.identity) as GameObject;
        block.transform.localScale = new Vector3(width, rowY/2, 0.25f);
        block.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f),
           Random.Range(0.0f, 1.0f),
           Random.Range(0.0f, 1.0f));

        ScoreManager.numBlocks++;
      }
    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
