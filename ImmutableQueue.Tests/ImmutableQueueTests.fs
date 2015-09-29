module System.Collections.Immutable.Tests.ImmutableQueueTests

open System.Collections.Immutable
open NUnit.Framework
open FsCheck

let enqueAndDequeueReturnsOriginal item =
    let actual = ImmutableQueue.empty |> ImmutableQueue.enqueue item |> ImmutableQueue.dequeue
    let expected = item, ImmutableQueue.empty
    actual = expected

[<Test>]
let ``Enqueue on empty produces queue with single Item`` () =
    Check.QuickThrowOnFailure enqueAndDequeueReturnsOriginal

let enqueueAndToListEqualsOriginal<'t when 't : equality> (list: 't list) =
    let rec toList queue =
        if ImmutableQueue.isEmpty queue then [] else
        let head, tail = ImmutableQueue.dequeue queue
        head :: toList tail

    let actual =
        List.fold (fun queue item -> ImmutableQueue.enqueue item queue) ImmutableQueue.empty list
        |> toList

    let expected = list

    actual = expected

[<Test>]
let ``Enqueue and Dequeue a list retains order`` () =
    Check.QuickThrowOnFailure enqueueAndToListEqualsOriginal<int>
    Check.QuickThrowOnFailure enqueueAndToListEqualsOriginal<NormalFloat>
    Check.QuickThrowOnFailure enqueueAndToListEqualsOriginal<string>

let ofListAndToList<'t when 't : equality> list =
    let actual = list |> ImmutableQueue.ofList |> ImmutableQueue.toList
    let expected = list
    actual = expected

[<Test>]
let ``Round trip ofList and toList`` () =
    Check.QuickThrowOnFailure ofListAndToList<int>
    Check.QuickThrowOnFailure ofListAndToList<NormalFloat>
    Check.QuickThrowOnFailure ofListAndToList<string>
