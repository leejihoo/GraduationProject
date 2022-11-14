// contracts/GLDToken.sol
// SPDX-License-Identifier: MIT
// ContractAddress: 0x846B1fe4b3449e1D6ab79D016831C54a036f2735
pragma solidity ^0.8.0;

import "@openzeppelin/contracts/token/ERC20/extensions/ERC20Burnable.sol";

contract GunDogGold is ERC20Burnable {
    constructor(uint256 initialSupply) ERC20("Gold", "GLD") {
        _mint(msg.sender, initialSupply);
    }

    function CreateGold(uint256 supply) public returns(uint256 result){
        _mint(msg.sender, supply);
        return supply;
    }

    function decimals() public view virtual override returns(uint8){
        return 0;
    }
}