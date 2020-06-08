using GAPP_Infrastructure.Domain;
using GAPP_Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GAPP.Controllers
{
	[Route("api/v1/posts")]
	[ApiController]
	public class PostsController : Controller
	{
		private readonly PostsService postsService;

		public PostsController(PostsService postsService)
		{
			this.postsService = postsService;
		}

		[HttpGet("{fileName}")]
		public IActionResult Test(string fileName)
		{
			return Ok(fileName);
		}

		[HttpPost("{fileName}")]
		public async Task<IActionResult> SavePost(string fileName)
		{
			var status = await postsService.SaveAccountPosts("dataFiles/" + fileName);

			return Ok(status);
		}

	}
}
