﻿using UnityEngine;
using System.Collections;

// ----- Low Poly FPS Pack Free Version -----
public class BulletScript : MonoBehaviour
{

	[Range(5, 100)]
	[Tooltip("After how long time should the bullet prefab be destroyed?")]
	public float destroyAfter;
	[Tooltip("If enabled the bullet destroys on impact")]
	public bool destroyOnImpact = false;
	[Tooltip("Minimum time after impact that the bullet is destroyed")]
	public float minDestroyTime;
	[Tooltip("Maximum time after impact that the bullet is destroyed")]
	public float maxDestroyTime;

	[Header("Impact Effect Prefabs")]
	public Transform[] metalImpactPrefabs;
	public GameObject redDot;

	private void Start()
	{
		//Start destroy timer
		StartCoroutine(DestroyAfter());
	}

	//If the bullet collides with anything
	private void OnCollisionEnter(Collision collision)
	{

        //If destroy on impact is false, start 
        //coroutine with random destroy timer
        if (!destroyOnImpact)
		{
			StartCoroutine(DestroyTimer());
		}
		//Otherwise, destroy bullet on impact
		else
		{
			Destroy(gameObject);
		}
		
		//If bullet collides with "Target" tag
		if (collision.transform.tag == "Target")
		{
			//Toggle "isHit" on target object
			collision.transform.gameObject.GetComponent
				<TargetScript>().isHit = true;
			//Destroy bullet object
			Destroy(gameObject);
		}
		
		if (collision.transform.CompareTag("GreenTarget"))
		{
			var hit = collision.GetContact(0);
			Instantiate(redDot, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(hit.normal));
			collision.gameObject.GetComponent<GreenTarget>().CalculateScores(hit.point);
			Destroy(gameObject);
		}
	}

	private IEnumerator DestroyTimer()
	{
		//Wait random time based on min and max values
		yield return new WaitForSeconds
			(Random.Range(minDestroyTime, maxDestroyTime));
		//Destroy bullet object
		Destroy(gameObject);
	}

	private IEnumerator DestroyAfter()
	{
		//Wait for set amount of time
		yield return new WaitForSeconds(destroyAfter);
		//Destroy bullet object
		Destroy(gameObject);
	}
}
// ----- Low Poly FPS Pack Free Version -----