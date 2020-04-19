using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
	private static Gamemanager instance
	{
		get{return gm;}
	}
	public static Gamemanager gm = null;
	public int currency;
	public int initialhealth = 100;
	public int currenthealth;

	public GameObject UI;

	public Text healthtext;
	public Text currencytext;

	private void Awake()
	{
		if (gm != null)
		{
			DestroyImmediate(gameObject);
			return;
		}
		gm = this;
	}

	// Start is called before the first frame update
	void Start()
    {
		currenthealth = initialhealth;
		currency = 100;
		currencytext.text = "Currency:" + currency.ToString();
		healthtext.text = "Health: " + currenthealth.ToString();
		UI.GetComponent<hotbar>().checkpuchasable(currency);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void updatecurrency(int amount)
	{
		currency += amount *10;

		currencytext.text = "Currency:" + currency.ToString();

		UI.GetComponent<hotbar>().checkpuchasable(currency);
	}

	public void buyitem(int amount)
	{
		currency -= amount;
		currencytext.text = "Currency: " + currency.ToString();
		UI.GetComponent<hotbar>().checkpuchasable(currency);
	}

	public void updatehealth(int oof)
	{
		currenthealth -= oof;
		healthtext.text = "Health: " + currenthealth.ToString();
	}
}
