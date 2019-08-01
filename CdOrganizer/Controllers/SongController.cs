using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;
using System.Collections.Generic;

namespace CdOrganizer.Controllers
{
  public class AlbumsController : Controller
  {
    [HttpGet("/albumLists/{albumListId}/songs/new")]
    public ActionResult New(int albumListId)
    {
      AlbumList albumList = AlbumList.Find(albumListId);
      return View(albumList);
    }

    [HttpGet("/albumLists/{albumListId}/albums/{songId}")]
    public ActionResult Show(int albumListId, int songId)
    {
      Song song = Song.Find(songId);
      AlbumList albumList = AlbumList.Find(albumListId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("song", song);
      model.Add("albumList", albumList);
      return View(model);
    }


    // //This will be useful later
    // [HttpPost("/songs/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Song.ClearAll();
    //   return View();
    // }
  }
}