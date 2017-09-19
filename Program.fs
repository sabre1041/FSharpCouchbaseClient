open System
open System.Collections.Generic
open Newtonsoft.Json
open Couchbase
open Couchbase.Configuration.Client

type Result<'a,'b> = Success of 'a | Failure of 'b

let toGenericList lst = List<_>(List.toSeq lst)

let fetch (cluster: Cluster) bucketName (query: string) =
    using (cluster.OpenBucket(bucketName)) 
        (fun bucket -> 
            using (bucket.Query(query))
                (fun result -> if result.Success 
                               then Success <| JsonConvert.SerializeObject(result) 
                               else Failure <| sprintf "%A, %A" result.Errors result.Exception))

[<EntryPoint>]
let main argv =
    let uris = [Uri("http://localhost:8091")]
    let cluster = new Cluster(ClientConfiguration(Servers = toGenericList uris, UseSsl = false))

    ("travel-sample", "SELECT * FROM `travel-sample` LIMIT 10")
    ||> fetch cluster
    |> function
       | Success msg -> printfn "SUCCESS: %s" msg
       | Failure msg -> printfn "FAILED:\n%s" msg
    0
    