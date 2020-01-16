# ExtendsApi
[![latest version](https://img.shields.io/nuget/v/ExtendsApi)](https://www.nuget.org/packages/ExtendsApi/) [![downloads](https://img.shields.io/nuget/dt/ExtendsApi)](https://www.nuget.org/packages/ExtendsApi)

Extends the most common things from an API

### Installation

ExtendsApi is available on [NuGet](https://www.nuget.org/packages/ExtendsApi).

```sh
dotnet add package ExtendsApi
```

Use the `--version` option to specify a [preview version](https://www.nuget.org/packages/ExtendsApi/absoluteLatest) to install.

Use the [daily builds](https://github.com/dotnet/aspnetcore/blob/master/docs/DailyBuilds.md) to verify bug fixes and provide early feedback.

### Usage

The following code demonstrates basic usage of ExtendsApi.

#### Inject BaseRepository
```cs
using X.BL.DTO;
using X.BL.Mappers;
using ExtendsApi.DataLayer.Interfaces;
using ExtendsApi.Models;
using System;
using System.Collections.Generic;

public class XService : IXService
{
  private readonly IBaseRepository<XModel, typeId> _repository;
  
  public XService(IBaseRepository<XModel, typeId> repository)
  {
    _repository = repository;
  }
  
  public Response<List<XModelDTO>> GetAll()
  {
    try
    {
      var list = _repository.GetAll();
      if (list == null)
        return new Response<List<XModelDTO>>().AddNotFoundMessage("There aren't XModel.");

      var listDTO = XModelMapper.MapFromEntityToDTO(list);

      return new Response<List<XModelDTO>> { Model = listDTO };
    }
    catch (Exception ex)
    {
      return new Response<List<XModelDTO>>().AddException(ex);
    }
  }
}
```
