using DailyProgress.VideoGameApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DailyProgress.VideoGameApi.Data;

namespace DailyProgress.VideoGameApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public VideoGameController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ResponseModel<List<VideoGame>> GetAllVideoGames()
        {
            var videoGames = dbContext.VideoGames.ToList();
            return new ResponseModel<List<VideoGame>>(data : videoGames, true, "Video games retrieved successfully.");

        }

        [HttpGet("{id}")]
        public ResponseModel<VideoGame> GetVideoGameById(int id)
        {
            var videoGame = dbContext.VideoGames.Find(id);

            if (videoGame == null)
                return new ResponseModel<VideoGame>(data: null, false, "Video game not found.");

            return new ResponseModel<VideoGame>(data: videoGame, true, "Video game retrieved successfully.");
        }

        [HttpPost]
        public ResponseModel<VideoGame> AddVideoGame(AddVideoGameDto addVideoGameDto)
        {
            var videoGameEntity = new VideoGame()
            {
                Title = addVideoGameDto.Title,
                Publisher = addVideoGameDto.Publisher,
                Platform = addVideoGameDto.Platform,
                Developer = addVideoGameDto.Developer
            };

            if (string.IsNullOrEmpty(videoGameEntity.Title) ||
               string.IsNullOrEmpty(videoGameEntity.Publisher) ||
               string.IsNullOrEmpty(videoGameEntity.Platform) ||
                string.IsNullOrEmpty(videoGameEntity.Developer)
               )
            {
                return new ResponseModel<VideoGame>(data: null, false, "Video game not found.");
            }
            dbContext.VideoGames.Add(videoGameEntity);
            dbContext.SaveChanges();

            return new ResponseModel<VideoGame>(data: videoGameEntity, true, "Video game added successfully.");
        }

        [HttpPut("{id}")]
        public ResponseModel<VideoGame> UpdateVideoGame(int id, UpdateVideoGameDto updateVideoGameDto)
        {
            var videoGameEntity = dbContext.VideoGames.Find(id);

            if (videoGameEntity == null)
                return new ResponseModel<VideoGame>(data: null, false, "Video game not found.");

            videoGameEntity.Title = updateVideoGameDto.Title;
            videoGameEntity.Publisher = updateVideoGameDto.Publisher;
            videoGameEntity.Platform = updateVideoGameDto.Platform;
            videoGameEntity.Developer = updateVideoGameDto.Developer;

            dbContext.VideoGames.Update(videoGameEntity);
            dbContext.SaveChanges();
            return new ResponseModel<VideoGame>(data: videoGameEntity, true, "Video game updated successfully.");
        }

        [HttpDelete("{id}")]
        public ResponseModel<VideoGame> DeleteVideoGame(int id)
        {
            var videoGameEntity = dbContext.VideoGames.Find(id);
            if (videoGameEntity == null)
                    return new ResponseModel<VideoGame>(data: null, false, "Video game not found.");

            dbContext.VideoGames.Remove(videoGameEntity);
            dbContext.SaveChanges();

            return new ResponseModel<VideoGame>(data: null, true, "Video game deleted successfully.");
        }
    }
}