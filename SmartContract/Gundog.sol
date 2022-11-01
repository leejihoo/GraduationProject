// contracts/Gundog.sol
// SPDX-License-Identifier: MIT
// contract address: 0x83827fc421496f04c3688363429eb73395cadf7e
pragma solidity ^0.8.0;

import "@openzeppelin/contracts/token/ERC721/extensions/ERC721Enumerable.sol";
import "@openzeppelin/contracts/utils/Counters.sol";

contract Gundog is ERC721Enumerable {
    using Counters for Counters.Counter;
    Counters.Counter private _tokenIds;
    uint randomDNA;
    uint [] GundogDNAs; 
    event Created(uint256 newItemId, uint DNA);
    constructor() ERC721("Gundog", "GDG") {}

    function createDog(address player) public returns (uint256){
        uint256 newItemId = _tokenIds.current();
        _mint(player, newItemId);

        randomDNA = uint(keccak256(abi.encodePacked(block.timestamp, msg.sender, newItemId))) % 10000;
        GundogDNAs.push(randomDNA);
        _tokenIds.increment();
        emit Created(newItemId,GundogDNAs[newItemId]);
        return newItemId;
    }

    function searchDNA(uint256 GundogId) view public returns (uint)
    {
        return GundogDNAs[GundogId];
    }

}