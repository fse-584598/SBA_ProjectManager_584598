# ProjectManger.NBenchPerformanceTesting.ProjectManagerLoadTest+TestGetProjects_Success
_5/15/2019 5:54:25 AM_
### System Info
```ini
NBench=NBench, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
OS=Microsoft Windows NT 6.2.9200.0
ProcessorCount=4
CLR=4.0.30319.42000,IsMono=False,MaxGcGeneration=2
```

### NBench Settings
```ini
RunMode=Iterations, TestMode=Test
SkipWarmups=True
NumberOfIterations=500, MaximumRunTime=00:00:01
Concurrent=False
Tracing=False
```

## Data
-------------------

### Totals
|          Metric |           Units |             Max |         Average |             Min |          StdDev |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|TotalCollections [Gen0] |     collections |            0.00 |            0.00 |            0.00 |            0.00 |
|TotalCollections [Gen1] |     collections |            0.00 |            0.00 |            0.00 |            0.00 |
|TotalCollections [Gen2] |     collections |            0.00 |            0.00 |            0.00 |            0.00 |
|TotalBytesAllocated |           bytes |            0.00 |            0.00 |            0.00 |            0.00 |
|[Counter] AddCounter |      operations |            0.00 |            0.00 |            0.00 |            0.00 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|TotalCollections [Gen0] |     collections |            0.00 |            0.00 |            0.00 |            0.00 |
|TotalCollections [Gen1] |     collections |            0.00 |            0.00 |            0.00 |            0.00 |
|TotalCollections [Gen2] |     collections |            0.00 |            0.00 |            0.00 |            0.00 |
|TotalBytesAllocated |           bytes |            0.00 |            0.00 |            0.00 |            0.00 |
|[Counter] AddCounter |      operations |            0.00 |            0.00 |            0.00 |            0.00 |

### Raw Data
#### TotalCollections [Gen0]
|           Run # |     collections | collections / s |ns / collections |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            0.00 |            0.00 |          100.00 |

#### TotalCollections [Gen1]
|           Run # |     collections | collections / s |ns / collections |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            0.00 |            0.00 |          100.00 |

#### TotalCollections [Gen2]
|           Run # |     collections | collections / s |ns / collections |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            0.00 |            0.00 |          100.00 |

#### TotalBytesAllocated
|           Run # |           bytes |       bytes / s |      ns / bytes |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            0.00 |            0.00 |          100.00 |

#### [Counter] AddCounter
|           Run # |      operations |  operations / s | ns / operations |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            0.00 |            0.00 |          100.00 |


## Benchmark Assertions

* [FAIL] Expected [Counter] AddCounter to must be greater than 200.00 operations; actual value was 0.00 operations.

```
NBench.NBenchException: Error occurred during $ProjectManger.NBenchPerformanceTesting.ProjectManagerLoadTest+TestGetProjects_Success RUN. ---> System.InvalidOperationException: No connection string named 'ProjectManagerContainer' could be found in the application config file.
   at System.Data.Entity.Internal.LazyInternalConnection.get_ConnectionHasModel()
   at System.Data.Entity.Internal.LazyInternalContext.InitializeContext()
   at System.Data.Entity.Internal.InternalContext.Initialize()
   at System.Data.Entity.Internal.InternalContext.GetEntitySetAndBaseTypeForType(Type entityType)
   at System.Data.Entity.Internal.Linq.InternalSet`1.Initialize()
   at System.Data.Entity.Internal.Linq.InternalSet`1.get_InternalContext()
   at System.Data.Entity.Infrastructure.DbQuery`1.System.Linq.IQueryable.get_Provider()
   at System.Linq.Queryable.Where[TSource](IQueryable`1 source, Expression`1 predicate)
   at lambda_method(Closure , Project )
   at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
   at ProjectManager.BC.ProjectBC.RetrieveProjects() in C:\PravinGupta_613786\FSE_SBA\SourceCode\server\ProjectManager\ProjectManager\BC\ProjectBC.cs:line 25
   at ProjectManager.Controllers.ProjectController.RetrieveProjects() in C:\PravinGupta_613786\FSE_SBA\SourceCode\server\ProjectManager\ProjectManager\Controllers\ProjectController.cs:line 32
   at ProjectManger.NBenchPerformanceTesting.ProjectManagerLoadTest.TestGetProjects_Success(BenchmarkContext benchContext) in C:\PravinGupta_613786\FSE_SBA\SourceCode\server\ProjectManager\ProjectManger.NBenchPerformanceTesting\ProjectManagerLoadTest.cs:line 60
   at NBench.Sdk.Benchmark.WarmUp()
   --- End of inner exception stack trace ---
```

