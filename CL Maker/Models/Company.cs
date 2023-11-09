using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Maker.Models
{
	internal class Company
	{
		private Address address;
		private string department, manager, name;

		public Company() { }
		public Company(string address, string name, string department, string manager)
		{
			this.address = new Address(address);
			this.name = name;
			this.department = department;
			this.manager = manager;
		}
		public Company(Address address, string name, string department, string manager)
		{
			this.address = address;
			this.name = name;
			this.department = department;
			this.manager = manager;
		}

		public Address GetAddress() {
			return address;
		}
		public string GetName()
		{
			return name;
		}
		public string GetDepartment()
		{
			return department;
		}
		public string GetManager() {
			return manager;
		}
	}
}
