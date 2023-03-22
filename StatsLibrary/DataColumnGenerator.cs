using StatsLibrary;

///class for generating data columns using different methods
public class DataColumnGenerator
{
    ///method for generating a column of random integers
    public static DataColumn GenerateRandomIntColumn(string name, int count, int min, int max)
    {
        DataColumn dataColumn = new(name);
        Random random = new();
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(random.Next(min, max));
        }
        return dataColumn;
    }
    ///method for generating a column of random doubles
    public static DataColumn GenerateRandomDoubleColumn(string name, int count, double min, double max)
    {
        DataColumn dataColumn = new(name);
        Random random = new();
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(random.NextDouble() * (max - min) + min);
        }
        return dataColumn;
    }
    ///method for generating a column of random DateTime
    public static DataColumn GenerateRandomDateTimeColumn(string name, int count, DateTime min, DateTime max)
    {
        DataColumn dataColumn = new(name);
        Random random = new();
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(min.AddTicks(random.Next((int)(max - min).Ticks)));
        }
        return dataColumn;
    }
    /// generate linspace column
    public static DataColumn GenerateLinspaceColumn(string name, int count, double min, double max)
    {
        DataColumn dataColumn = new(name);
        double step = (max - min) / (count - 1);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(min + step * i);
        }
        return dataColumn;
    }
    /// generate Arange column
    public static DataColumn GenerateArangeColumn(string name, int count, double min, double step)
    {
        DataColumn dataColumn = new(name);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(min + step * i);
        }
        return dataColumn;
    }
    /// generate logspace column
    public static DataColumn GenerateLogspaceColumn(string name, int count, double min, double max)
    {
        DataColumn dataColumn = new(name);
        double step = (Math.Log10(max) - Math.Log10(min)) / (count - 1);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(Math.Pow(10, Math.Log10(min) + step * i));
        }
        return dataColumn;
    }
    /// generate Geomspace column
    public static DataColumn GenerateGeomspaceColumn(string name, int count, double min, double max)
    {
        DataColumn dataColumn = new(name);
        double step = (Math.Log(max) - Math.Log(min)) / (count - 1);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(Math.Exp(Math.Log(min) + step * i));
        }
        return dataColumn;
    }
    /// generate RandomWalk column
    public static DataColumn GenerateRandomWalkColumn(string name, int count, double min, double max)
    {
        DataColumn dataColumn = new(name);
        Random random = new();
        double step = (max - min) / (count - 1);
        double value = min;
        for (int i = 0; i < count; i++)
        {
            value += random.NextDouble() * step - step / 2;
            dataColumn.Add(value);
        }
        return dataColumn;
    }
    /// generate RandomWalk column
    public static DataColumn GenerateRandomWalkColumn(string name, int count, double min, double max, double step)
    {
        DataColumn dataColumn = new(name);
        Random random = new();
        double value = min;
        for (int i = 0; i < count; i++)
        {
            value += random.NextDouble() * step - step / 2;
            dataColumn.Add(value);
        }
        return dataColumn;
    }
    /// generate RandomWalk column
    public static DataColumn GenerateRandomWalkColumn(string name, int count, double min, double max, double step, double start)
    {
        DataColumn dataColumn = new(name);
        Random random = new();
        double value = start;
        for (int i = 0; i < count; i++)
        {
            value += random.NextDouble() * step - step / 2;
            dataColumn.Add(value);
        }
        return dataColumn;
    }
    /// generate RandomWalk column
    public static DataColumn GenerateRandomWalkColumn(string name, int count, double min, double max, double step, double start, double seed)
    {
        DataColumn dataColumn = new(name);
        Random random = new((int)seed);
        double value = start;
        for (int i = 0; i < count; i++)
        {
            value += random.NextDouble() * step - step / 2;
            dataColumn.Add(value);
        }
        return dataColumn;
    }
    /// generate RandomWalk column
    public static DataColumn GenerateRandomWalkColumn(string name, int count, double min, double max, double step, double start, double seed, double seed2)
    {
        DataColumn dataColumn = new(name);
        Random random = new((int)seed, (int)seed2);
        double value = start;
        for (int i = 0; i < count; i++)
        {
            value += random.NextDouble() * step - step / 2;
            dataColumn.Add(value);
        }
        return dataColumn;
    }
    /// generate sine column  based on a given period, amplitude and phase and bias (offset) and a given number of points (count) and a given start value
    public static DataColumn GenerateSineColumn(string name, int count, double period, double amplitude, double phase, double bias, double start = 0)
    {
        DataColumn dataColumn = new(name);
        double step = period / count;
        double value = start;
        for (int i = 0; i < count; i++)
        {
            value += step;
            dataColumn.Add(amplitude * Math.Sin(2 * Math.PI * value / period + phase) + bias);
        }
        return dataColumn;
    }
    /// generate cosine column  based on a given frequency, amplitude and phase and bias (offset) and a given number of points (count) and a given start value and end value
    public static DataColumn GenerateCosineColumn(string name, int count, double frequency, double amplitude, double phase, double bias, double start = 0)
    {
        DataColumn dataColumn = new(name);
        double period = Math.PI*2.0 / frequency;
        double step = period / count;
        double value = start;
        for (int i = 0; i < count; i++)
        {
            value += step;
            dataColumn.Add(amplitude * Math.Cos(2 * Math.PI * value / period + phase) + bias);
        }
        return dataColumn;
    }

    /// system random generator
    public static Random Random = new();
    public static int Seed {get; set;} = 0;

    /// reset the random generator to a new seed
    public static void ResetRandom(int seed = 0)
    {
        if (seed == 0)
        {
            Random = new();
        }
        else
        {
            Random = new(seed);
        }
        Seed = seed;
    }
    /// save current state of random generator
    public static void SaveRandom()
    {
        Seed = Random.Next();
    }
    /// restore state of random generator
    public static void RestoreRandom()
    {
        Random = new(Seed);
    }
    /// generate one normally distributed random number with a given mean and standard deviation
    public static double Normal(double mean, double stdDev)
    {
        double u1 = 1.0 - Random.NextDouble(); //uniform(0,1] random doubles
        double u2 = 1.0 - Random.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                     Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        double randNormal =
                     mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
        return randNormal;
    }
    /// generate one normally distributed random number with a given mean and standard deviation
    public static double Normal(double mean, double stdDev, double seed)
    {
        Random random = new((int)seed);
        double u1 = 1.0 - random.NextDouble(); //uniform(0,1] random doubles
        double u2 = 1.0 - random.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                     Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        double randNormal =
                     mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
        return randNormal;
    }
    /// generate normally distributed random numbers with a given mean and standard deviation
    public static List<double> Normal(int count, double mean, double stdDev)
    {
        List<double> data = new();
        for (int i = 0; i < count; i++)
        {
            data.Add(Normal(mean, stdDev));
        }
        return data;
    }
    /// generate normally distributed random numbers with a given mean and standard deviation for a new DataColumn
    public static DataColumn NormalColumn(string name, int count, double mean, double stdDev)
    {
        DataColumn dataColumn = new(name);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(Normal(mean, stdDev));
        }
        return dataColumn;
    }
    /// generate one uniformly distributed random number with a given minimum and maximum
    public static double Uniform(double min, double max)
    {
        return min + (max - min) * Random.NextDouble();
    }   
    /// generate one uniformly distributed random number with a given minimum and maximum
    public static double Uniform(double min, double max, double seed)
    {
        Random random = new((int)seed);
        return min + (max - min) * random.NextDouble();
    }
    /// generate uniformly distributed random numbers with a given minimum and maximum
    public static List<double> Uniform(int count, double min, double max)
    {
        List<double> data = new();
        for (int i = 0; i < count; i++)
        {
            data.Add(Uniform(min, max));
        }
        return data;
    }   
    /// generate uniformly distributed random numbers with a given minimum and maximum for a new DataColumn
    public static DataColumn UniformColumn(string name, int count, double min, double max)
    {
        DataColumn dataColumn = new(name);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(Uniform(min, max));
        }
        return dataColumn;
    }
    /// generate one exponentially distributed random number with a given mean
    public static double Exponential(double mean)
    {
        return -mean * Math.Log(1.0 - Random.NextDouble());
    }
    /// generate one exponentially distributed random number with a given mean
    public static double Exponential(double mean, double seed)
    {
        Random random = new((int)seed);
        return -mean * Math.Log(1.0 - random.NextDouble());
    }
    /// generate exponentially distributed random numbers with a given mean
    public static List<double> Exponential(int count, double mean)
    {
        List<double> data = new();
        for (int i = 0; i < count; i++)
        {
            data.Add(Exponential(mean));
        }
        return data;
    }
    /// generate exponentially distributed random numbers with a given mean for a new DataColumn
    public static DataColumn ExponentialColumn(string name, int count, double mean)
    {
        DataColumn dataColumn = new(name);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(Exponential(mean));
        }
        return dataColumn;
    }
    /// generate one lognormally distributed random number with a given mean and standard deviation
    public static double LogNormal(double mean, double stdDev)
    {
        return Math.Exp(Normal(mean, stdDev));
    }
    /// generate one lognormally distributed random number with a given mean and standard deviation
    public static double LogNormal(double mean, double stdDev, double seed)
    {
        return Math.Exp(Normal(mean, stdDev, seed));
    }
    /// generate lognormally distributed random numbers with a given mean and standard deviation
    public static List<double> LogNormal(int count, double mean, double stdDev)
    {
        List<double> data = new();
        for (int i = 0; i < count; i++)
        {
            data.Add(LogNormal(mean, stdDev));
        }
        return data;
    }
    /// generate lognormally distributed random numbers with a given mean and standard deviation for a new DataColumn
    public static DataColumn LogNormalColumn(string name, int count, double mean, double stdDev)
    {
        DataColumn dataColumn = new(name);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(LogNormal(mean, stdDev));
        }
        return dataColumn;
    }
    /// generate one triangularly distributed random number with a given minimum, maximum and mode
    public static double Triangular(double min, double max, double mode)
    {
        double u = Random.NextDouble();
        double c = (mode - min) / (max - min);
        if (u <= c)
        {
            return min + Math.Sqrt(u * (max - min) * (mode - min));
        }
        else
        {
            return max - Math.Sqrt((1 - u) * (max - min) * (max - mode));
        }
    }
    /// generate one triangularly distributed random number with a given minimum, maximum and mode
    public static double Triangular(double min, double max, double mode, double seed)
    {
        Random random = new((int)seed);
        double u = random.NextDouble();
        double c = (mode - min) / (max - min);
        if (u <= c)
        {
            return min + Math.Sqrt(u * (max - min) * (mode - min));
        }
        else
        {
            return max - Math.Sqrt((1 - u) * (max - min) * (max - mode));
        }
    }
    /// generate triangularly distributed random numbers with a given minimum, maximum and mode
    public static List<double> Triangular(int count, double min, double max, double mode)
    {
        List<double> data = new();
        for (int i = 0; i < count; i++)
        {
            data.Add(Triangular(min, max, mode));
        }
        return data;
    }
    /// generate triangularly distributed random numbers with a given minimum, maximum and mode for a new DataColumn
    public static DataColumn TriangularColumn(string name, int count, double min, double max, double mode)
    {
        DataColumn dataColumn = new(name);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(Triangular(min, max, mode));
        }
        return dataColumn;
    }
    /// generate one beta distributed random number with a given alpha and beta
    public static double Beta(double alpha, double beta)
    {
        double u = Random.NextDouble();
        double v = Random.NextDouble();
        double w = Math.Pow(u, 1.0 / alpha) * Math.Pow(v, 1.0 / beta);
        return w / (w + Math.Pow(1 - u, 1.0 / alpha) * Math.Pow(1 - v, 1.0 / beta));
    }
    /// generate one beta distributed random number with a given alpha and beta
    public static double Beta(double alpha, double beta, double seed)
    {
        Random random = new((int)seed);
        double u = random.NextDouble();
        double v = random.NextDouble();
        double w = Math.Pow(u, 1.0 / alpha) * Math.Pow(v, 1.0 / beta);
        return w / (w + Math.Pow(1 - u, 1.0 / alpha) * Math.Pow(1 - v, 1.0 / beta));
    }
    /// generate beta distributed random numbers with a given alpha and beta
    public static List<double> Beta(int count, double alpha, double beta)
    {
        List<double> data = new();
        for (int i = 0; i < count; i++)
        {
            data.Add(Beta(alpha, beta));
        }
        return data;
    }
    /// generate beta distributed random numbers with a given alpha and beta for a new DataColumn
    public static DataColumn BetaColumn(string name, int count, double alpha, double beta)
    {
        DataColumn dataColumn = new(name);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(Beta(alpha, beta));
        }
        return dataColumn;
    }
    /// generate one gamma distributed random number with a given alpha and beta
    public static double Gamma(double alpha, double beta)
    {
        double u = Random.NextDouble();
        double v = Random.NextDouble();
        double w = Math.Pow(u, 1.0 / alpha) * Math.Pow(v, 1.0 / beta);
        return w / (w + Math.Pow(1 - u, 1.0 / alpha) * Math.Pow(1 - v, 1.0 / beta));
    }
    /// generate one gamma distributed random number with a given alpha and beta
    public static double Gamma(double alpha, double beta, double seed)
    {
        Random random = new((int)seed);
        double u = random.NextDouble();
        double v = random.NextDouble();
        double w = Math.Pow(u, 1.0 / alpha) * Math.Pow(v, 1.0 / beta);
        return w / (w + Math.Pow(1 - u, 1.0 / alpha) * Math.Pow(1 - v, 1.0 / beta));
    }
    /// generate gamma distributed random numbers with a given alpha and beta
    public static List<double> Gamma(int count, double alpha, double beta)
    {
        List<double> data = new();
        for (int i = 0; i < count; i++)
        {
            data.Add(Gamma(alpha, beta));
        }
        return data;
    }
    /// generate gamma distributed random numbers with a given alpha and beta for a new DataColumn
    public static DataColumn GammaColumn(string name, int count, double alpha, double beta)
    {
        DataColumn dataColumn = new(name);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(Gamma(alpha, beta));
        }
        return dataColumn;
    }
    /// generate one Weibull distributed random number with a given alpha and beta
    public static double Weibull(double alpha, double beta)
    {
        double u = Random.NextDouble();
        double v = Random.NextDouble();
        double w = Math.Pow(u, 1.0 / alpha) * Math.Pow(v, 1.0 / beta);
        return w / (w + Math.Pow(1 - u, 1.0 / alpha) * Math.Pow(1 - v, 1.0 / beta));
    }
    /// generate one Weibull distributed random number with a given alpha and beta
    public static double Weibull(double alpha, double beta, double seed)
    {
        Random random = new((int)seed);
        double u = random.NextDouble();
        double v = random.NextDouble();
        double w = Math.Pow(u, 1.0 / alpha) * Math.Pow(v, 1.0 / beta);
        return w / (w + Math.Pow(1 - u, 1.0 / alpha) * Math.Pow(1 - v, 1.0 / beta));
    }
    /// generate Weibull distributed random numbers with a given alpha and beta
    public static List<double> Weibull(int count, double alpha, double beta)
    {
        List<double> data = new();
        for (int i = 0; i < count; i++)
        {
            data.Add(Weibull(alpha, beta));
        }
        return data;
    }
    /// generate Weibull distributed random numbers with a given alpha and beta for a new DataColumn
    public static DataColumn WeibullColumn(string name, int count, double alpha, double beta)
    {
        DataColumn dataColumn = new(name);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(Weibull(alpha, beta));
        }
        return dataColumn;
    }
    /// generate one lognormal distributed random number with a given alpha and beta
    public static double Lognormal(double alpha, double beta)
    {
        double u = Random.NextDouble();
        double v = Random.NextDouble();
        double w = Math.Pow(u, 1.0 / alpha) * Math.Pow(v, 1.0 / beta);
        return w / (w + Math.Pow(1 - u, 1.0 / alpha) * Math.Pow(1 - v, 1.0 / beta));
    }
    /// generate one lognormal distributed random number with a given alpha and beta
    public static double Lognormal(double alpha, double beta, double seed)
    {
        Random random = new((int)seed);
        double u = random.NextDouble();
        double v = random.NextDouble();
        double w = Math.Pow(u, 1.0 / alpha) * Math.Pow(v, 1.0 / beta);
        return w / (w + Math.Pow(1 - u, 1.0 / alpha) * Math.Pow(1 - v, 1.0 / beta));
    }
    /// generate lognormal distributed random numbers with a given alpha and beta
    public static List<double> Lognormal(int count, double alpha, double beta)
    {
        List<double> data = new();
        for (int i = 0; i < count; i++)
        {
            data.Add(Lognormal(alpha, beta));
        }
        return data;
    }
    /// generate lognormal distributed random numbers with a given alpha and beta for a new DataColumn
    public static DataColumn LognormalColumn(string name, int count, double alpha, double beta)
    {
        DataColumn dataColumn = new(name);
        for (int i = 0; i < count; i++)
        {
            dataColumn.Add(Lognormal(alpha, beta));
        }
        return dataColumn;
    }
    


}