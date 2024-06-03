using System.Reflection;

var validPerson = Validator.Validate(new Person("John", 24));
var validDocument = Validator.Validate(new Document("audhaskdhfalksjdfhaskljdfhalkjhlkjhalkajshdlkjfhlk", "John"));
Console.WriteLine($"{validPerson}, {validDocument}" == "True, False");

class Person(string name, int age)
{
    [StringLengthValidator(2, 10)]
    public string Name { get; init; } = name;
    public int Age { get; init; } = age;
}

class Document(string title, string owner)
{
    [StringLengthValidator(2, 25)]
    public string Title { get; init; } = title;
    public string Owner { get; init; } = owner;
}

[AttributeUsage(AttributeTargets.Property)]
class StringLengthValidatorAttribute(int minLength, int maxLength) : Attribute
{
    public readonly int MinLength = minLength;
    public readonly int MaxLength = maxLength;
}

class Validator
{
    static public bool Validate(object obj)
    {
        var propertiesToValidate = ExtractPropertiesToValidateFrom(obj);
        foreach (var property in propertiesToValidate)
        {
            var propertyValue = property.GetValue(obj);
            if (propertyValue is not string s)
                throw new InvalidOperationException(
                    $"Attribute {nameof(StringLengthValidatorAttribute)}" +
                    " can only be applied to strings.");
            var attrType = typeof(StringLengthValidatorAttribute);
            var attribute = (StringLengthValidatorAttribute)property.GetCustomAttributes(attrType, true).First();
            var value = (string)propertyValue;
            if (value.Length < attribute.MinLength || value.Length > attribute.MaxLength)
                return false;
        }
        return true;
    }

    private static IEnumerable<PropertyInfo> ExtractPropertiesToValidateFrom(object obj)
    {
        var type = obj.GetType();
        var propertiesToValidate = type.GetProperties().Where(PropertyDefinedPredicate);
        return propertiesToValidate;
    }

    static private bool PropertyDefinedPredicate(PropertyInfo p)
    {
        return Attribute.IsDefined(p, typeof(StringLengthValidatorAttribute));
    }

    public struct Time
    {
        public int Hour { get; }
        public int Minute { get; }
    
        public Time(int hour, int minute)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(
                    "Hour is out of range of 0-23");
            }
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(
                    "Minute is out of range of 0-59");
            }
            Hour = hour;
            Minute = minute;
        }
    
        public override string ToString() =>
            $"{Hour.ToString("00")}:{Minute.ToString("00")}";

        public static bool operator !=(Time time1, Time time2) =>
            !(time1 == time2);

        public static bool operator ==(Time time1, Time time2) =>
            time1.Hour == time2.Hour && time1.Minute == time2.Minute;

        public static Time operator +(Time time1, Time time2)
        {
            int h1 = time1.Hour, h2 = time2.Hour;
            int m1 = time1.Minute, m2 = time2.Minute;
            int finalH = h1 + h2;
            System.Console.WriteLine(h1.GetHashCode());
            if (m1 + m2 > 59)
                finalH++; 
            return new Time(finalH % 24, (m1 + m2) % 60);
        }
    }
}
