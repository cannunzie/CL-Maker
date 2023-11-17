using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Maker.Models
{
	internal class Category
	{
		List<string> keywords;
		string name, output;

		public Category() {}
		public Category(List<string> keywords, string name)
		{
			this.keywords = keywords;
			this.name = name;
		}
		public Category(string name) {
			this.name = name;
		}
		public List<string> GetKeywords() {
			return keywords;
		}
		public string GetName() {
			return name;
		}
		public string GetOutput()
		{
			return output;
		}
		public void SetOutput(string output) {
			this.output = output;
		}
	}
}
