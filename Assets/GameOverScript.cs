using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	public bool gameOver;
	public TimerScript timerScript;
	public MeshRenderer textGameOver;
	public ScoreScript scoreScript;
	public LiveScript liveScript;
	public GameObject shade;

	void Start () {

		gameOver = false;
		shade.SetActive(false);
		textGameOver.enabled=false;
	
	}

	void RetryLevel()
	{
		if(Input.GetMouseButton(0))
		{
			Application.LoadLevel("whack");
			scoreScript.ResetScore();
			//score=0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(timerScript.time==0)
		{
			gameOver=true;
		}
		if(liveScript.lives<=0)
		{
			gameOver=true;
		}
		if(gameOver==true)
		{
			textGameOver.enabled=true;
			shade.SetActive(true);
			Invoke("RetryLevel",0.5f);

		}
		else
		{
			textGameOver.enabled=false;
			shade.SetActive(false);
		}
	
	}
}
