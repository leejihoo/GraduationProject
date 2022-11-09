using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SmartContract", fileName = "SmartContractData")]
public class FunctionDataModel : ScriptableObject
{
    [SerializeField] private string method;
    [SerializeField] private string abi;
    [SerializeField] private string contractAddress;
    [SerializeField] private string args;
    [SerializeField] private string value;
    [SerializeField] private string gasLimit;
    [SerializeField] private string gasPrice;

    public string Method => method;
    public string Abi => abi;
    public string ContractAddress => contractAddress;
    public string Args => args;
    public string Value => value;
    public string GasLimit => gasLimit;
    public string GasPrice => gasPrice;

}
