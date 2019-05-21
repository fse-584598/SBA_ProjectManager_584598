# ProjectManger.NBenchPerformanceTesting.ProjectManagerLoadTest+TestInsertTasks_Success
_5/15/2019 5:55:02 AM_
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
NBench.NBenchException: Error occurred during $ProjectManger.NBenchPerformanceTesting.ProjectManagerLoadTest+TestInsertTasks_Success RUN. ---> System.InvalidOperationException: No connection string named 'ProjectManagerContainer' could be found in the application config file.
   at System.Data.Entity.Internal.LazyInternalConnection.get_ConnectionHasModel()
   at System.Data.Entity.Internal.LazyInternalContext.InitializeContext()
   at System.Data.Entity.Internal.InternalContext.Initialize()
   at System.Data.Entity.Internal.InternalContext.GetEntitySetAndBaseTypeForType(Type entityType)
   at System.Data.Entity.Internal.Linq.InternalSet`1.Initialize()
   at System.Data.Entity.Internal.Linq.InternalSet`1.get_InternalContext()
   at System.Data.Entity.Internal.Linq.InternalSet`1.ActOnSet(Action action, EntityState newState, Object entity, String methodName)
   at System.Data.Entity.Internal.Linq.InternalSet`1.Add(Object entity)
   at System.Data.Entity.DbSet`1.Add(TEntity entity)
   at ProjectManager.BC.TaskBC.InsertTaskDetails(Task task) in C:\PravinGupta_613786\FSE_SBA\SourceCode\server\ProjectManager\ProjectManager\BC\TaskBC.cs:line 83
   at ProjectManager.Controllers.TaskController.InsertTaskDetails(Task task) in C:\PravinGupta_613786\FSE_SBA\SourceCode\server\ProjectManager\ProjectManager\Controllers\TaskController.cs:line 82
   at ProjectManger.NBenchPerformanceTesting.ProjectManagerLoadTest.TestInsertTasks_Success(BenchmarkContext benchContext) in C:\PravinGupta_613786\FSE_SBA\SourceCode\server\ProjectManager\ProjectManger.NBenchPerformanceTesting\ProjectManagerLoadTest.cs:line 327
   at NBench.Sdk.Benchmark.WarmUp()
   --- End of inner exception stack trace ---
```

