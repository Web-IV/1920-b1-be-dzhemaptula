namespace ZoundAPI.Models.Domain
{
    public sealed class FavoriteRoom
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoomId { get; set; }
        public MusicRoom Room { get; set; }

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
