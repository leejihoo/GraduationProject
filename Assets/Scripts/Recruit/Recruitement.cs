using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.UI;

namespace Recruit
{
	public class Recruitement : MonoBehaviour
	{
		public Text result;

		[SerializeField]
		private SpriteLibrary spriteLibrary = default;

		[SerializeField]
		private SpriteResolver[] targetResolver = default;

		[SerializeField]
		private string[] targetCategory = default;

		private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;
		
		public async void Recruit()
		{
			#region SmartContractInfo

			// smart contract method to call
			string method = "createDog";
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
		""name "": ""ApprovalForAll "",
		""type "": ""event""
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
			// address of contract
			string contract = "0x83827fc421496f04c3688363429eb73395cadf7e";
			// array of arguments for contract
			string args = $"[\"{PlayerPrefs.GetString("Account")}\"]";
			// value in wei
			string value = "0";
			// gas limit OPTIONAL
			string gasLimit = "";
			// gas price OPTIONAL
			string gasPrice = "";
			// connects to user's browser wallet (metamask) to update contract state

			#endregion
			
			try
			{
				string callResponse = await EVM.Call("ethereum", "goerli", contract, abi, method, args);
				string response = await Web3GL.SendContract(method, abi, contract, args, value, gasLimit, gasPrice);
				string txStatus = await EVM.TxStatus("ethereum", "goerli", response);

				while(txStatus != "success")
				{
					if(txStatus == "fail")
					{
						result.text = "Fail";
						break;
					}

					int randomValue = UnityEngine.Random.Range(0, 10000);

					SelectRandom(randomValue.ToString());

					result.text = "pedding... Wait Please";
					txStatus = await EVM.TxStatus("ethereum", "goerli", response);
				}

				string searchResponse = await EVM.Call("ethereum", "goerli", contract, abi, "searchDNA", $"[\"{int.Parse(callResponse)}\"]");

				SelectRandom(searchResponse);
				result.text = searchResponse;
				Debug.Log(response);
			}
			catch (Exception e)
			{
				Debug.LogException(e, this);
				result.text = "Ffail";
			}

		}

		private void SelectRandom(string gundogDna)
		{
			int index = 0;
			
			while (gundogDna.Length <= 3)
			{
				gundogDna = "0" + gundogDna;
			}

			for (int i = 0; i < targetCategory.Length; i++)
			{
				string[] labels = LibraryAsset.GetCategoryLabelNames(targetCategory[i]).ToArray();

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
	}
}
