using UnityEngine;

[CreateAssetMenu(fileName = "CallData", menuName = "ScriptableObject/Call")]
public class CallDataModel : ScriptableObject
{
    [SerializeField] private string chain;
    [SerializeField] private string network;
    [SerializeField] private string contractAddress;
    [SerializeField] private string abi;
    [SerializeField] private string method;
    [SerializeField] private string args;
    [SerializeField] private string rpc;

    public string Chain => chain;
    public string Network => network;
    public string ContractAddress => contractAddress;
    public string Abi => abi;
    public string Method => method;
    public string Args => args;
    public string Rpc => rpc;
}
