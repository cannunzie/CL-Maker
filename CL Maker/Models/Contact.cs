using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Maker.Models
{
	internal class Contact
	{
		private Address address;
		private string name, email;

		public Contact(Address address, string name, string email)
		{
			this.address = address;
			this.name = name;
			this.email = email;
		}
		public Contact(string address, string name, string email) {
			this.address = new Address(address);
			this.name = name;
			this.email = email;
		}
		public Contact() {}

		public string GetName() {
			return name;
		}
		public Address GetAddress() {
			return address;
		}
		public string GetEmail() {
			return email;
		}
	}
}
