namespace ZoundAPI.Models.Domain
{
    public class FavoriteRoom
    {
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual int RoomId { get; set; }
        public virtual MusicRoom Room { get; set; }

        public FavoriteRoom(User user, MusicRoom musicroom)
        {
            User = user;
            Room = musicroom;
            UserId = user.UserId;
            RoomId = musicroom.RoomId;
        }

        public FavoriteRoom()
        {
        }
    }
}
