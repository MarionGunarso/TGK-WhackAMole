using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
		
	public int health;

	private int baseHealth;
	// Use this for initialization
	void Start ()
	{
		baseHealth = health;
	}
	public void Damaged(int a)
	{
		health-=a;
	}
	public void ResetHealth()
	{
		health = baseHealth;
	}
	// Update is called once per frame
	void Update ()
	{

	}
}

