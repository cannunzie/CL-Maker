namespace CL_Maker.Models
{
	internal class Address
	{
		private string street, city, province;
		public Address() {}
		public Address(string address) {
			ParseAddress(address);
		}
		public Address(string street, string city, string province)
		{
			this.street = street;
			this.city = city;
			this.province = province;
		}

		internal string GetStreet()
		{
			return street;
		}
		internal string GetCity()
		{
			return city;
		}
		internal string GetProvince()
		{
			return province;
		}

		internal void ParseAddress(string address) {
			string[] addressArray = address.Split(',');
			for (int i = 0; i < addressArray.Length; i++) {
				addressArray[i] = addressArray[i].Trim();
			}
            street = addressArray[0];
			city = addressArray[1];
			province = addressArray[2];
		}
	}
}
