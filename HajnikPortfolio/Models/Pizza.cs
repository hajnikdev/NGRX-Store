using System.Collections.Generic;

namespace HajnikPortfolio.Models
{
	public class Pizza
	{
		public int id { get; set; }
		public string name { get; set; }
		public List<Topping> toppings { get; set; }
	}
}
