using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.SceneManagement;

public class RoadDNA : MonoBehaviour
{
	[SerializeField]
	private SpriteLibrary spriteLibrary = default;

	[SerializeField]
	private SpriteResolver[] targetResolver = default;

	[SerializeField]
	private string[] TargetCategory = default;

	private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;
	// Start is called before the first frame update

	void Start()
    {
		string dna = PlayerPrefs.GetString("DNA");
		SelectRandom(dna);

	}


	public void SelectRandom(string GundogDNA)
	{
		int index = 0;
		if (GundogDNA.Length == 3)
			GundogDNA = "0" + GundogDNA;

		for (int i = 0; i < TargetCategory.Length; i++)
		{
			string[] labels =
			LibraryAsset.GetCategoryLabelNames(TargetCategory[i]).ToArray();

			switch (GundogDNA[i])
			{
				case '0':
				case '1':
				case '2':
					index = 0;
					break;
				case '3':
				case '4':
				case '5':
					index = 1;
					break;
				case '6':
				case '7':
				case '8':
				case '9':
					index = 2;
					break;
			}

			string label = labels[index];

			targetResolver[i].SetCategoryAndLabel(TargetCategory[i], label);
		}


	}
}
