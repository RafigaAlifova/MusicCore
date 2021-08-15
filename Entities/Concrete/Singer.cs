using Core.Entities.Abstract;
namespace Entities.Concrete
{
    public class Singer : IEntity
    {
        public int SingerId { get; set; }
        public string SingerName { get; set; }

    }
}
