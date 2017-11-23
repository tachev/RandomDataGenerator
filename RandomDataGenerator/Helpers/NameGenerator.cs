using System;
using System.Collections.Generic;
using System.Linq;

namespace Geo.RandomNameGenerator
{
    public static class NameGenerator
    {
        private static List<Name> _maleFirstNames;
        private static List<Name> _femaleFirstNames;
        private static List<Name> _lastNames;

        private static double _lastNamesLoadedMax;
        private static double _maleNamesLoadedMax;
        private static double _femaleNamesLoadedMax;
        
        private static bool lastMale = false;

        static NameGenerator()
        {
            _maleFirstNames = NamesReader.LoadFromFile("Data/dist.male.first");
            _maleNamesLoadedMax = _maleFirstNames.Last().LoadedFrequency;

            _femaleFirstNames = NamesReader.LoadFromFile("Data/dist.female.first");
            _femaleNamesLoadedMax = _femaleFirstNames.Last().LoadedFrequency;

            _lastNames = NamesReader.LoadFromFile("Data/dist.all.last");
            _lastNamesLoadedMax = _lastNames.Last().LoadedFrequency;
        }

        public static string GetRandomLastName()
        {
            return GetRandomName(_lastNames, _lastNamesLoadedMax);
        }

		public static string GetRandomFirstName()
		{
			string firstName = lastMale ?
				GetRandomFirstMaleName() :
				GetRandomFirstFemaleName();

			lastMale = !lastMale;

			return firstName;
		}

		public static string GetRandomFirstMaleName()
		{
			return GetRandomName(_maleFirstNames, _maleNamesLoadedMax);
		}

		public static string GetRandomFirstFemaleName()
		{
			return GetRandomName(_femaleFirstNames, _femaleNamesLoadedMax);
		}

		public static string GetRandomFullName()
        {
			string firstName = GetRandomFirstName();

            string lastName = GetRandomLastName();

            return firstName + " " + lastName;
        }

        private static string GetRandomName(List<Name> names, double namesLoadedMax)
        {
            double randomFrequency = Utils.Random.Next(0, (int)(namesLoadedMax * 10000)) / 10000;

            var name = QuickFindLast(names, randomFrequency, 0, names.Count);

            return name.Value;
        }

        private static Name QuickFindLast(List<Name> names, double frequency, int start, int end)
        {
            if (start == end)
                return names[start];
            else
            {
                int mid = (start + end)/2;
                
                Name nameAtTheMiddle = names[mid];

                if (mid == start || nameAtTheMiddle.LoadedFrequency == frequency)
                {
                    return nameAtTheMiddle;
                }
                else if (nameAtTheMiddle.LoadedFrequency < frequency)
                {
                    return QuickFindLast(names, frequency, mid, end);
                }
                else
                {
                    return QuickFindLast(names, frequency, start, mid);
                }
            }
        }

        internal static string GetRandomSohoName()
        {
            int r = Utils.Random.Next(2);
            string name = GetRandomFullName();

            switch (r)
            {
                case 0:
                    return name + " Co.";
                case 1:
                    return name + " Inc.";
                case 2:
                    return name + " & Sons";
            }

            return name;
        }
    }
}
