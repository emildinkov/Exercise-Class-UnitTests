using System;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Reflection;
using NUnit.Framework;
using TestApp.Chat;
namespace TestApp.Tests;

[TestFixture]
public class ChatRoomTests
{
    private ChatRoom _chatRoom = null!;
    
    [SetUp]
    public void Setup()
    {
        this._chatRoom = new();
    }
    
    [Test]
    public void Test_SendMessage_MessageSentToChatRoom()
    {
        // Arrange
        string sender = "Bob";
        string message = "Hello";

        // Act
        this._chatRoom.SendMessage(sender, message);
        string result = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Does.Contain("Chat Room Messages:"));
        Assert.That(result, Does.Contain($"{sender}: {message} - Sent at "));
    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        // Arrange

        // Act
        string result = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        // Arrange
        string senderOne = "Bob";
        string messageOne = "Hello";
        string senderTwo = "Alice";
        string messageTwo = "Love";

        // Act
        this._chatRoom.SendMessage(senderOne, messageOne);
        this._chatRoom.SendMessage(senderTwo, messageTwo);
        string result = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Does.Contain("Chat Room Messages:"));
        Assert.That(result, Does.Contain($"{senderOne}: {messageOne} - Sent at "));
        Assert.That(result, Does.Contain($"{senderTwo}: {messageTwo} - Sent at "));
    }
}
