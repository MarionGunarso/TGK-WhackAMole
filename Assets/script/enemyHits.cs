using UnityEngine;
using System.Collections;

public class enemyHits : MonoBehaviour
{


	// Use this for initialization
	public Sprite spriteDefault;
	public Sprite spriteHit;
	//public GameObject Summon;
	public bool hit;


	private ScoreScript scoreScript;
	private HealthScript healthScript;

	public int tambahScore;
	public int damageIfHit;
	
	public float minhealth;
	public float maxhealth;

	public bool animated;

	public bool dontWhack;
	public int damageToLiveIfWhacked;



	private float healthStart;
	//private int myScore;
	private float health;

	private bool pool = true;

	private SpriteRenderer spriteRenderer;
	private Animator anim;
	private LiveScript liveScript;
	void Awake()
	{
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	void Start ()
	{
		if(animated==true)
		{
			anim = GetComponent<Animator>();
		}
		Debug.Log("start");
		liveScript = GameObject.Find ("Lives").GetComponent<LiveScript>();
		scoreScript = GameObject.Find("Score").GetComponent<ScoreScript>();
		healthScript = gameObject.GetComponent<HealthScript>();
		health = Random.Range(minhealth,maxhealth);

	}

	void OnEnable()
	{
		//Debug.Log("onEnable");
		if(animated==true)
		{
			anim.SetBool("isSpawn",true);
		}
		else{
			spriteRenderer.sprite = spriteDefault;
		}
		pool = true;
		//health = Random.Range(minhealth,maxhealth);

	}

	public void PoolObject()
	{
		ObjectPoolScript.instance.PoolObject(gameObject);
	}

	void OnMouseUp()
	{
		if(dontWhack==true)
		{
			liveScript.SubstractLive(damageToLiveIfWhacked);
			if(animated==true)
			{
				healthScript.ResetHealth();
				if(pool==true)
				{
					pool=false;
					anim.SetBool("isDespawn",true);
					anim.SetBool("isSpawn",false);
				}
			}
			else
			{
				spriteRenderer.sprite = spriteHit;
				healthScript.ResetHealth();
				if(pool==true)
				{
					pool = false;
					Invoke ("PoolObject",0.1f);
				}
				
			}
		}
		else
		{
			healthScript.Damaged(damageIfHit);
			if(healthScript.health<=0)
			{
				hit = true;
				//enemySummon.score++;
				scoreScript.AddScore(tambahScore);
				
				//spriteRenderer.sprite = spriteDefault;
				if(maxhealth>minhealth){
					maxhealth-=0.2f;
				}
				if(animated==true)
				{
					healthScript.ResetHealth();
					if(pool==true)
					{
						pool=false;
						anim.SetBool("isDie",true);
						anim.SetBool("isSpawn",false);
					}
				}
				else
				{
					spriteRenderer.sprite = spriteHit;
					healthScript.ResetHealth();
					if(pool==true)
					{
						pool = false;
						Invoke ("PoolObject",0.1f);
					}
					
				}
				
				//gameObject.SetActive(false);
				//health = Random.Range(minhealth,maxhealth);
				
			}
		}

		/*else
		{
			healthScript.Damaged(damageIfHit);
		}*/

		//Invoke ("hitted", 0.5f);
	}



	// Update is called once per frame
	void Update ()
	{
		if(health>0){
			health-=Time.deltaTime;
		}else{
			//gameObject.SetActive(false);
			if(animated==true)
			{
				healthScript.ResetHealth();
				health = Random.Range(minhealth,maxhealth);
				if(pool==true)
				{
					pool = false;
					anim.SetBool("isDespawn",true);
					anim.SetBool("isSpawn",false);
				}

			}
			else
			{
				healthScript.ResetHealth();
				health = Random.Range(minhealth,maxhealth);
				if(pool ==true)
				{
					pool = false;
					ObjectPoolScript.instance.PoolObject(gameObject);
					
				}
			}



		}
	}
}

