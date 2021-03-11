using System.Collections.Generic;

namespace PizzaWeb.Infrastructure.Models
{
	public class Pizza
	{
		public int id { get; set; }
		public string name { get; set; }
		public List<Topping> toppings { get; set; }
	}
}
