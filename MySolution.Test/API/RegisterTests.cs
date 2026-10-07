using System.Net;
using MySolution.Core.API.Clients;
using MySolution.Core.API.Models;

namespace MySolution.Test.API;

public class RegisterTests
{
    public RegisterClient Client { get; set; }

    [SetUp]
    public void Setup()
    {
        Client = new RegisterClient("https://reqres.in/");
    }

    [Test]
    public void PostRegister_Success()
    {
        var registerRequest = new RegisterRequest()
        {
            Email = "eve.holt@reqres.in",
            Password = "pistol",
        };
            
        var response = Client.PostRegister(registerRequest);
        
        Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Success.Id, Is.EqualTo(4));
        Assert.That(response.Success.Token, Is.Not.Null);
    }
    
    [Test]
    public void PostRegister_Empty_Fields()
    {
        var registerRequest = new RegisterRequest()
        {
            Email = "",
            Password = ""
        };
            
        var response = Client.PostRegister(registerRequest);
        
        Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(response.Error.Error, Is.EqualTo("Missing email or username"));
    }
}