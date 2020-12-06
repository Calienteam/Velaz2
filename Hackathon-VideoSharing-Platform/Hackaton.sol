// SPDX-License-Identifier: GPL-3.0

pragma solidity >=0.7.0 <0.8.0;

/**
 * @title Storage
 * @dev Store & retrieve value in a variable
 */
contract HackatonStorage {

    mapping (address => string) pubKeys;
    mapping (address => string) ipfsHashes;
    mapping (string => uint256) prices;
    
     event Payment(
        address _from,
        address _to,
        uint256 amount,
        string ipfsHash,
        string pubKey
    );
    
    

    function pay(address payable _to, string calldata  ipfsHash, string calldata pubKey) public payable {
        require(msg.value >= prices[ipfsHash]);

        _to.transfer(msg.value);
        emit Payment(msg.sender, _to, msg.value, ipfsHash, pubKey);
    }
    
    event VideoPassword(string encryptedPassword, string ipfsHash, address buyerAddress);
    
    function emitVideoPassword (string calldata encryptedPassword, string calldata ipfsHash, address buyerAddress) public{
        emit VideoPassword(encryptedPassword, ipfsHash, buyerAddress);    
    }
    
    
    
    function setPrice(string calldata ipfsHash, uint256 price) public {
        // require (ipfsHashes[msg.sender] == ipfsHash);
        prices[ipfsHash] = price;
    }
    
    function setPubkey(string calldata pubKey) public {
        pubKeys[msg.sender] = pubKey;
    }
    
    function setIpfsHash(string calldata ipfsHash) public {
        ipfsHashes[msg.sender] = ipfsHash;
    }

    
    function getPrice(string calldata ipfsHash) public view returns (uint256){
        return prices[ipfsHash];
    } 
    
    function getPubKey(address addr) public view returns (string memory){
        return pubKeys[addr];
    }
    
    function getIpfsHash(address addr) public view returns (string memory){
        return ipfsHashes[addr];
    }
    
}