using System.Net;
using MySolution.Core.API;
using MySolution.Core.API.Clients;
using MySolution.Core.API.Models.Responses;
using Newtonsoft.Json;

namespace MySolution.Test.API;

[TestFixture]
public class UsersApiTests : BaseTestApi
{
    public UserClient Client { get; set; }

    [OneTimeSetUp]
    public void Setup()
    {
        Client = new UserClient("https://reqres.in/");
    }
    
    [Test]
    public void GetUsers_Success()
    {
        var usersListResponse = Client.GetUsers();
        Assert.That(usersListResponse.Data.Count, Is.EqualTo(6));
        Assert.That(usersListResponse.Data[0].FirstName, Is.EqualTo("George"));
    }
    
    [Test]
    public void GetUser_Success()
    {
        var usersListResponse = Client.GetUser(2);
        Assert.That(usersListResponse.Data.Id, Is.EqualTo(2));
        Assert.That(usersListResponse.Data.FirstName, Is.EqualTo("Janet"));
    }
    
    [Test]
    public void GetUsersSecondPage_Success()
    {
        var usersListResponse = Client.GetUsersByPage(2);
        Assert.That(usersListResponse.Data.Count, Is.EqualTo(6));
        Assert.That(usersListResponse.Data[0].FirstName, Is.EqualTo("Michael"));
    }
}