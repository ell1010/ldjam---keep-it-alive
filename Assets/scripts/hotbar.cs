using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hotbar : MonoBehaviour
{
	public GameObject mouseobject;
	public Text mousetext;
	//public GameObject[] objects = new GameObject[4];
	public List<Transform> slots;
	public List<objecttypes> otypes = new List<objecttypes>();
    // Start is called before the first frame update
    void Awake()
    {
		foreach (Transform child in transform)
		{
			slots.Add(child);
		}
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
		print(gameObject.transform.GetSiblingIndex());
		Gamemanager.gm.buyitem(otypes[gameObject.transform.GetSiblingIndex()].cost);
	}

	public void checkpuchasable(int moony)
	{
		for (int i = 0; i < slots.Count; i++)
		{
			if (otypes[i].cost > moony)
			{
				slots[i].GetComponentInChildren<Button>().interactable = false;
				
			}
			else
			{
				slots[i].GetComponentInChildren<Button>().interactable = true;
			}
		}
	}



	[System.Serializable]
	public class objecttypes
	{
		public string ObjectName;
		public Sprite ObjectImage;
		public GameObject prefab;
		public int cost;
	}


}
