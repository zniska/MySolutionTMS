using System.Net;
using MySolution.Core.API.Clients;

namespace MySolution.Test.API;

[TestFixture]
public class ApiTests
{
    public UsersClient Client { get; set; }

    [SetUp]
    public void Setup()
    {
        Client = new UsersClient("https://reqres.in/");
    }
    
    [Test]
    public void GetUser_ShouldReturnUser()
    {
        var response = Client.GetUser(2);
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        Assert.Multiple(() =>
        {
            Assert.That(response.Data.Data.FirstName, Is.EqualTo("Janet"));
            Assert.That(response.Data.Data.LastName, Is.EqualTo("Weaver"));
        });
    }
    
    [Test]
    public void GetUserPage()
    {
        var response = Client.GetUserPage(2);
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data.Data.Count, Is.EqualTo(6));
        Assert.That(response.Data.Data[0].FirstName, Is.EqualTo("Michael"));
    }
}