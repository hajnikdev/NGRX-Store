using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using MySql.Data.MySqlClient;
using PizzaWeb.Domain.Contracts;
using PizzaWeb.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaWeb.Infrastructure.Data
{
	public class PizzaWebRepository : IPizzaWebRepository
	{
		private readonly MySqlConnection connection;
		private readonly IMapper mapper;
		private readonly IMemoryCache cache;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="mapper"></param>
		public PizzaWebRepository(MySqlConnection connection, IMapper mapper = null, IMemoryCache cache = null)
		{
			this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
			this.mapper = mapper;
			this.cache = cache;
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Get All Pizzas
		/// </summary>
		/// <returns>List<Pizza></returns>
		public async Task<List<Domain.Models.Pizza>> GetAllPizzasAsync()
		{
			var query = @"
				SELECT *
				FROM pizzas";

			await connection.OpenAsync();

			List<Domain.Models.Pizza> list = new List<Domain.Models.Pizza>();

			using var command = new MySqlCommand(query, connection);
			using var reader = await command.ExecuteReaderAsync();
			List<Domain.Models.Topping> toppingy = new List<Domain.Models.Topping>();
			toppingy.Add(new Domain.Models.Topping() {id = 1, name = "anchovy" });
			toppingy.Add(new Domain.Models.Topping() { id = 2, name = "bacon" });
			toppingy.Add(new Domain.Models.Topping() { id = 5, name = "mozzarella" });

			while (await reader.ReadAsync())
			{
				list.Add(new Domain.Models.Pizza()
				{
					id = Convert.ToInt32(reader["id"]),
					name = reader["name"].ToString(),
					toppings = toppingy
				});
			}

			return list;
		}

		/// <summary>
		/// Get All Toppings
		/// </summary>
		/// <returns>List<Pizza></returns>
		public async Task<List<Domain.Models.Topping>> GetAllToppingsAsync()
		{
			var query = @"
				SELECT *
				FROM toppings";

			await connection.OpenAsync();

			List<Domain.Models.Topping> list = new List<Domain.Models.Topping>();

			using var command = new MySqlCommand(query, connection);
			using var reader = await command.ExecuteReaderAsync();

			while (await reader.ReadAsync())
			{
				list.Add(new Domain.Models.Topping()
				{
					id = Convert.ToInt32(reader["id"]),
					name = reader["name"].ToString()
				});
			}

			return list;
		}
	}
}
