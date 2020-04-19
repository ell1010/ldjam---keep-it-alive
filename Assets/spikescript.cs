using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikescript : defenderbase
{
	public int ammo = 10;

	public override void spawnbullet()
	{
		attackersinrange[0].GetComponent<baseattacker>().currenthealth -= damage;
		attackersinrange[0].GetComponent<baseattacker>().checkhealth();
		ammo -= 1;
		if (ammo <= 0)
			Destroy(gameObject);
	}

}
