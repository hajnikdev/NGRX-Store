using PizzaWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Domain.Contracts
{
	public interface IPizzaWebService : IDisposable
	{
		/// <summary>
		/// Get All Pizzas
		/// </summary>
		/// <returns>List<Pizza></returns>
		Task<List<Pizza>> GetAllPizzasAsync();

		/// <summary>
		/// Get All Toppings
		/// </summary>
		/// <returns>List<Pizza></returns>
		Task<List<Topping>> GetAllToppingsAsync();
	}
}
