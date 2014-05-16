using UnityEngine;
using System.Collections;

public class LiveScript : MonoBehaviour {

	// Use this for initialization
	public int lives;
	public TextMesh textMesh;

	void Start () {
	
	}

	public void SubstractLive(int a)
	{
		lives-=a;
	}

	public void AddLive(int a)
	{
		lives+=a;
	}
	
	// Update is called once per frame
	void Update () {
		textMesh.text = lives.ToString();
	}
}
