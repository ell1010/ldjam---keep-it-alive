using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hotbar : MonoBehaviour
{
	public GameObject mouseobject;
	public Text mousetext;
	//public GameObject[] objects = new GameObject[4];
	public Transform[] slots;
	public List<objecttypes> otypes = new List<objecttypes>();
    // Start is called before the first frame update
    void Start()
    {
		slots = transform.GetComponentsInChildren<Transform>();
		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).GetComponent<Image>().sprite = otypes[i].ObjectImage;
		}
		//mousetext = transform.parent.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		mousetext.transform.position = Camera.main.WorldToScreenPoint(mouseobject.transform.position);
    }

	public void MouseOver(GameObject gameObject)
	{
		mousetext.text = otypes[gameObject.transform.GetSiblingIndex()].ObjectName;
	}

	public void mouseend()
	{
		mousetext.text = "";
	}

	public void holdobject(GameObject gameObject)
	{
		mouseobject.GetComponent<mouse>().heldobject = otypes[gameObject.transform.GetSiblingIndex()].prefab;
		mouseobject.GetComponent<mouse>().holding = true;
	}
	[System.Serializable]
	public class objecttypes
	{
		public string ObjectName;
		public Sprite ObjectImage;
		public GameObject prefab;
	}
}
