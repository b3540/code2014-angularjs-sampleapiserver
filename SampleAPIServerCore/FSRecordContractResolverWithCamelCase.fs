namespace SampleAPIServer
open System
open System.Linq
open System.Reflection
open Newtonsoft.Json.Serialization

type FSRecordContractResolverWithCamelCase() =

    inherit CamelCasePropertyNamesContractResolver()

    override this.GetSerializableMembers (objectType: Type) =
        objectType
            .GetProperties()
            .Cast<MemberInfo>()
            .ToList()
