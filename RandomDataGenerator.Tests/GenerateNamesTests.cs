using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geo.RandomNameGenerator;

namespace Geo.RandomDataGenerator.Tests
{
	[TestClass]
	public class GenerateNamesTests
	{
		[TestMethod]
		public void ReadAName()
		{
			//We are seeding, so we can get the same results every time. This is 
			Utils.Random = new Random(234);
			string name = NameGenerator.GetRandomFullName();
			string firstFemaleName = NameGenerator.GetRandomFirstFemaleName();
			string firstMaleName = NameGenerator.GetRandomFirstMaleName();
			string firstName = NameGenerator.GetRandomFirstName();
			string lastName = NameGenerator.GetRandomLastName();
			string fullName = NameGenerator.GetRandomFullName();

			Assert.IsNotNull(name);
		}

		[TestMethod]
		public void CheckDistribution()
		{
			var testName = "George";
			var percentage = 0.927;
			var iterations = 10000;

			//We are seeding, so we can get the same results every time.
			Utils.Random = new Random(234);
			int counter = 0;
			for (int i = 0; i <= iterations; i++)
			{
				var firstName = NameGenerator.GetRandomFirstMaleName();
				if (firstName.Equals(testName))
				{
					counter++;
				}
			}


			var expectedCounter = (percentage/100) * iterations;
			//0.5% deviation is acceptible
			var deviation = (0.5/100) * iterations;

			Assert.IsTrue(expectedCounter - deviation < counter && counter < expectedCounter + deviation);

		}
	}
}
