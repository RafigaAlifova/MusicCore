using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Music : IEntity
    {
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public int GenreId { get; set; }
        public int SingerId { get; set; }
    }
}
