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

		if (Input.GetButtonDown("Fire1") && holding && hit.transform.gameObject == floor)
		{
			Instantiate(heldobject , this.transform.position , Quaternion.identity);
		}

		if (holding)
		{
			transform.GetChild(1).gameObject.SetActive(true);
			transform.GetChild(1).localScale = Vector3.one * heldobject.GetComponent<defenderbase>().range;
		}
		else
			transform.GetChild(1).gameObject.SetActive(false);
	}

}
