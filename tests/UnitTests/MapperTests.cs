using EntityToDto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Dtos;
using UnitTests.Entities;

namespace UnitTests
{
    [TestClass]
    public class MapperTests
    {
        [TestMethod]
        public void MappingDepth_Keys_ExcludesPrimitiveProperties()
        {
            Genre genre = new Genre()
            {
                ID = 1,
                Name = "Classical"
            };

            var dto = Mapper.Map<GenreDto, Genre>(genre, MappingDepth.Keys);

            Assert.IsNotNull(dto);
            Assert.AreEqual(genre.ID, dto.ID);
            Assert.IsNull(dto.Name);
        }

        [TestMethod]
        public void MappingDepth_Primitives_MapsAllPrimitiveTypes()
        {
            Genre genre = new Genre()
            {
                ID = 1,
                Name = "Classical"
            };

            var dto = Mapper.Map<GenreDto, Genre>(genre, MappingDepth.Primitives);
            
            Assert.IsNotNull(dto);
            Assert.AreEqual(genre.ID, dto.ID);
            Assert.AreEqual(genre.Name, dto.Name);
        }

        [TestMethod]
        public void MappingDepth_BitOR_KeysRoot_MapsAllPrimitivesInRootObjectAndOnlyKeysOnItsProperties()
        {
            Track track = new Track()
            {
                ID = 1,
                Name = "\"Eine Kleine Nachtmusik\" Serenade In G, K. 525: I. Allegro",
                Composer = "Wolfgang Amadeus Mozart",
                Milliseconds = 348971,
                Bytes = 5760129,
                UnitPrice = .99m,

                Genre = new Genre
                {
                    ID = 1,
                    Name = "Classical"
                },

                MediaType = new MediaType
                {
                    ID = 1,
                    Name = "Protected AAC audio file"
                }
            };

            var dto = Mapper.Map<TrackDto, Track>(track, MappingDepth.Root | MappingDepth.Keys);

            Assert.IsNotNull(dto);
            Assert.AreEqual(track.ID, dto.ID);
            Assert.AreEqual(track.Name, dto.Name);
            Assert.AreEqual(track.Composer, dto.Composer);
            Assert.AreEqual(track.Milliseconds, dto.Milliseconds);
            Assert.AreEqual(track.Bytes, dto.Bytes);
            Assert.AreEqual(track.UnitPrice, dto.UnitPrice);
            Assert.AreEqual(track.Genre.ID, dto.Genre.ID);
            Assert.AreEqual(track.MediaType.ID, dto.MediaType.ID);
            Assert.IsNull(dto.Genre.Name);
            Assert.IsNull(dto.MediaType.Name);
        }

        [TestMethod]
        public void MappingDepth_BitOR_PrimitivesRoot_MapsAllPrimitivesInBothRootObjectItsProperties()
        {
            Track track = new Track()
            {
                ID = 1,
                Name = "\"Eine Kleine Nachtmusik\" Serenade In G, K. 525: I. Allegro",
                Composer = "Wolfgang Amadeus Mozart",
                Milliseconds = 348971,
                Bytes = 5760129,
                UnitPrice = .99m,

                Genre = new Genre
                {
                    ID = 1,
                    Name = "Classical"
                },

                MediaType = new MediaType
                {
                    ID = 1,
                    Name = "Protected AAC audio file"
                }
            };

            var dto = Mapper.Map<TrackDto, Track>(track, MappingDepth.Root | MappingDepth.Primitives);

            Assert.IsNotNull(dto);
            Assert.AreEqual(track.ID, dto.ID);
            Assert.AreEqual(track.Name, dto.Name);
            Assert.AreEqual(track.Composer, dto.Composer);
            Assert.AreEqual(track.Milliseconds, dto.Milliseconds);
            Assert.AreEqual(track.Bytes, dto.Bytes);
            Assert.AreEqual(track.UnitPrice, dto.UnitPrice);
            Assert.AreEqual(track.Genre.ID, dto.Genre.ID);
            Assert.AreEqual(track.MediaType.ID, dto.MediaType.ID);
            Assert.AreEqual(track.Genre.Name, dto.Genre.Name);
            Assert.AreEqual(track.MediaType.Name, dto.MediaType.Name);
        }
    }
}
