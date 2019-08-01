using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;

namespace CdOrganizer.Controllers
{
  public class AlbumListsController : Controller
  {
    [HttpGet("/albumLists")]
    public ActionResult Index()
    {
      List<AlbumList> allAlbumLists = AlbumList.GetAll();
      return View(allAlbumLists);
    }

    [HttpGet("/albumLists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/albumLists")]
    public ActionResult Create(string albumListName)
    {
      AlbumList newAlbumList = new AlbumList(albumListName);
      return RedirectToAction("Index");
    }

    [HttpGet("/albumLists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      AlbumList selectedAlbumList = AlbumList.Find(id);
      List<Song> albumListSongs = selectedAlbumList.Songs;
      model.Add("albumList", selectedAlbumList);
      model.Add("songs", albumListSongs);
      return View(model);
    }

    // This one creates new Songs within a given AlbumList, not new AlbumLists:
    [HttpPost("/albumLists/{albumListId}/songs")]
    public ActionResult Create(int albumListId, string songDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      AlbumList foundAlbumList = AlbumList.Find(albumListId);
      Song newSong = new Song(songDescription);
      foundAlbumList.AddSong(newSong);
      List<Song> albumListSongs = foundAlbumList.Songs;
      model.Add("songs", albumListSongs);
      model.Add("albumList", foundAlbumList);
      return View("Show", model);
    }
  }
}