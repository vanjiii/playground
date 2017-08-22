using System;
using System.Collections.Generic;
using System.Text;

//enumeration
enum BatteryType { LiIon, NiMH, NiCd }

//mobile phone device class
class GSM
{
    private Battery battery;
    private Display display;

    //static field
    public static GSM Iphone4S;

    private string model;
    private string manufacture;
    private string owner;
    private decimal? price;

    //properties
    public string Model
    {
        get 
        { 
            return this.model;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Invalid model: " + value);
            this.model = value; 
        }
    }
    public string Manufacture
    {
        get
        {
            return this.manufacture;
        }
        set
        {
            this.manufacture = value;
        }
    }
    public string Owner
    {
        get
        {
            return this.owner;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Invalid owner" + value);
            this.owner = value;
        }
    }
    public decimal? Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Ivalid number for price: " + value);
            }
            this.price = value;
        }
    }

    //the field CallHistory
    public List<Call> CallHistory = new List<Call> ();
    //the property CallHistory
    //public List<Call> CallHistory
    //{
    //    get { return callHistory; }
    //    set { callHistory = value; }
    //}

    static GSM()
    {
        GSM iphone4S = new GSM("4S", "Apple", "Asparuh", 569, new Battery ("MAS4313", 50, 12, BatteryType.NiMH), new Display(550, 5000000));
    }
    //constructors
    public GSM(string owner, string model)
        : this(model, null, owner, null, null, null)
    { }
    public GSM(string model, string manufactire, string owner, decimal? price, Battery battery, Display display)
    {
        this.model = model;
        this.manufacture = manufactire;
        this.owner = owner;
        this.price = price;
        this.battery = battery;
        this.display = display;
    }

    //method for displaying all info - ToString()
    public void ToOverride()
    {
        StringBuilder result = new StringBuilder();
        result.Append("\n" + new string('-', 10) + "GSM" + new string('-', 10) + "\n");
        result.Append(string.Format("\nThe owner is: {0}\n", this.owner));
        result.Append(string.Format("\nThe model of the phone is {0}\n", this.model));
        result.Append(string.Format(this.price == null ? "\nThe price of the phone is {0}\n" : "\nThe price of the phone is {0}\n", this.price));
        result.Append(string.Format(this.manufacture == null ? "\nThe manifacture of the phone is {0}\n" : "\nThe manifacture of the phone is {0}\n", this.manufacture));
    }
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append("\n" + new string('-', 10) + "all the info" + new string('-', 10) + "\n");
        result.Append("\n" + new string('-', 10) + "GSM" + new string('-', 10) + "\n");
        result.Append(string.Format("\nThe owner is: {0}\n", this.owner));
        result.Append(string.Format("\nThe model of the phone is {0}\n", this.model));
        result.Append(string.Format(this.price == null ? "\nThe price of the phone is {0}\n" : "\nThe price of the phone is {0}\n", this.price));
        result.Append(string.Format(this.manufacture == null ? "\nThe manifacture of the phone is {0}\n" : "\nThe manifacture of the phone is {0}\n", this.manufacture));
        return result.ToString();
    }

    //the history thing..
    public void AddCalls(string number, int duration)
    {
        Call obj = new Call(DateTime.Now, number, duration);
        CallHistory.Add(obj);
    }
    public void RemoveCalls(int index)
    {

        if (this.CallHistory.Count > 0)
        {
            //if (CallHistory.Equals(number))
            //{
            //    CallHistory.Remove(number);
            //}
            //else
            //{
            //    Console.WriteLine("Match not found");
            //}
            CallHistory.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("The history is empty");
        }
    }
    public void ClearHistory()
    {
        this.CallHistory.Clear();

        Console.WriteLine("\nAll calls cleared\n");
    }

    //calculating the price
    public decimal CalculatePrice(decimal costPerMinute)
    {
        int totalSeconds = 0;
        foreach (var call in CallHistory)
        {
            totalSeconds += call.Duration;
        }
        return (totalSeconds / 60) * costPerMinute;
    }

}

//battery characteristics
class Battery
{
    private BatteryType? battType;
    private string model;
    private int? hoursIdle;
    private int? hoursTalk;

