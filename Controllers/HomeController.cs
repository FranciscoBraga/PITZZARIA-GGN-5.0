

using Microsoft.AspNetCore.Mvc;
using Npgsql;
using PizzariaGGN.Models;

namespace PizzariaGGN.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly DatabaseConnection _dbconnection;

    public HomeController(ILogger<HomeController> logger, DatabaseConnection databaseConnection)
    {
        _logger = logger;
        _dbconnection = databaseConnection;

    }

    public IActionResult Index()
    {
        using var conn = _dbconnection.GetConnection();
        using var cmd = new NpgsqlCommand("select a.nome,a.email from usuario a",conn);
        using var read = cmd.ExecuteReader();

        while(read.read){
            nome.add (read.GetString(0));
            email.add(read.GetString(1));

            ViewData ["nome"] = nome;
            ViewData ["email"] =email;
            ViewData ["cont"] = cont; 

        }

        
        return View();
    }

    public IActionResult Pizza()
    {
        
        return View();
    }
    public IActionResult Refrigerante()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<IActionResult>Register(User user,IFormFile Photo){

    if(ModelState.IsValid){
        await _userRepository.InsertUser(user,Photo);
        return RedirectToAction("Index");

    }    
     return View(user);
    }
    public IActionResult ListUser(){
        var users = _userRepository.ListUser();
        return View(users);
    }
}
