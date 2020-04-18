using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
	Transform mytransform;
	public bool holding;
	public GameObject heldobject;
	public GameObject floor;

    void Start()
    {
		mytransform = this.transform;
    }
	

    void Update()
    {
		Vector3 mousepos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mytransform.position = new Vector3 (mousepos.x, mousepos.y, 0);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray , out hit);

		if (holding)
		{
			transform.GetChild(1).gameObject.SetActive(true);
			transform.GetChild(1).localScale = Vector3.one * heldobject.GetComponent<defenderbase>().range;

			if (Input.GetButtonDown("Fire1") && hit.transform.CompareTag("floor"))
			{
				Instantiate(heldobject , this.transform.position , Quaternion.identity);
				holding = false;
				heldobject = null;

			}
			if (hit.transform.CompareTag("floor"))
			{
				transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,1,0,0.2f);
			}
			else
				transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,0,0,0.2f);
			
				
			
		}
		else
			transform.GetChild(1).gameObject.SetActive(false);

	}

}
