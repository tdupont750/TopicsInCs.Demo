using Microsoft.AspNetCore.Mvc;
using TopicsInCs.Demo.Social;

namespace TopicsInCs.Demo.Web.Controllers;

[ApiController, Route("friends")]
public class FriendsListController : ControllerBase
{
    private readonly FriendListService _friendListService;

    public FriendsListController(FriendListService friendListService)
    {
        _friendListService = friendListService;
    }
    
    [HttpGet, Route(nameof(List))]
    public IActionResult List()
    {
        var allFriends = _friendListService.List();
        return Ok(allFriends);
    }

    [HttpPost, Route(nameof(Add))]
    public IActionResult Add([FromQuery]string firstName, [FromQuery]string lastName)
    {
        var isAddSuccess = _friendListService.Add(firstName, lastName);
        return isAddSuccess ? Ok() : BadRequest();
    }

    [HttpDelete, Route(nameof(Remove))]
    public IActionResult Remove([FromQuery]string firstName, [FromQuery]string lastName)
    {
        var isRemoveSuccess = _friendListService.Remove(firstName, lastName);
        return isRemoveSuccess ? Ok() : NotFound();
    }
}