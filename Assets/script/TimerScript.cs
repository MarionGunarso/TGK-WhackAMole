using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

	// Use this for initialization

	public float time;

	public TextMesh textMesh;

	void Start () {
		StartTimer();
	}

	IEnumerator Timer()
	{
		textMesh.text = time.ToString();
		while(time>0)
		{
			yield return new WaitForSeconds(1);
			time-=1;

			textMesh.text = time.ToString();


		}

	}

	public void StartTimer()
	{
		StartCoroutine(Timer ());
	}
	// Update is called once per frame
	void Update () {
	
	}
}
