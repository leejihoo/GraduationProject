using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System;

public class AllErc721Example : MonoBehaviour
{
    public Text result;
    private class NFTs
    {
        public string contract { get; set; }
        public string tokenId { get; set; }
        public string uri { get; set; }
        public string balance { get; set; }
    }

    async void Start()
    {
        string chain = "ethereum";
        string network = "goerli"; // mainnet ropsten kovan rinkeby goerli
        string account = "0xFf7B4b56F3B43D7061Ded409eb5D86341DAD8a95";
        string contract = "";
        int first = 500;
        int skip = 0;
        string[] obj = { account };
        string args = JsonConvert.SerializeObject(obj);

        string response = await EVM.AllErc721(chain, network, args, contract, first, skip);
        try
        {
            NFTs[] erc721s = JsonConvert.DeserializeObject<NFTs[]>(response);
            print(erc721s[0].contract);
            print(erc721s[0].tokenId);
            print(erc721s[0].uri);
            print(erc721s[0].balance);
        }
        catch
        {
            print("Error: " + response);
        }
    }

    //async public void SearchERC721Info()
    //{
    //    string chain = "ethereum";
    //    string network = "goerli"; // mainnet ropsten kovan rinkeby goerli
    //    string account =  "0xFf7B4b56F3B43D7061Ded409eb5D86341DAD8a95";

    //    string contract = "";
    //    int first = 500;
    //    int skip = 0;
    //    string response = await EVM.AllErc721(chain, network, account, contract, first, skip);
    //    try
    //    {
    //        NFTs[] erc721s = JsonConvert.DeserializeObject<NFTs[]>(response);
    //        print(erc721s[0].contract);
    //        print(erc721s[0].tokenId);
    //        print(erc721s[0].uri);
    //        print(erc721s[0].balance);

    //        result.text = erc721s[0].contract + " " + erc721s[0].tokenId;
    //    }
    //    catch
    //    {
    //        print("Error: " + response);
    //        print(account);
    //    }
    //}
}
