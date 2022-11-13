using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.UI;
using TMPro;

public class NftManager : MonoBehaviour
{
	public Text gunDogDnaText;
	public Text currentTokenIndexText;
	public Text loadingResultText;
	public Image loadingImage;
	public TMP_InputField addressInputField;
	public List<string> gunDogDnas;
	
	[SerializeField] private SpriteLibrary spriteLibrary = default;
	[SerializeField] private SpriteResolver[] targetResolver = default;
	[SerializeField] private string[] targetCategory = default;
	[SerializeField] private string presentToAddress;
	[SerializeField] private GameObject charater;
	[SerializeField] private CallDataModel balanceOfCall;
	[SerializeField] private CallDataModel tokenOfOwnerByIndexCall;
	[SerializeField] private CallDataModel searchDnaCall;
	[SerializeField] private FunctionDataModel transferFromFunction;
	
	private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;
	private int _currentTokenOrder;
	private int _totalTokenNumber;
	
    public NftManager()
    {
        gunDogDnas = new List<string>();
		_currentTokenOrder = 0;
		_totalTokenNumber = 0;
	}

    // Start is called before the first frame update
    private async void Start()
    {
	    string account = PlayerPrefs.GetString("Account");
		int balance = await ERC721.BalanceOf(balanceOfCall.Chain, balanceOfCall.Network, balanceOfCall.ContractAddress, account);
		_totalTokenNumber = balance;

		AddDnas(balance);
    }

    private void Update()
    {
        if (charater.activeSelf)
        {
			UpdateInventoryUI();
			presentToAddress = addressInputField.text;
		}
    }

    private async void AddDnas(int balance)
	{
		for (int i = 0; i < balance; i++)
        {
			string args = $"[\"{PlayerPrefs.GetString("Account")}\",\"{i}\"]";
			// connects to user's browser wallet to call a transaction
			string response = await EVM.Call(tokenOfOwnerByIndexCall.Chain, tokenOfOwnerByIndexCall.Network, 
				tokenOfOwnerByIndexCall.ContractAddress, tokenOfOwnerByIndexCall.Abi, tokenOfOwnerByIndexCall.Method, args);
			response = await EVM.Call(searchDnaCall.Chain, searchDnaCall.Network, searchDnaCall.ContractAddress, 
				searchDnaCall.Abi, searchDnaCall.Method, $"[\"{response}\"]");
			gunDogDnas.Add(response);
		}

		charater.SetActive(true);
	}

    public async void PresentToken()
    {
	    string args = $"[\"{PlayerPrefs.GetString("Account")}\",\"{_currentTokenOrder}\"]";
		// connects to user's browser wallet to call a transaction
		string response = await EVM.Call(tokenOfOwnerByIndexCall.Chain, tokenOfOwnerByIndexCall.Network, 
			tokenOfOwnerByIndexCall.ContractAddress, tokenOfOwnerByIndexCall.Abi, tokenOfOwnerByIndexCall.Method, args);

		args = $"[\"{PlayerPrefs.GetString("Account")}\",\"{presentToAddress}\",\"{int.Parse(response)}\"]";
		
		string presentTransaction = await Web3GL.SendContract(transferFromFunction.Method, transferFromFunction.Abi, 
			transferFromFunction.ContractAddress, args, transferFromFunction.Value, 
			"", "");
		string txStatus = await EVM.TxStatus("ethereum", "goerli", presentTransaction);

		loadingImage.gameObject.SetActive(true);

		while (txStatus != "success")
		{
			if (loadingImage.fillAmount < 1)
            {
				loadingImage.fillAmount += 0.3f;
			}
            else
            {
				loadingImage.fillAmount = 0;
			}

			if (txStatus == "fail")
			{
				loadingResultText.text = "delivery failed";
				break;
			}

			loadingResultText.text = "delivering..";
			txStatus = await EVM.TxStatus("ethereum", "goerli", presentTransaction);
		}

		loadingResultText.text = "delivery complete!";

		loadingImage.gameObject.SetActive(false);
    }
 
	public void ClickRightMoveButton()
    {
        if (_currentTokenOrder < _totalTokenNumber - 1)
        {
			_currentTokenOrder++;
		}
        else
        {
			_currentTokenOrder = 0;
		}
	}

	public void ClickLeftMoveButton()
	{
		if (_currentTokenOrder > 0)
		{
			_currentTokenOrder--;
		}
		else
		{
			_currentTokenOrder = _totalTokenNumber-1;
		}
	}

	private void UpdateInventoryUI()
    {
		gunDogDnaText.text = gunDogDnas[_currentTokenOrder];
		currentTokenIndexText.text = Convert.ToString(_currentTokenOrder + 1);
		SelectRandom(gunDogDnas[_currentTokenOrder]);
	}

	private void SelectRandom(string gundogDna)
	{
		int index = 0;
		if (gundogDna.Length == 3)
			gundogDna = "0" + gundogDna;

		for(int i = 0; i < targetCategory.Length; i++)
        {
			string[] labels =
			LibraryAsset.GetCategoryLabelNames(targetCategory[i]).ToArray();

            switch (gundogDna[i])
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

			targetResolver[i].SetCategoryAndLabel(targetCategory[i], label);
		}
	}

	public void SaveDNA()
    {
		PlayerPrefs.SetString("DNA", gunDogDnas[_currentTokenOrder]);
    }
}
