using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HajnikPortfolio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaWeb.Domain.Contracts;

namespace HajnikPortfolio.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Toppings : ControllerBase
	{
		/// <summary>
		/// Coordinator2035Service
		/// </summary>
		public IPizzaWebService PizzaWebService { get; private set; }

		public Toppings(IPizzaWebService PizzaWebService)
		{
			this.PizzaWebService = PizzaWebService ?? throw new ArgumentNullException(nameof(PizzaWebService)); ;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllToppings()
		{
			try
			{
				var toppings = await PizzaWebService.GetAllToppingsAsync(); ;
				return Ok(toppings);
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
