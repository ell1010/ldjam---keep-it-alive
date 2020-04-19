using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenderbase : MonoBehaviour
{
	public float range;
	public int damage;
	public float attackdelay;
	public GameObject projectile;
	public List<GameObject> attackersinrange = new List<GameObject>();
	public bool canattack;
	bool attacking = false;


	void Start()
    {
        //does anything need to go here?

    }
	

    void Update()
    {
		//dop attacking here
		if (attackersinrange.Count > 0)
		{
			transform.up = attackersinrange[0].gameObject.transform.position - transform.position;
			if (!attacking)
				StartCoroutine(attack());
		}
	}

	IEnumerator attack()
	{
		attacking = true;
		print("start attacking");
		while (attacking)
		{
			canattack = true;
			if (canattack)
			{
				spawnbullet();
				//print(attackersinrange[0].gameObject.name);
				canattack = false;
			}
			if (!canattack)
			{
				yield return new WaitForSeconds(attackdelay);
				canattack = true;
			}
			if (attackersinrange.Count == 0)
			{
				print("none in range");
				attacking = false;
				yield break;
			}
			print("wait for frame");
			yield return null;
		}
	}

	public virtual void spawnbullet()
	{
		GameObject p = Instantiate(projectile , transform.position , Quaternion.identity);
		p.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
		p.GetComponent<bulletscript>().damage = damage;
		p.GetComponent<bulletscript>().destroy = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("enemy"))
		{
			attackersinrange.Add(collision.gameObject);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("enemy"))
		{
			attackersinrange.Remove(collision.gameObject);
		}
	}
}
