#I @"../packages/NUnit.2.6.4/lib"
#I @"../packages/FsCheck.2.0.7/lib/net45"

#r @"bin/Debug/ImmutableQueue.dll"
#r @"nunit.framework.dll"
#r "FsCheck.dll"

#load "ImmutableQueueTests.fs"

open System.Collections.Immutable
open System.Collections.Immutable.Tests.ImmutableQueueTests
open FsCheck

Check.Verbose enqueueAndToListEqualsOriginal<float>

enqueueAndToListEqualsOriginal [nan]

ImmutableQueue.enqueue nan ImmutableQueue.empty
|> ImmutableQueue.dequeue
