namespace System.Collections.Immutable

type ImmutableQueue<'t> = { Front: List<'t>; Back: List<'t> }

module ImmutableQueue =
    let empty = { Front = []; Back = [] }

    let enqueue item queue = { queue with Front = queue.Front; Back = item :: queue.Back }

    let inline private dequeueSimple front back =
        List.head front, { Front = List.tail front; Back = back }

    let dequeue queue =
        match queue with
        | { Front = []; Back = [] } -> raise <| System.InvalidOperationException ()
        | { Front = []; Back = back } -> let front = List.rev back in dequeueSimple front []
        | { Front = front; Back = back } -> dequeueSimple front back

    let isEmpty queue =
        match queue with
        | { Front = []; Back = [] } -> true
        | _ -> false

    let toList queue = queue.Front @ (List.rev queue.Back)

    let toSeq queue = seq { yield! queue.Front
                            yield! List.rev queue.Back }

    let ofList list = { Front = list; Back = [] }

    let ofSeq source = ofList <| List.ofSeq source
