using System.ComponentModel.DataAnnotations.Schema;

namespace ZoundAPI.Models.Domain
{
    public class FeaturedArtist
    {
        [ForeignKey(nameof(ArtistId))] 
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }

        [ForeignKey(nameof(SongId))]
        public Song Song { get; set; }
        public int SongId { get; set; }

        public FeaturedArtist(Artist artist, Song song)
        {
            Artist = artist;
            Song = song;
            ArtistId = artist.ArtistId;
            SongId = song.SongId;
        }

        public FeaturedArtist()
        {
        }
    }
}
