using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
	public int damage;
	public bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void destroythis()
	{
		if (destroy)
			Destroy(gameObject);
		else
			print("nodie");
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("enemy"))
			destroythis();
	}
}
