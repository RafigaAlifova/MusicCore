using Core.Entities.Abstract;
namespace Entities.Dtos
{
    public class MusicDetail : IDto
    {
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public string GenreName { get; set; }
        public string SingerName { get; set; }
    }
}
