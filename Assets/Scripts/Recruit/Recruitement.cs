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
		
		[SerializeField] private SpriteLibrary spriteLibrary = default;
		[SerializeField] private SpriteResolver[] targetResolver = default;
		[SerializeField] private string[] targetCategory = default;
		[SerializeField] private FunctionDataModel createDogFunction;
		[SerializeField] private FunctionDataModel burnFunction;
		[SerializeField] private CallDataModel searchDnaCall;
		[SerializeField] private Text needCoinText;
		
		private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;
		private const int NeedCoin = 5;

		public void Start()
		{
			needCoinText.text = NeedCoin.ToString();
		}

		public async void Recruit()
		{
			try
			{
				string temp = await Web3GL.SendContract(burnFunction.Method, burnFunction.Abi, 
					burnFunction.ContractAddress, $"[\"{NeedCoin}\"]", burnFunction.Value, 
					"", "");
				string args = $"[\"{PlayerPrefs.GetString("Account")}\"]";
				// 컨트렉트의 return을 반환한다. 새로운 토큰의 tokenId를 반환한다.
				string callResponse = await EVM.Call("ethereum", "goerli", createDogFunction.ContractAddress, createDogFunction.Abi
					, createDogFunction.Method, args);
				// 트랜잭션 해쉬를 반환한다. 
				string response = await Web3GL.SendContract(createDogFunction.Method, createDogFunction.Abi, 
					createDogFunction.ContractAddress, args, createDogFunction.Value, 
					"", "");
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

				string searchResponse = await EVM.Call(searchDnaCall.Chain, searchDnaCall.Network, searchDnaCall.ContractAddress, 
					searchDnaCall.Abi, searchDnaCall.Method, $"[\"{int.Parse(callResponse)}\"]");

				SelectRandom(searchResponse);
				result.text = searchResponse;
				Debug.Log(response);
			}
			catch (Exception e)
			{
				Debug.LogException(e, this);
				result.text = "Fail";
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
