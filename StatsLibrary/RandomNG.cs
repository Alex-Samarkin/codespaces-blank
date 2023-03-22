using StatsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// better Random Generator class as subclass of Random class with methods for generating random numbers of various types
public class RandomNG : Random
{
    /// seed propert
    public int seed { get; set; }

    /// constructor with seed
    public RandomNG(int seed) : base(seed)
    {
    }
    /// constructor with no seed
    public RandomNG() : base()
    {
    }
    /// method to generate random double
    public double NextDouble(double min, double max)
    {
        return min + (max - min) * NextDouble();
    }
    /// method to generate random int
    public int NextInt(int min, int max)
    {
        return min + (int)(NextDouble() * (max - min));
    }
    /// method to generate random DateTime
    public DateTime NextDateTime(DateTime min, DateTime max)
    {
        return min + TimeSpan.FromTicks((long)(NextDouble() * (max - min).Ticks));
    }
    /// method to generate random string
    public string NextString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[NextInt(0, s.Length)]).ToArray());
    }

    /// Merseene Twister random number generator algorithm
    /// https://en.wikipedia.org/wiki/Mersenne_Twister
    /// https://en.wikipedia.org/wiki/Linear_congruential_generator
    /// https://en.wikipedia.org/wiki/Lehmer_random_number_generator
    /// https://en.wikipedia.org/wiki/Random_number_generation
    /// https://en.wikipedia.org/wiki/Random_seed
    /// https://en.wikipedia.org/wiki/Randomness
    /// https://en.wikipedia.org/wiki/Randomness_in_computing
    /// https://en.wikipedia.org/wiki/Randomness_in_mathematics
    /// https://en.wikipedia.org/wiki/Randomness_in_physics
    /// https://en.wikipedia.org/wiki/Randomness_in_statistics

    /// Generate a random number between 0 and 1 using the good old Lehmer random number generator algorithm
    public double GoodOldLehmerRandomNumberGeneratorAlgorithm()
    {
        // multiplier
        int a = 16807;
        // modulus
        int m = 2147483647;
        // next random number
        seed = (a * seed) % m;
        // return random number between 0 and 1
        return (double)seed / m;
    }
    /// Generate a random number between 0 and 1 using the Mersenne Twister random number generator algorithm
    public double MersenneTwisterRandomNumberGeneratorAlgorithm()
    {
        // multiplier
        int a = 16807;
        // modulus
        int m = 2147483647;
        // next random number
        seed = (a * seed) % m;
        // return random number between 0 and 1
        return (double)seed / m;
    }


    /// Generate a random number between 0 and 1 using the Linear congruential random number generator algorithm
    public double LinearCongruentialRandomNumberGeneratorAlgorithm()
    {
        // multiplier
        int a = 16807;
        // modulus
        int m = 2147483647;
        // next random number
        seed = (a * seed) % m;
        // return random number between 0 and 1
        return (double)seed / m;
    }

    /// Generate a random number between 0 and 1 using the cryptography hard random number generator algorithm
    

    
}