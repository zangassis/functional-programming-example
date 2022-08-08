using FPExampleApp;
using static System.Console;

#region Mutable/Immutable example

// Imperative Approach

var order = new Order();
order.UnitPrice = 99;
order.Discount = 10;
order.SpecialCustomer(99, 20); 

// order.UnitPrice is 99, order.Discount = 30, same instance of order


// Functional Approach

var immutableOrder = new ImmutableOrder(99, 10);
immutableOrder = immutableOrder.SpecialCustomer(99, 20);

// order.UnitPrice is 99, order.Discount = 30, new instance of order

#endregion

#region Expressions instead of declarations 

static string WeatherVerify(double tempInCelsius) 
{
	// Here we have state change, unnecessary logic, multiple lines of code

	string climate = string.Empty;

	if (tempInCelsius < 20.0)
		climate = "Cold";
	else
		climate = "Perfect";

	return climate;
}

static string ImmutableWeatherVerify(double tempInCelsius) => 
	tempInCelsius < 20.0 ? "Cold" : "Perfect"; // Here we avoid changing state, there is no unnecessary logic and only two lines of code

#endregion

#region LINQ Expressions

int[] scores = { 97, 92, 81, 60 };

// Imperative approach
var scoreImperative = new List<int>();

foreach (var item in scores)
{
    if (item > 80)
    {
		scoreImperative.Add(item);
    }
}

// Functional approach

// Query expression
IEnumerable<int> scoreQuery = from score in scores
							  where score > 80
							  select score;

// Lambda expression
IEnumerable<int> scoreLambda = scores.Where(score => score > 80);

#endregion

#region Higher-order Functions

var users = new List<User>()
{
	new User("John smith", 31),
    new User("Alice Smith", 31),
};

var olderUser = users.MyWhere(user => user.Age == 31);

foreach (var user in olderUser)
	WriteLine(user?.Name);

static class Helper
{
    public static IEnumerable<T> MyWhere<T>
        (this IEnumerable<T> source, Func<T, bool> predicate) //A predicate is passed as an argument
	{
		//The criterium determining which items are included is decided by the caller
		foreach (T s in source)
            if (predicate(s))
                yield return s;
    }
}

#endregion