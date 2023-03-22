using StatsLibrary;

/// class DataColumn with list of double values and ColumnHeader
public class DataColumn
{
    /// list of double values
    public List<double> Values { get; set; }
    /// ColumnHeader
    public ColumnHeader ColumnHeader { get; set; }

    /// constructor with list of double values and ColumnHeader
    public DataColumn(List<double> values, ColumnHeader columnHeader)
    {
        Values = values;
        ColumnHeader = columnHeader;
    }

    /// constructor with list of double values
    public DataColumn(List<double> values) : this(values, new ColumnHeader("Column"))
    {
    }

    /// constructor with ColumnHeader
    public DataColumn(ColumnHeader columnHeader) : this(new List<double>(), columnHeader)
    {
    }

    /// constructor
    public DataColumn() : this(new List<double>(), new ColumnHeader("Column"))
    {
    }

    /// equals method
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        DataColumn dataColumn = (DataColumn)obj;
        return Values.SequenceEqual(dataColumn.Values) && ColumnHeader.Equals(dataColumn.ColumnHeader);
    }

    /// get hash code
    public override int GetHashCode()
    {
        return HashCode.Combine(Values, ColumnHeader);
    }

    /// equality operator
    public static bool operator ==(DataColumn dataColumn1, DataColumn dataColumn2)
    {
        return dataColumn1.Equals(dataColumn2);
    }

    /// inequality operator
    public static bool operator !=(DataColumn dataColumn1, DataColumn dataColumn2)
    {
        return !(dataColumn1 == dataColumn2);
    }

    /// check if data column is empty
    public bool IsEmpty()
    {
        return Values.Count == 0;
    }
    /// get number of values in data column
    public int Count()
    {
        return Values.Count;
    }
    /// check if index is valid
    public bool IsValidIndex(int index)
    {
        return index >= 0 && index < Values.Count;
    }
    /// check if index is valid and correct invalid index? return valid index with no exception
    public int CorrectIndex(int index)
    {
        if (index < 0)
        {
            return 0;
        }
        else if (index >= Values.Count)
        {
            return Values.Count - 1;
        }
        else
        {
            return index;
        }
    }
    /// get value at index, check if index is valid and correct invalid index
    public double GetValue(int index)
    {
        return index <0 ? GetValueAtNegativeIndex(index) : Values[CorrectIndex(index)];
    }
    /// get value at index, check if index is valid and correct invalid index
    public double this[int index]
    {
        get
        {
            return GetValue(index);
        }
        set
        {
            Values[CorrectIndex(index)] = value;
        }
    }

    /// get value ar negative index, check if index is valid and correct invalid index
    public double GetValueAtNegativeIndex(int index)
    {
        return Values[CorrectIndex(Values.Count + index)];
    }

    /// adding data, remove data, and clear data
    public void Add(double value)
    {
        Values.Add(value);
    }
    public void AddRange(IEnumerable<double> values)
    {
        Values.AddRange(values);
    }    
    
    public void RemoveAt(int index)
    {
        Values.RemoveAt(index);
    }
    public void RemoveRange(int index, int count)
    {
        Values.RemoveRange(index, count);
    }
    public void RemoveRange(int index)
    {
        Values.RemoveRange(index, Values.Count - index);
    }
    public void RemoveRange(IEnumerable<double> values)
    {
        foreach (double value in values)
        {
            Values.Remove(value);
        }
    }
    public void RemoveRange(DataColumn dataColumn)
    {
        RemoveRange(dataColumn.Values);
    }
    public void RemoveAll(Predicate<double> match)
    {
        Values.RemoveAll(match);
    }
    public void RemoveAll(double value)
    {
        Values.RemoveAll(x => x == value);
    }
    public void RemoveAll(IEnumerable<double> values)
    {
        foreach (double value in values)
        {
            RemoveAll(value);
        }
    }
    public void RemoveAll(DataColumn dataColumn)
    {
        RemoveAll(dataColumn.Values);
    }
    public void Clear()
    {
        Values.Clear();
    }

    /// find index of value
    public int IndexOf(double value)
    {
        return Values.IndexOf(value);
    }
    public int IndexOf(double value, int index)
    {
        return Values.IndexOf(value, index);
    }
    public int IndexOf(double value, int index, int count)
    {
        return Values.IndexOf(value, index, count);
    }
    public int IndexOf(double value, int index, int count, IEqualityComparer<double> comparer)
    {
        return Values.IndexOf(value, index, count, comparer);
    }
    public int IndexOf(double value, IEqualityComparer<double> comparer)
    {
        return Values.IndexOf(value, comparer);
    }
    public int IndexOf(double value, int index, IEqualityComparer<double> comparer)
    {
        return Values.IndexOf(value, index, comparer);
    }
    public int IndexOf(double value, int index, int count, IEqualityComparer<double> comparer)
    {
        return Values.IndexOf(value, index, count, comparer);
    }

    /// find last index of value
    public int LastIndexOf(double value)
    {
        return Values.LastIndexOf(value);
    }
    public int LastIndexOf(double value, int index)
    {
        return Values.LastIndexOf(value, index);
    }
    public int LastIndexOf(double value, int index, int count)
    {
        return Values.LastIndexOf(value, index, count);
    }

    /// find value in data column and return index of value or -1 if value is not found in data column with epsilon tolerance
    public int FindIndex(double value, double epsilon)
    {
        return FindIndex(x => Math.Abs(x - value) < epsilon);
    }
    public int FindIndex(double value, int index, double epsilon)
    {
        return FindIndex(index, x => Math.Abs(x - value) < epsilon);
    }
    public int FindIndex(double value, int index, int count, double epsilon)
    {
        return FindIndex(index, count, x => Math.Abs(x - value) < epsilon);
    }
    public int FindIndex(Predicate<double> match)
    {
        return Values.FindIndex(match);
    }
    public int FindIndex(int index, Predicate<double> match)
    {
        return Values.FindIndex(index, match);
    }   
    public int FindIndex(int index, int count, Predicate<double> match)
    {
        return Values.FindIndex(index, count, match);
    }

    /// replace value at index with new value
    public void ReplaceAt(int index, double value)
    {
        Values[index] = value;
    }
    /// replace value at index with new value
    public void ReplaceAt(int index, double value, double epsilon)
    {
        int i = FindIndex(index, x => Math.Abs(x - value) < epsilon);
        if (i != -1)
        {
            Values[i] = value;
        }
    }
    /// replace value at index with new value
    public void ReplaceAt(int index, double value, double epsilon, out bool replaced)
    {
        int i = FindIndex(index, x => Math.Abs(x - value) < epsilon);
        if (i != -1)
        {
            Values[i] = value;
            replaced = true;
        }
        else
        {
            replaced = false;
        }
    }
    /// replace value at index with new value
    public void ReplaceAt(int index, double value, double epsilon, out int replacedIndex)
    {
        int i = FindIndex(index, x => Math.Abs(x - value) < epsilon);
        if (i != -1)
        {
            Values[i] = value;
            replacedIndex = i;
        }
        else
        {
            replacedIndex = -1;
        }
    }
    /// replace value at index with new value
    public void ReplaceAt(int index, double value, double epsilon, out bool replaced, out int replacedIndex)
    {
        int i = FindIndex(index, x => Math.Abs(x - value) < epsilon);
        if (i != -1)
        {
            Values[i] = value;
            replaced = true;
            replacedIndex = i;
        }
        else
        {
            replaced = false;
            replacedIndex = -1;
        }
    }

    /// replace specific value with new value
    public void Replace(double oldValue, double newValue)
    {
        Replace(oldValue, newValue, 0, Values.Count);
    }   
    public void Replace(double oldValue, double newValue, int index)
    {
        Replace(oldValue, newValue, index, Values.Count - index);
    }
    public void Replace(double oldValue, double newValue, int index, int count)
    {
        for (int i = index; i < index + count; i++)
        {
            if (Values[i] == oldValue)
            {
                Values[i] = newValue;
            }
        }
    }
    public void Replace(double oldValue, double newValue, double epsilon)
    {
        Replace(oldValue, newValue, 0, Values.Count, epsilon);
    }
    public void Replace(double oldValue, double newValue, int index, double epsilon)
    {
        Replace(oldValue, newValue, index, Values.Count - index, epsilon);
    }
    public void Replace(double oldValue, double newValue, int index, int count, double epsilon)
    {
        for (int i = index; i < index + count; i++)
        {
            if (Math.Abs(Values[i] - oldValue) < epsilon)
            {
                Values[i] = newValue;
            }
        }
    }
    
    /// replace specific value with new value   
    public void Replace(double oldValue, double newValue, out int replacedCount)
    {
        Replace(oldValue, newValue, 0, Values.Count, out replacedCount);
    }
    public void Replace(double oldValue, double newValue, int index, out int replacedCount)
    {
        Replace(oldValue, newValue, index, Values.Count - index, out replacedCount);
    }
    public void Replace(double oldValue, double newValue, int index, int count, out int replacedCount)
    {
        replacedCount = 0;
        for (int i = index; i < index + count; i++)
        {
            if (Values[i] == oldValue)
            {
                Values[i] = newValue;
                replacedCount++;
            }
        }
    }
    public void Replace(double oldValue, double newValue, double epsilon, out int replacedCount)
    {
        Replace(oldValue, newValue, 0, Values.Count, epsilon, out replacedCount);
    }
    public void Replace(double oldValue, double newValue, int index, double epsilon, out int replacedCount)
    {
        Replace(oldValue, newValue, index, Values.Count - index, epsilon, out replacedCount);
    }
    public void Replace(double oldValue, double newValue, int index, int count, double epsilon, out int replacedCount)
    {
        replacedCount = 0;
        for (int i = index; i < index + count; i++)
        {
            if (Math.Abs(Values[i] - oldValue) < epsilon)
            {
                Values[i] = newValue;
                replacedCount++;
            }
        }
    }

    /// replace all specific value with new value
    public void ReplaceAll(double oldValue, double newValue)
    {
        ReplaceAll(oldValue, newValue, 0, Values.Count);
    }
    public void ReplaceAll(double oldValue, double newValue, int index)
    {
        ReplaceAll(oldValue, newValue, index, Values.Count - index);
    }
    public void ReplaceAll(double oldValue, double newValue, int index, int count)
    {
        for (int i = index; i < index + count; i++)
        {
            if (Values[i] == oldValue)
            {
                Values[i] = newValue;
            }
        }
    }
    public void ReplaceAll(double oldValue, double newValue, double epsilon)
    {
        ReplaceAll(oldValue, newValue, 0, Values.Count, epsilon);
    }
    public void ReplaceAll(double oldValue, double newValue, int index, double epsilon)
    {
        ReplaceAll(oldValue, newValue, index, Values.Count - index, epsilon);
    }
    public void ReplaceAll(double oldValue, double newValue, int index, int count, double epsilon)
    {
        for (int i = index; i < index + count; i++)
        {
            if (Math.Abs(Values[i] - oldValue) < epsilon)
            {
                Values[i] = newValue;
            }
        }
    }
    /// append Values from another DataColumn to this DataColumn
    public void Append(DataColumn column)
    {
        Append(column, 0, column.Count);
    }
    public void Append(DataColumn column, int index)
    {
        Append(column, index, column.Count - index);
    }
    public void Append(DataColumn column, int index, int count)
    {
        for (int i = index; i < index + count; i++)
        {
            Values.Add(column.Values[i]);
        }
    }
    /// find unique values and return a new DataColumn
    public DataColumn Unique()
    {
        DataColumn column = new DataColumn();
        column.Values = Values.Distinct().ToList();
        return column;
    }

    /// apply one argument function to all values
    public void Apply(Func<double, double> func)
    {
        Apply(func, 0, Values.Count);
    }
    public void Apply(Func<double, double> func, int index)
    {
        Apply(func, index, Values.Count - index);
    }
    public void Apply(Func<double, double> func, int index, int count)
    {
        for (int i = index; i < index + count; i++)
        {
            Values[i] = func(Values[i]);
        }
    }

    /// apply two argument function to all values
    public void Apply(Func<double, double, double> func, double arg)
    {
        Apply(func, arg, 0, Values.Count);
    }
    public void Apply(Func<double, double, double> func, double arg, int index)
    {
        Apply(func, arg, index, Values.Count - index);
    }
    public void Apply(Func<double, double, double> func, double arg, int index, int count)
    {
        for (int i = index; i < index + count; i++)
        {
            Values[i] = func(Values[i], arg);
        }
    }

    /// apply one argument function to all values mathched by predicate
    public void Apply(Func<double, double> func, Predicate<double> predicate)
    {
        Apply(func, predicate, 0, Values.Count);
    }
    public void Apply(Func<double, double> func, Predicate<double> predicate, int index)
    {
        Apply(func, predicate, index, Values.Count - index);
    }
    public void Apply(Func<double, double> func, Predicate<double> predicate, int index, int count)
    {
        for (int i = index; i < index + count; i++)
        {
            if (predicate(Values[i]))
            {
                Values[i] = func(Values[i]);
            }
        }
    }

    /// perform unary operation on all values
    public void UnaryOperation(UnaryOperation operation)
    {
        UnaryOperation(operation, 0, Values.Count);
    }
    public void UnaryOperation(UnaryOperation operation, int index)
    {
        UnaryOperation(operation, index, Values.Count - index);
    }
    public void UnaryOperation(UnaryOperation operation, int index, int count)
    {
        for (int i = index; i < index + count; i++)
        {
            Values[i] = operation(Values[i]);
        }
    }
    /// define unary operation
    public delegate double UnaryOperation(double value);

    /// unary operation: negate
    public static double Negate(double value)
    {
        return -value;
    }
    /// unary operation: absolute value
    public static double Abs(double value)
    {
        return Math.Abs(value);
    }
    /// unary operation: square root
    public static double Sqrt(double value)
    {
        return Math.Sqrt(value);
    }
    /// unary operation: natural logarithm
    public static double Log(double value)
    {
        return Math.Log(value);
    }
    /// unary operation: base 10 logarithm
    public static double Log10(double value)
    {
        return Math.Log10(value);
    }
    /// unary operation: sine
    public static double Sin(double value)
    {
        return Math.Sin(value);
    }
    /// unary operation: cosine
    public static double Cos(double value)
    {
        return Math.Cos(value);
    }
    /// unary operation: tangent
    public static double Tan(double value)
    {
        return Math.Tan(value);
    }
    /// unary operation: arc sine and check for domain error and correct it
    public static double Asin(double value)
    {
        if (value < -1.0)
        {
            return -Math.PI / 2.0;
        }
        else if (value > 1.0)
        {
            return Math.PI / 2.0;
        }
        else
        {
            return Math.Asin(value);
        }
    }
    /// unary operation: arc cosine and check for domain error and correct it
    public static double Acos(double value)
    {
        if (value < -1.0)
        {
            return Math.PI;
        }
        else if (value > 1.0)
        {
            return 0.0;
        }
        else
        {
            return Math.Acos(value);
        }
    }
    /// unary operation: arc tangent
    public static double Atan(double value)
    {
        return Math.Atan(value);
    }   
    /// perform binary operation on all values
    public void BinaryOperation(BinaryOperation operation, double arg)
    {
        BinaryOperation(operation, arg, 0, Values.Count);
    }
    public void BinaryOperation(BinaryOperation operation, double arg, int index)
    {
        BinaryOperation(operation, arg, index, Values.Count - index);
    }
    public void BinaryOperation(BinaryOperation operation, double arg, int index, int count)
    {
        for (int i = index; i < index + count; i++)
        {
            Values[i] = operation(Values[i], arg);
        }
    }
    /// define binary operation
    public delegate double BinaryOperation(double value, double arg);

    /// binary operation: add
    public static double Add(double value, double arg)
    {
        return value + arg;
    }
    /// binary operation: subtract

    public static double Subtract(double value, double arg)
    {
        return value - arg;
    }
    /// binary operation: multiply
    public static double Multiply(double value, double arg)
    {
        return value * arg;
    }
    /// binary operation: divide
    public static double Divide(double value, double arg)
    {
        return value / arg;
    }
    /// binary operation: power
    public static double Power(double value, double arg)
    {
        return Math.Pow(value, arg);
    }
    /// binary operation: logarithm
    public static double Logarithm(double value, double arg)
    {
        return Math.Log(value, arg);
    }
    /// binary operation: remainder
    public static double Remainder(double value, double arg)
    {
        return value % arg;
    }
    /// binary operation: maximum
    public static double Max(double value, double arg)
    {
        return Math.Max(value, arg);
    }
    /// binary operation: minimum
    public static double Min(double value, double arg)
    {
        return Math.Min(value, arg);
    }
    /// binary operation: hypotenuse
    public static double Hypot(double value, double arg)
    {
        return Math.Sqrt(value * value + arg * arg);
    }
    /// binary operation: arc tangent of two variables
    public static double Atan2(double value, double arg)
    {
        return Math.Atan2(value, arg);
    }

    /// negate all values
    public void Negate()
    {
        UnaryOperation(Negate);
    }
    /// absolute value of all values
    public void Abs()
    {
        UnaryOperation(Abs);
    }
    /// square root of all values
    public void Sqrt()
    {
        UnaryOperation(Sqrt);
    }   
    /// natural logarithm of all values
    public void Log()
    {
        UnaryOperation(Log);
    }
    /// base 10 logarithm of all values
    public void Log10()
    {
        UnaryOperation(Log10);
    }
    /// sine of all values
    public void Sin()
    {
        UnaryOperation(Sin);
    }
    /// cosine of all values
    public void Cos()
    {
        UnaryOperation(Cos);
    }
    /// tangent of all values
    public void Tan()
    {
        UnaryOperation(Tan);
    }
    /// arc sine of all values and check for domain error and correct it
    public void Asin()
    {
        UnaryOperation(Asin);
    }
    /// arc cosine of all values and check for domain error and correct it
    public void Acos()
    {
        UnaryOperation(Acos);
    }
    /// arc tangent of all values
    public void Atan()
    {
        UnaryOperation(Atan);
    }
    /// add a value to all values
    public void Add(double arg)
    {
        BinaryOperation(Add, arg);
    }
    /// subtract a value from all values
    public void Subtract(double arg)
    {
        BinaryOperation(Subtract, arg);
    }
    /// multiply all values by a value
    public void Multiply(double arg)
    {
        BinaryOperation(Multiply, arg);
    }
    /// divide all values by a value
    public void Divide(double arg)
    {
        BinaryOperation(Divide, arg);
    }
    /// raise all values to a power
    public void Power(double arg)
    {
        BinaryOperation(Power, arg);
    }
    /// logarithm of all values
    public void Logarithm(double arg)
    {
        BinaryOperation(Logarithm, arg);
    }
    /// remainder of all values
    public void Remainder(double arg)
    {
        BinaryOperation(Remainder, arg);
    }
    /// maximum of all values
    public void Max(double arg)
    {
        BinaryOperation(Max, arg);
    }
    /// minimum of all values
    public void Min(double arg)
    {
        BinaryOperation(Min, arg);
    }
    /// hypotenuse of all values
    public void Hypot(double arg)
    {
        BinaryOperation(Hypot, arg);
    }
    /// arc tangent of two variables
    public void Atan2(double arg)
    {
        BinaryOperation(Atan2, arg);
    }
    
    /// unary plus operator return DataColumn
    public static DataColumn operator +(DataColumn column)
    {
        return column;
    }
    /// unary minus operator return DataColumn
    public static DataColumn operator -(DataColumn column)
    {
        DataColumn result = new DataColumn(column);
        result.Negate();
        return result;
    }
    /// add operator return DataColumn
    public static DataColumn operator +(DataColumn column, double arg)
    {
        DataColumn result = new DataColumn(column);
        result.Add(arg);
        return result;
    }
    /// subtract operator return DataColumn
    public static DataColumn operator -(DataColumn column, double arg)
    {
        DataColumn result = new DataColumn(column);
        result.Subtract(arg);
        return result;
    }
    /// multiply operator return DataColumn

    public static DataColumn operator *(DataColumn column, double arg)
    {
        DataColumn result = new DataColumn(column);
        result.Multiply(arg);
        return result;
    }
    /// divide operator return DataColumn
    public static DataColumn operator /(DataColumn column, double arg)
    {
        DataColumn result = new DataColumn(column);
        result.Divide(arg);
        return result;
    }
    /// power operator return DataColumn
    public static DataColumn operator ^(DataColumn column, double arg)
    {
        DataColumn result = new DataColumn(column);
        result.Power(arg);
        return result;
    }

    /// add two columns
    public static DataColumn operator +(DataColumn column1, DataColumn column2)
    {
        DataColumn result = new DataColumn(column1);
        result.BinaryOperation(Add, column2);
        return result;
    }
    /// subtract two columns
    public static DataColumn operator -(DataColumn column1, DataColumn column2)
    {
        DataColumn result = new DataColumn(column1);
        result.BinaryOperation(Subtract, column2);
        return result;
    }
    /// multiply two columns
    public static DataColumn operator *(DataColumn column1, DataColumn column2)
    {
        DataColumn result = new DataColumn(column1);
        result.BinaryOperation(Multiply, column2);
        return result;
    }
    /// divide two columns
    public static DataColumn operator /(DataColumn column1, DataColumn column2)
    {
        DataColumn result = new DataColumn(column1);
        result.BinaryOperation(Divide, column2);
        return result;
    }
    /// power two columns
    public static DataColumn operator ^(DataColumn column1, DataColumn column2)
    {
        DataColumn result = new DataColumn(column1);
        result.BinaryOperation(Power, column2);
        return result;
    }

    /// cumulative sum of all values
    public void CumulativeSum()
    {
        double sum = 0;
        for (int i = 0; i < Count; i++)
        {
            sum += this[i];
            this[i] = sum;
        }
    }
    /// cumulative product of all values
    public void CumulativeProduct()
    {
        double product = 1;
        for (int i = 0; i < Count; i++)
        {
            product *= this[i];
            this[i] = product;
        }
    }
    /// difference of all values with previous value
    public void Difference()
    {
        double previous = this[0];
        for (int i = 1; i < Count; i++)
        {
            double current = this[i];
            this[i] = current - previous;
            previous = current;
        }
    }
    /// difference of all values with lagged value  
    public void Difference(int lag)
    {
        double lagged = this[lag];
        for (int i = lag; i < Count; i++)
        {
            double current = this[i];
            this[i] = current - lagged;
            lagged = current;
        }
    }
    /// rolling sum of all values with window size
    public void RollingSum(int window)
    {
        double sum = 0;
        for (int i = 0; i < window; i++)
        {
            sum += this[i];
        }
        for (int i = window; i < Count; i++)
        {
            sum += this[i] - this[i - window];
            this[i] = sum;
        }
    }
    /// rolling product of all values with window size
    public void RollingProduct(int window)
    {
        double product = 1;
        for (int i = 0; i < window; i++)
        {
            product *= this[i];
        }
        for (int i = window; i < Count; i++)
        {
            product *= this[i] / this[i - window];
            this[i] = product;
        }
    }
    /// rolling mean of all values with window size
    public void RollingMean(int window)
    {
        double sum = 0;
        for (int i = 0; i < window; i++)
        {
            sum += this[i];
        }
        for (int i = window; i < Count; i++)
        {
            sum += this[i] - this[i - window];
            this[i] = sum / window;
        }
    }
    /// rolling standard deviation of all values with window size
    public void RollingStdDev(int window)
    {
        double sum = 0;
        double sum2 = 0;
        for (int i = 0; i < window; i++)
        {
            double value = this[i];
            sum += value;
            sum2 += value * value;
        }
        for (int i = window; i < Count; i++)
        {
            double value = this[i];
            sum += value - this[i - window];
            sum2 += value * value - this[i - window] * this[i - window];
            this[i] = Math.Sqrt((sum2 - sum * sum / window) / (window - 1));
        }
    }    
    /// rolling variance of all values with window size
    public void RollingVariance(int window)
    {
        double sum = 0;
        double sum2 = 0;
        for (int i = 0; i < window; i++)
        {
            double value = this[i];
            sum += value;
            sum2 += value * value;
        }
        for (int i = window; i < Count; i++)
        {
            double value = this[i];
            sum += value - this[i - window];
            sum2 += value * value - this[i - window] * this[i - window];
            this[i] = (sum2 - sum * sum / window) / (window - 1);
        }
    }  

    /// find minimum value
    public double Min()
    {
        double min = double.MaxValue;
        for (int i = 0; i < Count; i++)
        {
            double value = this[i];
            if (value < min)
            {
                min = value;
            }
        }
        return min;
    }
    /// find maximum value
    public double Max()
    {
        double max = double.MinValue;
        for (int i = 0; i < Count; i++)
        {
            double value = this[i];
            if (value > max)
            {
                max = value;
            }
        }
        return max;
    }
    /// find minimum value and its index
    public double Min(out int index)
    {
        double min = double.MaxValue;
        index = -1;
        for (int i = 0; i < Count; i++)
        {
            double value = this[i];
            if (value < min)
            {
                min = value;
                index = i;
            }
        }
        return min;
    }
    /// find maximum value and its index
    public double Max(out int index)
    {
        double max = double.MinValue;
        index = -1;
        for (int i = 0; i < Count; i++)
        {
            double value = this[i];
            if (value > max)
            {
                max = value;
                index = i;
            }
        }
        return max;
    }
    /// find percentile value
    public double Percentile(double percentile)
    {
        double[] values = new double[Count];
        for (int i = 0; i < Count; i++)
        {
            values[i] = this[i];
        }
        Array.Sort(values);
        int index = (int)(percentile * (Count - 1));
        return values[index];
    }
    /// find percentile value and its index
    public double Percentile(double percentile, out int index)
    {
        double[] values = new double[Count];
        for (int i = 0; i < Count; i++)
        {
            values[i] = this[i];
        }
        Array.Sort(values);
        index = (int)(percentile * (Count - 1));
        return values[index];
    }
    /// find median value
    public double Median()
    {
        double[] values = new double[Count];
        for (int i = 0; i < Count; i++)
        {
            values[i] = this[i];
        }
        Array.Sort(values);
        int index = Count / 2;
        return values[index];
    }
    /// find median value and its index
    public double Median(out int index)
    {
        double[] values = new double[Count];
        for (int i = 0; i < Count; i++)
        {
            values[i] = this[i];
        }
        Array.Sort(values);
        index = Count / 2;
        return values[index];
    }
    /// find mean value
    public double Mean()
    {
        double sum = 0;
        for (int i = 0; i < Count; i++)
        {
            sum += this[i];
        }
        return sum / Count;
    }
    /// find standard deviation value
    public double StdDev()
    {
        double sum = 0;
        double sum2 = 0;
        for (int i = 0; i < Count; i++)
        {
            double value = this[i];
            sum += value;
            sum2 += value * value;
        }
        return Math.Sqrt((sum2 - sum * sum / Count) / (Count - 1));
    }
    /// find variance value
    public double Variance()
    {
        double sum = 0;
        double sum2 = 0;
        for (int i = 0; i < Count; i++)
        {
            double value = this[i];
            sum += value;
            sum2 += value * value;
        }
        return (sum2 - sum * sum / Count) / (Count - 1);
    }
    /// find skewness value
    public double Skewness()
    {
        double sum = 0;
        double sum2 = 0;
        double sum3 = 0;
        for (int i = 0; i < Count; i++)
        {
            double value = this[i];
            sum += value;
            sum2 += value * value;
            sum3 += value * value * value;
        }
        double mean = sum / Count;
        double variance = (sum2 - sum * sum / Count) / (Count - 1);
        double stdDev = Math.Sqrt(variance);
        return (sum3 - 3 * mean * sum2 + 2 * mean * mean * sum) / (Count * stdDev * stdDev * stdDev);
    }
    /// find kurtosis value
    public double Kurtosis()
    {
        double sum = 0;
        double sum2 = 0;
        double sum3 = 0;
        double sum4 = 0;
        for (int i = 0; i < Count; i++)
        {
            double value = this[i];
            sum += value;
            sum2 += value * value;
            sum3 += value * value * value;
            sum4 += value * value * value * value;
        }
        double mean = sum / Count;
        double variance = (sum2 - sum * sum / Count) / (Count - 1);
        double stdDev = Math.Sqrt(variance);
        return (sum4 - 4 * mean * sum3 + 6 * mean * mean * sum2 - 3 * mean * mean * mean * sum) / (Count * stdDev * stdDev * stdDev * stdDev) - 3;
    }
    /// find autocorrelation value by lag
    public double Autocorrelation(int lag)
    {
        double sum = 0;
        double sum2 = 0;
        double sum3 = 0;
        for (int i = lag; i < Count; i++)
        {
            double value = this[i];
            double value2 = this[i - lag];
            sum += value * value2;
            sum2 += value;
            sum3 += value2;
        }
        double mean = sum2 / (Count - lag);
        double mean2 = sum3 / (Count - lag);
        double sum4 = 0;
        double sum5 = 0;
        for (int i = lag; i < Count; i++)
        {
            double value = this[i];
            double value2 = this[i - lag];
            sum4 += (value - mean) * (value - mean);
            sum5 += (value2 - mean2) * (value2 - mean2);
        }
        return (sum - (Count - lag) * mean * mean2) / Math.Sqrt(sum4 * sum5);
    }
    /// find autocorrelation function with lags and return DataColumn with autocorrelation values
    public DataColumn AutocorrelationFunction(int lags)
    {
        DataColumn column = new DataColumn();
        for (int i = 0; i <= lags; i++)
        {
            column.Add(Autocorrelation(i));
        }
        return column;
    }
    /// find partial autocorrelation value by lag
    public PartialAutocorrelation(int lag)
    {
        double sum = 0;
        double sum2 = 0;
        double sum3 = 0;
        for (int i = lag; i < Count; i++)
        {
            double value = this[i];
            double value2 = this[i - lag];
            sum += value * value2;
            sum2 += value;
            sum3 += value2;
        }
        double mean = sum2 / (Count - lag);
        double mean2 = sum3 / (Count - lag);
        double sum4 = 0;
        double sum5 = 0;
        for (int i = lag; i < Count; i++)
        {
            double value = this[i];
            double value2 = this[i - lag];
            sum4 += (value - mean) * (value - mean);
            sum5 += (value2 - mean2) * (value2 - mean2);
        }
        return (sum - (Count - lag) * mean * mean2) / Math.Sqrt(sum4 * sum5);
    }
    /// find partial autocorrelation function with lags and return DataColumn with partial autocorrelation values
    public DataColumn PartialAutocorrelationFunction(int lags)
    {
        DataColumn column = new DataColumn();
        for (int i = 0; i <= lags; i++)
        {
            column.Add(PartialAutocorrelation(i));
        }
        return column;
    }
    /// calculate covariance between two data columns
    public static double Covariance(DataColumn column1, DataColumn column2)
    {
        double sum = 0;
        double sum2 = 0;
        double sum3 = 0;
        for (int i = 0; i < column1.Count; i++)
        {
            double value = column1[i];
            double value2 = column2[i];
            sum += value * value2;
            sum2 += value;
            sum3 += value2;
        }
        double mean = sum2 / column1.Count;
        double mean2 = sum3 / column1.Count;
        return (sum - column1.Count * mean * mean2) / (column1.Count - 1);
    }
    /// calculate correlation between two data columns
    public static double Correlation(DataColumn column1, DataColumn column2)
    {
        double sum = 0;
        double sum2 = 0;
        double sum3 = 0;
        for (int i = 0; i < column1.Count; i++)
        {
            double value = column1[i];
            double value2 = column2[i];
            sum += value * value2;
            sum2 += value;
            sum3 += value2;
        }
        double mean = sum2 / column1.Count;
        double mean2 = sum3 / column1.Count;
        double sum4 = 0;
        double sum5 = 0;
        for (int i = 0; i < column1.Count; i++)
        {
            double value = column1[i];
            double value2 = column2[i];
            sum4 += (value - mean) * (value - mean);
            sum5 += (value2 - mean2) * (value2 - mean2);
        }
        return (sum - column1.Count * mean * mean2) / Math.Sqrt(sum4 * sum5);
    }
    /// calculate covariance matrix for data columns
    public static double[,] CovarianceMatrix(DataColumn[] columns)
    {
        double[,] matrix = new double[columns.Length, columns.Length];
        for (int i = 0; i < columns.Length; i++)
        {
            for (int j = 0; j < columns.Length; j++)
            {
                matrix[i, j] = Covariance(columns[i], columns[j]);
            }
        }
        return matrix;
    }
    /// calculate correlation matrix for data columns
    public static double[,] CorrelationMatrix(DataColumn[] columns)
    {
        double[,] matrix = new double[columns.Length, columns.Length];
        for (int i = 0; i < columns.Length; i++)
        {
            for (int j = 0; j < columns.Length; j++)
            {
                matrix[i, j] = Correlation(columns[i], columns[j]);
            }
        }
        return matrix;
    }
    /// transform data column to z-scores
    public void ZScores()
    {
        double sum = 0;
        double sum2 = 0;
        for (int i = 0; i < Count; i++)
        {
            double value = this[i];
            sum += value;
            sum2 += value * value;
        }
        double mean = sum / Count;
        double variance = (sum2 - sum * sum / Count) / (Count - 1);
        double stdDev = Math.Sqrt(variance);
        for (int i = 0; i < Count; i++)
        {
            this[i] = (this[i] - mean) / stdDev;
        }
    }
    /// transform data column to z-scores
    public void ZScores(double mean, double stdDev)
    {
        for (int i = 0; i < Count; i++)
        {
            this[i] = (this[i] - mean) / stdDev;
        }
    }
    /// transform data column to t-scores
    public void TScores()
    {
        double sum = 0;
        double sum2 = 0;
        for (int i = 0; i < Count; i++)
        {
            double value = this[i];
            sum += value;
            sum2 += value * value;
        }
        double mean = sum / Count;
        double variance = (sum2 - sum * sum / Count) / (Count - 1);
        double stdDev = Math.Sqrt(variance);
        for (int i = 0; i < Count; i++)
        {
            this[i] = (this[i] - mean) / stdDev * Math.Sqrt(Count);
        }
    }
    /// transform data column to t-scores
    public void TScores(double mean, double stdDev)
    {
        for (int i = 0; i < Count; i++)
        {
            this[i] = (this[i] - mean) / stdDev * Math.Sqrt(Count);
        }
    }

    /// calculate counts of bins for histogram
    public static int[] Histogram(DataColumn column, int bins)
    {
        double min = column.Min();
        double max = column.Max();
        double step = (max - min) / bins;
        int[] counts = new int[bins];
        for (int i = 0; i < column.Count; i++)
        {
            double value = column[i];
            int index = (int)((value - min) / step);
            if (index == bins)
            {
                index--;
            }
            counts[index]++;
        }
        return counts;
    }
    /// calculate counts of bins for histogram according to Sturges' formula
    public static int[] Histogram(DataColumn column)
    {
        int bins = (int)Math.Ceiling(Math.Log(column.Count, 2) + 1);
        return Histogram(column, bins);
    }
    /// calculate borders of bins for histogram
    public static double[] HistogramBorders(DataColumn column, int bins)
    {
        double min = column.Min();
        double max = column.Max();
        double step = (max - min) / bins;
        double[] borders = new double[bins + 1];
        for (int i = 0; i <= bins; i++)
        {
            borders[i] = min + i * step;
        }
        return borders;
    }
    /// calculate borders of bins for histogram according to Sturges' formula
    public static double[] HistogramBorders(DataColumn column)
    {
        int bins = (int)Math.Ceiling(Math.Log(column.Count, 2) + 1);
        return HistogramBorders(column, bins);
    }
    /// calculate counts of bins for histogram
    public static int[] Histogram(DataColumn column, double[] borders)
    {
        int bins = borders.Length - 1;
        int[] counts = new int[bins];
        for (int i = 0; i < column.Count; i++)
        {
            double value = column[i];
            int index = 0;
            while (index < bins && value > borders[index + 1])
            {
                index++;
            }
            counts[index]++;
        }
        return counts;
    }

}