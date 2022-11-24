using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentForTest : MonoBehaviour
{
    private string _walletAddress = "0xFf7B4b56F3B43D7061Ded409eb5D86341DAD8a95";
    private int _charaterCount = 5;

    public string WalletAddress => _walletAddress;
    public int CharaterCount => _charaterCount;
    
    public bool VerifyWalletAddress(string address)
    {
        if (address == _walletAddress)
        {
            return true;
        }

        return false;
    }

    public bool Verifycharater(int charaterIndex)
    {
        if (_charaterCount >= charaterIndex)
        {
            return true;
        }

        return false;
    }
}
