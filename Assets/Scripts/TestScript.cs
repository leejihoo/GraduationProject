using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScript : MonoBehaviour
{
    public FunctionDataModel transferFrom;
    public TextMeshProUGUI text;

    public CallDataModel tokenOfOwnerByIndex;
    // Start is called before the first frame update
    void Start()
    {
        TokenOfOwnerByIndex();
        // string response = await EVM.Call(tokenOfOwnerByIndex.Chain, tokenOfOwnerByIndex.Network, tokenOfOwnerByIndex.ContractAddress, 
        //  tokenOfOwnerByIndex.Abi, tokenOfOwnerByIndex.Method, "[\"0xFf7B4b56F3B43D7061Ded409eb5D86341DAD8a95\", \"0\"]");
        // text.text = response;
    }

    private async void TokenOfOwnerByIndex()
    {
        string response = await EVM.Call(tokenOfOwnerByIndex.Chain, tokenOfOwnerByIndex.Network, tokenOfOwnerByIndex.ContractAddress, 
            tokenOfOwnerByIndex.Abi, tokenOfOwnerByIndex.Method, "[\"0xFf7B4b56F3B43D7061Ded409eb5D86341DAD8a95\", \"0\"]");
        text.text = response;
    }
    
    
    // Update is called once per frame
    void Update()
    {

    }
}
