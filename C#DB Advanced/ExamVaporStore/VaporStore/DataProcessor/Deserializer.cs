using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AutoMapper;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.ImportDtos;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            var games = new List<Game>();
            var sb = new StringBuilder();
            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = GetDeveloper(gameDto.Developer,context);
                var genre = GetGenre(gameDto.Genre, context);
                foreach (var gameDtoTag in gameDto.Tags)
                {
                    var tag = GetTag(gameDtoTag, context);
                }
                  
            }
        }

        private static object GetTag(string gameDtoTag, VaporStoreDbContext context)
        {
            var tag = context.Tags.FirstOrDefault(x => x.Name == gameDtoTag);

            if (tag == null)
            {
                tag = new Tag()
                {
                   Name = gameDtoTag
                };
                context.Tags.Add(tag);
                context.SaveChanges();
            }

            return tag;
        }

        private static Genre GetGenre(string gameDtoGenre, VaporStoreDbContext context)
        {
            var genre = context.Genres.FirstOrDefault(x => x.Name == gameDtoGenre);

            if (genre == null)
            {
                genre = new Genre()
                {
                    Name = gameDtoGenre
                };
                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static Developer GetDeveloper(string gameDtoDeveloper, VaporStoreDbContext context)
        {
            var developer = context.Developers.FirstOrDefault(x => x.Name == gameDtoDeveloper);

           if (developer == null)
           {
                developer = new Developer()
                {
                    Name = gameDtoDeveloper
                };
                context.Developers.Add(developer);
                context.SaveChanges();
           }

           return developer;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			throw new NotImplementedException();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}
	}
}