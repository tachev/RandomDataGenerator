using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geo.RandomNameGenerator
{
    public static class Utils
    {
		private static Random random;

		public static Random Random {
			get {
				if (random == null)
				{
					random = new Random();
				}
				return random;
			}
			set => random = value; }
	}
}
