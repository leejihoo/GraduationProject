using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxStatus: MonoBehaviour
{
    async void Start()
    {
        string chain = "ethereum";
        string network = "goerli";
        string transaction = "0xa319f625e57428a69d2e3e4c5e29ec246230c7b0cdb94f3aadcd3833cee7ab1e";

        string txStatus = await EVM.TxStatus(chain, network, transaction);
        print(txStatus); // success, fail, pending
    }
}
