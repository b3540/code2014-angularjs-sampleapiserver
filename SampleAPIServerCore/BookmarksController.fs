namespace SampleAPIServer.Controller
open System.Linq
open SampleAPIServer.Models
open System.Web.Http.Cors

[<EnableCors("*", "*", "*")>]
type BookmarksController() = 
    inherit System.Web.Http.ApiController()
    
    let db = new SampleAPIDBContext()
    
    member this.Get() = db.Bookmarks
    
    member this.Get(id:int) = db.Bookmarks.Find(id)
    
    member this.Post(bookmark:Bookmark) = 
        bookmark |> db.Bookmarks.Add |> ignore
        db.SaveChanges() 
        |> ignore

    member this.Put(id:int, value:Bookmark) =
        let bookmark = this.Get(id)
        bookmark.Title <- value.Title
        bookmark.URL <- value.URL
        bookmark.Rating <- value.Rating
        db.SaveChanges() |> ignore

    member this.Delete(id: int) =
        id |> this.Get |> db.Bookmarks.Remove |> ignore
        db.SaveChanges() |> ignore
