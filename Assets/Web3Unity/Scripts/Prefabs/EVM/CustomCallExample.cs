using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCallExample : MonoBehaviour
{

	public Text result;
//    async void Start()
//    {
//        /*
//        // SPDX-License-Identifier: MIT
//        pragma solidity ^0.8.0;

//        contract AddTotal {
//            uint256 public myTotal = 0;

//            function addTotal(uint8 _myArg) public {
//                myTotal = myTotal + _myArg;
//            }
//        }
//        */
//        // set chain: ethereum, moonbeam, polygon etc
//        string chain = "ethereum";
//        // set network mainnet, testnet
//        string network = "goerli";
//        // smart contract method to call
//        string method = "createDog";
//        // abi in json format
//        string abi = @"[
//	{
//		""inputs"": [],
//		""stateMutability"": ""nonpayable"",
//		""type"": ""constructor""
//	},
//	{
//		""anonymous"": false,
//		""inputs"": [
//			{
//				""indexed"": true,
//				""internalType"": ""address"",
//				""name"": ""owner"",
//				""type"": ""address""
//			},
//			{
//				""indexed"": true,
//				""internalType"": ""address"",
//				""name"": ""approved"",
//				""type"": ""address""
//			},
//			{
//				""indexed"": true,
//				""internalType"": ""uint256"",
//				""name"": ""tokenId"",
//				""type"": ""uint256""
//			}
//		],
//		""name"": ""Approval"",
//		""type"": ""event""
//	},
//	{
//		""anonymous"": false,
//		""inputs"": [
//			{
//				""indexed"": true,
//				""internalType"": ""address"",
//				""name"": ""owner"",
//				""type"": ""address""
//			},
//			{
//				""indexed"": true,
//				""internalType"": ""address"",
//				""name"": ""operator"",
//				""type"": ""address""
//			},
//			{
//				""indexed"": false,
//				""internalType"": ""bool"",
//				""name"": ""approved"",
//				""type"": ""bool""
//			}
//		],
//		""name"": ""ApprovalForAll"",
//		""type"": ""event""
//	},
//	{
//		""anonymous"": false,
//		""inputs"": [
//			{
//				""indexed"": true,
//				""internalType"": ""address"",
//				""name"": ""from"",
//				""type"": ""address""
//			},
//			{
//				""indexed"": true,
//				""internalType"": ""address"",
//				""name"": ""to"",
//				""type"": ""address""
//			},
//			{
//				""indexed"": true,
//				""internalType"": ""uint256"",
//				""name"": ""tokenId"",
//				""type"": ""uint256""
//			}
//		],
//		""name"": ""Transfer"",
//		""type"": ""event""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""address"",
//				""name"": ""to"",
//				""type"": ""address""
//			},
//			{
//				""internalType"": ""uint256"",
//				""name"": ""tokenId"",
//				""type"": ""uint256""
//			}
//		],
//		""name"": ""approve"",
//		""outputs"": [],
//		""stateMutability"": ""nonpayable"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""address"",
//				""name"": ""owner"",
//				""type"": ""address""
//			}
//		],
//		""name"": ""balanceOf"",
//		""outputs"": [
//			{
//				""internalType"": ""uint256"",
//				""name"": """",
//				""type"": ""uint256""
//			}
//		],
//		""stateMutability"": ""view"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""address"",
//				""name"": ""player"",
//				""type"": ""address""
//			}
//		],
//		""name"": ""createDog"",
//		""outputs"": [
//			{
//				""internalType"": ""uint256"",
//				""name"": """",
//				""type"": ""uint256""
//			}
//		],
//		""stateMutability"": ""nonpayable"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""uint256"",
//				""name"": ""tokenId"",
//				""type"": ""uint256""
//			}
//		],
//		""name"": ""getApproved"",
//		""outputs"": [
//			{
//				""internalType"": ""address"",
//				""name"": """",
//				""type"": ""address""
//			}
//		],
//		""stateMutability"": ""view"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""address"",
//				""name"": ""owner"",
//				""type"": ""address""
//			},
//			{
//				""internalType"": ""address"",
//				""name"": ""operator"",
//				""type"": ""address""
//			}
//		],
//		""name"": ""isApprovedForAll"",
//		""outputs"": [
//			{
//				""internalType"": ""bool"",
//				""name"": """",
//				""type"": ""bool""
//			}
//		],
//		""stateMutability"": ""view"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [],
//		""name"": ""name"",
//		""outputs"": [
//			{
//				""internalType"": ""string"",
//				""name"": """",
//				""type"": ""string""
//			}
//		],
//		""stateMutability"": ""view"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""uint256"",
//				""name"": ""tokenId"",
//				""type"": ""uint256""
//			}
//		],
//		""name"": ""ownerOf"",
//		""outputs"": [
//			{
//				""internalType"": ""address"",
//				""name"": """",
//				""type"": ""address""
//			}
//		],
//		""stateMutability"": ""view"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""address"",
//				""name"": ""from"",
//				""type"": ""address""
//			},
//			{
//				""internalType"": ""address"",
//				""name"": ""to"",
//				""type"": ""address""
//			},
//			{
//				""internalType"": ""uint256"",
//				""name"": ""tokenId"",
//				""type"": ""uint256""
//			}
//		],
//		""name"": ""safeTransferFrom"",
//		""outputs"": [],
//		""stateMutability"": ""nonpayable"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""address"",
//				""name"": ""from"",
//				""type"": ""address""
//			},
//			{
//				""internalType"": ""address"",
//				""name"": ""to"",
//				""type"": ""address""
//			},
//			{
//				""internalType"": ""uint256"",
//				""name"": ""tokenId"",
//				""type"": ""uint256""
//			},
//			{
//				""internalType"": ""bytes"",
//				""name"": ""data"",
//				""type"": ""bytes""
//			}
//		],
//		""name"": ""safeTransferFrom"",
//		""outputs"": [],
//		""stateMutability"": ""nonpayable"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""uint256"",
//				""name"": ""GundogId"",
//				""type"": ""uint256""
//			}
//		],
//		""name"": ""searchDNA"",
//		""outputs"": [
//			{
//				""internalType"": ""uint256"",
//				""name"": """",
//				""type"": ""uint256""
//			}
//		],
//		""stateMutability"": ""view"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""address"",
//				""name"": ""operator"",
//				""type"": ""address""
//			},
//			{
//				""internalType"": ""bool"",
//				""name"": ""approved"",
//				""type"": ""bool""
//			}
//		],
//		""name"": ""setApprovalForAll"",
//		""outputs"": [],
//		""stateMutability"": ""nonpayable"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""bytes4"",
//				""name"": ""interfaceId"",
//				""type"": ""bytes4""
//			}
//		],
//		""name"": ""supportsInterface"",
//		""outputs"": [
//			{
//				""internalType"": ""bool"",
//				""name"": """",
//				""type"": ""bool""
//			}
//		],
//		""stateMutability"": ""view"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [],
//		""name"": ""symbol"",
//		""outputs"": [
//			{
//				""internalType"": ""string"",
//				""name"": """",
//				""type"": ""string""
//			}
//		],
//		""stateMutability"": ""view"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""uint256"",
//				""name"": ""tokenId"",
//				""type"": ""uint256""
//			}
//		],
//		""name"": ""tokenURI"",
//		""outputs"": [
//			{
//				""internalType"": ""string"",
//				""name"": """",
//				""type"": ""string""
//			}
//		],
//		""stateMutability"": ""view"",
//		""type"": ""function""
//	},
//	{
//		""inputs"": [
//			{
//				""internalType"": ""address"",
//				""name"": ""from"",
//				""type"": ""address""
//			},
//			{
//				""internalType"": ""address"",
//				""name"": ""to"",
//				""type"": ""address""
//			},
//			{
//				""internalType"": ""uint256"",
//				""name"": ""tokenId"",
//				""type"": ""uint256""
//			}
//		],
//		""name"": ""transferFrom"",
//		""outputs"": [],
//		""stateMutability"": ""nonpayable"",
//		""type"": ""function""
//	}
//]";
//        // address of contract
//        string contract = "0x52be329A424eF520ba626e3Cb508Ae6732AdA342";
//        // array of arguments for contract
//        string args = @"[""0xFf7B4b56F3B43D7061Ded409eb5D86341DAD8a95""]";
//        // connects to user's browser wallet to call a transaction
//        string response = await EVM.Call(chain, network, contract, abi, method, args);
//        // display response in game
//        print(response);
//    }

	async public void createToken()
    {
		/*
        // SPDX-License-Identifier: MIT
        pragma solidity ^0.8.0;

        contract AddTotal {
            uint256 public myTotal = 0;

            function addTotal(uint8 _myArg) public {
                myTotal = myTotal + _myArg;
            }
        }
        */
		// set chain: ethereum, moonbeam, polygon etc
		string chain = "ethereum";
		// set network mainnet, testnet
		string network = "goerli";
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
		string contract = "0x94f3f1dab5325d96bc39cd14866d5ad755869fea";
		// array of arguments for contract
		string args = @"[""0xFf7B4b56F3B43D7061Ded409eb5D86341DAD8a95""]";
		// connects to user's browser wallet to call a transaction
		string response = await EVM.Call(chain, network, contract, abi, method, args);
		// display response in game
		print(response);
		result.text = response;

	}
}
