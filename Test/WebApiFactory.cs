using BusinessLogic;
using DataAcess;
using DataAcess.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace FruitTest
{
    public class WebApiFactory : WebApplicationFactory<FruitApplication.Startup>
    {

    }
}
