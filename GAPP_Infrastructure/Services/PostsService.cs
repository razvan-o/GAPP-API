using GAPP_Infrastructure.Domain;
using GAPP_Infrastructure.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GAPP_Infrastructure.Services
{
	public class PostsService
	{
		private readonly InstagramAccountRepository instagramAccountRepository;
		private readonly InstagramPostRepository instagramPostRepository;

		public PostsService(InstagramAccountRepository instagramAccountRepository, InstagramPostRepository instagramPostRepository)
		{
			this.instagramAccountRepository = instagramAccountRepository;
			this.instagramPostRepository = instagramPostRepository;
		}

		public async Task<string> SaveAccountPosts(string fileName)
		{
			var account = new InstagramAccount();
			int totalPosts;

			FileStream fileStream = new FileStream(fileName, FileMode.Open);
			using (StreamReader reader = new StreamReader(fileStream))
			{
				account.Name = fileName[10..^4];
				var dataLines = GetPostDataList(reader);
				totalPosts = dataLines.Count;
				account.InstagramPosts = GetPostsFromStringData(dataLines);
			}

			instagramAccountRepository.DbSet.Add(account);
			await instagramAccountRepository.SaveChangesAsync();

			return $"posts saved: {account.InstagramPosts.Count};\ttotal posts:{totalPosts}";
		}


		private List<InstagramPost> GetPostsFromStringData(List<string> dataLines)
		{
			var posts = new List<InstagramPost>();
			foreach (var line in dataLines)
			{
				try
				{
					var postJObject = JObject.Parse(line);
					posts.Add(GetPostFromJObject(postJObject));
				}
				catch
				{
					continue;
				}
			}

			return posts;
		}

		private InstagramPost GetPostFromJObject(JObject postJObject)
		{
			var postProperties = postJObject.Children().ToList();

			var post = new InstagramPost()
			{
				Id = postProperties[0].First.ToString(),
				Date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
					.AddSeconds(double.Parse(postProperties[1].First.ToString())).ToLocalTime(),
				ShortCode = postProperties[2].First.ToString(),
				Url = postProperties[3].First.ToString(),
				Caption = postProperties[4].First.ToString(),
				LikesCount = long.Parse(postProperties[5].First.ToString()),
				Hashtags = postProperties[6].First.ToString().Replace("\\n", "").Replace("\\r", ""),
				CommentsCount = long.Parse(postProperties[7].First.ToString())

			};

			return post;
		}

		private static List<string> GetPostDataList(StreamReader reader)
		{
			var lines = new List<string>();
			string line;

			while ((line = reader.ReadLine()) != null)
			{
				line = line.Replace("\\n", "").Replace("\\", "");
				line = line.Substring(1, line.Length - 2);

				line = Regex.Replace(line, @"\p{Cs}", "");

				lines.Add(line);
			}

			return lines;
		}
	}
}
