#load "ImmutableQueue.fs"
open System.Collections.Immutable

ImmutableQueue.empty
|> ImmutableQueue.enqueue 1
|> ImmutableQueue.enqueue 2
|> ImmutableQueue.toList
