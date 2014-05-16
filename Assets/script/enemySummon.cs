using UnityEngine;
using System.Collections;

public class enemySummon : MonoBehaviour {

	public GameObject[] enemy;


	public float minTimeSpan;
	public float maxTimeSpan;
	public float reduceTimeSpan;



	public ScoreScript scoreScript;
	public TimerScript timerScript;

	[HideInInspector]
	public float baseTime;

	[HideInInspector]
	public bool increaseDiff = false;

	
	public GameOverScript gameOverScript;

	private bool sekali = true;
	private float countdown;

	//private TextMesh textMeshTimer;

	void Start () {
		Debug.Log(enemy.Length);
		baseTime=timerScript.time;
		//baseTime=time;

		StartCoroutine(Summon());

	}


	int a;
	int b;

	IEnumerator Summon()
	{
		while(gameOverScript.gameOver==false)
		{
			countdown = Random.Range(minTimeSpan, maxTimeSpan);

			b = Random.Range(0,enemy.Length-1);
			while(enemy[b].transform.childCount>0)
			{
				b = Random.Range (0,enemy.Length-1);
				yield return null;
			}
			Debug.Log(b);
			a = Random.Range (1,3);



			//Debug.Log(a);
			//Debug.Log(b);
			if(a==1)
			{
				GameObject objekPool = ObjectPoolScript.instance.GetObjectForType("enemy1",true,b);
				objekPool.transform.parent = enemy[b].transform;
				objekPool.transform.localPosition = new Vector3(0,0,-1) ;

				
			}
			else if(a==2)
			{
				GameObject objekPool = ObjectPoolScript.instance.GetObjectForType("enemy2",true,b);
				objekPool.transform.parent = enemy[b].transform;
				objekPool.transform.localPosition = new Vector3(0,0,-1) ;

			}

			yield return new WaitForSeconds(countdown);
			//summon();
			if(maxTimeSpan>minTimeSpan){
				//public
				maxTimeSpan-=reduceTimeSpan;
			}

		}

	}

	// Update is called once per frame
	void Update () {
		//SCORE.GetComponent<TextMesh>().text = score+"";


		if(timerScript.time<baseTime/4){

			increaseDiff = true;
		}
		if(increaseDiff==true)
		{
			if(sekali==true)
			{
				//Debug.Log("jalan");	
				StartCoroutine(Summon());
				sekali = false;
			}
		}
	}

	void summon(){
		int enemyActive = Random.Range(0,9);
		enemy[enemyActive].SetActive(true);
	}
}

