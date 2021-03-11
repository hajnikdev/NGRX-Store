using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWeb.Domain.Models
{
	public class Topping
	{
		public int id { get; set; }
		public string name { get; set; }
		public List<Topping> toppings { get; set; }
	}
}
