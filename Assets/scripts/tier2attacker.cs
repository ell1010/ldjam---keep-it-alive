using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tier2attacker : baseattacker
{
	public GameObject tier1;
    // Start is called before the first frame update
    public override void Start()
    {
		base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
		base.Update();
    }

	public override void checkhealth()
	{
		base.checkhealth();
		if (currenthealth <= 0)
		{
			GameObject t1 = Instantiate(tier1 , transform.position , Quaternion.identity);
			t1.GetComponent<baseattacker>().currentnode = currentnode;
		}
	}
}
