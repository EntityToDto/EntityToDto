# EntityToDto

Entity to DTO mapper that enables a granular mapping configuration without the use of ```System.Reflection```.

#### Mapping depth configuration
* Recursive map of **_identity property/ies only_**, use **```MappingDepth.Keys```**
```csharp
    Genre genre = new Genre()
    {
        ID = 1,
        Name = "Classical"
    };
    var dto = Mapper.Map<GenreDto, Genre>(genre, MappingDepth.Keys);
```
* Recursive map of **_all primitive type property/ies only_**, use **```MappingDepth.Primitives```**
```csharp
    Genre genre = new Genre()
    {
        ID = 1,
        Name = "Classical"
    };
    var dto = Mapper.Map<GenreDto, Genre>(genre, MappingDepth.Primitives);
```
* ... and other modes of mapping configuration in sample [Unit Tests](https://github.com/EntityToDto/master/blob/master/tests/UnitTests/MapperTests.cs)

#### Create subclass of ```DtoMapVisitor<TDto, TEntity>```
```DtoMapVisitor<TDto, TEntity>``` is inspired from Visitor design pattern. The idea is that, the ```DtoMapVisitor<TDto, TEntity>``` is responsible for mutating properties of entity to your DTO's properties. [See this example of a map visitor](https://github.com/EntityToDto/master/blob/master/tests/UnitTests/DtoMapping/TrackMapVisitor.cs)
