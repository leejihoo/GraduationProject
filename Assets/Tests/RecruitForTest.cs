using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitForTest
{
    private string _smartContractAddress = "0x846B1fe4b3449e1D6ab79D016831C54a036f2735";
    private int _totalGold = 50;

    public string SmartContractAddress => _smartContractAddress;
    public int TotalGold => _totalGold;

    public bool VerifySmartContractAddress(string address)
    {
        if (address == _smartContractAddress)
        {
            return true;
        }

        return false;
    }

    public bool VerifyGold(int neededGold)
    {
        if (_totalGold >= neededGold)
        {
            _totalGold -= neededGold;
            return true;
        }

        return false;
    }
}
