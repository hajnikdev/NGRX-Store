using HajnikPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using PizzaWeb.Domain.Contracts;
using PizzaWeb.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HajnikPortfolio.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Pizzas : ControllerBase
	{
		/// <summary>
		/// Coordinator2035Service
		/// </summary>
		public IPizzaWebService PizzaWebService { get; private set; }

		public Pizzas(IPizzaWebService PizzaWebService) 
		{
			this.PizzaWebService = PizzaWebService ?? throw new ArgumentNullException(nameof(PizzaWebService)); ;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllPizzas()
		{
			try
			{
				var pizzas = await PizzaWebService.GetAllPizzasAsync(); ;
				return Ok(pizzas);
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

		//[HttpPost]
		//public Pizza CreatePizza([FromBody] Pizza pizza)
		//{
		//	var a = pizza;
		//	return this.pizzaStoreContext.CreatePizza(pizza);
		//}
	}
}
