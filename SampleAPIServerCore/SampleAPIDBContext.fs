namespace SampleAPIServer.Models
open System.Data.Entity;

type SampleAPIDBContext() =
    inherit DbContext()

    [<DefaultValue>] val mutable bookmarks : DbSet<Bookmark>
    member this.Bookmarks with get() = this.bookmarks and set(x) = this.bookmarks <- x
