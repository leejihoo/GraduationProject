using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

namespace Lobby
{
    public class UpdateTotalCoin : MonoBehaviour
    {
        [SerializeField] private CallDataModel balanceOfGoldCall;
        [SerializeField] private Text totalGoldText;
        async void Update()
        {
            BigInteger balanceOf = await ERC20.BalanceOf(balanceOfGoldCall.Chain, balanceOfGoldCall.Network, 
                balanceOfGoldCall.ContractAddress,PlayerPrefs.GetString("Account"));
            // "0xFf7B4b56F3B43D7061Ded409eb5D86341DAD8a95"
            totalGoldText.text = balanceOf.ToString();
        }
    }
}
