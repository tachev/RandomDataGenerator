using System;
using System.Collections.Generic;
using System.IO;

namespace Geo.RandomNameGenerator
{
    public class NamesReader
    {
        public static List<Name> LoadFromFile(string filename)
        {
            List<Name> result = new List<Name>();

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var split = line.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    Name name = new Name()
                    {
                        Value = split[0][0] + split[0].Substring(1).ToLower(),
                        Frequency = Double.Parse(split[1]),
                        LoadedFrequency = Double.Parse(split[2]),
                        Rank = int.Parse(split[3])
                    };

                    result.Add(name);
                }
            }

            return result;

        }
    }
}
