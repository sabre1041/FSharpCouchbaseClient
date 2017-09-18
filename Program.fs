open System
open System.Collections.Generic
open Newtonsoft.Json
open Couchbase
open Couchbase.Configuration.Client

let toGenericList lst = List<_>(List.toSeq lst)

let fetch (cluster: Cluster) (query: string) =
    using (cluster.OpenBucket("travel-sample")) 
        (fun bucket -> 
            using (bucket.Query(query))
                (fun result -> JsonConvert.SerializeObject(result)))

[<EntryPoint>]
let main argv =
    let uris = [Uri("http://localhost:8091")]
    let cluster = new Cluster(ClientConfiguration(Servers = toGenericList uris, UseSsl = false))

    "SELECT * FROM `travel-sample` LIMIT 10"
    |> fetch cluster
    |> printfn "%s"
    0
    