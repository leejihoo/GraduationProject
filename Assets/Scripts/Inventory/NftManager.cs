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
	[SerializeField]
	private SpriteLibrary spriteLibrary = default;

	[SerializeField]
	private SpriteResolver[] targetResolver = default;

	[SerializeField]
	private string[] TargetCategory = default;

	private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;

	public Text GunDogDnaText;
	public Text CurrentTokenOrder;
	public Text LoadingResult;
	public Image LoadingImage;
	public TMP_InputField InputAddress;

	public List<string> GugDogDNAs;
	private int _currentTokenOrder;
	private int _totalTokenNumber;

	[SerializeField]
	private string _PresentToAddress;
	[SerializeField]
	private GameObject _charater;

    public NftManager()
    {
        GugDogDNAs = new List<string>();
		_currentTokenOrder = 0;
		_totalTokenNumber = 0;
	}

    // Start is called before the first frame update
    async private void Start()
    {

		string chain = "ethereum";
		string network = "goerli";
		string contract = "0x83827fc421496f04c3688363429eb73395cadf7e";
		string account = PlayerPrefs.GetString("Account");
		int balance = await ERC721.BalanceOf(chain, network, contract, account);
		_totalTokenNumber = balance;

		AddDNAs(balance);

	}

    private void Update()
    {
        if (_charater.activeSelf)
        {
			UpdateInventoryUI();
			_PresentToAddress = InputAddress.text;
		}

	}

    async public void AddDNAs(int balance)
	{

		#region ContractInfo
		// set chain: ethereum, moonbeam, polygon etc
		string chain = "ethereum";
		// set network mainnet, testnet
		string network = "goerli";
		// smart contract method to call
		string method = "tokenOfOwnerByIndex";
		// abi in json format
		string abi = @"[
	{
		""inputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""owner"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""approved"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""Approval"",
		""type"": ""event""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""owner"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""operator"",
				""type"": ""address""
			},
			{
				""indexed"": false,
				""internalType"": ""bool"",
				""name"": ""approved"",
				""type"": ""bool""
			}
		],
		""name"": ""ApprovalForAll"",
		""type"": ""event""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""from"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""to"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""Transfer"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""to"",
				""type"": ""address""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""approve"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""owner"",
				""type"": ""address""
			}
		],
		""name"": ""balanceOf"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""player"",
				""type"": ""address""
			}
		],
		""name"": ""createDog"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""getApproved"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""owner"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""operator"",
				""type"": ""address""
			}
		],
		""name"": ""isApprovedForAll"",
		""outputs"": [
			{
				""internalType"": ""bool"",
				""name"": """",
				""type"": ""bool""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""name"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""ownerOf"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""from"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""to"",
				""type"": ""address""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""safeTransferFrom"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""from"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""to"",
				""type"": ""address""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""bytes"",
				""name"": ""data"",
				""type"": ""bytes""
			}
		],
		""name"": ""safeTransferFrom"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""GundogId"",
				""type"": ""uint256""
			}
		],
		""name"": ""searchDNA"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""operator"",
				""type"": ""address""
			},
			{
				""internalType"": ""bool"",
				""name"": ""approved"",
				""type"": ""bool""
			}
		],
		""name"": ""setApprovalForAll"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""bytes4"",
				""name"": ""interfaceId"",
				""type"": ""bytes4""
			}
		],
		""name"": ""supportsInterface"",
		""outputs"": [
			{
				""internalType"": ""bool"",
				""name"": """",
				""type"": ""bool""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""symbol"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""index"",
				""type"": ""uint256""
			}
		],
		""name"": ""tokenByIndex"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""owner"",
				""type"": ""address""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""index"",
				""type"": ""uint256""
			}
		],
		""name"": ""tokenOfOwnerByIndex"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""tokenURI"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""totalSupply"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""from"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""to"",
				""type"": ""address""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""transferFrom"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	}
]";
		#endregion

		// address of contract
		string contract = "0x83827fc421496f04c3688363429eb73395cadf7e";
		// array of arguments for contract

		//GugDogDNAs.Clear();

		for (int i = 0; i < balance; i++)
        {
			string args = $"[\"{PlayerPrefs.GetString("Account")}\",\"{i}\"]";
			// connects to user's browser wallet to call a transaction
			string response = await EVM.Call(chain, network, contract, abi, method, args);
			response = await EVM.Call(chain, network, contract, abi, "searchDNA", $"[\"{response}\"]");
			GugDogDNAs.Add(response);
		}

		_charater.SetActive(true);
	}

	async public void PresentToken()
    {
		#region ContractInfo
		// set chain: ethereum, moonbeam, polygon etc
		string chain = "ethereum";
		// set network mainnet, testnet
		string network = "goerli";
		// smart contract method to call
		string method = "tokenOfOwnerByIndex";
		// abi in json format
		string abi = @"[
	{
		""inputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""owner"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""approved"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""Approval"",
		""type"": ""event""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""owner"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""operator"",
				""type"": ""address""
			},
			{
				""indexed"": false,
				""internalType"": ""bool"",
				""name"": ""approved"",
				""type"": ""bool""
			}
		],
		""name"": ""ApprovalForAll"",
		""type"": ""event""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""from"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""to"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""Transfer"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""to"",
				""type"": ""address""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""approve"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""owner"",
				""type"": ""address""
			}
		],
		""name"": ""balanceOf"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""player"",
				""type"": ""address""
			}
		],
		""name"": ""createDog"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""getApproved"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""owner"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""operator"",
				""type"": ""address""
			}
		],
		""name"": ""isApprovedForAll"",
		""outputs"": [
			{
				""internalType"": ""bool"",
				""name"": """",
				""type"": ""bool""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""name"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""ownerOf"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""from"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""to"",
				""type"": ""address""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""safeTransferFrom"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""from"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""to"",
				""type"": ""address""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""bytes"",
				""name"": ""data"",
				""type"": ""bytes""
			}
		],
		""name"": ""safeTransferFrom"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""GundogId"",
				""type"": ""uint256""
			}
		],
		""name"": ""searchDNA"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""operator"",
				""type"": ""address""
			},
			{
				""internalType"": ""bool"",
				""name"": ""approved"",
				""type"": ""bool""
			}
		],
		""name"": ""setApprovalForAll"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""bytes4"",
				""name"": ""interfaceId"",
				""type"": ""bytes4""
			}
		],
		""name"": ""supportsInterface"",
		""outputs"": [
			{
				""internalType"": ""bool"",
				""name"": """",
				""type"": ""bool""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""symbol"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""index"",
				""type"": ""uint256""
			}
		],
		""name"": ""tokenByIndex"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""owner"",
				""type"": ""address""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""index"",
				""type"": ""uint256""
			}
		],
		""name"": ""tokenOfOwnerByIndex"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""tokenURI"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""totalSupply"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""from"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""to"",
				""type"": ""address""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""tokenId"",
				""type"": ""uint256""
			}
		],
		""name"": ""transferFrom"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	}
]";
		#endregion

		// address of contract
		string contract = "0x83827fc421496f04c3688363429eb73395cadf7e";
		string args = $"[\"{PlayerPrefs.GetString("Account")}\",\"{_currentTokenOrder}\"]";
		// connects to user's browser wallet to call a transaction
		string response = await EVM.Call(chain, network, contract, abi, method, args);
		
		//string temptAddress = "0x0436480c30fbda970D620BcaBFd0aCB4fCB5669f";
		
		args = $"[\"{PlayerPrefs.GetString("Account")}\",\"{_PresentToAddress}\",\"{int.Parse(response)}\"]";
		//args = $"[\"{PlayerPrefs.GetString("Account")}\",\"0x0436480c30fbda970D620BcaBFd0aCB4fCB5669f\",\"{int.Parse(response)}\"]";
		string PresentTransaction = await Web3GL.SendContract("transferFrom", abi, contract, args, "0", "", "");


		string txStatus = await EVM.TxStatus("ethereum", "goerli", PresentTransaction);

		LoadingImage.gameObject.SetActive(true);

		while (txStatus != "success")
		{
			if (LoadingImage.fillAmount < 1)
            {
				LoadingImage.fillAmount += 0.3f;
			}
            else
            {
				LoadingImage.fillAmount = 0;
			}

			if (txStatus == "fail")
			{
				LoadingResult.text = "delivery failed";
				break;
			}

			LoadingResult.text = "delivering..";
			txStatus = await EVM.TxStatus("ethereum", "goerli", PresentTransaction);
		}

		LoadingResult.text = "delivery complete!";

		LoadingImage.gameObject.SetActive(false);
		BalanceOfGundogToken();
		AddDNAs(_totalTokenNumber);

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

	public void UpdateInventoryUI()
    {
		GunDogDnaText.text = GugDogDNAs[_currentTokenOrder];
		CurrentTokenOrder.text = Convert.ToString(_currentTokenOrder + 1);
		SelectRandom(GugDogDNAs[_currentTokenOrder]);
	}

	public void SelectRandom(string GundogDNA)
	{
		int index = 0;
		if (GundogDNA.Length == 3)
			GundogDNA = "0" + GundogDNA;

		for(int i = 0; i < TargetCategory.Length; i++)
        {
			string[] labels =
			LibraryAsset.GetCategoryLabelNames(TargetCategory[i]).ToArray();

            switch (GundogDNA[i])
            {
				case '0': case '1': case '2':
					index = 0;
					break;
				case '3': case '4': case '5':
					index = 1;
					break;
				case '6': case '7': case '8': case '9':
					index = 2;
					break;
            }

			string label = labels[index];

			targetResolver[i].SetCategoryAndLabel(TargetCategory[i], label);
		}


	}

	public void MetaMaskAddressChange(TextMeshProUGUI text)
    {
		
		//_PresentToAddress = text.text;
		
	}

	async public void BalanceOfGundogToken()
    {
		string chain = "ethereum";
		string network = "goerli";
		string contract = "0x83827fc421496f04c3688363429eb73395cadf7e";
		string account = PlayerPrefs.GetString("Account");
		int balance = await ERC721.BalanceOf(chain, network, contract, account);
		_totalTokenNumber = balance;

		//AddDNAs(_totalTokenNumber);
	}

	public void SaveDNA()
    {
		PlayerPrefs.SetString("DNA", GugDogDNAs[_currentTokenOrder]); 

	}
}
