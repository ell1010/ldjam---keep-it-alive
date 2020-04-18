using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseattacker : MonoBehaviour
{
	public int maxhealth;
	public int currenthealth;
	public float movespeed = 2;
	public GameObject path;
	node[] pathnode;
	public int currentnode;
	Vector3 targetpos;
	Vector3 startpos;
	float time;
	float dist;

    // Start is called before the first frame update
    public virtual void Start()
    {
		currenthealth = maxhealth;
		path = GameObject.FindGameObjectWithTag("nodes");
		pathnode = path.GetComponentsInChildren<node>();
		checknode();
    }
	public virtual void checknode()
	{
		time = 0;
		startpos = transform.position;
		if (currentnode < pathnode.Length)
			targetpos = pathnode[currentnode].transform.position;
		else
			damage();
		dist = Vector3.Distance(startpos , targetpos);
	}
    // Update is called once per frame
    public virtual void Update()
    {
		time += Time.deltaTime * (movespeed / dist);

		if (transform.position != targetpos)
		{
			transform.position = Vector3.Lerp(startpos , targetpos , time);
		}
		else
		{
			currentnode++;
			checknode();
		}

		


    }
	public virtual void checkhealth()
	{
		if (currenthealth <= 0)
		{
			//Instantiate(self , transform.position , Quaternion.identity);
			Destroy(this.gameObject);
		}

	}
	public virtual void damage()
	{
		print("OUCH");
		Destroy(this.gameObject);
		//take away health
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("projectile"))
		{
			currenthealth--;
			checkhealth();
			Destroy(collision.gameObject);
		}
	}

}
