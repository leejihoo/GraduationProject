using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class ERC721BalanceOfExample : MonoBehaviour
{
    async void Start()
    {
        string chain = "ethereum";
        string network = "goerli";
        string contract = "0x94f3f1dab5325d96bc39cd14866d5ad755869fea";
        string account = "0xFf7B4b56F3B43D7061Ded409eb5D86341DAD8a95";

        int balance = await ERC721.BalanceOf(chain, network, contract, account);
        print("balance: " + balance);
    }
}
