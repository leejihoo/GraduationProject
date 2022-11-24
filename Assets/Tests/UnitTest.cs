using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitTest
{
    private RecruitForTest _recruitForTest = new RecruitForTest();
    private PresentForTest _presentForTest = new PresentForTest();
    private DnaForTest _dnaForTest = new DnaForTest();
    
    [Test]
    public void CorrectSmartContractAddress()
    {
        var result = _recruitForTest.VerifySmartContractAddress("0x846B1fe4b3449e1D6ab79D016831C54a036f2735");
        Assert.AreEqual(true, result);
    }
    
    [Test]
    public void InColletSmartContractAddress()
    {
        var result = _recruitForTest.VerifySmartContractAddress("아무문자당");
        Assert.AreEqual( false, result);
    }

    [Test]
    public void SufficientGold()
    {
        var result = _recruitForTest.VerifyGold(50);
            Assert.AreEqual(true,result);
    } 
    
    [Test]
    public void InSufficientGold()
    {
        var result = _recruitForTest.VerifyGold(70);
            Assert.AreEqual(false,result);
    }
    
    [Test]
    public void CorrectWalletAddress()
    {
        var result = _presentForTest.VerifyWalletAddress("0xFf7B4b56F3B43D7061Ded409eb5D86341DAD8a95");
        Assert.AreEqual(true, result);
    }
    
    [Test]
    public void InColletWalletAddress()
    {
        var result = _presentForTest.VerifyWalletAddress("아무문자당");
        Assert.AreEqual( false, result);
    }

    [Test]
    public void CharaterExit()
    {
        var result = _presentForTest.Verifycharater(5);
        Assert.AreEqual(true,result);
    } 
    
    [Test]
    public void CharaterNotExit()
    {
        var result = _presentForTest.Verifycharater(7);
        Assert.AreEqual(false,result);
    }

    [Test]
    public void CorrectDna()
    {
        var result = _dnaForTest.CheckDna(5000);
        Assert.AreEqual(true,result);
    }
    
    [Test]
    public void InCorrectDna()
    {
        var result = _dnaForTest.CheckDna(99999);
        Assert.AreEqual(false,result);
    }
}
