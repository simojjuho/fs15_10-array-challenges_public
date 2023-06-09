﻿/*
Challenge 1. Given a jagged array of integers (two dimensions).
Find the common elements in the nested arrays.
Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
*/

int[] CommonItems(int[][] jaggedArray)
{
    List<int> result = new List<int>();
    for (int i = 0; i < jaggedArray[0].Length; i++)
    {
        if(jaggedArray[1].Contains(jaggedArray[0][i]))
        {
            result.Add(jaggedArray[0][i]);
        }
  }
    return result.ToArray();
}
int[][] arr1 = { new int[] { 0, 2, 3, 8 }, new int[] { 2, 1, 6, 8, 9, 3 } };
int[] arr1Common = CommonItems(arr1);
void printCommon(int[] array)
{
    Console.Write("Array with common values is: [");
    for(int i = 0; i < array.Length; i++) 
    {
        Console.Write(array[i]);
        if(array.Length - i > 1)
        {
            Console.Write(',');
        }
    }
    Console.WriteLine(']');
}
printCommon(arr1Common);

/* 
Challenge 2. Inverse the elements of a jagged array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
*/
void InverseJagged(int[][] jaggedArray)
{
    for(int i = 0; i < jaggedArray.Length; i++)
    {
        jaggedArray[i] = jaggedArray[i].Reverse().ToArray();
    }
}
int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 }, new int[] {2, 4, 1} };
InverseJagged(arr2);
void printReversed(int[][] jgdArr)
{
    Console.Write("Arr2 with values reversed: [");
    for(int i = 0; i < jgdArr.Length; i++)
    {
        Console.Write('[');
        for(int j = 0; j < jgdArr[i].Length; j++)
        {
            Console.Write(jgdArr[i][j]);
            if(jgdArr[i].Length - j > 1)
            {
                Console.Write(',');
            }
        }
        Console.Write(']');
        if(jgdArr.Length - i > 1)
        {
            Console.WriteLine(',');
        }
    }
    Console.Write(']');
    
}
printReversed(arr2);
/* 
Challenge 3.Find the difference between 2 consecutive elements of an array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
 */
void CalculateDiff(int[][] jaggedArray)
{
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        int[] newArr = new int[jaggedArray[i].Length- 1];
        for (int j = 0; j < jaggedArray[i].Length - 1; j++)
        {
            newArr[j] = jaggedArray[i][j] - jaggedArray[i][j + 1];
        }
        jaggedArray[i] = newArr;
    }
}
int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 5 } };
CalculateDiff(arr3);
/* write method to print arr3 */
void printDifferences (int[][] jgdArr)
{
    Console.Write("Arr3 with differences: [");
    for(int i = 0; i < jgdArr.Length; i++)
    {
        Console.Write('[');
        for(int j = 0; j < jgdArr[i].Length; j++)
        {
            Console.Write(jgdArr[i][j]);
            if(jgdArr[i].Length - j > 1)
            {
                Console.Write(',');
            }
        }
        Console.Write(']');
        if(jgdArr.Length - i > 1)
        {
            Console.Write(',');
        }
    }
    Console.WriteLine(']');
}
printDifferences(arr3);

/* 
Challenge 4. Inverse column/row of a rectangular array.
For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
Expected result: {{1,4},{2,5},{3,6}}
 */
int[,] InverseRec(int[,] recArray)
{
    int newRows = recArray.GetLength(1);
    int newColumns = recArray.GetLength(0);
    int[,] newRecArr = new int [newRows,newColumns];
    for(int i = 0; i < recArray.GetLength(0); i++)
    {
        for(int j = 0; j < recArray.GetLength(1); j++)
        {
            newRecArr[j,i] = recArray[i, j];
        }
    }
    return newRecArr;
}
int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr4Inverse = InverseRec(arr4);
/* write method to print arr4Inverse */
void printInversed (int[,] recArr)
{
    Console.Write("Arr3 with differences: [");
    for(int i = 0; i < recArr.GetLength(0); i++)
    {
        Console.Write('[');
        for(int j = 0; j < recArr.GetLength(1); j++)
        {
            Console.Write(recArr[i,j]);
            if(recArr.GetLength(1) - j > 1)
            {
                Console.Write(',');
            }
        }
        Console.Write(']');
        if(recArr.GetLength(0) - i > 1)
        {
            Console.Write(',');
        }
    }
    Console.WriteLine(']');
}
printInversed(arr4Inverse);
/* 
Challenge 5. Write a function that accepts a variable number of params of any of these types: 
string, number. 
- For strings, join them in a sentence. 
- For numbers then sum them up. 
- Finally print everything out. 
Example: Demo("hello", 1, 2, "world") 
Expected result: hello world; 3 */
void Demo(params object[] list)
{
    string sentence = "";
    int sum = 0;
    for(int i = 0; i < list.Length; i++)
    {
        switch (list[i])
        {
            case string:
                sentence = sentence + list[i] + ' ';
                continue;
            case int:
                sum += Convert.ToInt32(list[i]);
                continue;
            default:
                continue;
        }
    }
    Console.WriteLine($"{sentence.TrimEnd()}; {sum}");
}
Demo("hello", 1, 2, "world"); //should print out "hello world; 3"
Demo("My", 2, 3, "daughter", true, "is");//should print put "My daughter is; 5"


/* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
and if they’re string, lengths have to be more than 5. 
If they’re numbers, they have to be more than 18. */
void SwapTwo(object[] list)
{
    if(list.Length != 2)
    {
        throw new Exception("Only a list of two items is allowed");
    }
    if(list[0] is int && list[1] is int && Convert.ToInt32(list[0]) > 18 && Convert.ToInt32(list[0]) > 18 )
    {
        int temp = Convert.ToInt32(list[0]);
        list[0] = list[1];
        list[1] = temp;
    }
    else if (list[0] is string && list[1] is string && Convert.ToString(list[0]).Length > 5 && Convert.ToString(list[1]).Length > 5 )
    {
        string temp = Convert.ToString(list[0]);
        list[0] = list[1];
        list[1] = temp;
    }
    
}
object[] list = {"aapeli", "kaapeli"};
SwapTwo(list);
for (int i = 0; i < 2; i++)
{
    Console.WriteLine(list[i]);
}

/* Challenge 7. Write a function that does the guessing game. 
The function will think of a random integer number (lets say within 100) 
and ask the user to input a guess. 
It’ll repeat the asking until the user puts the correct answer. */
void GuessingGame()
{
    Random rnd = new Random();
    
    int randNum = rnd.Next(0, 100);
    Console.WriteLine("Guess a number between 0 and 100");
    while(true)
    {
        try
        {
            int guess = Convert.ToInt32(Console.ReadLine());
            if(guess < randNum)
            {
                Console.WriteLine("The number is bigger");
            }
            else if(guess > randNum)
            {
                Console.WriteLine("The number is smaller");
            }
            else
            {
                Console.WriteLine("Congrats, you guessed it!");
                break;
            }
        }
        catch (System.FormatException)
        {
            Console.WriteLine("Error: not a number. Give a proper number between 0 and 100.");
            continue;
        }
    }
}
GuessingGame();

/* Challenge 8. Provide class Product, OrderItem, Cart, which make a feature of a store
Complete the required features in OrderItem and Cart, so that the test codes are error-free */

var product1 = new Product(1, 30);
var product2 = new Product(2, 50);
var product3 = new Product(3, 40);
var product4 = new Product(4, 35);
var product5 = new Product(5, 75);

var orderItem1 = new OrderItem(product1, 2);
var orderItem2 = new OrderItem(product2, 1);
var orderItem3 = new OrderItem(product3, 3);
var orderItem4 = new OrderItem(product4, 2);
var orderItem5 = new OrderItem(product5, 5);
var orderItem6 = new OrderItem(product2, 2);

var cart = new Cart();
cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

//get 1st item in cart
var firstItem = cart[0];
Console.WriteLine(firstItem);

//Get cart info
cart.GetCartInfo(out int totalPrice, out int totalQuantity);
Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

//get sub array from a range
var subCart = cart[1, 3];
Console.WriteLine(subCart);
class Product
{
    public int Id { get; set; }
    public int Price { get; set; }

    public Product(int id, int price)
    {
        this.Id = id;
        this.Price = price;
    }
}

class OrderItem : Product
{
    public int Quantity { get; set; }
    private Product _product;



    public OrderItem(Product product, int quantity) : base(product.Id, product.Price)
    {
        this.Quantity = quantity;
        this._product = product;
    }

    public override string ToString()
    {
        return $"ID: {this._product.Id}: Amount: {this.Quantity}, Price: {this._product.Price}\n";
    }

    /* Override ToString() method so the item can be printed out conveniently with Id, Price, and Quantity */
}

class Cart
{
    private List<OrderItem> _cart { get; set; } = new List<OrderItem>();

    /* Write indexer property to get nth item from _cart */
    public OrderItem this[int index]
    {
        get
        {
            if(index >= 0 && index < _cart.Count())
            {
                return _cart[index];
            }
            else {
                throw new IndexOutOfRangeException();
            }
        }
    }

    public Cart this[int startIndex, int endIndex]
    {
        get
        {
            if(startIndex > 0 && startIndex < endIndex && endIndex > 0 && endIndex < _cart.Count())
            {
                Cart subCart = new Cart();
                for(int i = startIndex; i < endIndex; i++)
                {
                    subCart.AddToCart(this[i]);
                }
                return subCart;
            }
            else {
                throw new IndexOutOfRangeException();
            }
        }
    }
    public void AddToCart(params OrderItem[] items)
    {
        /* this method should check if each item exists --> increase value / or else, add item to cart */
        for(int i = 0; i < items.Length; i++)
        {
            if(_cart.Contains(items[i]))
            {
                items[i].Quantity++;
            }
            else
            {
                _cart.Add(items[i]);
            }
        }
    }
    /* Write another method called Index */

    public void GetCartInfo(out int totalPrice, out int totalQuantity)
    {
        totalPrice = 0;
        totalQuantity = _cart.Count;
        for(int i = 0; i < _cart.Count; i++)
        {
            totalPrice += this[i].Quantity * this[i].Price;
        }
    }

    public override string ToString()
    {
        string cartString = "This shopping cart has:\n";
        for(int i = 0; i < _cart.Count; i++)
        {
            cartString += $"{this[i].ToString()}";
        }
        return cartString;
    }
}