using AutoMapper;
using PizzaWeb.Domain.Contracts;
using PizzaWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Domain.Services
{
	public class PizzaWebService : IPizzaWebService
	{
		private readonly IPizzaWebRepository pizzaWebRepository;
		private readonly IMapper mapper;


		public PizzaWebService(IPizzaWebRepository pizzaWebRepository, IMapper mapper = null) 
		{
			this.pizzaWebRepository = pizzaWebRepository ?? throw new ArgumentNullException(nameof(pizzaWebRepository));
			this.mapper = mapper;
		}

		public async Task<List<Pizza>> GetAllPizzasAsync()
		{
			var repoList = await this.pizzaWebRepository.GetAllPizzasAsync();

			return repoList;
		}

		public async Task<List<Topping>> GetAllToppingsAsync()
		{
			var repoList = await this.pizzaWebRepository.GetAllToppingsAsync();

			return repoList;
		}

		public void Dispose()
		{
			this.pizzaWebRepository.Dispose();
		}
	}
}
