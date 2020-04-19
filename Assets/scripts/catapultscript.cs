using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catapultscript : defenderbase
{
	public override void spawnbullet()
	{
		GameObject p = Instantiate(projectile , transform.position , Quaternion.identity);
		p.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
		p.GetComponent<bulletscript>().damage = damage;
		p.GetComponent<bulletscript>().destroy = false;
	}
}
