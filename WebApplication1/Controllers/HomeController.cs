using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IUserRepository _userRepository;

    public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        var users = _userRepository.GetAll();
        return View();
    }

    public IActionResult AddUser(User user)
    {
        var existedUser = _userRepository.GetUserByUsername(user.Username);
        if (existedUser == null)
        {
            _userRepository.Add(user);
        }
        var users = _userRepository.GetAll();
        return View("Index", users);
    }

    public IActionResult DeleteUser(int id)
    {
        try
        {
            var user = _userRepository.GetById(id);
            if( user != null)
            {
                _userRepository.Delete(user);
            }
            else
            {
                ModelState.AddModelError("username", "user is not existed");
            }
        }
        catch (Exception ex)
        {

        }
        var user = _userRepository.GetAll();
        return View("Index", user);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
