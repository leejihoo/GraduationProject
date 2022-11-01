using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;

public class Recruitement : MonoBehaviour
{
	public Text Result;
	public Text CallResult;
	public Text SearchResult;
	async public void Recruit()
	{
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
		try
		{
			string callResponse = await EVM.Call("ethereum", "goerli", contract, abi, method, args);
			string response = await Web3GL.SendContract(method, abi, contract, args, value, gasLimit, gasPrice);
			string searchResponse = await EVM.Call("ethereum", "goerli", contract, abi, "searchDNA", $"[\"{int.Parse(callResponse)}\"]");

			Debug.Log(response);
			CallResult.text = callResponse;
			Result.text = response;
			SearchResult.text = searchResponse;
		}
		catch (Exception e)
		{
			Debug.LogException(e, this);
			Result.text = "FAIL";
		}

	}

	

}
