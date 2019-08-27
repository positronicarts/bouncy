using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

  public GUIText scoreLabel;
  public static int score;
  public static int numBlocks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    scoreLabel.text = "Score: " + score + ", numBlocks " + numBlocks;
	}
}
