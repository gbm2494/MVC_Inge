using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using MVC_Capas.Services.Interface;
using MVC_Capas.Services.Implementation;
using MVC_Capas.DAOs.Interface;
using MVC_Capas.DAOs.Implementation;

namespace MVC_Capas
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

    // register all your components with the container here
    // it is NOT necessary to register your controllers

    // e.g. container.RegisterType<ITestService, TestService>();    

    /*Services*/
    container.RegisterType<IClientsService, ClientsServiceImpl>();

    /*DAOs*/   
    container.RegisterType<IPersonaDAO, PersonaDAOImpl>();

    RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}