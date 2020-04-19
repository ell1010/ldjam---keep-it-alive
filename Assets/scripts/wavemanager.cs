using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wavemanager : MonoBehaviour
{
	public waves[] wave = new waves[5];
	int wavenumber = 0;
	GameObject wavebutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void nextwave(GameObject booton)
	{
		StartCoroutine(spawnwave());
		wavebutton = booton;
	}

	IEnumerator spawnwave()
	{
		while (true)
		{
			foreach (waves.wavecontents w in wave[wavenumber].waveinfo)
			{
				for (int i = 0; i < w.amount; i++)
				{
					Instantiate(w.type , transform.position , Quaternion.identity);
					yield return new WaitForSeconds(0.2f);
				}
				yield return new WaitForSeconds(wave[wavenumber].typedelay);
			}
			wavenumber++;
			wavebutton.GetComponent<Button>().interactable = true;
			yield break;
		}
	}
}
