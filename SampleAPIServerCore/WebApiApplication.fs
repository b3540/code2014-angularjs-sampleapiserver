namespace SampleAPIServer
open System.Data.Entity
open System.Web.Http
open System.Reflection
open Newtonsoft.Json.Serialization;
open SampleAPIServer.Models

type defaults = {id:RouteParameter}

type WebApiApplication() =
    inherit System.Web.HttpApplication()

    let ConfigureWebAPI(config : HttpConfiguration) =
        
        let contractResolver = new FSRecordContractResolverWithCamelCase()
        //let contractResolver = new CamelCasePropertyNamesContractResolver()
        config.Formatters
            .JsonFormatter
            .SerializerSettings
            .ContractResolver <- contractResolver
        
        config.EnableCors()
        
        config.MapHttpAttributeRoutes();
        
        config.Routes.MapHttpRoute("DefaultApi","api/{controller}/{id}",{id=RouteParameter.Optional})

        |> ignore

    member this.Application_Start() =
        GlobalConfiguration.Configure(fun config -> ConfigureWebAPI config)
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SampleAPIDBContext>());
