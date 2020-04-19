using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Wave", menuName ="wavefile")]
public class waves : ScriptableObject
{
	[System.Serializable]
	public class wavecontents
	{
		public GameObject type;
		public int amount;
	}

	public wavecontents[] waveinfo;
	public float typedelay;
}