    //properties
    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Invalid model: " + value);
            this.model = value;
        }
    }
    public int? HoursIdle
    {
        get
        {
            return this.hoursIdle;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid hours: " + value);
            }
            this.hoursIdle = value;
        }
    }
    public int? HoursTalk
    {
        get
        {
            return this.hoursTalk;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid hours: " + value);
            }
            this.hoursTalk = value;
        }
    }
    //constructors
    public Battery()
        : this(null)
    { 
    }
    public Battery(string model)
        : this (model, null)
    {
    }
    public Battery(string model, int? hoursIdle)
        : this (model, hoursIdle, null, null)
    {

    }
    public Battery(string model, int? hoursIdle, int? hoursTalk, BatteryType? type)
    {
        this.model = model;
        this.hoursIdle = hoursIdle;
        this.hoursTalk = hoursTalk;
        this.battType = type;
    }
    

}

//display characteristics
class Display
{
    private int? size;
    private int? numColors;

    //properties
    public int? Size
    {
        get
        {
            return this.size;
        }
        set
        {
            if (value < 0)
                throw new ArgumentException("Ivalid size " + value);
            this.size = value;
        }
    }
    public int? NumColors
    {
        get
        {
            return this.numColors;
        }
        set
        {
            if(value < 0)
                throw new ArgumentException("Invalid number of colors" + numColors);
            this.numColors = value;
        }
    }
    //constructors
    public Display()
        : this (null)
    { }
    public Display(int? size)
        : this (size, null)
    { }
    public Display (int? size, int? numColors)
    {
        this.size = size;
        this.numColors = numColors;
    }
}

//test class
class GSMTest
{
    private static  GSM[] testObj = new GSM[2];
    //static void Main()
    //{
    //    GSMTest.Test();
    //}
    static void Test()
    {
        //initialize the test objects
        testObj[0] = new GSM("Kiro", "Desire 500");
        testObj[1] = new GSM("Galaxy Trend", "Samsung", "Sonic", 370, new Battery (), new Display ());

        //print them 
        foreach (var item in testObj)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(GSM.Iphone4S);
    }
}

//class that contain the calls performed
class Call
{
    private DateTime timeOfCall;
    private string dailedPhone;
    private int duration;

    public Call(DateTime timeOfCall, string number, int dur)
    {
        this.timeOfCall = timeOfCall;
        this.dailedPhone = number;
        this.duration = dur;
    }

    public DateTime TimeOfCall
    {
        get { return this.timeOfCall; }
        set { this.timeOfCall = value; }
    }
    public string DailedPhone
    {
        get { return this.dailedPhone; }
        set { this.dailedPhone = value; }
    }
    public int Duration
    {
        get { return this.duration; }
        set { this.duration = value; }
    }
}

//class to test the call history etc.
class GSMCallHistoryTest
{
    private static  GSM[] gsm = new GSM[]
        { new GSM("Grishata", "3310"),
          new GSM("nexus 4", "LG", "Stamat", 430, new Battery(), new Display())};
    public static void Main()
    {
        // add few calls
        gsm[0].AddCalls("0888 1234 567", 370);
        gsm[1].AddCalls("0895 876 321", 9870);
        gsm[0].AddCalls("0886 872 656", 505);
        gsm[0].AddCalls("0888 842 656", 3205);
        gsm[0].AddCalls("0878 352 521", 1205);
        gsm[0].AddCalls("0898 282 158", 805);
 

        //display info 'bout the calls
        foreach (var item in gsm)
	    {
            Console.WriteLine(item);
	    }
        Console.WriteLine("The sum of the first number: " + gsm[0].CalculatePrice(0.37m));
        Console.WriteLine("The sum of the second number: " + gsm[1].CalculatePrice(0.37m));

        //remove the longest call
        int index = 0;
        int duration = 0;
        for (var i = 0; i < gsm[0].CallHistory.Count; i++)
        {
            if (gsm[0].CallHistory[i].Duration > duration)
            {
                duration = gsm[0].CallHistory[i].Duration;
                index = i;
            }
        }
        gsm[0].RemoveCalls(index);


        //clear history
        gsm[0].ClearHistory();
    }
}
//class Program
//{
//    static void Main()
//    {
//        TestHistory();
//    }
//}