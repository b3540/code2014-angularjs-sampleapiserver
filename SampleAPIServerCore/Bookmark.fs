namespace SampleAPIServer.Models
open System

[<CLIMutable>]
type Bookmark = {
    mutable Id : int
    mutable Title : string
    mutable URL : string
    mutable Rating : int
}
