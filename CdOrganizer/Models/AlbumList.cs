using System.Collections.Generic;

namespace CdOrganizer.Models
{
  public class AlbumList
  {
    private static List<AlbumList> _instances = new List<AlbumList> { };
    public string Name { get; set; }
    public int Id { get; }
    public List<Song> Songs { get; set; }

    public AlbumList(string albumListName)
    {
      Name = albumListName;
      _instances.Add(this);
      Id = _instances.Count;
      Songs = new List<Song> { };
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<AlbumList> GetAll()
    {
      return _instances;
    }

    public static AlbumList Find(int searchId)
    {
      return _instances[searchId - 1];
    }


    public void AddSong(Song song)
    {
      Songs.Add(song);
    }
  }
}